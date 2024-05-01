using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyBlog.EntityLayer.Concrete;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;

namespace MyBlog.PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Notification")]
    public class NotificationController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        private readonly INotificationService _notificationService;

        public NotificationController(UserManager<AppUser> userManager, INotificationService notificationService)
        {
            _userManager = userManager;
            _notificationService = notificationService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _notificationService.TGetListAll();

            return View(values);
        }

        [Route("DeleteNotification/{id}")]
        public async Task<IActionResult> DeleteNotification(int id)
        {

            _notificationService.TDelete(id);

            return RedirectToAction("Index", "Notification", new { area = "Admin" });
        }

        [HttpGet]
        [Route("CreateNotification")]
        public IActionResult CreateNotification()
        {

            return View();
        }

        [HttpPost]
        [Route("CreateNotification")]
        public IActionResult CreateNotification(Notification notification)
        {
            notification.Created= DateTime.Now;
            _notificationService.TInsert(notification);

            return RedirectToAction("Index", "Notification", new { area = "Admin" });
        }


        [HttpGet]
        [Route("UpdateNotification/{id}")]
        public IActionResult UpdateNotification(int id)
        {
        
            var values = _notificationService.TGetById(id);
            return View(values);
        }

        [HttpPost]
        [Route("UpdateNotification/{id}")]
        public async Task<IActionResult> UpdateNotification(Notification notification)
        {    
            notification.Created = DateTime.Now;
       
            _notificationService.TUpdate(notification);
            return RedirectToAction("Index", "Notification", new { area = "Admin" });
        }





    }
}
