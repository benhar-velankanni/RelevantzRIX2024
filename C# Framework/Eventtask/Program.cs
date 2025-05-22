
 
using System;
 
// Define the delegate
public delegate void FileUploadedEventHandler(string fileName);
 
// Define the FileUploader class
public class FileUploader
{
    // Declare the event using the delegate
    public event FileUploadedEventHandler FileUploaded;
 
    public void UploadFile(string fileName)
    {
        Console.WriteLine($"Uploading file: {fileName}");
        // Trigger the event
        OnFileUploaded(fileName);
    }
 
    protected virtual void OnFileUploaded(string fileName)
    {
        FileUploaded?.Invoke(fileName);
    }
}
 
// Define the Logger component
public class Logger
{
    public void Log(string fileName)
    {
        Console.WriteLine($"[Logger] File uploaded: {fileName}");
    }
}
 
// Define the UI Notifier component
public class UINotifier
{
    public void Notify(string fileName)
    {
        Console.WriteLine($"[UI] Upload successful: {fileName}");
    }
}
 
// Define the Email Service component
public class EmailService
{
    public void SendEmail(string fileName)
    {
        Console.WriteLine($"[Email] Confirmation sent for: {fileName}");
    }
}
 
// Example usage
public class Program
{
    public static void Main()
    {
        var uploader = new FileUploader();
        var logger = new Logger();
        var uiNotifier = new UINotifier();
        var emailService = new EmailService();
 
        // Subscribe the components to the event
        uploader.FileUploaded += logger.Log;
        uploader.FileUploaded += uiNotifier.Notify;
        uploader.FileUploaded += emailService.SendEmail;
 
        // Upload a file
        uploader.UploadFile("LegalDocument.pdf");
    }
}
 
 
