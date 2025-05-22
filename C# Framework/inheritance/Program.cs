using System;
namespace HybridInheritance{
    class Vechile{
        public string Brand{get; set;}
        public int speed{get; set;}
        
        public Vechile(string brand, int speed)
        {
            this.Brand = brand;
            this.speed = speed;
    }
    public void Show(){
        Console.WriteLine("Brand: {0} Speed: {1}", this.Brand, this.speed);
        
    }


    }


    class Car : Vechile{
        public string fueltype{get; set;}
        public Car(string brand, int speed,string fueltype) : base(brand, speed){
            this.fueltype = fueltype;
        }
        public void CarShow(){
            Console.WriteLine("Brand: {0} Speed: {1} Fueltype: {2}", this.Brand, this.speed, this.fueltype);

        }
        }

        interface IElectriccar{
            int batterycapacity{get; set;}

            void Showbatterycapacity();
        }

    class Electriccar : Car, IElectriccar
    {
        public int batterycapacity { get; set ; }
        public Electriccar(string brand,int speed,int batterycapacity): base(brand,speed,"Electric"){
            this.batterycapacity = batterycapacity;
        }

        public void Showbatterycapacity()
        {
            Console.WriteLine("Brand: {0} Speed: {1} Batterycapacity: {2}", this.Brand, this.speed, this.batterycapacity);
        }

        public void DisplayFullinfo(){
            Show();
            CarShow();
            Showbatterycapacity();
        }


    }

    }
    class Program
    {
        static void Main(string[] args)
        {
          
            HybridInheritance.Electriccar car = new HybridInheritance.Electriccar("Tesla", 200, 100);
            car.DisplayFullinfo();
        }
    }