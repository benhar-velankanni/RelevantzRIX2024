using System;

namespace DocumentManagementSystem
{
    public delegate void FileUploadedEventHandler(string fileName);

    public class FileUploader
    {
        public event FileUploadedEventHandler FileUploaded;

        public void UploadFile(string fileName)
        {
            Console.WriteLine($"Uploading file: {fileName}");
            OnFileUploaded(fileName);
        }
        protected virtual void OnFileUploaded(string fileName)
        {
            FileUploaded?.Invoke(fileName);
        }
    }
    public class Logger
    {
        public void Log(string fileName)
        {
            Console.WriteLine($"[Logger] File uploaded: {fileName}");
        }
    }

    public class UINotifier
    {
        public void Notify(string fileName)
        {
            Console.WriteLine($"[UI] Upload successful: {fileName}");
        }
    }

    public class EmailService
    {
        public void SendEmail(string fileName)
        {
            Console.WriteLine($"[Email] Confirmation sent for: {fileName}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            FileUploader uploader = new FileUploader();
            Logger logger = new Logger();
            UINotifier uiNotifier = new UINotifier();
            EmailService emailService = new EmailService();

            uploader.FileUploaded += logger.Log;
            uploader.FileUploaded += uiNotifier.Notify;
            uploader.FileUploaded += emailService.SendEmail;

            uploader.UploadFile("LegalDocument.pdf");
        }
    }
}
