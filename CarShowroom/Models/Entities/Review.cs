using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarShowroom.Models.Entities
{
    public class Review
    {
        [Key,
         DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Body { get; set; }
        public DateTime Date { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [DefaultValue(false)]
        public bool IsAccept { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}