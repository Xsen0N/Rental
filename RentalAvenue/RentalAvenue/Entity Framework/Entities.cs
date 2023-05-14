using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace RentalAvenue
{
    public class Entities
    {
        public class User
        {
            public int Id { get; set; }
            public string? Email { get; set; }
            public string? Login { get; set; }
            public bool IsAdmin { get; set; }
        }
        public class Houses
        {
            [Key]
            public int Id { get; set; }
            public string? Address { get; set; }
            public int? Price { get; set; }
            public int? Metrage { get; set; }
            public int? Rooms { get; set; }
            public string? Owner { get; set; }
            public string? Description { get; set; }

            public int PropertyTypeId { get; set; }
            public virtual PropertyType PropertyType { get; set; }
        }

        public class PropertyType
        {
            [Key]
            public int Id { get; set; }

            [Required]
            public string? Type { get; set; }

            public virtual ICollection<Houses> Houses { get; set; }
        }



    }
}
