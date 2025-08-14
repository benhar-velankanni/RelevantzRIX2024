using TransatorDAL.AppData;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranslatorMD;

namespace TransatorDAL
{
    public class TranslatorDal
    {
        public List<Translation> GetAllTranslations()
        {
            using (var db = new MyDBContext())
            {
                return db.Translations.ToList();
            }
        }

        public Translation GetTranslationById(int id)
        {
            using (var db = new MyDBContext())
            {
                return db.Translations.FirstOrDefault(e => e.TranslationId == id);
            }
        }

        public void InsertTranslation(Translation translation)
        {
            using (var db = new MyDBContext())
            {
                db.Translations.Add(translation);
                db.SaveChanges();
            }
        }

        public void UpdateTranslation(Translation translation)
        {
            using (var db = new MyDBContext())
            {
                var existing = db.Translations.FirstOrDefault(e => e.TranslationId == translation.TranslationId);
                if (existing != null)
                {
                    existing.TranslationString = translation.TranslationString;
                    existing.FromLang = translation.FromLang;
                    existing.ToLang = translation.ToLang;
                    db.SaveChanges();
                }
            }
        }

        public void DeleteTranslation(int id)
        {
            using (var db = new MyDBContext())
            {
                var translation = db.Translations.FirstOrDefault(e => e.TranslationId == id);
                if (translation != null)
                {
                    db.Translations.Remove(translation);
                    db.SaveChanges();
                }
            }
        }
    }
}
