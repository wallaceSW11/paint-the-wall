namespace paint_the_wall.src.Models
{
    public class LivingRoom : EntityBase
    {
        public Wall FirstWall { get; set; }
        public Wall SecondWall { get; set; }
        public Wall ThirdWall { get; set; }
        public Wall FourthWall { get; set; }

        public LivingRoom(Wall firstWall, Wall secondWall, Wall thirdWall, Wall fourthWall)
        {
            FirstWall = firstWall;
            SecondWall = secondWall;
            ThirdWall = thirdWall;
            FourthWall = fourthWall;
        }

        public bool Valid()
        {
            if (FirstWall == null || SecondWall == null || ThirdWall == null || FourthWall == null)
            {
                AddValidation(true, "Devem ser informadas as quatro paredes.");
                return false;
            }

            AddValidation(!FirstWall.Valid(), "(FirstWall) " + FirstWall.DescriptionInvalidModel());
            AddValidation(!SecondWall.Valid(), "(SecondWall) " + SecondWall.DescriptionInvalidModel());
            AddValidation(!ThirdWall.Valid(), "(ThirdWall) " + ThirdWall.DescriptionInvalidModel());
            AddValidation(!FourthWall.Valid(), "(FourthWall) " + FourthWall.DescriptionInvalidModel());

            return ValidModel;
        }

        public double TotalSquareMeter()
        {
            return
              FirstWall.SquareMeter() +
              SecondWall.SquareMeter() +
              ThirdWall.SquareMeter() +
              FourthWall.SquareMeter();
        }
    }
}