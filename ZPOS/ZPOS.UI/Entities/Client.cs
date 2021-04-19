using System;
using System.ComponentModel.DataAnnotations;

namespace ZPOS.UI.Entities
{
    public class Client
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(20)]
        public string Document { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(50)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MaxLength(10)]
        public string Phone { get; set; }
        [Required]
        [MaxLength(400)]
        public string Address { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }

        public bool Deleted { get; set; }

    }
}
