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
            public virtual List<Review>? Reviews { get; set; }
            public virtual List<Booking>? Bookings { get; set; }
            public virtual List<FavoriteHouses>? FavoriteHouses { get; set; }
        }
        public class Booking
        {
            public int Id { get; set; }
            public DateTime BookingDate { get; set; }
            public int HouseId { get; set; }
            public virtual Houses? Houses { get; set; }
            public int UserId { get; set; }
            public virtual User? User { get; set; }       

        }

        public class Review
        {
            public int Id { get; set; }
            public string? Comment { get; set; }
            public int UserId { get; set; }
            public virtual User? User { get; set; }

        }
        public class FavoriteHouses
        {
            public int Id { get; set; }
            public int UserId { get; set; }
            public virtual User? Users { get; set; }
            public int HouseId { get; set; }



        }
        public class Houses
        {
            
            public int Id { get; set; }
            public string? Address { get; set; }
            public int? Price { get; set; }
            public int? Metrage { get; set; }
            public int? Rooms { get; set; }
            public User? Owner { get; set; }

            public int? OwnerId { get; set; }
            public string? Description { get; set; }
            
            public int? PropertyTypeId { get; set; }
            public virtual PropertyType? PropertyType { get; set; }
            public string? Img { get; set; }
            public bool IsFavorite { get; set; }
        }

        public class PropertyType
        {
            public int Id { get; set; }

            public string? Type { get; set; }
            public string? Imgs { get; set; }

        }



    }
}
