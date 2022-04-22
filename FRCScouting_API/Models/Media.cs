namespace FRCScouting_API.Models
{
    public class Media
    {
        public byte[]? Data { get; set; }

        public Media(byte[] data)
        {
            Data = data;
        }
    }
}
