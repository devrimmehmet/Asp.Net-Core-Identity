using System.ComponentModel.DataAnnotations;

namespace AspNetCoreIdentityApp.Web.Areas.Admin.Models
{
    public class RoleUpdateViewModel
    {
       
        public string? Id { get; set; }
        [Required(ErrorMessage = "Rol isim alanı boş bırakılamaz.")]
        [Display(Name = "Rol ismi :")]
        public string Name { get; set; } = null!;
    }
}
