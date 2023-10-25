using System.ComponentModel.DataAnnotations;

namespace AspNetCoreIdentityApp.Web.ViewModels
{
    public class SignUpViewModel
    {
        public SignUpViewModel() { }
        public SignUpViewModel(string userName, string email, string phone, string password, string passwordconfirm)
        {
            UserName = userName;
            Email = email;
            Phone = phone;
            Password = password;
            PasswordConfirm = passwordconfirm;
        }  
        
        
        [Display(Name ="Kullanıcı Adı :")]
        [Required(ErrorMessage ="Kullanıcı Ad alanı boş bırakılamaz.")]
        public string? UserName { get; set; }
        
        [Display(Name = "Email :")]
        [EmailAddress(ErrorMessage ="Email formatı yanlıştır.")]
        [Required(ErrorMessage = "Email alanı boş bırakılamaz.")]
        public string? Email { get; set; }
        
        
        [Display(Name = "Telefon :")]
        [Required(ErrorMessage = "Telefon alanı boş bırakılamaz.")]
        public string? Phone { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre alanı boş bırakılamaz.")]
        [Display(Name = "Şifre :")]
        public string? Password { get; set; }
        [DataType(DataType.Password)]
        [Compare(nameof(Password),ErrorMessage ="Şifreler aynı değildir.")]
        [Required(ErrorMessage = "Şifre Tekrar alanı boş bırakılamaz.")]
        [Display(Name = "Şifre Tekrar :")]
        public string? PasswordConfirm { get; set; }
    }
}
