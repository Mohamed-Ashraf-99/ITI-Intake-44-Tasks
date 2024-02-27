using Microsoft.AspNetCore.Mvc;
using TaskTwo.Models;

namespace TaskTwo.Controllers
{
    public class SliderController : Controller
    {
        public IActionResult CreateCardView()
        {
            return View("CreateCardView");
        }

        public IActionResult CreateCardSave(Slider sliderOne)
        {
            Slider sliderTwo = new Slider();
            sliderTwo.ID = sliderOne.ID;
            sliderTwo.Name = sliderOne.Name;
            sliderTwo.Image = sliderOne.Image;
            SliderList.sliderList.Add(sliderTwo);
            return RedirectToAction("CreatedCard");
        }

        public IActionResult CreatedCard()
        {
            Slider slider = SliderList.sliderList.Last();

            return View("CreatedCard", slider);
        }



    }
}
