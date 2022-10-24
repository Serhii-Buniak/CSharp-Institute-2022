using Microsoft.EntityFrameworkCore;

namespace CityMicroService.DAL.Entities;

internal static class CategoryEventSeeder
{
    public static ModelBuilder ApplyCategoryEventSeeder(this ModelBuilder builder)
    {
        builder.Entity("CategoryEvent", categoryEvent =>
        {
            categoryEvent.HasData(new[]
            {
                new { CategoriesId = 1L, EventsId = 1L },
                new { CategoriesId = 1L, EventsId = 2L },
                new { CategoriesId = 2L, EventsId = 2L },
                new { CategoriesId = 3L, EventsId = 3L },
                new { CategoriesId = 3L, EventsId = 4L },
                new { CategoriesId = 3L, EventsId = 5L },
            });
        });

        return builder;
    }
}