using System.ComponentModel.DataAnnotations;

namespace AspNetCoreIdentityApp.Web.Models
{
    public class ResetPasswordViewModel
    {
        [Display(Name = "Email :")]
        [EmailAddress(ErrorMessage = "Email formatı yanlıştır.")]
        [Required(ErrorMessage = "Email alanı boş bırakılamaz.")]
        public string? Email { get; set; }
    }
}
