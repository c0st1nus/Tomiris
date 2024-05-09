using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using UnityEngine;
using MySql.Data.MySqlClient;

public class DataBaseHandler : MonoBehaviour
{
 //     string connStr = " server=c0nstanta.germanywestcentral.cloudapp.azure.com; uid=c0nstanta; database=Nomadik; pwd=03062008@rjitdjqK; charset=utf8";
 //     public Data[] Select(string query = "SELECT * FROM users")
 //     {
 //         List<Data> dataList = new List<Data>();
 //         try
 //         {
 //             using (MySqlConnection connection = new MySqlConnection(connStr))
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
 //                     string UID = reader.GetString("UID");
 //
 //                     Data data = new Data(id, username, password, tgId, balance, lives, UID);
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
 //     private void Start()
 //     {
 //         ServicePointManager.ServerCertificateValidationCallback = ValidateServerCertificate;
 //         Select();
 //     }
 //     private bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
 //     {
 //         if (sslPolicyErrors == SslPolicyErrors.None)
 //             return true;
 //
 //         Debug.LogError("Certificate error: " + sslPolicyErrors);
 //         return false;
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
 //     public string UID { get; set; }
 //
 //     public Data(int id, string username, string password, string tgId, int balance, int lives, string UID)
 //     {
 //         this.Id = id;
 //         this.Username = username;
 //         this.Password = password;
 //         this.TgId = tgId;
 //         this.Balance = balance;
 //         this.Lives = lives;
 //         this.UID = UID;
 //     }
     private MySqlConnection connection;
     private string server;
     private string database;
     private string uid;
     private string password;

     void Start()
     {
         
         string connectionString = "server=20.52.101.204;user=c0nstanta@%;password=03062008@rjitdjqK;database=Nomadic;SslMode=None;";
        
         connection = new MySqlConnection(connectionString);
         OpenConnection();
     }

     private void OpenConnection()
     {
         if (connection.State == ConnectionState.Closed)
         {
             try
             {
                 connection.Open();
                 Debug.Log("Connected to database");
             }
             catch (MySqlException ex)
             {
                 Debug.LogError("Failed to connect to database: " + ex.Message);
             }
         }
     }

     private void CloseConnection()
     {
         if (connection.State == ConnectionState.Open)
         {
             connection.Close();
             Debug.Log("Connection closed");
         }
     }

     void OnApplicationQuit()
     {
         CloseConnection();
     }
 }
 