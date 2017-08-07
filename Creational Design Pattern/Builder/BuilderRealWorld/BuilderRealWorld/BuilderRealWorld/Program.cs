using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderRealWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            VehicleBuilder builder;

            Shop shop = new Shop();
            builder = new ScooterBuilder();
            shop.Construct(builder);
            builder.Vehicle.Show();

            Console.WriteLine("\n");
            builder = new CarBuilder();
            shop.Construct(builder);
            builder.Vehicle.Show();

            Console.WriteLine("\n");
            builder = new MotorcycleBuilder();
            shop.Construct(builder);
            builder.Vehicle.Show();

            //Wait for user key
            Console.ReadKey();

        }
    }

    class Shop
    {
        public void Construct(VehicleBuilder vehicleBuilder)
        {
            vehicleBuilder.BuildFrames();
            vehicleBuilder.BuildEngine();
            vehicleBuilder.BuildWheels();
            vehicleBuilder.BuildDoors();
        }
    }

    abstract class VehicleBuilder
    {
        protected Vehicle vehecle;

        public Vehicle Vehicle
        {
            get { return vehecle;  }
        }
 
        public abstract void BuildDoors();
        public abstract void BuildEngine();
        public abstract void BuildFrames();
        public abstract void BuildWheels();
    }

    /// <summary>
    /// The 'MotorcycleBuilder' class
    /// </summary>
    class MotorcycleBuilder : VehicleBuilder
    {
        public MotorcycleBuilder()
        {
            vehecle = new Vehicle("Motorcycle");
        } 

        public override void BuildDoors()
        {
            vehecle["doors"] = "0";
        }

        public override void BuildEngine()
        {
            vehecle["engine"] = "500cc";
        }

        public override void BuildFrames()
        {
            vehecle["frame"] = "2";
        }

        public override void BuildWheels()
        {
            vehecle["wheels"] = "2";
        }
    }

    /// <summary>
    /// The 'CarBuilder' class
    /// </summary>
    class CarBuilder : VehicleBuilder
    {
        public CarBuilder()
        {
            vehecle = new Vehicle("Car");
        }

        public override void BuildDoors()
        {
            vehecle["doors"] = "4";
        }

        public override void BuildEngine()
        {
            vehecle["engine"] = "2500cc";
        }

        public override void BuildFrames()
        {
            vehecle["frame"] = "car frame";
        }

        public override void BuildWheels()
        {
            vehecle["wheels"] = "4";
        }
    }
    /// <summary>
    /// The 'ScooterBuilder' class
    /// </summary>
    class ScooterBuilder : VehicleBuilder
    {
        public ScooterBuilder()
        {
            vehecle = new Vehicle("Scooter");
        }

        public override void BuildDoors()
        {
            vehecle["doors"] = "0";
        }

        public override void BuildEngine()
        {
            vehecle["engine"] = "50cc";
        }

        public override void BuildFrames()
        {
            vehecle["frame"] = "Scooter frame";
        }

        public override void BuildWheels()
        {
            vehecle["wheels"] = "2";
        }
    }

    class Vehicle
    {
        public string _vehicleType;
        private Dictionary<string, string> _parts = new Dictionary<string, string>();

        //Constructor
        public Vehicle(string vehicleType)
        {
            _vehicleType = vehicleType;
        }

        //Indexer
        public string this[string key]
        {
            get { return _parts[key]; }
            set { _parts[key] = value; }
        }

        public void Show()
        {
            Console.WriteLine("\n---------------------------");
            Console.WriteLine("Vihecle type : {0}", _vehicleType);
            Console.WriteLine(" Frame : {0}", _parts["frame"]);
            Console.WriteLine(" Engine : {0}", _parts["engine"]);
            Console.WriteLine(" Wheels : {0}", _parts["wheels"]);
            Console.WriteLine(" Doors : {0}", _parts["doors"]);
        }


    }
}
