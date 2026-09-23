using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using portolok_13B_FR.Models;
using portolok_13B_FR.Models.DTOs;

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

        [HttpPost]
        public Eredmeny AddNewEredmeny(AddEredmenyDTO eredmeny)
        {

            var connector = new MySqlConnection(ConnectionString);
            connector.Open();

            var e = new Eredmeny
            {

                Competition = eredmeny.Competition,
                Description = eredmeny.Description,
                ResultTime = DateTime.Now,
                UpdateTime = DateTime.Now,
                SportoloId = eredmeny.sportoloId

            };

            var sql = $"INSERT INTO `eredmeny`(`Competition`, `Description`, `ResultTime`, `UpdateTime`, `SportoloId`) VALUES (@competition, @description, @resulttime, @updatetime, @sportoloid)";

            var cmd = new MySqlCommand(sql, connector);

            cmd.Parameters.AddWithValue("@competition", e.Competition);
            cmd.Parameters.AddWithValue("@description", e.Description);
            cmd.Parameters.AddWithValue("@resulttime", e.ResultTime);
            cmd.Parameters.AddWithValue("@updatetime", e.UpdateTime);
            cmd.Parameters.AddWithValue("@sportoloid", e.SportoloId);

            cmd.ExecuteNonQuery();

            connector.Close();

            return e;

        }

    }
}
