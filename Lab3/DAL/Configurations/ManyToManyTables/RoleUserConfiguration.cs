using Microsoft.EntityFrameworkCore;

namespace DAL.Configurations.ManyToManyTables;

public static class RoleUserConfiguration
{
    public static ModelBuilder ApplyRoleUserConfiguration(this ModelBuilder builder)
    {
        builder.Entity("RoleUser", roleUser =>
        {
            roleUser.HasData(new[]
            {
                new { UsersId = 1L, RolesId = 1L },
                new { UsersId = 1L, RolesId = 2L },
                new { UsersId = 2L, RolesId = 2L },
                new { UsersId = 3L, RolesId = 3L },
            });
        });

        return builder;
    }
}
