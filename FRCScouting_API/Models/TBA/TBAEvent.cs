namespace FRCScouting_API.Models.TBA
{
    public class TBAEvent : TBALocation
    {
        public string? Key { get; set; }
        public string? Name { get; set; }
        public string? Short_Name { get; set; }
        public DateTime? Start_Date { get; set; }
        public DateTime? End_Date { get; set; }
        public int? Year { get; set; }
        public int? Week { get; set; }
        public string? Event_Type_String { get; set; }
    }
}
