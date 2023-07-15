namespace TimCorey.Grpc.Server.DataAccess
{
    public class CustomerEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; }
        public bool IsAlive { get; set; }
        public int Age { get; set; }

        public CustomerEntity(int id, string firstName, string lastName, string emailAddress, bool isAlive, int age)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            IsAlive = isAlive;
            Age = age;
        }
    }
}
