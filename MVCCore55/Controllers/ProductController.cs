using Microsoft.AspNetCore.Mvc;
using MVCCore55.Models;

namespace MVCCore55.Controllers
{
    public class ProductController : Controller
    {
        static List<Product> products = new List<Product>()
        {
            new Product{Id=1, Name ="Laptop",Price=233},
            new Product{Id=2, Name ="Coffee",Price=255},
            new Product{Id=3, Name ="Phone",Price=333}
        };

        [HttpPost]
        public IActionResult CreateCar(Car car)
        {
            MyDB2Context db = new MyDB2Context();
            db.Cars.Add(car);
            db.SaveChanges();
            return RedirectToAction("AllCars");

        }

        [HttpGet]
        public IActionResult CreateCar()
        {
            return View();
        }

        public IActionResult AllCars()
        {
            MyDB2Context db = new MyDB2Context();
            return View(db.Cars.ToList());
        }
       
        [HttpPost]
        public IActionResult Search(String txtSearch)
        {
            //search tren Array
            var result = products.Where(p=>p.Name.Contains(txtSearch)).ToList();    
            //goi View: All, model la result
            return View("All", result);
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            //kiem tra Id da ton tai chua
            var pro = products.SingleOrDefault(p => p.Id == product.Id);
            if (pro != null)
            {
                ModelState.AddModelError("Id", "Id da ton tai!");
                //goi lai view Create
                return View("Create");
            }
            else
            {
                products.Add(product);
                return RedirectToAction("All");
            }          
        }

        public  IActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(x => x.Id == id);
            products.Remove(product);
            return RedirectToAction("All");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult All()
        {
            return View(products);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
