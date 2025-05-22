class Baseio{
    public virtual void baseio(){
        Console.WriteLine("Baseio");
    }
}

interface Ipict{
    void deleteimage();
    void displayimage();
}

interface Ipictmanpic{
    void applyalpha();
    void displayimage();
}

class Myimage : Baseio, Ipict, Ipictmanpic{
    public override void baseio(){
        Console.WriteLine("Myimage");
    }

    public void deleteimage(){
        Console.WriteLine("Image deleted");
    }

    void Ipict.displayimage(){
        Console.WriteLine("Image displayed (Ipict)");
    }

    void Ipictmanpic.displayimage(){
        Console.WriteLine("Image displayed (Ipictmanpic)");
    }

    public void applyalpha(){
        Console.WriteLine("Alpha applied");
    }
}
class Program{
    static void Main(string[] args){
        Myimage myimage = new Myimage();
        myimage.baseio();
        myimage.deleteimage();
        ((Ipict)myimage).displayimage();
        myimage.applyalpha();
    }
}