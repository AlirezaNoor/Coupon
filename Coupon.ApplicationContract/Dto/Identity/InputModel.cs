using System.ComponentModel.DataAnnotations;

namespace Coupon.ApplicationContract.Dto.Identity;

public class InputModel
{
    [Required]
    [Phone]
    [Display(Name = "شماره")]
    public string PhoneNumber { get; set; }

    [Required]
    [Display(Name = "نام کاربری")]
    public string Username { get; set; }

    [Required] [Display(Name = "نام  ")] public string name { get; set; }

    [Required]
    [Display(Name = "نام خانوادگی کاربری")]
    public string lastname { get; set; }

    [Required] [Display(Name = "کد ملی")] public string codemeli { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; }


    public bool RememberMe { get; set; }
}