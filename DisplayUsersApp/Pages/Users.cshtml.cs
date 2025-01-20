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
            // Check if the email already exists in the database before any operations
            var existingUser = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == NewUser.Email);

            if (existingUser != null)
            {
                // Add custom validation error if the email is already in use
                ModelState.AddModelError("NewUser.Email", "The email address is already in use.");
                UserList = await _context.Users.ToListAsync();  // Reload the user list to show the current users
                return Page();  // Re-render the page with the validation error
            }

            if (!ModelState.IsValid)
            {
                // If the model state is invalid after checking email, just reload the user list and return the page
                UserList = await _context.Users.ToListAsync();
                return Page();
            }

            // Add new user to the database if email is unique
            _context.Users.Add(NewUser);
            await _context.SaveChangesAsync();

            // Redirect to the same page after saving the new user
            return RedirectToPage();
        }

    }
}
