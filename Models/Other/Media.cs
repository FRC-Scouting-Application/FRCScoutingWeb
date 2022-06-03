namespace Models.Other
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
