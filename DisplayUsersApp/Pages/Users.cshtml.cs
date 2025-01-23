using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DisplayUsersApp.Data;
using DisplayUsersApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace DisplayUsersApp.Pages
{
    public class UsersModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public UsersModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<User> UserList { get; set; } = new List<User>();

        [BindProperty]
        public User NewUser { get; set; } = new User();
        public async Task OnGetAsync()
        {
            UserList = await _context.Users.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (NewUser != null) _context.Users.Add(NewUser);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Users");
        }


    }
}
