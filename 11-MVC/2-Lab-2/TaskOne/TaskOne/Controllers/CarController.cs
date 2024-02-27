using Microsoft.AspNetCore.Mvc;
using TaskOne.Models;

namespace TaskOne.Controllers
{
    public class CarController : Controller
    {
        public IActionResult GetAllCars()
        {
            List<Car> Cars = CarList.SelectAllCars();
            return View("GetAllCars", Cars);
        }

        public IActionResult GetCar(int id)
        {
            Car car = CarList.SelectAllCars().Where(c => c.Num == id).FirstOrDefault();
            return View("GetCar", car);
        }

        public IActionResult CreateCarView()
        {
            return View();
        }

        public IActionResult CreateCar(Car carOne)
        {
            Car carTwo = new Car();
            carTwo.Num = carOne.Num;
            carTwo.Color = carOne.Color;
            carTwo.Model = carOne.Model;
            carTwo.Manfacture = carOne.Manfacture;
            carTwo.image = carOne.image;
            CarList.Cars.Add(carTwo);
            return RedirectToAction("GetAllCars");
        }


        public IActionResult DeleteCar(int id)
        {
            CarList.Cars.Remove(CarList.Cars.Where(c => c.Num == id).FirstOrDefault());
            return RedirectToAction("GetAllCars");
        }

        public IActionResult Edit (int id)
        {
            Car car = CarList.Cars.Where(c => c.Num == id).FirstOrDefault();
            return View("Edit", car);
        }
        
        public IActionResult EditSave(Car carOne)
        {
            Car carTwo = CarList.Cars.Where(c => c.Num == carOne.Num).FirstOrDefault();
            
            carTwo.Color = carOne.Color;
            carTwo.Model = carOne.Model;
            carTwo.Manfacture =carOne.Manfacture;
            carTwo.image = carOne.image;

            return RedirectToAction("GetAllCars");
        }
    }
}
