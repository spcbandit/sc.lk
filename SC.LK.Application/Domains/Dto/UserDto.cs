using Newtonsoft.Json;
using SC.LK.Application.Domains.Enums;

namespace SC.LK.Application.Domains.Dto;

public class UserDto : Domains.BaseDto
{
      /// <summary>
      /// Активен ли аккаунт
      /// </summary>
      public bool IsActive { get; set; }

      /// <summary>
      ///  главный контрагент для пользовател
      /// </summary>
      public Guid MainContractor { get; set; }

      /// <summary>
      /// Имя
      /// </summary>
      public string? Name { get; set; }

      /// <summary>
      /// Отчество
      /// </summary>
      public string? Parent { get; set; }

      /// <summary>
      /// Фамилия
      /// </summary>
      public string? Family { get; set; }

      /// <summary>
      /// Login
      /// </summary>
      public string? Login { get; set; }

      /// <summary>
      /// Token
      /// </summary>
      public string? Token { get; set; }

      /// <summary>
      /// Password
      /// </summary>
      public string? Password { get; set; }

      /// <summary>
      /// Удален ли аккаунт
      /// </summary>
      public bool? IsDelete { get; set; }

      /// <summary>
      /// Контрагент
      /// </summary>
      public List<ContractorDto> Сontractor { get; set; }

}