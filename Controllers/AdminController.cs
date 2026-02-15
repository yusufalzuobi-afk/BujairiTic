using BujairiTic.Models;
using BujairiTic.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static BujairiTic.Models.Enums;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly AppDbContext _context;

    public AdminController(AppDbContext context)
    {
        _context = context;
    }

    // ================= DASHBOARD =================
    public IActionResult Dashboard()
    {
        return View(); // الصفحة تعتمد AJAX
    }

    // ================= AJAX: GET ORDERS =================
    [HttpGet]
    public IActionResult GetOrders()
    {
        var orders = _context.Orders
                             .Include(o => o.Items)
                             .Where(o => o.Status == OrderStatus.PendingAdmin)
                             .OrderByDescending(o => o.Id)
                             .ToList();

        return PartialView("_OrdersTable", orders);
    }

    // ================= DELETE ORDER =================
    [HttpPost]
    public IActionResult Delete([FromBody] IdDto dto)
    {
        var order = _context.Orders
                            .Include(o => o.Items)
                            .FirstOrDefault(o => o.Id == dto.Id);

        if (order == null)
            return Json(new { success = false });

        _context.OrderItems.RemoveRange(order.Items);
        _context.Orders.Remove(order);

        _context.SaveChanges();

        return Json(new { success = true });
    }

    // ================= CONFIRM TRANSACTION =================
    [HttpPost]
    public IActionResult ConfirmTransaction([FromBody] ConfirmDto dto)
    {
        var order = _context.Orders.Find(dto.Id);

        if (order == null)
            return Json(new { success = false });

        order.TransactionNo = dto.TransactionNo;

        // 🔥 مهم — يخفي الكونفيرم
       

        _context.SaveChanges();

        return Json(new { success = true });
    }

}
