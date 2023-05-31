using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using NLog;
using NLog.Config;
using NLog.Layouts;
using NLog.Targets;
using NLog.Targets.GraylogHttp;
using NLog.Targets.Wrappers;
using SC.LK.Application.Abstractions.Logging;
using LogLevel = NLog.LogLevel;

namespace SC.LK.Infrastructure.Logger;

public class LoggerContext : ILoggerContext
{
	private readonly LoggerOption _settings;
	private Lazy<LogFactory> _instance = null;
	private LoggingConfiguration _logConfig = null;
	
	/// <summary>
	/// Instance
	/// </summary>
	private Lazy<LogFactory> Instance
	{
		get { return _instance ?? (_instance = new Lazy<LogFactory>(BuildLogFactory)); }
	}

	public string Header { get; set; }

	/// <summary>
	/// Конструктор LoggerContext
	/// </summary>
	/// <param name="options"></param>
	/// <exception cref="ArgumentException"></exception>
	public LoggerContext(IOptions<LoggerOption> options)
	{
		_settings = options != null ? options.Value : throw new ArgumentException(nameof(options));
		Header = _settings.LogHeaderBack;
	}

	public string PreparingMessage(string type, object obj) =>
	JsonConvert.SerializeObject(new {Type = type, Message = obj});

	/// <summary>
	/// GetLogger
	/// </summary>
	/// <returns></returns>
	public ILogger GetLogger()
	{
		return Instance.Value.GetCurrentClassLogger();
	}

	/// <summary>
	/// BuildLogFactory
	/// </summary>
	/// <returns></returns>
	private LogFactory BuildLogFactory()
	{
		var config = _logConfig ?? new LoggingConfiguration();
		Layout header = Header;
		
		Layout layout =
			"${longdate} [${callsite:className=true:includeNamespace=true:fileName=false:includeSourcePath=false:methodName=true:cleanNamesOfAnonymousDelegates=true:cleanNamesOfAsyncContinuations=true}] -> ${level:format=FirstCharacter} : ${message}${onexception:inner=${newline}${exception:format=@}}";

		#region [Targets]

		#region [ConsoleTarget]

		if (_settings.IsConsoleTarget)
		{
			Target consoleTarget = MakeAsyncTarget(ConsoleTarget(header, layout));
			config.AddTarget(consoleTarget);
			config.AddRuleForAllLevels(consoleTarget);
		}

		#endregion

		#region [DebuggerTarget]

		if (_settings.IsDebugTarget)
		{
			Target debugTarget = MakeAsyncTarget(DebuggerTarget(header, layout));
			config.AddTarget(debugTarget);
			config.AddRuleForAllLevels(debugTarget);
		}

		#endregion

		#region [GelfTarget]
		// Это такая простенькая защита от набивания Graylog лишними логами, пока приложение не боевое
		if (_settings.IsGelfTarget)
		{
			GraylogHttpTarget gelfTarget = GelfTarget(Header);
			config.AddTarget(gelfTarget);
			config.AddRuleForAllLevels(gelfTarget);
		}
		#endregion

		#endregion
		LogFactory logFactory = new LogFactory
		{ Configuration = config };
		
		try
		{
			config.LoggingRules.ToList()
				.ForEach(r => r.SetLoggingLevels(LogLevel.AllLevels.Min(), LogLevel.AllLevels.Max()));
			_logConfig = config;
		}
		catch (Exception ex)
		{
			Debug.Write(ex);
		}
		return logFactory;
	}

	#region Target Methods
	
	/// <summary>
	/// ConsoleTarget
	/// </summary>
	/// <param name="header"></param>
	/// <param name="layout"></param>
	/// <returns></returns>
	private ColoredConsoleTarget ConsoleTarget(Layout header, Layout layout)
	{
		#region ConsoleTarget ----------------------------

		ColoredConsoleTarget consoleTarget = new ColoredConsoleTarget("log_console_target")
		{
			Encoding = Encoding.UTF8,
			EnableAnsiOutput = false,

			UseDefaultRowHighlightingRules = true,

			Layout = layout,
			Header = header
		};

		ConsoleWordHighlightingRule dateHighLightRule = new ConsoleWordHighlightingRule
		{
			Regex = @"^(?=\d).+(?=\s\[)",
			ForegroundColor = ConsoleOutputColor.Yellow
		};

		ConsoleWordHighlightingRule methodsHighLightRule = new ConsoleWordHighlightingRule
		{
			Regex = @"(?<=\[).+(?=\])",
			ForegroundColor = ConsoleOutputColor.Blue
		};

		ConsoleWordHighlightingRule levelHighLightRule = new ConsoleWordHighlightingRule
		{
			Regex = @"(?<=>).+(?=\s:)",
			ForegroundColor = ConsoleOutputColor.Red
		};

		ConsoleWordHighlightingRule messageHighLightRule = new ConsoleWordHighlightingRule
		{
			Regex = @"(?<=\s:\s).+",
			ForegroundColor = ConsoleOutputColor.Green
		};

		consoleTarget.WordHighlightingRules.Add(dateHighLightRule);
		consoleTarget.WordHighlightingRules.Add(methodsHighLightRule);
		consoleTarget.WordHighlightingRules.Add(levelHighLightRule);
		consoleTarget.WordHighlightingRules.Add(messageHighLightRule);

		#endregion

		return consoleTarget;
	}
	
