using AspNetCoreIdentityApp.Web.Models;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreIdentityApp.Web.ViewModels
{
    public class UserEditViewModel
    {
     

        [Display(Name = "Kullanıcı Adı :")]
        [Required(ErrorMessage = "Kullanıcı Ad alanı boş bırakılamaz.")]
        public string? UserName { get; set; }

        [Display(Name = "Email :")]
        [EmailAddress(ErrorMessage = "Email formatı yanlıştır.")]
        [Required(ErrorMessage = "Email alanı boş bırakılamaz.")]
        public string? Email { get; set; }


        [Display(Name = "Telefon :")]
        [Required(ErrorMessage = "Telefon alanı boş bırakılamaz.")]
        public string Phone { get; set; } = null!;
        [DataType(DataType.Date)]

        [Display(Name = "Doğum Tarihi :")]
        public DateTime? BirthDate { get; set; }
       
        [Display(Name = "Şehir :")]
        public string? City { get; set; }
        
        [Display(Name = "Profil Resmi :")]
        public IFormFile? Picture { get; set; }
       
        [Display(Name = "Cinsiyet :")]
        public Gender? Gender { get; set; }


    }
}
