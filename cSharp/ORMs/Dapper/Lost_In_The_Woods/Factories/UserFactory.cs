using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using LostInTheWoods.Models;
using Microsoft.Extensions.Options;

namespace LostInTheWoods.Factory {

    public class UserFactory : IFactory<User> {

        private readonly IOptions<MySqlOptions> MySqlConfig;
 
        public UserFactory(IOptions<MySqlOptions> config)
        {
            MySqlConfig = config;
        }
        internal IDbConnection Connection {
            get {
                return new MySqlConnection(MySqlConfig.Value.ConnectionString);
            }
        }
        
        // ------------------- My Factory Methods ----------------------- //
        public void Add(User newUser)
        {
            using (IDbConnection dbConnection = Connection) {
                string query =  "INSERT INTO Users (first_name, last_name, email, password, created_at, updated_at) VALUES (@first_nam, @last_name, @email, @password, NOW(), NOW())";
                dbConnection.Open();
                dbConnection.Execute(query, newUser);
            }
        }
        public User FindByEmail(string email)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<User>("SELECT * FROM users WHERE email = @email", new { email = email }).FirstOrDefault();
            }
        }
       
 
    }
}