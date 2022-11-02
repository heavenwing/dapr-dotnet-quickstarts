namespace BindingsWithSdk.Models
{
    public class User
    {
        public Guid? Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string DisplayName { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Email: {Email}, DisplayName: {DisplayName}";
        }
    }
}
