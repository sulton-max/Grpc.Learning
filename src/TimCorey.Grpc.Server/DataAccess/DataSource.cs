namespace TimCorey.Grpc.Server.DataAccess
{
    public class DataSource
    {
        public List<CustomerEntity> Customers { get; set; }

        public DataSource()
        {
            Customers = new List<CustomerEntity>
            {
                new(1, "John", "Doe", "john.doe@gmail.com", true, 15),
                new(2, "Jane", "Doe", "jane.doe@gmail.com", true, 20),
            };
        }
    }
}
