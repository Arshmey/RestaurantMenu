using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantMenu.Models
{
    public class Dish
    {
        [Key]
        public int Id { get; set; }
        
        [Display(Name = "Дата создания")]
        [DataType(DataType.DateTime)]
        public DateTime DateCreate { get; set; }
        
        [Required(ErrorMessage = "Заполните поле")]
        [Display(Name = "Название")]
        [StringLength(255, ErrorMessage = "Длина имени должна быть не более 255 знаков")]
        [Remote("VerifyName", "Dish", HttpMethod = "POST", ErrorMessage = "Такое название уже используется")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Заполните поле")]
        [Display(Name = "Состав")]
        public string Composition { get; set; }
        
        [Required(ErrorMessage = "Заполните поле")]
        [Display(Name = "Описание")]
        [StringLength(500, ErrorMessage = "Длина описания должна быть не более 500 знаков")]
        public string Description { get; set; }
        
        [DefaultValue(0.1)]
        [Display(Name = "Цена")]
        [Range(0.1, Single.MaxValue, ErrorMessage = "Цена должна быть не менее 0.1")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        
        [DefaultValue(1)]
        [Display(Name = "Граммовка")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Граммовка должна быть не менее 1")]
        public int Grams { get; set; }
        
        [DefaultValue(0.1)]
        [Display(Name = "Калорийность")]
        [Range(0.1, Single.MaxValue, ErrorMessage = "Калорийность должна быть не менее 0.1")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Calorie { get; set; }
        
        [DefaultValue(1)]
        [Display(Name = "Время приготвления")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Время приготовления должно быть не менее 1")]
        public int CookTime { get; set; }
    }
}