	/// <summary>
	/// DebuggerTarget
	/// </summary>
	/// <param name="header"></param>
	/// <param name="layout"></param>
	/// <returns></returns>
	private DebuggerTarget DebuggerTarget(Layout header, Layout layout)
	{
		#region DebuggerTarget ----------------------------

		DebuggerTarget debugTarget = new DebuggerTarget("log_debug_target")
		{
			Layout = layout,
			Header = header
		};

		#endregion

		return debugTarget;
	}
	
	/// <summary>
	/// GelfTarget
	/// </summary>
	/// <param name="header"></param>
	/// <returns></returns>
	private GraylogHttpTarget GelfTarget(string header)
	{
		Layout gelfCommonLayout = "${message}";

		IList<TargetPropertyWithContext> gelfParameterInfos =
			new List<TargetPropertyWithContext>()
			{
				// Все эти дополнительные параметры описаны: https://nlog-project.org/config/?tab=layout-renderers
				new TargetPropertyWithContext() {Name = "appdomain", Layout = "${appdomain}"},
				new TargetPropertyWithContext() {Name = "assembly-version", Layout = "${assembly-version}"},
				new TargetPropertyWithContext() {Name = "activityid", Layout = "${activityid}"},
				new TargetPropertyWithContext() {Name = "callsite", Layout = "${callsite}"},
				new TargetPropertyWithContext() {Name = "callsite-linenumber", Layout = "${callsite-linenumber}"},
				new TargetPropertyWithContext()
					{Name = "environment-user", Layout = "${environment-user:userName=true:domain=true}"},
				new TargetPropertyWithContext()
					{Name = "exeption_json_data", Layout = "${onexception:inner=${exception:format=@}}"},
				new TargetPropertyWithContext()
				{
					Name = "frameWorkInfo",
					Layout = $"{RuntimeInformation.FrameworkDescription} ({RuntimeInformation.ProcessArchitecture})"
				},
				new TargetPropertyWithContext() {Name = "guid", Layout = "${guid:format=N}"},
				new TargetPropertyWithContext() {Name = "hostname", Layout = "${hostname}"},
				new TargetPropertyWithContext()
				{
					Name = "identity", Layout = "${identity:authType=true:separator=\n:name=true:isAuthenticated=true}"
				},
				new TargetPropertyWithContext() {Name = "level_name", Layout = "${level:format=Name}"},
				new TargetPropertyWithContext() {Name = "local-ip", Layout = "${local-ip:addressFamily=InterNetwork}"},
				new TargetPropertyWithContext() {Name = "logger", Layout = "${logger:shortName=false}"},
				new TargetPropertyWithContext() {Name = "machinename", Layout = "${machinename}"},
				new TargetPropertyWithContext()
				{
					Name = "osInfo",
					Layout = $"{RuntimeInformation.OSDescription} ({RuntimeInformation.OSArchitecture})"
				},
				new TargetPropertyWithContext() {Name = "processid", Layout = "${processid}"},
				new TargetPropertyWithContext()
					{Name = "processinfo_MainWindowHandle", Layout = "${processinfo:property=MainWindowHandle}"},
				new TargetPropertyWithContext()
					{Name = "processinfo_PagedMemorySize", Layout = "${processinfo:property=PagedMemorySize}"},
				new TargetPropertyWithContext() {Name = "processname", Layout = "${processname:fullName=true}"},
				new TargetPropertyWithContext() {Name = "processtime", Layout = "${processtime:invariant=false}"},
				new TargetPropertyWithContext() {Name = "sequenceid", Layout = "${sequenceid}"},
				new TargetPropertyWithContext()
					{Name = "stacktrace", Layout = "${stacktrace:format=Raw:topFrames=3:skipFrames=0:separator=}"},
				new TargetPropertyWithContext() {Name = "threadid", Layout = "${threadid}"},
				new TargetPropertyWithContext() {Name = "threadname", Layout = "${threadname}"},
				new TargetPropertyWithContext()
					{Name = "timestamp", Layout = $"{DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()}"},
				new TargetPropertyWithContext()
				{
					Name = "timestamp_local", Layout = @"${date:universalTime=false:format=yyyy-MM-dd HH\:mm\:ss zzz}"
				},
				new TargetPropertyWithContext()
					{Name = "windows-identity", Layout = "${windows-identity:userName=true:domain=true}"}
			};

		GraylogHttpTarget gelfUdpTarget = new GraylogHttpTarget
		{
			AddNLogLevelName = true,
			Facility = header,
			GraylogServer = _settings.LogServerAddress,
			GraylogPort = _settings.LogServerPort,
			IncludeCallSite = true,
			IncludeCallSiteStackTrace = true,
			IncludeEventProperties = true,
			Layout = gelfCommonLayout,
			Name = "GelfHttp",
			OptimizeBufferReuse = true
		};

		foreach (TargetPropertyWithContext gelfParameterInfo in gelfParameterInfos)
		{
			gelfUdpTarget.ContextProperties.Add(gelfParameterInfo);
		}
		
		return gelfUdpTarget;
	}
	
	/// <summary>
	/// MakeAsyncTarget
	/// </summary>
	/// <param name="targ"></param>
	/// <returns></returns>
	private Target MakeAsyncTarget(Target targ)
	{
		return new AsyncTargetWrapper
		{
			BatchSize = 100,
			ForceLockingQueue = true,
			FullBatchSizeWriteLimit = 5,
			Name = targ.Name,
			OptimizeBufferReuse = true,
			OverflowAction = AsyncTargetWrapperOverflowAction.Grow,
			QueueLimit = 10000,
			TimeToSleepBetweenBatches = 1,
			WrappedTarget = targ
		};
	}
	#endregion

}