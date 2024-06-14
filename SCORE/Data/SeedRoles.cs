using Microsoft.AspNetCore.Identity;

namespace SCORE.Data
{
    public static class SeedRoles
    {
        public static void Seed(RoleManager<IdentityRole> roleManager)
        {
            if(roleManager.Roles.Any() == false)
            {
                roleManager.CreateAsync(new IdentityRole("Docente")).Wait();
                roleManager.CreateAsync(new IdentityRole("Aluno")).Wait();
                roleManager.CreateAsync(new IdentityRole("Admin")).Wait();
            }
        }
    }
}
