using System;
namespace Hybirdinheritance{
    class Vehicle{
        public string Brand { get; set; }
        public int Speed { get; set; }
        public Vehicle(string brand, int speed){
            this.Brand = brand;
            this.Speed = speed;
        }
        public void PrintInfo(){
            Console.WriteLine($"Brand: {Brand}, Speed: {Speed} km/h");
        }
    }
    class Car: Vehicle{
        public string fuelType { get; set; }
        public Car(string brand, int speed,string fuelType): base(brand, speed){
            this.fuelType = fuelType;
        }
        
    }
    interface Electriccar{
        int BatteryCapacity { get; set; }
        void DisplayElectricarinfo();
    }
    class IElectriccar:Car, Electriccar{
        public int BatteryCapacity { get; set; }
        public IElectriccar(string brand, int speed, string fuelType, int batteryCapacity): base(brand, speed,"Electric"){
            this.BatteryCapacity = batteryCapacity;
        }
        public void DisplayElectricarinfo(){
            Console.WriteLine($"Brand: {Brand}, Speed: {Speed} km/h, Fuel Type: {fuelType}, Battery Capacity: {BatteryCapacity} kWh");
        }
        
    }
}