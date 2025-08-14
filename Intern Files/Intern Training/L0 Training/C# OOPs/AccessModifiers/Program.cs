class UsingAccessSpecifiers
{
    int propertyId;

    public UsingAccessSpecifiers()
    {
        propertyId = 30062004;
    }

    public UsingAccessSpecifiers(int propertyId)
    {
        this.propertyId = propertyId;
    }

    //Global access.
    public void PublicMethod()
    {
        Console.WriteLine("\nThis is within a public method!");
    }

    //Accessible within the class.
    private void PrivateMethod()
    {
        Console.WriteLine("\nThis is within a private method!");
    }

    //Accessible within the class and derived class.
    protected void ProtectedMethod()
    {
        Console.WriteLine("\nThis is within a protected method!");
    }

    //Accessible within the same assembly file / package.
    internal void InternalMethod()
    {
        Console.WriteLine("\nThis is within a internal method!");
    }

    //Accessible within the same assembly file and derived assembly file (protected access).
    protected internal void ProtectedInternalMethod()
    {
        Console.WriteLine("\nThis is within a protected internal method!");
    }
}

class Test
{
    public static void Main()
    {
        UsingAccessSpecifiers u = new UsingAccessSpecifiers();

        u.PublicMethod();
        u.InternalMethod();
        u.ProtectedInternalMethod();
        //u.PrivateMethod(); - can not access.
        //u.ProtectedMethod(); - can not access.
    }
}
