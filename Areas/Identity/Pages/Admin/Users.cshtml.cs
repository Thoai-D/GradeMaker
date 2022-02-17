using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using GradeMaker.Data;

namespace GradeMaker.Areas.Identity.Pages.Admin
{
    public class UsersModel : PageModel
    {
        private readonly SchoolContext db;
        public UsersModel(SchoolContext db) => this.db = db;
        public SchoolContext _bakeryContext { get; set; }
        public List<IdentityUser> Users { get; set; } = new List<IdentityUser>();

        public async Task OnGetAsync()
        {
            Users = await db.Users.ToListAsync();
        }
    }
}