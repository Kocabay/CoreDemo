using System.ComponentModel.DataAnnotations;

namespace CoreDemo.Areas.Admin.Models
{
    public class RoleViewModel
    {
        [Required(ErrorMessage = "Lütfen Rol Adı Giriniz.")]
        public string name { get; set; }
    }
}
