using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.CodeFirst;
using System.Windows.Controls;

namespace Domain.Data.Tables
{
    [Table("Persons")] //название табл
    public class Person
    {
        [Key] // ключевое поле 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Unique] // один раз введено
        [Required]
        public string Name { get; set; }
        // public int? Email { get; set; }
        // public int? Password { get; set; }


        //[ForeignKey("PersonRole")]
        // public long? RoleId { get; set; }

        // public Role PersonRole { get; set; }

        // public ICollection<Order> Orders { get; set; }
        public override string ToString()
        {
            return $"{Id}-{Name}";//-{Email}"
        }
    }
}
