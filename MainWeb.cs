
using System.Data.SqlClient;
using APBD5;

class MainWeb
{
    public static void Main(string[] args)
    {
        SqlConnection connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=apbd;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        AnimalController controller = new AnimalController(connection);
    }
}