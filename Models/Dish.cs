 using System.ComponentModel.DataAnnotations;
    using System;
    namespace CRUDelicious.Models
    {
        public class Dish
        {
            // auto-implemented properties need to match the columns in your table
            // the [Key] attribute is used to mark the Model property being used for your table's Primary Key
            [Key]
            public int DishId { get; set; }
            // MySQL VARCHAR and TEXT types can be represeted by a string
            [Required]
            [Display(Name="Name of Dish")]
            public string Name { get; set; }
            [Required]
            [Display(Name="Chef's Name")]
            public string Chef { get; set; }
            [Required]
            [Range(1,5,ErrorMessage="Grade between 1-5")]
            public int Tastiness { get; set; }
            [Required]
            [Range(0,Int32.MaxValue,ErrorMessage="Minimum Value is 0")]
            [Display(Name="# of Calories")]
            public int Calories { get; set; }
            [Required]
            public string Description {get;set;}
            // The MySQL DATETIME type can be represented by a DateTime
            public DateTime CreatedAt {get;set;}
            public DateTime UpdatedAt {get;set;}
        }
    }