namespace IImage
{
    interface IPict
    {
        void deleteImage();
        void showImage();
    }

    interface IPictManPic
    {
        void applyAlpha();
        public void showImage();
    }

    class MyImage : IPict, IPictManPic
    {
        public void deleteImage()
        {
            Console.WriteLine("Image deleted.");
        }
        void IPict.showImage()
        {
            Console.WriteLine("Image shown.");
        }
        public void applyAlpha()
        {
            Console.WriteLine("Alpha applied.");
        }
        void IPictManPic.showImage()
        {
            Console.WriteLine("Image shown in another way.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyImage myImage = new MyImage();
            myImage.deleteImage();
            myImage.applyAlpha();
            ((IPict)myImage).showImage();
            ((IPictManPic)myImage).showImage();

        }
    }
}