using fish_mvc.Infrastructure.DatabaseManagement;
using fish_mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace fish_mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly DatabaseConnection _dbContext;
        public HomeController (DatabaseConnection database)
        {
            _dbContext = database;
        }

        private List<Marker> Markers { get; set; } = [];

        #region HUETA

        private static void MakeMarkers(List<Marker> Markers)
        {
            Markers.Add(new Marker { X = 55.5f, Y = 61, TotalPlaces = 1, Place="1", Type = " fa-regular fa-circle" });                    //1
            Markers.Add(new Marker { X = 51.4f, Y = 57.5f, TotalPlaces = 1, Place="2", Type = " fa-regular fa-circle" });                 //2
            Markers.Add(new Marker { X = 47.3f, Y = 54f, TotalPlaces = 1, Place="3", Type = " fa-regular fa-circle" });                   //3
            Markers.Add(new Marker { X = 43.2f, Y = 50.5f, TotalPlaces = 1, Place="4", Type = " fa-regular fa-circle" });                 //4
            Markers.Add(new Marker { X = 39.1f, Y = 47.1f, TotalPlaces = 1, Place="5", Type = " fa-regular fa-circle" });                 //5
            Markers.Add(new Marker { X = 35.5f, Y = 45.5f, TotalPlaces = 1, Place="6", Type = " fa-regular fa-circle" });                 //6
            Markers.Add(new Marker { X = 30.6f, Y = 45.9f, TotalPlaces = 1, Place="7", Type = " fa-regular fa-circle" });                 //7
            Markers.Add(new Marker { X = 27.3f, Y = 47.5f, TotalPlaces = 1, Place="8", Type = " fa-regular fa-circle" });                 //8
            Markers.Add(new Marker { X = 23.8f, Y = 49f, TotalPlaces = 1, Place="9", Type = " fa-regular fa-circle" });                   //9
            Markers.Add(new Marker { X = 20.5f, Y = 50.5f, TotalPlaces = 1, Place="10", Type = " fa-regular fa-circle" });                 //10
            Markers.Add(new Marker { X = 17f, Y = 52.4f, TotalPlaces = 1, Place="11", Type = " fa-regular fa-circle" });                   //11
            Markers.Add(new Marker { X = 13.3f, Y = 56.8f, TotalPlaces = 1, Place="12", Type = " fa-regular fa-circle" });                 //12
            Markers.Add(new Marker { X = 11.5f, Y = 62.5f, TotalPlaces = 1, Place="13", Type = " fa-regular fa-circle" });                 //13
            Markers.Add(new Marker { X = 11f, Y = 69.7f, TotalPlaces = 1, Place="14", Type = " fa-regular fa-circle" });                   //14
            Markers.Add(new Marker { X = 19.8f, Y = 42.3f, TotalPlaces = 1, Place="15-25", Type = " fa-regular fa-circle", Size = "fa-lg" }); //15 - 25
            Markers.Add(new Marker { X = 76.8f, Y = 29.4f, TotalPlaces = 1, Place="25-34", Type = " fa-regular fa-circle", Size = "fa-xs" }); //25 - 34
            Markers.Add(new Marker { X = 82.7f, Y = 28.4f, TotalPlaces = 1, Place="35-49", Type = " fa-regular fa-circle", Size = "fa-xs" }); //35 - 49
            Markers.Add(new Marker { X = 18.3f, Y = 17.5f, TotalPlaces = 1, Place="50", Type = " fa-regular fa-circle" });                 //50
            Markers.Add(new Marker { X = 23.3f, Y = 15.2f, TotalPlaces = 1, Place="51", Type = " fa-regular fa-circle" });                 //51
            Markers.Add(new Marker { X = 28.1f, Y = 13.6f, TotalPlaces = 1, Place="52", Type = " fa-regular fa-circle" });                 //52
            Markers.Add(new Marker { X = 33.3f, Y = 12.2f, TotalPlaces = 1, Place="53", Type = " fa-regular fa-circle" });                 //53
            Markers.Add(new Marker { X = 38.4f, Y = 12.6f, TotalPlaces = 1, Place="54", Type = " fa-regular fa-circle" });                 //54
            Markers.Add(new Marker { X = 43.6f, Y = 13f, TotalPlaces = 1, Place="55", Type = " fa-regular fa-circle" });                   //55
            Markers.Add(new Marker { X = 48.8f, Y = 13.4f, TotalPlaces = 1, Place="56", Type = " fa-regular fa-circle" });                 //56
            Markers.Add(new Marker { X = 53.8f, Y = 13.8f, TotalPlaces = 1, Place="57", Type = " fa-regular fa-circle" });                 //57
            Markers.Add(new Marker { X = 58.8f, Y = 15.3f, TotalPlaces = 1, Place="58", Type = " fa-regular fa-circle" });                 //58
            Markers.Add(new Marker { X = 63.3f, Y = 18f, TotalPlaces = 1, Place="59", Type = " fa-regular fa-circle" });                   //59
            Markers.Add(new Marker { X = 67.2f, Y = 21.4f, TotalPlaces = 1, Place="60", Type = " fa-regular fa-circle" });                 //60
            Markers.Add(new Marker { X = 88.6f, Y = 53f, TotalPlaces = 1, Place="61-65", Type = " fa-regular fa-circle", Size = "fa-xs" });   //61-65
            Markers.Add(new Marker { X = 82.8f, Y = 60.2f, TotalPlaces = 1, Place="66-68", Type = " fa-regular fa-circle", Size = "fa-xs" }); //66 - 68
        }

        public IActionResult Index ()
        {
            MakeMarkers(Markers);
            return View(Markers);
        }

        [HttpPost]
        public async Task<IActionResult> SaveUserData (ARENDATOR userData)
        {
            if ( ModelState.IsValid )
            {
                _dbContext.Arendators.Add(userData);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            MakeMarkers(Markers);
            return View("Index", Markers);
        }

        #endregion

        [HttpGet]
        public IActionResult Create ()
        {
            return View();
        }

        [Authorize(Policy = "admin")]
        public IActionResult OrderList ()
        {
            var list = _dbContext.Arendators.ToList();
            return View(list);
        }

        [HttpPost]
        public IActionResult RemoveOrder(int id)
        {
            var arendatorEntry = _dbContext.Arendators.FirstOrDefault(x => x.Id == id);
            if(arendatorEntry == null)
            {
                return View("Error", "marker entry with this id is not found");
            }

            _dbContext.Arendators.Remove(arendatorEntry);
            _dbContext.SaveChanges();

            return Redirect($"/Home/OrderList");
        }

        [HttpPost]
        public IActionResult Create (ARENDATOR userData)
        {
            if ( ModelState.IsValid )
            {
                _dbContext.Arendators.Add(userData);
                _dbContext.SaveChanges();
                return RedirectToAction("Success");
            }

            return View(new ARENDATOR());
        }

        public IActionResult Success ()
        {
            return View();
        }

/*        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error ()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }*/
    }
}
