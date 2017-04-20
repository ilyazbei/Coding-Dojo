using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using LostInTheWoods.Models;
using LostInTheWoods.Controllers;
using Microsoft.Extensions.Options;


namespace LostInTheWoods.Factory {

    public class TrailFactory : IFactory<Trail> {

        private readonly IOptions<MySqlOptions> MySqlConfig;
 
        public TrailFactory(IOptions<MySqlOptions> config)
        {
            MySqlConfig = config;
        }
        internal IDbConnection Connection {
            get {
                return new MySqlConnection(MySqlConfig.Value.ConnectionString);
            }
        }
    
        // ------------------- My Factory Methods ----------------------- //
        public void Add(Trail newTrail) {

            using (IDbConnection dbConnection = Connection) {

                string query = "INSERT INTO Trails (trail_name, description, trail_length, elevation_change, longitude, latitude, created_at, updated_at, Users_idUsert) VALUES (@newTrail.trail_name, @newTrail.description, @newTrail.trail_length, @newTrail.elevation_change, @newTrail.longitude, @newTrail.latitude, NOW(), NOW(), @UserId)";
                dbConnection.Open();
                dbConnection.Execute(query, newTrail);
            }
        }
    }
}