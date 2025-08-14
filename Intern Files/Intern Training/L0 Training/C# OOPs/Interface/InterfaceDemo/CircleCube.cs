class CircleCube : IArea, IVolume
{
    public void CalcAr(double radius){
        double pi = 3.14;
        double result = radius * radius * pi;
        Console.WriteLine("\nThe area of the circle: "+ result);
    }

    public void CalcVol (int side){
        int result = side * side * side;
        Console.WriteLine("\nThe volume is: "+ result);

    }
}