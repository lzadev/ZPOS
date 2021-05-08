using System.ComponentModel.DataAnnotations;

namespace ZPOS.UI.Models
{
    public class UpdateUserMV
    {

        public string Id { get; set; }

        [Required(ErrorMessage = "campo requerido")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "campo requerido")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "campo requerido")]
        public string LastName { get; set; }
        public bool Status { get; set; }
    }
}
