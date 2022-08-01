namespace paint_the_wall.src.Models
{
    public class Wall : EntityBase
    {
        private readonly double _ONE_SQUARE_METER = 1.00;
        private readonly double _FIFTY_SQUARE_METER = 50.00;
        private readonly double _WINDOW_SQUARE_METER = 2.40;
        private readonly double _DOOR_SQUARE_METER = 1.52;

        public double Height { get; private set; }
        public double Width { get; private set; }
        public double Doors { get; set; } = 0;
        public double Windows { get; set; } = 0;

        public Wall(double height, double width, double windows = 0, double doors = 0)
        {
            Height = height;
            Width = width;
            Windows = windows;
            Doors = doors;
        }

        public double SquareMeter()
        {
            return
              ((Height / 100) * (Width / 100)) +
              TotalSquareMeterWindows +
              TotalSquareMeterDoors;
        }

        private double TotalSquareMeterWindows => (Windows * _WINDOW_SQUARE_METER);
        private double TotalSquareMeterDoors => (Doors * _DOOR_SQUARE_METER);

        private bool TotalAreaCantFit()
        {
            double metade = (SquareMeter() / 2.00);
            double TotalArea = 0;

            if (Windows > 0) TotalArea += TotalSquareMeterWindows;
            if (Doors > 0) TotalArea += TotalSquareMeterDoors;

            return (TotalArea > metade);
        }

        private bool MinimumHeightDoor()
        {
            const double DOOR_HEIGHT = 1.90;
            const double MINIMUM_HEIGHT = 30;
            return Doors == 0 ? true : ((Height - DOOR_HEIGHT) >= MINIMUM_HEIGHT);
        }

        public bool Valid()
        {
            AddValidation((Height == 0), "A altura da parede não foi informada.");
            AddValidation((Width == 0), "A largura da parede não foi informada.");
            AddValidation((SquareMeter() < _ONE_SQUARE_METER), $"O metro quadrado não pode ser menor que 1");
            AddValidation((SquareMeter() > _FIFTY_SQUARE_METER), $"O metro quadrado não pode ser maior que 50");
            AddValidation(TotalAreaCantFit(), "O total de área das portas e janelas deve ser no máximo 50% da área de parede");
            AddValidation(!MinimumHeightDoor(), "A altura de paredes com porta deve ser, no mínimo, 30 centímetros maior que a altura da porta");

            return ValidModel;
        }

    }
}