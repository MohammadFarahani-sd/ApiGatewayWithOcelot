using System.ComponentModel.DataAnnotations;

namespace ProductsAPI.Enums;

public enum Language
{
    None = 0,

    [Display(Name = "en")]
    English = 1,

    [Display(Name = "ar")]
    Arabic = 2
}