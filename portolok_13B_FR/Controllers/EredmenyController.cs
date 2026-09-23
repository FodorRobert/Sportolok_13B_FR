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

        [HttpGet("byid")]
        public object GetEredmeny(int id)
        {

            var connector = new MySqlConnection(ConnectionString);
            connector.Open();

            string sql = @"SELECT `Competition`, `Description`, `ResultTime`, `UpdateTime`, `SportoloId` FROM `eredmeny` WHERE `Id`=@id";

            var cmd = new MySqlCommand(sql, connector);
            cmd.Parameters.AddWithValue("@id", id);

            var dataReader = cmd.ExecuteReader();

            dataReader.Read();

            var eredmeny1 = new 
            {
                Competition = dataReader.GetString(0),
                Description = dataReader.GetString(1),
                ResultTime = dataReader.GetDateTime(2),
                UpdateTime = dataReader.GetDateTime(3),
                SportoloId = dataReader.GetInt32(4)
            };

            connector.Close();

            return eredmeny1;

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

        [HttpPut]
        public object UpdatePost([FromQuery] int id, [FromBody] UpdateEredmenyDTO updateEredmenyDTO)
        {

            var connector = new MySqlConnection(ConnectionString);
            connector.Open();

            var sql = @"UPDATE `eredmeny` SET `Competition`=@competition,`Description`=@description,`ResultTime`=@resulttime,`UpdateTime`=@updatetime,`SportoloId`=@sportoloid WHERE `Id`=@id";

            var cmd = new MySqlCommand(sql, connector);

            cmd.Parameters.AddWithValue("@competition", updateEredmenyDTO.Competition);
            cmd.Parameters.AddWithValue("@description", updateEredmenyDTO.Description);
            cmd.Parameters.AddWithValue("@resulttime", DateTime.Now);
            cmd.Parameters.AddWithValue("@updatetime", DateTime.Now);
            cmd.Parameters.AddWithValue("@sportoloid", id);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            var updatePost = new Eredmeny
            {
                Competition = updateEredmenyDTO.Competition,
                Description = updateEredmenyDTO.Description,
                ResultTime = DateTime.Now,
                UpdateTime = DateTime.Now,
                SportoloId = id
            };

            connector.Close();

            return updatePost;
        }

        [HttpDelete]
        public object DeleteEredmeny(int id)
        {

            var connector = new MySqlConnection(ConnectionString);
            connector.Open();

            var sql = $"DELETE FROM eredmeny WHERE id = @id";

            var cmd = new MySqlCommand(sql, connector);

            cmd.Parameters.AddWithValue(@"id", id);

            cmd.ExecuteNonQuery();

            connector.Close();

            return new { message = "Sikeres törlés!" };

        }

    }
}
