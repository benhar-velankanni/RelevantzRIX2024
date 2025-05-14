namespace DocumentManagementSystem
{
    public class FileUploader
    {
        public delegate void FileUploadedHandler(string fileName);
        public event FileUploadedHandler? FileUploaded;

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
            Console.WriteLine($"\n[Logger] File uploaded: {fileName}");
        }
    }

    public class UINotifier
    {
        public void Notify(string fileName)
        {
            Console.WriteLine($"\n[UI] Upload successful: {fileName}");
        }
    }

    public class EmailService
    {
        public void SendEmail(string fileName)
        {
            Console.WriteLine($"\n[Email] Confirmation sent for: {fileName}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var uploader = new FileUploader();
            var logger = new Logger();
            var uiNotifier = new UINotifier();
            var emailService = new EmailService();

            uploader.FileUploaded += logger.Log;
            uploader.FileUploaded += uiNotifier.Notify;
            uploader.FileUploaded += emailService.SendEmail;

            uploader.UploadFile("LegalDocument.pdf");
        }
    }
}