using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace APBD5;

public class AnimalController
{
    private SqlConnection _connection;

    public AnimalController(SqlConnection connection)
    {
        _connection = connection;
    }

    [HttpGet ("/api/animals")]
    private IActionResult GetAnimal()
    {
        SqlCommand Retrieve = new SqlCommand();
        Retrieve.Connection = _connection;
        Retrieve.CommandText = "SELECT * FROM Animal";
        _connection.Open();
        SqlDataReader dr = Retrieve.ExecuteReader();
        
        return null;
    }

    [HttpPost]
    private IActionResult EditAnimal()
    {
        
    }

    [HttpPut]
    private IActionResult AddAnimal()
    {
        
    }

    [HttpDelete]
    private IActionResult DeleteAnimal()
    {
        
    }
    
}