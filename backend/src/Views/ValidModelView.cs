using paint_the_wall.src.Models;

namespace paint_the_wall.src.Views
{
    public class ValidModelView
    {
        private string _totalLiters;
        private string _totalSquareMeter;
        public string TotalSquareMeter
        {
            get
            {
                Double total = Convert.ToDouble(_totalSquareMeter);
                return total.ToString("0.00").Replace(",", ".");
            }
            set { _totalSquareMeter = value; }
        }

        public string TotalLiters
        {
            get
            {
                Double total = Convert.ToDouble(_totalLiters);
                return total.ToString("0.00").Replace(",", ".");
            }
            set { _totalLiters = value; }
        }

        public List<Cans> Cans { get; set; }

        public ValidModelView(double totalSquareMeter, double totalLiters, List<Cans> cans)
        {
            TotalSquareMeter = totalSquareMeter.ToString();
            TotalLiters = totalLiters.ToString(); ;
            Cans = cans;
        }
    }
}