interface Notification{
    public void EmailNotification();
    public void SMSNotification();
    public void PushNotification();
}
class Email:Notification{
    public void EmailNotification(){
        Console.WriteLine("Email Notification");
    }
    public void SMSNotification(){

    }
    public void PushNotification(){

    }
}
class SMS:Notification{
    public void EmailNotification(){

    }
    public void SMSNotification(){
        Console.WriteLine("SMS Notification");
    }
    public void PushNotification(){    
    }
}
class Push:Notification{
    public void EmailNotification(){
    }
    public void SMSNotification(){
    }
    public void PushNotification(){
        Console.WriteLine("Push Notification");
    }
}
class Program{
    static void Main(string[] args){
        Email email=new Email();
        email.EmailNotification();
        SMS sms=new SMS();
        sms.SMSNotification();
        Push push=new Push();
        push.PushNotification();
}
}