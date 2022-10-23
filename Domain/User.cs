using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [MaxLength(50)]
        [Column(TypeName = "nvarchar(MAX)")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(128)]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Passsword { get; set; }

        [Required(ErrorMessage = "Firstname is required")]
        [StringLength(100)]
        [Column(TypeName = "nvarchar(MAX)")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Lastname is required")]
        [StringLength(100)]
        [Column(TypeName = "nvarchar(MAX)")]
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [StringLength(256)]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Email { get; set; }

        [StringLength(50)]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Phone { get; set; }

        [StringLength(50)]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Mobile { get; set; }
    }
}
