using System;
namespace Наследование
{
    class Transport
    {
        public double Velocity;
        public double KilometerPrice;
        public int Capacity;

        public Transport()
        {

        }
    }

    class CombustionEngineTransport : Transport
    {
        public double EngineVolume;
        public double EnginePower;
    }

    enum ControlType
    {
        Forward,
        Backward
    }

    class Car : CombustionEngineTransport
    {
        public ControlType Control;
    }


    class Program1
    {
        static void MainX(string[] args)
        {
            Car car = new Car();

            Transport carAsTransport = (Transport)car;

            Car car1 = (Car)carAsTransport;



            //var cet = new CombustionEngineTransport();

            var cet = (CombustionEngineTransport)(new Car());

            if (cet is Car)
            {
                var cetAsCar = (Car)cet;
                Console.WriteLine(true);
            }
            else
            {
                Console.WriteLine(false);
            }




        }
    }



}
