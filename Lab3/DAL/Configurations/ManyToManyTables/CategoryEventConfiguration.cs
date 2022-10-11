using Microsoft.EntityFrameworkCore;

namespace DAL.Configurations.ManyToManyTables;

public static class CategoryEventConfiguration
{
    public static ModelBuilder ApplyCategoryEventConfiguration(this ModelBuilder builder)
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
