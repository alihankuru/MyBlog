using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;

namespace MyBlog.PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Writer")]
    public class WriterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        private readonly IWriterService _writerService;

        public WriterController(UserManager<AppUser> userManager, IWriterService writerService)
        {
            _userManager = userManager;
            _writerService = writerService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            // Get all users
            var users = await _userManager.Users.ToListAsync();

            // Filter users with the "Writer" role
            var writerUsers = users.Where(u => _userManager.IsInRoleAsync(u, "Writer").Result).ToList();

            return View(writerUsers);
        }

        [Route("DeleteWriter/{id}")]
        public async Task<IActionResult> DeleteWriter(int id)
        {

            _writerService.TChangeStatus(id);

            return RedirectToAction("Index", "Writer", new { area = "Admin" });
        }

        [HttpGet]
        [Route("UpdateWriter/{id}")]
        public async Task<IActionResult> UpdateWriter(int id)
        {

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
          

            // Pass the user data to the view for editing
            return View(user);

        }

        [HttpPost]
        [Route("UpdateWriter/{id}")]
        public async Task<IActionResult> UpdateWriter(AppUser AppUser)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user == null)
            {
                // Handle the scenario where the user is not found
                return NotFound();
            }

            // Update the user data with the new information
            user.UserName = AppUser.UserName;
            user.Name = AppUser.Name;
            user.Surname = AppUser.Surname;
            // Add more properties to update as needed

            // Update the user in the data store
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                // Handle the scenario where the update fails
                // For example, display an error message to the user
                return View(AppUser);
            }

            return RedirectToAction("Index", "Writer", new { area = "Admin" });
        }

        [HttpGet]
        [Route("CreateWriter")]
        public IActionResult CreateWriter()
        {
       
            return View();
        }

        [HttpPost]
        [Route("CreateWriter")]
        public async Task<IActionResult> CreateWriter(AppUser user)
        {
            if (ModelState.IsValid)
            {
                // Create the new user
                var result = await _userManager.CreateAsync(user);

                if (result.Succeeded)
                {
                    // If user creation is successful, assign the "Writer" role to the user
                    await _userManager.AddToRoleAsync(user, "Writer");

                    // Redirect to the writer index page
                    return RedirectToAction("Index", "Writer", new { area = "Admin" });
                }
                else
                {
                    // If there are errors during creation, add model errors
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            // If the model state is invalid or creation fails, redisplay the form with errors
            return View(user);
        }




    }
}
