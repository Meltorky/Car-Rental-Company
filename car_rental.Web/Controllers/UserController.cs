using Microsoft.AspNetCore.Mvc;

namespace car_rental.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IBookingService _bookingService;
        public UserController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }


        [HttpGet]
        public async Task<IActionResult> Bookings(string userId)
        {
            return View(await _bookingService.GetUserBookings(userId));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CancelBooking(int bookingId,string userId )
        {
            await _bookingService.CancelBooking(bookingId);
            return RedirectToAction(nameof(Bookings),new { userId = userId});
        }
    }
}
