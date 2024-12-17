namespace _2._5_dars
{
    public class Vehicle
    {
        public int speed { get; set; }

        private double _fuel;

        public double Fuel
        {
            get { return _fuel; }
            set
            {
                if (50 >= value + _fuel)
                {
                    _fuel += value;
                }
            }
        }

    }
}
