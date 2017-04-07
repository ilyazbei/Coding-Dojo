using System;
using System.Collections.Generic;


namespace DbConnection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            showUsers();
            // createUsers();
            //updateUserInfo();
            //deleteUserByID();
        }

        // Build a Read function that displays all current users information when the app start and after every insert
        public static void showUsers()
        {
            List<Dictionary<string, object>> users = DbConnector.Query("SELECT * FROM Users");
            System.Console.WriteLine("List of Users: ");
            foreach(var user in users)
            {
                System.Console.WriteLine($"First name is: {user["FirstName"]}, Last name is: {user["LastName"]}, and favorite number is: {user["FavoriteNumber"]}, users ID is: {user["idUsers"]}");
            }
        }

        // Build a "create" function that accepts input and create a new User row
        public static void createUsers()
        {
            System.Console.Write("Input First Name: ");
            string FirstName = Console.ReadLine(); 
            System.Console.Write("Input Last Name: ");
            string LastName = Console.ReadLine(); 
            System.Console.Write("Input Favorite Number: ");
            string FavNum = Console.ReadLine(); 

            DbConnector.Execute( "INSERT INTO Users (FirstName, LastName, FavoriteNumber) VALUES ('" +FirstName+"', '"+LastName+"',"+FavNum+")" );
            System.Console.WriteLine( $"You just created The user with First Name: {FirstName}, Last Name: {LastName}, Favorite Name: {FavNum}" );
        }

        // Build a Update function that when you specify a User Id will allow you to update all prompted rows
        public static void updateUserInfo()
        {
            System.Console.Write("Enter Users ID you want to edit: ");
            string UserID = Console.ReadLine();
            System.Console.Write("Edit First Name: ");
            string FirstName = Console.ReadLine();

            DbConnector.Execute( "UPDATE Users SET FirstName='"+FirstName+"' WHERE idUsers ='"+UserID+"'" );
        }

        // Build a Delete function that will remove a user with the ID specified
        public static void deleteUserByID()
        {
            System.Console.Write("Enter Users ID you want to delete: ");
            string UserID = Console.ReadLine();

            DbConnector.Execute( "DELETE FROM Users WHERE idUsers = '"+UserID+"' " );
            
            
        }

    }
}
