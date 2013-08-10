namespace CAST2013.PageObjects
{
    public class Car
    {
        string make;
        string model;
        string color;
        string message;

        public Car(string make, string model, string color, string message)
        {
            this.make = make;
            this.model = model;
            this.color = color;
            this.message = message;
        }

        public string Make
        {
            get
            {
                return make;
            }
        }

        public string Model
        {
            get
            {
                return model;
            }
        }

        public string Color
        {
            get
            {
                return color;
            }
        }

        public string Message
        {
            get
            {
                return message;
            }
        }
    }
}