using Microsoft.AspNetCore.Mvc;
using TaskTwo.Models;

namespace TaskTwo.Controllers
{
    public class SliderController : Controller
    {
        public IActionResult SelectCard()
        {
            List<Slider> sliders = SliderList.sliderList;
            return View("SelectCard", sliders);
        }

        public IActionResult CreateCard(Slider sliderOne)
        {
            return View("CreateCard");
        }

        public IActionResult CreateCardSave(Slider sliderOne)
        {
            Slider sliderTwo = new Slider();
            sliderTwo.ID = sliderOne.ID;
            sliderTwo.Name = sliderOne.Name;
            sliderTwo.Image = sliderOne.Image;
            SliderList.sliderList.Add(sliderTwo);
            return RedirectToAction("SelectCard");
        }

        public IActionResult GetCard(int id)
        {
            Slider slider = SliderList.sliderList.Where( s => s.ID == id).FirstOrDefault();

            return View("GetCard", slider);
        }



    }
}
