using BujairiTic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class RestaurantsController : Controller
{
    private readonly AppDbContext _context;

    public RestaurantsController(AppDbContext context)
    {
        _context = context;
    }

    // صفحة عرض كل المطاعم
    public IActionResult Restaurants()
    {
        var restaurants = _context.Restaurants.ToList();
        return View(restaurants);
    }

    // يفتح View مختلفة حسب المطعم
    public IActionResult Details(int id)
    {
        var restaurant = _context.Restaurants
            .FirstOrDefault(r => r.Id == id);

        if (restaurant == null)
            return NotFound();

        // اختيار الصفحة حسب ID
        switch (id)
        {
            case 1: return View("Brunch", restaurant);
            case 2: return View("Cova", restaurant);
            case 3: return View("LongChim", restaurant);
            case 4: return View("Somewhere", restaurant);
            case 5: return View("Maiz", restaurant);
            case 6: return View("Sarabeths", restaurant);
            case 7: return View("VillaMamas", restaurant);
            case 8: return View("Angelina", restaurant);
            case 9: return View("SumThings", restaurant);
            case 10: return View("Flamingo", restaurant);
            case 11: return View("Takya", restaurant);
            case 12: return View("Altopiano", restaurant);
            case 13: return View("AfricanLounge", restaurant);
            case 14: return View("MaisonAssouline", restaurant);
            case 15: return View("DolceGabbana", restaurant);
            case 16: return View("Liza", restaurant);
            default:
                return NotFound();
        }
    }
}
