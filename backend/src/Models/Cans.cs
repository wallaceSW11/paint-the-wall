namespace paint_the_wall.src.Models
{
    public class Cans
    {
        public const Double EIGHTEEN_LITERS = 18;
        public const Double THREE_POINT_SIX_LITERS = 3.6;
        public const Double TWO_POINT_FIVE_LITERS = 2.5;
        public const Double ZERO_POINT_FIVE_LITERS = 0.5;

        private string _liters;

        public int Quantity { get; set; }
        public string Liters
        {
            get
            {
                Double total = Convert.ToDouble(_liters);
                return total.ToString("0.00").Replace(",", ".");
            }
            set { _liters = value; }

        }

        public Cans(int quantity, string liters)
        {
            this.Quantity = quantity;
            this.Liters = liters;
        }

    }
}