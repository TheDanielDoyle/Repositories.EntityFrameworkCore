namespace Repositories.EntityFrameworkCore.Samples.Models
{
    internal class Banana
    {
        public Banana()
        {
        }

        public Banana(string type)
        {
            Type = type;
        }

        public int Id { get; set; }

        public string Type { get; set; }
    }
}
