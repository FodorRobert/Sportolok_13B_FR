using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using portolok_13B_FR.Models;

namespace portolok_13B_FR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EredmenyController : ControllerBase
    {

        public readonly string ConnectionString = "server=localhost;database=sportolok13b;uid=root;password=";

        [HttpGet]
        public List<Eredmeny> GetAllEredmeny()
        {

            List<Eredmeny> eredmeny = new();

            var connector = new MySqlConnection(ConnectionString);
            connector.Open();

            string sql = "SELECT * FROM eredmeny;";

            var cmd = new MySqlCommand(sql, connector);
            var dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                var eredmeny1 = new Eredmeny
                {
                    Id = dataReader.GetInt32(0),
                    Competition = dataReader.GetString(1),
                    Description = dataReader.GetString(2),
                    ResultTime = dataReader.GetDateTime(3),
                    UpdateTime = dataReader.GetDateTime(4),
                    SportoloId = dataReader.GetInt32(5)
                };

                eredmeny.Add(eredmeny1);
            }

            connector.Close();

            return eredmeny;

        }

        [HttpGet("{id}")]
        public List<Eredmeny> GetEredmeny(int Id)
        {

            List<Eredmeny> eredmeny = new();

            var connector = new MySqlConnection(ConnectionString);
            connector.Open();

            string sql = "SELECT * FROM `eredmeny` WHERE 'Id'=@id";

            var cmd = new MySqlCommand(sql, connector);
            cmd.Parameters.AddWithValue("@id", Id);

            var dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                var eredmeny1 = new Eredmeny
                {
                    Id = dataReader.GetInt32(0),
                    Competition = dataReader.GetString(1),
                    Description = dataReader.GetString(2),
                    ResultTime = dataReader.GetDateTime(3),
                    UpdateTime = dataReader.GetDateTime(4),
                    SportoloId = dataReader.GetInt32(5)
                };

                eredmeny.Add(eredmeny1);
            }

            connector.Close();

            return eredmeny;

        }

    }
}
