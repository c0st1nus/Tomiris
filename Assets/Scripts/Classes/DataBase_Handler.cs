using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
//using MySql.Data.MySqlClient;

// public class DataBase_Handler : MonoBehaviour
// {
//     string connectionString = "Server=myServerAddress;Database=myDataBase;Uid=myUsername;Pwd=myPassword;ConnectionTimeout=1";
//     
//     public async Task<bool> CheckConnectionAsync()
//     {
//         try
//         {
//             using (MySqlConnection connection = new MySqlConnection(connectionString))
//             {
//                 await connection.OpenAsync();
//                 return true;
//             }
//         }
//         catch (MySqlException)
//         {
//             return false;
//         }
//     }
//     
//     public Data[] Select(string query = "SELECT * FROM users")
//     {
//         List<Data> dataList = new List<Data>();
//         try
//         {
//             using (MySqlConnection connection = new MySqlConnection(connectionString))
//             {
//                 connection.Open();
//
//                 MySqlCommand command = new MySqlCommand(query, connection);
//                 MySqlDataReader reader = command.ExecuteReader();
//
//                 while (reader.Read())
//                 {
//                     int id = reader.GetInt32("idusers");
//                     string username = reader.GetString("username");
//                     string password = reader.GetString("password");
//                     string tgId = reader.GetString("telegramID");
//                     int balance = reader.GetInt32("balance");
//                     int lives = reader.GetInt32("lives");
//
//                     Data data = new Data(id, username, password, tgId, balance, lives);
//                     dataList.Add(data);
//                 }
//             
//                 connection.Close();
//             }
//
//             return dataList.ToArray();
//         }
//         catch (MySqlException e)
//         {
//             Debug.LogError(e);
//             return null;
//         }
//     }
// }
//
// public class Data
// {
//     public int Id { get; set; }
//     public string Username { get; set; }
//     public string Password { get; set; }
//     public string TgId { get; set; }
//     public int Balance { get; set; }
//     public int Lives { get; set; }
//
//     public Data(int id, string username, string password, string tgId, int balance, int lives)
//     {
//         this.Id = id;
//         this.Username = username;
//         this.Password = password;
//         this.TgId = tgId;
//         this.Balance = balance;
//         this.Lives = lives;
//     }
// }