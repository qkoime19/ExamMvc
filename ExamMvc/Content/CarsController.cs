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
        // TODO 1.1: атрибут за HTTP метода
        public ActionResult Index(string search, string category)
        {
            // Списъкът за падащото меню (готово)
            ViewBag.Categories = db.Cars.Select(x => x.FuelType).Distinct().OrderBy(c => c).ToList();
            ViewBag.Search = search;
            ViewBag.Category = category;

            // TODO 1.2: ако search не е празен — само записи, в които „Модел“ ИЛИ „Марка“ съдържа search
            // TODO 1.3: ако category не е празен — само записи с това поле „Гориво“
            return View(db.Cars.OrderBy(x => x.Model).ToList());
        }

        // ---------------------------------------------------------------
        // СТЪПКА 2 — Детайли. Адрес: /Cars/Details/5
        // ---------------------------------------------------------------
        // TODO 2.1: атрибут за HTTP метода
        public ActionResult Details(int? id)
        {
            // TODO 2.2: без id → 400;  TODO 2.3: няма такъв запис → 404;  TODO 2.4: иначе → изгледа
            return new HttpStatusCodeResult(HttpStatusCode.NotImplemented);
        }

        // ---------------------------------------------------------------
        // СТЪПКА 3 — Добавяне. Адрес: /Cars/Create
        // ---------------------------------------------------------------
        // TODO 3.1: атрибут — този метод показва празната форма
        public ActionResult Create()
        {
            return View();
        }

        // TODO 3.2: атрибути — този метод приема попълнената форма (+ защита от фалшиви заявки)
        public ActionResult Create([Bind(Include = "Model,Brand,FuelType,Year,Price")] Car item)
        {
            // TODO 3.3: невалидни данни → същата форма с грешките
            // TODO 3.4: валидни → запис, съобщение в TempData["Message"], пренасочване към списъка
            return new HttpStatusCodeResult(HttpStatusCode.NotImplemented);
        }

        // ---------------------------------------------------------------
        // СТЪПКА 4 — Редакция с PUT. Адрес: /Cars/Edit/5
        // ---------------------------------------------------------------
        // TODO 4.1: атрибут — този метод показва формата за редакция
        public ActionResult Edit(int? id)
        {
            // TODO 4.2: без id → 400; няма такъв запис → 404; иначе → изгледа
            return new HttpStatusCodeResult(HttpStatusCode.NotImplemented);
        }

        // TODO 4.3: атрибути — този метод записва с PUT (+ защита от фалшиви заявки)
        public ActionResult Edit([Bind(Include = "Id,Model,Brand,FuelType,Year,Price")] Car item)
        {
            // TODO 4.4: записът е изтрит междувременно → 404
            // TODO 4.5: невалидни данни → същата форма с грешките
            // TODO 4.6: копирайте полетата в записа от базата, запишете, TempData, пренасочване
            // TODO 4.7: в Views/Cars/Edit.cshtml — формата трябва да „изпрати“ PUT
            return new HttpStatusCodeResult(HttpStatusCode.NotImplemented);
        }

        // ---------------------------------------------------------------
        // СТЪПКА 5 — Изтриване с DELETE. Адрес: /Cars/Delete/5
        // ---------------------------------------------------------------
        // TODO 5.1: атрибут — този метод показва страницата „Сигурни ли сте?“
        public ActionResult Delete(int? id)
        {
            // TODO 5.2: без id → 400; няма такъв запис → 404; иначе → изгледа
            return new HttpStatusCodeResult(HttpStatusCode.NotImplemented);
        }

        // TODO 5.3: атрибути — изтрива с DELETE (+ защита от фалшиви заявки).
        //           Методът се казва DeleteConfirmed, но трябва да отговаря на /Cars/Delete/5.
        public ActionResult DeleteConfirmed(int id)
        {
            // TODO 5.4: записът вече е изтрит → 404 (не 500!)
            // TODO 5.5: изтрийте, запишете, TempData, пренасочване към списъка
            // TODO 5.6: в Views/Cars/Delete.cshtml — формата трябва да „изпрати“ DELETE
            return new HttpStatusCodeResult(HttpStatusCode.NotImplemented);
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
