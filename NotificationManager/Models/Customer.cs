using NotificationManager.Infrastructure;

namespace NotificationManager.Models
{
    public class Customer : IEntity<int>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public int Matricola { get; set; }
        public int Status { get; set; }
    }
}
