using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;

namespace MyBlog.PresentationLayer.ViewComponents.WriterLayoutViewComponents
{
    public class _NotificationsComponentPartial:ViewComponent
    {
        private readonly INotificationService _notificationtService;

        public _NotificationsComponentPartial(INotificationService notificationtService)
        {
            _notificationtService = notificationtService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
           
            var values = _notificationtService.TGetListAll();
            var lastFiveItems = values.OrderByDescending(item => item.Created)
                           .Take(5)
                           .ToList();

            return View(lastFiveItems);
        }


    }
}
