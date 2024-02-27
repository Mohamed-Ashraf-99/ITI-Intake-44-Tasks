namespace TaskOne.Models
{
    public class CarList
    {
        public static List<Car> Cars { get; set; } = new()
        {
            new Car {Num = 1 , Color = "Gray", Model = "320i", Manfacture = "BMW", image = "1.png" },
            new Car {Num = 2 , Color = "Black", Model = "Cerato", Manfacture = "KIA", image = "2.png"  },
            new Car {Num = 3 , Color = "Gray", Model = "Corolla", Manfacture = "Toyota", image = "3.png"  },
            new Car {Num = 4 , Color = "Gray", Model = "C 180", Manfacture = "Mercedes", image = "4.png"  },
            new Car {Num = 5 , Color = "Red", Model = "sf90", Manfacture = "Ferrari", image = "5.png"  },
            new Car {Num = 6 , Color = "Red", Model = "GT3", Manfacture = "Porsche", image = "6.png"  },
        };

        public static List<Car> SelectAllCars()
        {
            return Cars;
        }
    }
}
