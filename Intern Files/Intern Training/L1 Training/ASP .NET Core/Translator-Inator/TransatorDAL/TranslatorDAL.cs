using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranslatorMD;
using MySql.Data.MySqlClient;

namespace TransatorDAL
{
    public class TranslatorDal
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

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

        public Translation GetTranslationById(int id)
        {
            Translation translation = new Translation();
            using(MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Translations WHERE TranslationId=@TranslationId", connection);
                cmd.Parameters.AddWithValue("@TranslationId", id);
                MySqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    translation.TranslationId = Convert.ToInt32(reader["TranslationId"]);
                    translation.TranslationString = reader["TranslationString"].ToString();
                    translation.FromLang = reader["FromLang"].ToString();
                    translation.ToLang = reader["ToLang"].ToString();
                }
            }

            return translation;
        }

        public void InsertTranslation(Translation translation)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO Translations (TranslationString, FromLang, ToLang) VALUES (@TranslationString, @FromLang, @ToLang)", connection);
                cmd.Parameters.AddWithValue("@TranslationString", translation.TranslationString);
                cmd.Parameters.AddWithValue("@FromLang", translation.FromLang);
                cmd.Parameters.AddWithValue ("@Tolang", translation.ToLang);
                cmd.ExecuteNonQuery();                
            }
        }

        public void UpdateTranslation(Translation translation)
        {
            using(MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE Translations SET TranslationString=@TranslationString, FromLang=@FromLang, ToLang=@ToLang WHERE TranslationId=@TranslationId", connection);
                cmd.Parameters.AddWithValue("@TranslationId", translation.TranslationId);
                cmd.Parameters.AddWithValue("@TranslationString", translation.TranslationString);
                cmd.Parameters.AddWithValue("@FromLang", translation.FromLang);
                cmd.Parameters.AddWithValue("@Tolang", translation.ToLang);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteTranslation(int id)
        {
            using(MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM Translations WHERE TranslationId=@TranslationId", connection);
                cmd.Parameters.AddWithValue("@TranslationId", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
