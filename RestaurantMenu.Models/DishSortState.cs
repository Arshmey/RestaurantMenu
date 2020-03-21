using System.Collections.Generic;
using System.Linq;

namespace RestaurantMenu.Models
{
    public enum DishSortState
    {
        //Каждая сортировка по полю разделена на пары и помечены в качестве десятков (0,10...70)
        //Asc - 0 - по возрастанию, Desc - 1 - по убыванию
        DateCreateAsc = 0,
        DateCreateDesc = 1,
        NameAsc = 10,
        NameDesc = 11,
        CompositionAsc = 20,
        CompositionDesc = 21,
        DescriptionAsc = 30,
        DescriptionDesc = 31,
        PriceAsc = 40,
        PriceDesc = 41,
        GramsAsc = 50,
        GramsDesc = 51,
        CalorieAsc = 60,
        CalorieDesc = 61,
        CookTimeAsc = 70,
        CookTimeDesc = 71
    }

    public static class DishSort
    {
        public static IQueryable<Dish> SortDishes(this IQueryable<Dish> dishes, DishSortState sortOrder) =>
            sortOrder switch
            {
                DishSortState.DateCreateDesc => dishes.OrderByDescending(x => x.DateCreate),
                DishSortState.NameAsc => dishes.OrderBy(x => x.Name),
                DishSortState.NameDesc => dishes.OrderByDescending(x => x.Name),
                DishSortState.CompositionAsc => dishes.OrderBy(x => x.Composition),
                DishSortState.CompositionDesc => dishes.OrderByDescending(x => x.Composition),
                DishSortState.DescriptionAsc => dishes.OrderBy(x => x.Description),
                DishSortState.DescriptionDesc => dishes.OrderByDescending(x => x.Description),
                DishSortState.PriceAsc => dishes.OrderBy(x => x.Price),
                DishSortState.PriceDesc => dishes.OrderByDescending(x => x.Price),
                DishSortState.GramsAsc => dishes.OrderBy(x => x.Grams),
                DishSortState.GramsDesc => dishes.OrderByDescending(x => x.Grams),
                DishSortState.CalorieAsc => dishes.OrderBy(x => x.Calorie),
                DishSortState.CalorieDesc => dishes.OrderByDescending(x => x.Calorie),
                DishSortState.CookTimeAsc => dishes.OrderBy(x => x.CookTime),
                DishSortState.CookTimeDesc => dishes.OrderByDescending(x => x.CookTime),
                _ => dishes.OrderBy(x => x.DateCreate)
            };

        //Как это работает. См. DishSortState
        //Постепенно приходясь по каждой паре метод создает имя сортировки, сравнивает оригинальный sortOrder и в случае 
        //соответствия берет следующие значение(сортировка по убыванию)
        public static List<KeyValuePair<string, object>> CurrentSortStates(this DishSortState sortOrder)
        {
            List<KeyValuePair<string, object>> sorts = new List<KeyValuePair<string, object>>();
            for (int i = 0; i <= 70; i += 10)
            {
                DishSortState newState = (DishSortState) i;
                string nameOfSort = newState.ToString().Replace("Asc", "Sort");
                if (sortOrder == newState) newState++;
                sorts.Add(new KeyValuePair<string, object>(nameOfSort, newState));
            }

            return sorts;
        }
    }
}