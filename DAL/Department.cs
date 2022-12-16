
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DepartmentId {get; set;}
        [Required]
        [Column(TypeName = "varchar(200)")]
        public string Name { get; set; }

    }
}
