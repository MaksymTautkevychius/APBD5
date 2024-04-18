using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace APBD5;


[ApiController]
[Route("/api/[controller]")]
public class AnimalController : ControllerBase
{
    private IConfiguration _configuration; 
    List<Animal> animals = new List<Animal>();

    public AnimalController(IConfiguration configuration)
    {
        _configuration=configuration;
    }

    [HttpGet]
    private IActionResult GetAnimal()
    {
        SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("(localdb)\\MSSQLLocalDB;Initial Catalog=APBD;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"));
        
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM Animal", connection);
            
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Animal animal = new Animal
                        {
                            IdAnimal = reader.GetInt32(reader.GetOrdinal("IdAnimal")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null : reader.GetString(reader.GetOrdinal("Description")),
                            Category = reader.GetString(reader.GetOrdinal("Category")),
                            Area = reader.GetString(reader.GetOrdinal("Area"))
                        };
                        animals.Add(animal);
                    }
                }
        return Ok();
    }

    [HttpPost]
    private IActionResult EditAnimal()
    {
        return Ok();
    }

    [HttpPut]
    private IActionResult AddAnimal(Animal animal)
    {
        SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
        
            connection.Open();
            SqlCommand command =
                new SqlCommand(
                    "INSERT INTO Animal (Name, Description, Category, Area) VALUES (@Name, @Description, @Category, @Area)",
                    connection);
            
                command.Parameters.AddWithValue("@Name", animal.Name);
                command.Parameters.AddWithValue("@Description", animal.Description ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Category", animal.Category);
                command.Parameters.AddWithValue("@Area", animal.Area);
                command.ExecuteNonQuery();
            
        
        return Ok();
    }

    [HttpDelete("{id}")]
    private IActionResult DeleteAnimal()
    {
        return Ok();
    }
    
}