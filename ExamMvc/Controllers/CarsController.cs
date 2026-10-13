using System.Linq;
using System.Net;
using System.Web.Mvc;
using ExamMvc.Models;

namespace ExamMvc.Controllers
{
    // Вариант 3: Автомобили
    // Изпълнете местата с TODO. Номерата съвпадат със стъпките в условието.
    // Докато не поставите атрибутите за HTTP методите, Create, Edit и Delete
    // дават грешка „ambiguous“ — MVC не знае кой от двата метода да извика.
    public class CarsController : Controller
    {
        private ExamContext db = new ExamContext();

        // ---------------------------------------------------------------
        // СТЪПКА 1 — Списък, търсене и филтър
        // Адрес: /Cars   или   /Cars?search=toyota&category=Дизел
        // ---------------------------------------------------------------
        [HttpGet]
        public ActionResult Index(string search, string category)
        {
            // Списъкът за падащото меню (готово)
            ViewBag.Categories = db.Cars.Select(x => x.FuelType).Distinct().OrderBy(c => c).ToList();
            ViewBag.Search = search;
            ViewBag.Category = category;

            IQueryable<Car> cars = db.Cars;

            if (!string.IsNullOrWhiteSpace(search))
            {
                cars = cars.Where(x => x.Model.Contains(search) || x.Brand.Contains(search));
            }

            if (!string.IsNullOrWhiteSpace(category))
            {
                cars = cars.Where(x => x.FuelType == category);
            }

            return View(cars.OrderBy(x => x.Model).ToList());
        }

        // ---------------------------------------------------------------
        // СТЪПКА 2 — Детайли. Адрес: /Cars/Details/5
        // ---------------------------------------------------------------
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }

            return View(car);
        }

        // ---------------------------------------------------------------
        // СТЪПКА 3 — Добавяне. Адрес: /Cars/Create
        // ---------------------------------------------------------------
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Model,Brand,FuelType,Year,Price")] Car item)
        {
            if (!ModelState.IsValid)
            {
                return View(item);
            }

            db.Cars.Add(item);
            db.SaveChanges();
            TempData["Message"] = "Записът е добавен.";
            return RedirectToAction("Index");
        }

        // ---------------------------------------------------------------
        // СТЪПКА 4 — Редакция с PUT. Адрес: /Cars/Edit/5
        // ---------------------------------------------------------------
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }

            return View(car);
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Model,Brand,FuelType,Year,Price")] Car item)
        {
            Car car = db.Cars.Find(item.Id);
            if (car == null)
            {
                return HttpNotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(item);
            }

            car.Model = item.Model;
            car.Brand = item.Brand;
            car.FuelType = item.FuelType;
            car.Year = item.Year;
            car.Price = item.Price;
            db.SaveChanges();

            TempData["Message"] = "Записът е редактиран.";
            return RedirectToAction("Index");
        }

        // ---------------------------------------------------------------
        // СТЪПКА 5 — Изтриване с DELETE. Адрес: /Cars/Delete/5
        // ---------------------------------------------------------------
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }

            return View(car);
        }

        [HttpDelete]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }

            db.Cars.Remove(car);
            db.SaveChanges();
            TempData["Message"] = "Записът е изтрит.";
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
