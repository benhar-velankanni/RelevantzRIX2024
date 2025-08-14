using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Web.Services;
using TranslatorMD;

namespace TranslatorWeb
{
    /// <summary>
    /// Summary description for TranslatorWeb
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class TranslatorWeb : System.Web.Services.WebService
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        [WebMethod]
        public List<Translation> GetAllTranslations()
        {
            List<Translation> translations = new List<Translation>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Translations", connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    translations.Add(new Translation
                    {
                        TranslationId = Convert.ToInt32(reader["TranslationId"]),
                        TranslationString = reader["TranslationString"].ToString(),
                        FromLang = reader["FromLang"].ToString(),
                        ToLang = reader["ToLang"].ToString()
                    });
                }
            }

            return translations;
        }

        [WebMethod]
        public Translation GetTranslationById(int id)
        {
            Translation translation = new Translation();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Translations WHERE TranslationId=@TranslationId", connection);
                cmd.Parameters.AddWithValue("@TranslationId", id);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    translation.TranslationId = Convert.ToInt32(reader["TranslationId"]);
                    translation.TranslationString = reader["TranslationString"].ToString();
                    translation.FromLang = reader["FromLang"].ToString();
                    translation.ToLang = reader["ToLang"].ToString();
                }
            }

            return translation;
        }

        [WebMethod]
        public void InsertTranslation(string TranslationString, string FromLang, string ToLang)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO Translations (TranslationString, FromLang, ToLang) VALUES (@TranslationString, @FromLang, @ToLang)", connection);
                cmd.Parameters.AddWithValue("@TranslationString", TranslationString);
                cmd.Parameters.AddWithValue("@FromLang", FromLang);
                cmd.Parameters.AddWithValue("@Tolang", ToLang);
                cmd.ExecuteNonQuery();
            }
        }

        [WebMethod]
        public void UpdateTranslation(int TranslationId, string TranslationString, string FromLang, string ToLang)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE Translations SET TranslationString=@TranslationString, FromLang=@FromLang, ToLang=@ToLang WHERE TranslationId=@TranslationId", connection);
                cmd.Parameters.AddWithValue("@TranslationId", TranslationId);
                cmd.Parameters.AddWithValue("@TranslationString", TranslationString);
                cmd.Parameters.AddWithValue("@FromLang", FromLang);
                cmd.Parameters.AddWithValue("@Tolang", ToLang);
                cmd.ExecuteNonQuery();
            }
        }

        [WebMethod]
        public void DeleteTranslation(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM Translations WHERE TranslationId=@TranslationId", connection);
                cmd.Parameters.AddWithValue("@TranslationId", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
    public class Translation
    {
        [Key]
        public int TranslationId { get; set; }

        public string TranslationString { get; set; }

        public string FromLang { get; set; }

        public string ToLang { get; set; }
    }
}
