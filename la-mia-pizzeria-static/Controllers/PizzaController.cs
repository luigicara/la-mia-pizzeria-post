using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Hosting;
using System.Globalization;
using System.Web;

namespace la_mia_pizzeria_static.Controllers
{
    public class PizzaController : Controller
    {

        private IWebHostEnvironment Environment;

        public PizzaController(IWebHostEnvironment _environment)
        {
            Environment = _environment;
        }
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Pizza data, IFormFile img)
        {
            data.ImgPath = Path.Combine(Environment.WebRootPath, "img", img.FileName);

            ModelState.ClearValidationState("ImgPath");

            TryValidateModel(data);

            if (!ModelState.IsValid)
            {
                return View("Create", data);
            }

            using (var stream = System.IO.File.Create(data.ImgPath))
            {
                await img.CopyToAsync(stream);
            }

            using (PizzaContext db = new PizzaContext())
            {
                Pizza pizzaToCreate = new Pizza();
                pizzaToCreate.Name = data.Name;
                pizzaToCreate.Ingredients = data.Ingredients;
                pizzaToCreate.ImgPath = "~/" + Path.GetRelativePath(Environment.WebRootPath, data.ImgPath);
                pizzaToCreate.Price = data.Price;
                db.Pizzas.Add(pizzaToCreate);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }
    }
}
