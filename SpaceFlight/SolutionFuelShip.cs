using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFlight
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the ship's mass:");
            double mass = double.Parse(Console.ReadLine());

            var destinations = new List<Destination>();
            Console.WriteLine("Enter the number of route steps:");
            int steps = int.Parse(Console.ReadLine());

            for (int i = 0; i < steps; i++)
            {
                Console.WriteLine("Choose the object (0 - Earth, 1 - Moon, 2 - Mars):");
                TargetSpaceObject target = (TargetSpaceObject)int.Parse(Console.ReadLine());

                Console.WriteLine("Choose the operation (0 - Launch, 1 - Land):");
                OperationType operation = (OperationType)int.Parse(Console.ReadLine());

                destinations.Add(new Destination
                {
                    TargetSpaceObject = target,
                    OperationType = operation
                });
            }

            SolutionFuelShip.ProcessLaunchAndLand(mass, destinations);
            Console.WriteLine("Маршрут завершен.");
        }
    }
    public class SolutionFuelShip
    {
        public static void ProcessLaunchAndLand(double mass, List<Destination> destinations)
        {
            var ship = new Ship(mass);
            destinations.Reverse();
            foreach (Destination destStep in destinations)
            {
                double gravity = Gravitys.Gravity[destStep.TargetSpaceObject];
                Console.WriteLine($"Object: {destStep.TargetSpaceObject}, Operation: {destStep.OperationType}");
                switch (destStep.OperationType)
                {
                    case OperationType.Launch:
                        ship.CulculateFuelShip(OperationType.Launch, gravity);
                        break;
                    case OperationType.Land:
                        ship.CulculateFuelShip(OperationType.Land, gravity);
                        break;
                }
            }
        }

    }
    public class Ship
    {

        private double _shipMass { get; set; }
        public Ship(double shipMass) => _shipMass = shipMass;

        public double LaunchShip(double gravity, double mass)
        {
            double total = Math.Floor(mass * gravity * 0.042) - 33;
            Console.WriteLine($"Logs launch ship: {total} {mass} {gravity}");
            return total;
        }

        public double LandShip(double gravity, double mass)
        {
            double total = Math.Floor(mass * gravity * 0.033) - 42;
            Console.WriteLine($"Logs landing ship: {total} {mass} {gravity}");
            return total;
        }
        public void CulculateFuelShip(OperationType operationType, double gravity)
        {
            int totalShipMass = (int)_shipMass;
            double totalFuel = CalculateFuel(totalShipMass, gravity, operationType);
            Console.WriteLine($"Operation: {operationType}, Fuel required for this step: {totalFuel}");
            totalShipMass += (int)totalFuel;
            Console.WriteLine($"Total fuel: {totalFuel}, Total ship mass with fuel: {totalShipMass}");
            _shipMass = totalShipMass;
        }
        private int CalculateFuel(double mass, double gravity, OperationType operationType)
        {
            double massFuel = operationType switch
            {
                OperationType.Launch => LaunchShip(gravity, mass),
                OperationType.Land => LandShip(gravity, mass),
                _ => 0
            };
            Console.WriteLine($"Mass: {mass}, Gravity: {gravity}, Operation: {operationType}, Calculated fuel: {massFuel}");
            if (massFuel > 0)
            {
                return (int)massFuel + CalculateFuel(massFuel, gravity, operationType);
            }


            return 0;

        }
    }
}

public static class Gravitys
{
    static readonly double Earth = 9.807;
    static readonly double Moon = 1.62;
    static readonly double Mars = 3.711;
    public static readonly Dictionary<TargetSpaceObject, double> Gravity = new()
    {
        { TargetSpaceObject.Earth, Earth },
        { TargetSpaceObject.Moon, Moon },
        { TargetSpaceObject.Mars, Mars }
    };
}


public class Destination
{
    public OperationType OperationType { get; set; }
    public TargetSpaceObject TargetSpaceObject { get; set; }
}
public enum TargetSpaceObject
{
    Earth,
    Moon,
    Mars
}
public enum OperationType
{
    Launch,
    Land
}