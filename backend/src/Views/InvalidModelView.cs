namespace paint_the_wall.src.Views
{
    public class InvalidModelView
    {
        public string Status { get; set; }
        public List<string> Occurrences { get; set; }

        public InvalidModelView(List<string> messages)
        {
            Status = "error";
            Occurrences = messages;
        }
    }
}