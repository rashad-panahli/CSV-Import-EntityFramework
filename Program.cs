using CSV_to_SQL_EF;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace CSV_to_SQL_EF
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=ServerName;Database=Test;User Id=YourID;Password=YourPwd;TrustServerCertificate=True;";
            string filePath = "people-100.csv";

            try
            {
                var optionBuilder = new DbContextOptionsBuilder<CustomerDbContext>()
                .UseSqlServer(connectionString);
                using (var dbContext = new CustomerDbContext(optionBuilder.Options))
                {
                    using (var reader = new StreamReader(filePath))
                    {
                        reader.ReadLine();

                        while (!reader.EndOfStream)
                        {
                            var line = reader.ReadLine();
                            var values = line.Split(",");

                            var customer = new Customer
                            {
                                Index = int.Parse(values[0]),
                                UserId = values[1],
                                FirstName = values[2],
                                LastName = values[3],
                                Gender = values[4],
                                Email = values[5],
                                Phone = values[6],
                                DateofBirth = DateTime.Parse(values[7]),
                                JobTitle = values[8]
                            };

                            dbContext.Customers.Add(customer);
                            dbContext.SaveChanges();
                        }
                    }
                }
                Console.WriteLine("Rows are inserted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            Console.ReadLine();
        }
    }
}



