using System.Collections.Generic;
using CAST2013.PageObjects;

namespace CAST2013
{
    public class CarLoader
    {
        public IList<Car> load_list()
        {
            IList<Car>cars = new List<Car>();
            cars.Add(new Car("Acura", "Integra", "Sea Green", "You have chosen a Sea Green Acura Integra. Nice car!"));
            cars.Add(new Car("Audi", "A6", "Cyan", "You have chosen a Cyan Audi A6. Nice car!"));
            cars.Add(new Car("BMW", "5 series", "Banana", "You have chosen a Banana BMW 5 series. Nice car!"));
            cars.Add(new Car("Dodge", "Challenger", "Orange", "You have chosen a Orange Dodge Challenger. Nice car!"));
            return cars;
        }
    }
}