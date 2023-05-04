using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace la_mia_pizzeria_static.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            using (PizzaContext db = new PizzaContext())
            {
                List<Pizza> pizze = db.Pizzas.ToList<Pizza>();

                return View(pizze);
            }
        }

        public IActionResult Details(int Id)
        {
            using (PizzaContext db = new PizzaContext())
            {
                Pizza pizza;
                try
                {
                    pizza = db.Pizzas.First(p => p.PizzaId == Id);

                    return View(pizza);  

                }catch (Exception)
                { 
                    return View("NotFound", Id);    
                }
            }
        }

    }
}
