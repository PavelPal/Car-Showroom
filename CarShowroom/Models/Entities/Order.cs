using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarShowroom.Models.Entities
{
    public class Order
    {
        [Key,
         DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public decimal Cost { get; set; }
        public int ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateDelivery { get; set; }

        [DefaultValue(false)]
        public bool InProgress { get; set; }

        [DefaultValue(false)]
        public bool IsComplete { get; set; }
    }
}