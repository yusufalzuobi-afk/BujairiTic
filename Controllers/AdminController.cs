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

   
    public IActionResult Dashboard()
    {
        return View(); 
    }

  
    [HttpGet]
    public IActionResult GetOrders()
    {
        var orders = _context.Orders
                             .Include(o => o.Items)
                             .Where(o => o.Status == OrderStatus.Draft)
                             .OrderByDescending(o => o.Id)
                             .ToList();

        return PartialView("_OrdersTable", orders);
    }

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

    [HttpPost]
    public IActionResult ConfirmTransaction([FromBody] ConfirmDto dto)
    {
        var order = _context.Orders.Find(dto.Id);

        if (order == null)
            return Json(new { success = false });

        order.TransactionNo = dto.TransactionNo;

       

        _context.SaveChanges();

        return Json(new { success = true });
    }

}
