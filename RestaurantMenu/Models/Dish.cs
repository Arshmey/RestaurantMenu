using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantMenu.Models
{
    public class Dish
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Display(Name = "Дата создания")]
        [DataType(DataType.DateTime)]
        public DateTime DateCreate { get; }
        
        [Required(ErrorMessage = "Заполните поле")]
        [Display(Name = "Название")]
        [StringLength(255, ErrorMessage = "Длина имени должна быть не более 255 знаков")]
        //TODO: Add remote check
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Заполните поле")]
        [Display(Name = "Состав")]
        public string Composition { get; set; }
        
        [Required(ErrorMessage = "Заполните поле")]
        [Display(Name = "Описание")]
        [StringLength(500, ErrorMessage = "Длина описания должна быть не более 500 знаков")]
        public string Description { get; set; }
        
        [DefaultValue(0)]
        [Display(Name = "Цена")]
        [Range(0, Single.MaxValue, ErrorMessage = "Цена должна быть не менее 0")]
        public float Price { get; set; }
        
        [DefaultValue(0)]
        [Display(Name = "Граммовка")]
        [Range(0, Int32.MaxValue, ErrorMessage = "Граммовка должна быть не менее 0")]
        public int Grams { get; set; }
        
        [DefaultValue(0)]
        [Display(Name = "Калорийность")]
        [Range(0, Single.MaxValue, ErrorMessage = "Калорийность должна быть не менее 0")]
        public float Calorie { get; set; }
        
        [DefaultValue(0)]
        [Display(Name = "Время приготвления")]
        [Range(0, Int32.MaxValue, ErrorMessage = "Время приготовления должно быть не менее 0")]
        public int CookTime { get; set; }

        public Dish()
        {
            DateCreate = DateTime.Now;
        }
    }
}