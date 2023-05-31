using System.Net.Http.Headers;
using Microsoft.Extensions.Options;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.SigningEncryptionService;

namespace SC.LK.Infrastructure.InternalConnector.Adaptors;

[System.CodeDom.Compiler.GeneratedCode("NSwag", "13.15.9.0 (NJsonSchema v10.6.8.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class SigningEncryptionClient : ISigningEncryptionAdaptor
{
    private string _baseUrl = "";
    private System.Net.Http.HttpClient _httpClient;
    private System.Lazy<Newtonsoft.Json.JsonSerializerSettings> _settings;
    private static string  _login = "LK";
    private static string _password = "123456";
    private string _tagAuth = "Bearer ";
    private string _authHeader = "";
    
    /// <summary>
    /// AuthHeader
    /// </summary>
    public string AuthHeader
    {
        get { return _authHeader;}
        set
        {
            if(value!= null)
                _authHeader = _tagAuth + value;
            else
            {
                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(_login + ":" + _password);
                _authHeader = _tagAuth +  System.Convert.ToBase64String(plainTextBytes);
            }
        }
    }

    private SigningEncryptionOptions _settingsClient;
    
    /// <summary>
    /// SigningEncryptionClient
    /// </summary>
    /// <param name="options"></param>
    public SigningEncryptionClient(IOptions<SigningEncryptionOptions> options)
    {
        _settingsClient = options.Value;
        _login = _settingsClient.Login;
        _password = _settingsClient.Password;
        BaseUrl = _settingsClient.BaseUrl;
            
        _httpClient = new HttpClient() { BaseAddress = new Uri(BaseUrl) };
        _settings = new System.Lazy<Newtonsoft.Json.JsonSerializerSettings>(CreateSerializerSettings);
    }

    /// <summary>
    /// CreateSerializerSettings
    /// </summary>
    /// <returns></returns>
    private Newtonsoft.Json.JsonSerializerSettings CreateSerializerSettings()
    {
        var settings = new Newtonsoft.Json.JsonSerializerSettings();
        UpdateJsonSerializerSettings(settings);
        return settings;
    }

    public string BaseUrl
    {
        get { return _baseUrl; }
        set { _baseUrl = value; }
    }

    /// <summary>
    /// JsonSerializerSettings
    /// </summary>
    protected Newtonsoft.Json.JsonSerializerSettings JsonSerializerSettings
    {
        get { return _settings.Value; }
    }

    partial void UpdateJsonSerializerSettings(Newtonsoft.Json.JsonSerializerSettings settings);
    partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request,
        string url);
    partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request,
        System.Text.StringBuilder urlBuilder);
    partial void ProcessResponse(System.Net.Http.HttpClient client, System.Net.Http.HttpResponseMessage response);

    /// <summary>
    /// Получение сертификата для сканера
    /// </summary>
    /// <param name="scannerId">Id терминала из БД</param>
    /// <returns>Тело сертификата</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<string> GetCurrentCertificateAsync(System.Guid? scannerId)
    {
        return GetCurrentCertificateAsync(scannerId, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <summary>
    /// Получение сертификата для сканера
    /// </summary>
    /// <param name="scannerId">Id терминала из БД</param>
    /// <returns>Тело сертификата</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<string> GetCurrentCertificateAsync(System.Guid? scannerId,
        System.Threading.CancellationToken cancellationToken)
    {
        var urlBuilder_ = new System.Text.StringBuilder();
        urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/GetCurrentCertificate?");
        if (scannerId != null)
        {
            urlBuilder_.Append(System.Uri.EscapeDataString("scannerId") + "=").Append(
                System.Uri.EscapeDataString(ConvertToString(scannerId,
                    System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }

        urlBuilder_.Length--;

        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new System.Net.Http.HttpRequestMessage())
            {
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(
                    System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_
                    .SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken)
                    .ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int) response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ =
                            await ReadObjectResponseAsync<string>(response_, headers_, cancellationToken)
                                .ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_,
                                objectResponse_.Text, headers_, null);
                        }

                        return objectResponse_.Object;
                    }
                    else if (status_ == 404)
                    {
                        string responseText_ = (response_.Content == null)
                            ? string.Empty
                            : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException(
                            "\u041d\u0435\u0442 \u0442\u0430\u043a\u043e\u0433\u043e \u0441\u0435\u0440\u0442\u0438\u0444\u0438\u043a\u0430\u0442\u0430",
                            status_, responseText_, headers_, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null
                            ? null
                            : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException(
                            "The HTTP status code of the response was not expected (" + status_ + ").", status_,
                            responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    /// <summary>
    /// Регистрация нового сканера
    /// </summary>
    /// <param name="body">id торговой сети</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<ClientView> RegisterClientAsync(string body)
    {
        return RegisterClientAsync(body, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <summary>
    /// Регистрация нового сканера
    /// </summary>
    /// <param name="body">id торговой сети</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<ClientView> RegisterClientAsync(string body,
        System.Threading.CancellationToken cancellationToken)
    {
        var urlBuilder_ = new System.Text.StringBuilder();
        urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/RegisterClient");

        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new System.Net.Http.HttpRequestMessage())
            {
                var content_ =
                    new System.Net.Http.StringContent(
                        Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value));
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("POST");
                request_.Headers.Accept.Add(
                    System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_
                    .SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken)
                    .ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int) response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ =
                            await ReadObjectResponseAsync<ClientView>(response_, headers_, cancellationToken)
                                .ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_,
                                objectResponse_.Text, headers_, null);
                        }

                        return objectResponse_.Object;
                    }
                    else
                    {
                        var responseData_ = response_.Content == null
                            ? null
                            : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException(
                            "The HTTP status code of the response was not expected (" + status_ + ").", status_,
                            responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    /// <summary>
    /// Подписывание файлов
    /// </summary>
    /// <param name="scanerId">Чем подписываем</param>
    /// <param name="body">Что подпичсываем</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<string> SigningAsync(System.Guid? scanerId, string body)
    {
        return SigningAsync(scanerId, body, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <summary>
    /// Подписывание файлов
    /// </summary>
    /// <param name="scanerId">Чем подписываем</param>
    /// <param name="body">Что подпичсываем</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<string> SigningAsync(System.Guid? scanerId, string body,
        System.Threading.CancellationToken cancellationToken)
    {
        var urlBuilder_ = new System.Text.StringBuilder();
        urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/Signing?");
        if (scanerId != null)
        {
            urlBuilder_.Append(System.Uri.EscapeDataString("scanerId") + "=").Append(
                System.Uri.EscapeDataString(
                    ConvertToString(scanerId, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }

        urlBuilder_.Length--;

        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new System.Net.Http.HttpRequestMessage())
            {
                var content_ =
                    new System.Net.Http.StringContent(
                        Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value));
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("POST");
                request_.Headers.Accept.Add(
                    System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_
                    .SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken)
                    .ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int) response_.StatusCode;
                    if (status_ == 404)
                    {
                        var objectResponse_ =
                            await ReadObjectResponseAsync<ProblemDetails>(response_, headers_, cancellationToken)
                                .ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_,
                                objectResponse_.Text, headers_, null);
                        }

                        throw new ApiException<ProblemDetails>("Not Found", status_, objectResponse_.Text, headers_,
                            objectResponse_.Object, null);
                    }
                    else if (status_ == 200)
                    {
                        var objectResponse_ =
                            await ReadObjectResponseAsync<string>(response_, headers_, cancellationToken)
                                .ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_,
                                objectResponse_.Text, headers_, null);
                        }

                        return objectResponse_.Object;
                    }
                    else
                    {
                        var responseData_ = response_.Content == null
                            ? null
                            : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException(
                            "The HTTP status code of the response was not expected (" + status_ + ").", status_,
                            responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    /// <summary>
    /// Регистрация сертификата контрагента
    /// </summary>
    /// <param name="kontragentId">id контрагента</param>
    /// <returns>Успешно зарегистрирован</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual Task<bool> GenerateCertificateKontragentAsync(System.Guid kontragentId)
    {
        return GenerateCertificateKontragentAsync(kontragentId, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <summary>
    /// Регистрация сертификата контрагента
    /// </summary>
    /// <param name="kontragentId">id контрагента</param>
    /// <returns>Успешно зарегистрирован</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<bool> GenerateCertificateKontragentAsync(System.Guid kontragentId,
        System.Threading.CancellationToken cancellationToken)
    {
        if (kontragentId == null)
            throw new System.ArgumentNullException("kontragentId");

        var urlBuilder_ = new System.Text.StringBuilder();
        urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "")
            .Append("/generateCertificateKontragent/{kontragentId}");
        urlBuilder_.Replace("{kontragentId}",
            System.Uri.EscapeDataString(
                ConvertToString(kontragentId, System.Globalization.CultureInfo.InvariantCulture)));

        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new System.Net.Http.HttpRequestMessage())
            {
                request_.Headers.Authorization = AuthenticationHeaderValue.Parse(AuthHeader);
                request_.Content =
                    new System.Net.Http.StringContent(string.Empty, System.Text.Encoding.UTF8, "application/json");
                request_.Method = new System.Net.Http.HttpMethod("POST");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_
                    .SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken)
                    .ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int) response_.StatusCode;
                    if (status_ == 200)
                    {
                        return true;
                    }
                    else if (status_ == 404)
                    {
                        string responseText_ = (response_.Content == null)
                            ? string.Empty
                            : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException(
                            "\u0421\u0435\u0440\u0442\u0438\u0444\u0438\u043a\u0430\u0442 \u043d\u0435 \u0441\u043e\u0437\u0434\u0430\u043d",
                            status_, responseText_, headers_, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null
                            ? null
                            : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException(
                            "The HTTP status code of the response was not expected (" + status_ + ").", status_,
                            responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    /// <summary>
    /// Получение сертификата для контрагента
    /// </summary>
    /// <param name="kontragentId">Id контрагента</param>
    /// <returns>Тело сертификата</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<KontragentCertificateView> GetKontragentCertificateAsync(
        System.Guid? kontragentId)
    {
        return GetKontragentCertificateAsync(kontragentId, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <summary>
    /// Получение сертификата для контрагента
    /// </summary>
    /// <param name="kontragentId">Id контрагента</param>
    /// <returns>Тело сертификата</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<KontragentCertificateView> GetKontragentCertificateAsync(
        System.Guid? kontragentId, System.Threading.CancellationToken cancellationToken)
    {
        var urlBuilder_ = new System.Text.StringBuilder();
        urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/getKontragentCertificate?");
        if (kontragentId != null)
        {
            urlBuilder_.Append(System.Uri.EscapeDataString("kontragentId") + "=")
                .Append(System.Uri.EscapeDataString(ConvertToString(kontragentId,
                    System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }

        urlBuilder_.Length--;

        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new System.Net.Http.HttpRequestMessage())
            {
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(
                    System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_
                    .SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken)
                    .ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int) response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ =
                            await ReadObjectResponseAsync<KontragentCertificateView>(response_, headers_,
                                cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_,
                                objectResponse_.Text, headers_, null);
                        }

                        return objectResponse_.Object;
                    }
                    else if (status_ == 404)
                    {
                        string responseText_ = (response_.Content == null)
                            ? string.Empty
                            : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException(
                            "\u041d\u0435\u0442 \u0442\u0430\u043a\u043e\u0433\u043e \u0441\u0435\u0440\u0442\u0438\u0444\u0438\u043a\u0430\u0442\u0430",
                            status_, responseText_, headers_, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null
                            ? null
                            : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException(
                            "The HTTP status code of the response was not expected (" + status_ + ").", status_,
                            responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    /// <summary>
    /// Подписывание файлов
    /// </summary>
    /// <param name="body">Что подпичсываем</param>
    /// <returns>Подписанный файл</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<SignedKontragentFileView> SigningKontragentAsync(
        SignKontragentFileView body)
    {
        return SigningKontragentAsync(body, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <summary>
    /// Подписывание файлов
    /// </summary>
    /// <param name="body">Что подпичсываем</param>
    /// <returns>Подписанный файл</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<SignedKontragentFileView> SigningKontragentAsync(
        SignKontragentFileView body, System.Threading.CancellationToken cancellationToken)
    {
        var urlBuilder_ = new System.Text.StringBuilder();
        urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/signingKontragent");

        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new System.Net.Http.HttpRequestMessage())
            {
                var content_ =
                    new System.Net.Http.StringContent(
                        Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value));
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new System.Net.Http.HttpMethod("PUT");
                request_.Headers.Accept.Add(
                    System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_
                    .SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken)
                    .ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int) response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ =
                            await ReadObjectResponseAsync<SignedKontragentFileView>(response_, headers_,
                                cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_,
                                objectResponse_.Text, headers_, null);
                        }

                        return objectResponse_.Object;
                    }
                    else if (status_ == 404)
                    {
                        string responseText_ = (response_.Content == null)
                            ? string.Empty
                            : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException(
                            "\u041d\u0435\u0442 \u0442\u0430\u043a\u043e\u0433\u043e \u0441\u0435\u0440\u0442\u0438\u0444\u0438\u043a\u0430\u0442\u0430",
                            status_, responseText_, headers_, null);
                    }
                    else
                    {
                        var responseData_ = response_.Content == null
                            ? null
                            : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException(
                            "The HTTP status code of the response was not expected (" + status_ + ").", status_,
                            responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    /// <summary>
    /// ObjectResponseResult
    /// </summary>
    /// <typeparam name="T"></typeparam>
    protected struct ObjectResponseResult<T>
    {
        public ObjectResponseResult(T responseObject, string responseText)
        {
            this.Object = responseObject;
            this.Text = responseText;
        }

        public T Object { get; }

        public string Text { get; }
    }

    /// <summary>
    /// ReadResponseAsString
    /// </summary>
    public bool ReadResponseAsString { get; set; }

    /// <summary>
    /// ReadObjectResponseAsync
    /// </summary>
    /// <param name="response"></param>
    /// <param name="headers"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="ApiException"></exception>
    protected virtual async System.Threading.Tasks.Task<ObjectResponseResult<T>> ReadObjectResponseAsync<T>(
        System.Net.Http.HttpResponseMessage response,
        System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> headers,
        System.Threading.CancellationToken cancellationToken)
    {
        if (response == null || response.Content == null)
        {
            return new ObjectResponseResult<T>(default(T), string.Empty);
        }

        if (ReadResponseAsString)
        {
            var responseText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            try
            {
                var typedBody = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(responseText, JsonSerializerSettings);
                return new ObjectResponseResult<T>(typedBody, responseText);
            }
            catch (Newtonsoft.Json.JsonException exception)
            {
                var message = "Could not deserialize the response body string as " + typeof(T).FullName + ".";
                throw new ApiException(message, (int) response.StatusCode, responseText, headers, exception);
            }
        }
        else
        {
            try
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                using (var streamReader = new System.IO.StreamReader(responseStream))
                using (var jsonTextReader = new Newtonsoft.Json.JsonTextReader(streamReader))
                {
                    var serializer = Newtonsoft.Json.JsonSerializer.Create(JsonSerializerSettings);
                    var typedBody = serializer.Deserialize<T>(jsonTextReader);
                    return new ObjectResponseResult<T>(typedBody, string.Empty);
                }
            }
            catch (Newtonsoft.Json.JsonException exception)
            {
                var message = "Could not deserialize the response body stream as " + typeof(T).FullName + ".";
                throw new ApiException(message, (int) response.StatusCode, string.Empty, headers, exception);
            }
        }
    }

    /// <summary>
    /// ConvertToString
    /// </summary>
    /// <param name="value"></param>
    /// <param name="cultureInfo"></param>
    /// <returns></returns>
    private string ConvertToString(object value, System.Globalization.CultureInfo cultureInfo)
    {
        if (value == null)
        {
            return "";
        }

        if (value is System.Enum)
        {
            var name = System.Enum.GetName(value.GetType(), value);
            if (name != null)
            {
                var field = System.Reflection.IntrospectionExtensions.GetTypeInfo(value.GetType())
                    .GetDeclaredField(name);
                if (field != null)
                {
                    var attribute = System.Reflection.CustomAttributeExtensions.GetCustomAttribute(field,
                            typeof(System.Runtime.Serialization.EnumMemberAttribute))
                        as System.Runtime.Serialization.EnumMemberAttribute;
                    if (attribute != null)
                    {
                        return attribute.Value != null ? attribute.Value : name;
                    }
                }

                var converted = System.Convert.ToString(System.Convert.ChangeType(value,
                    System.Enum.GetUnderlyingType(value.GetType()), cultureInfo));
                return converted == null ? string.Empty : converted;
            }
        }
        else if (value is bool)
        {
            return System.Convert.ToString((bool) value, cultureInfo).ToLowerInvariant();
        }
        else if (value is byte[])
        {
            return System.Convert.ToBase64String((byte[]) value);
        }
        else if (value.GetType().IsArray)
        {
            var array = System.Linq.Enumerable.OfType<object>((System.Array) value);
            return string.Join(",", System.Linq.Enumerable.Select(array, o => ConvertToString(o, cultureInfo)));
        }

        var result = System.Convert.ToString(value, cultureInfo);
        return result == null ? "" : result;
    }
}