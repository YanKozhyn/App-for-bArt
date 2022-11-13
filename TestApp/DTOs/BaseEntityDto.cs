namespace TestApp.DTOs
{
    public abstract class BaseEntityDto
    {
        public Guid Id { get; set; } = new Guid();
    }
}
