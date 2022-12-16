using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }
        [Required]
        [Column(TypeName ="varchar(200)")]
        public string Address { get; set; }

        public decimal Salary { get; set; }

        public int DepartmentId { get; set; }

        //navigation property
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
    }
}