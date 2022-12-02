using Microsoft.AspNetCore.Identity;

namespace IdentityMicroService.DAL.Data;

public class ApplicationRole : IdentityRole<Guid>
{
    public ApplicationRole()
    {

    }

    public ApplicationRole(string name) : base(name)
    {

    }
}
