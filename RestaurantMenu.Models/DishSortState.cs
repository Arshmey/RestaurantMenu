using System.Linq;

namespace RestaurantMenu.Models
{
    public enum DishSortState
    {
        //Asc - по возрастанию, Desc - по убыванию
        DateCreateAsc,
        DateCreateDesc,
        NameAsc,
        NameDesc,
        CompositionAsc,
        CompositionDesc,
        DescriptionAsc,
        DescriptionDesc,
        PriceAsc,
        PriceDesc,
        GramsAsc,
        GramsDesc,
        CalorieAsc,
        CalorieDesc,
        CookTimeAsc,
        CookTimeDesc
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
    }
}