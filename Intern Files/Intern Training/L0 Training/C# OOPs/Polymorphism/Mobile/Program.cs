// Ex : 2	Mobile Class - Method Overloading
// Objective: Practice method overloading with the Mobile class.
// Instructions:
// Create a Mobile class with the following overloaded SendMessage methods:
// SendMessage(string phoneNumber, string message)
// SendMessage(string phoneNumber, string message, string mediaUrl)
// SendMessage(string phoneNumber, byte[] mediaData)
// Add overloaded MakeCall methods:
// MakeCall(string phoneNumber)
// MakeCall(string phoneNumber, string contactName)

public class Mobile
{
    // Overloaded SendMessage methods
    public void SendMessage(string phoneNumber, string message)
    {
        Console.WriteLine($"\nSending text message to {phoneNumber}: {message}");
    }

    public void SendMessage(string phoneNumber, string message, string mediaUrl)
    {
        Console.WriteLine($"\nSending text message to {phoneNumber}: {message}, \nwith media: {mediaUrl}");
    }

    public void SendMessage(string phoneNumber, byte[] mediaData)
    {
        Console.WriteLine($"\nSending media message to {phoneNumber} with media data of length: {mediaData.Length}");
    }

    // Overloaded MakeCall methods
    public void MakeCall(string phoneNumber)
    {
        Console.WriteLine($"\nMaking call to {phoneNumber}");
    }

    public void MakeCall(string phoneNumber, string contactName)
    {
        Console.WriteLine($"\nMaking call to {phoneNumber} (Contact Name: {contactName})");
    }
}

public class Program
{
    public static void Main()
    {
        Mobile myMobile = new Mobile();

        // Calling SendMessage methods
        myMobile.SendMessage("123456789", "Hello there child!");
        myMobile.SendMessage("123456789", "Check out this gallery!", "https://developers.google.com/speed/webp/gallery");
        byte[] mediaData = { 0x1, 0x2, 0x3, 0x4 }; // Example data
        myMobile.SendMessage("123456789", mediaData);

        // Calling MakeCall methods
        myMobile.MakeCall("123456789");
        myMobile.MakeCall("123456789", "John Doe");

        Console.WriteLine("\nAll methods have been called.");
    }
}
