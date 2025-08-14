using System.Collections.Generic;
using TransatorDAL;
using TranslatorMD;

namespace TranslatorBAL
{
    public class TranslatorBal
    {
        TranslatorDal _translatorDAL = new TranslatorDal();

        public List<Translation> GetAllTranslations() => _translatorDAL.GetAllTranslations();
        public Translation GetTranslationById(int id) => _translatorDAL.GetTranslationById(id);
        public void InsertTranslation(Translation translation) => _translatorDAL.InsertTranslation(translation);
        public void UpdateTranslation(Translation translation) => _translatorDAL.UpdateTranslation(translation);
        public void DeleteTranslation(int id) => _translatorDAL.DeleteTranslation(id);
    }
}
