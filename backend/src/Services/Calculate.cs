using paint_the_wall.src.Models;
using paint_the_wall.src.Views;

namespace paint_the_wall.src.Services
{
    public class Calculate
    {
        private readonly double _SQUARE_METER_FOR_LITER = 5;

        public List<Cans> CansOfPaint { get; set; }

        private Dictionary<double, int> ListOfCans { get; set; }

        public Calculate()
        {
            CansOfPaint = new List<Cans>();
            ListOfCans = new Dictionary<double, int>()
            {
                {Cans.EIGHTEEN_LITERS, 0},
                {Cans.THREE_POINT_SIX_LITERS, 0},
                {Cans.TWO_POINT_FIVE_LITERS, 0},
                {Cans.ZERO_POINT_FIVE_LITERS, 0}
            };
        }

        public ValidModelView CalculateCanOfPaint(LivingRoom livingRoom)
        {
            double Liters = (livingRoom.TotalSquareMeter() / _SQUARE_METER_FOR_LITER);

            double RemainingLiters = Liters;

            while (RemainingLiters > 0)
            {
                if (RemainingLiters >= Cans.EIGHTEEN_LITERS)
                {
                    ListOfCans[Cans.EIGHTEEN_LITERS] += 1;
                    RemainingLiters -= Cans.EIGHTEEN_LITERS;
                    continue;
                }

                if (RemainingLiters >= Cans.THREE_POINT_SIX_LITERS)
                {
                    ListOfCans[Cans.THREE_POINT_SIX_LITERS] += 1;
                    RemainingLiters -= Cans.THREE_POINT_SIX_LITERS;
                    continue;
                }

                if (RemainingLiters >= Cans.TWO_POINT_FIVE_LITERS)
                {
                    ListOfCans[Cans.TWO_POINT_FIVE_LITERS] += 1;
                    RemainingLiters -= Cans.TWO_POINT_FIVE_LITERS;
                    continue;
                }

                RemainingLiters -= Cans.ZERO_POINT_FIVE_LITERS;
                ListOfCans[Cans.ZERO_POINT_FIVE_LITERS] += 1;
            }


            foreach (var pair in ListOfCans)
            {
                if (pair.Value == 0) continue;

                if ((pair.Key == Cans.ZERO_POINT_FIVE_LITERS) && (pair.Value % 5 == 0))
                {
                    CansOfPaint.Add(new Cans(pair.Value / 5, Cans.TWO_POINT_FIVE_LITERS.ToString()));
                }
                else
                {
                    CansOfPaint.Add(new Cans(pair.Value, pair.Key.ToString()));
                }
            }

            return new ValidModelView(livingRoom.TotalSquareMeter(), Liters, CansOfPaint);

        }

    }
}