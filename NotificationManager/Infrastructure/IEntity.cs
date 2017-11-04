namespace NotificationManager.Infrastructure
{
    public interface IEntity<T>
    {
         T Id { get; set; }
    }
}