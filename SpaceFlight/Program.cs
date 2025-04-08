//// See https://aka.ms/new-console-template for more information

//public enum OperationTypeEnum
//{
//    Launch,
//    Land
//}
//public enum TargetSpaceObjectEnum
//{
//    Earth,
//    Moon,
//    Mars
//}
//public class DestinationModel
//{
//    public OperationTypeEnum OperationType { get; set; }
//    public TargetSpaceObjectEnum TargetSpaceObject { get; set; }
//}
//public class SolutionFuelShip
//{
//    private const decimal Earth = (decimal)9.807;
//    private const decimal Moon = (decimal)1.62;
//    private const decimal Mars = (decimal)3.711;


//    private static readonly Dictionary<TargetSpaceObjectEnum, decimal> Gravity = new()
//        {
//            { TargetSpaceObjectEnum.Earth, Earth },
//            { TargetSpaceObjectEnum.Moon, Moon },
//            { TargetSpaceObjectEnum.Mars, Mars }
//        };
//    private static int CalculateFuel(decimal mass, decimal gravity, decimal coefficient, int baseFuel)
//    {
//        int totalFuel = 0;
//        decimal fuel = (int)Math.Floor(mass * gravity * coefficient) - baseFuel;

//        while (fuel > 0)
//        {
//            totalFuel += (int)fuel;
//            fuel = Math.Floor(fuel * gravity * coefficient) - baseFuel;
//        }

//        return totalFuel;
//    }
//    public static int ProcessLaunchAndLand(decimal mass, List<DestinationModel> destinations)
//    {
//        decimal totalMass = mass;
//        int totalFuel = 0;

//        destinations.Reverse();

//        foreach (DestinationModel destStep in destinations)
//        {
//            if (!Gravity.ContainsKey(destStep.TargetSpaceObject))
//            {
//                throw new ArgumentException($"Unknown space object: {destStep.TargetSpaceObject}");
//            }
//            decimal gravity = Gravity[destStep.TargetSpaceObject];
//            bool isLaunch = destStep.OperationType == OperationTypeEnum.Launch;
//            // Total Fuel Launch : Land 
//            int fuelCheckNeeded = isLaunch ? CalculateFuel(totalMass, gravity, (decimal)0.042, 33) : CalculateFuel(totalMass, gravity, (decimal)0.033, 42);

//            totalFuel += fuelCheckNeeded;
//            totalMass += fuelCheckNeeded;
//        }
//        return (int)totalFuel;
//    }

//}
//class Program
//{
//    static void Main()
//    {
//        decimal shipMass = decimal.Parse(Console.ReadLine());

//        var flightPath = new List<DestinationModel>
//        {
//            new DestinationModel { OperationType = OperationTypeEnum.Launch, TargetSpaceObject = TargetSpaceObjectEnum.Earth },
//            new DestinationModel { OperationType = OperationTypeEnum.Land, TargetSpaceObject = TargetSpaceObjectEnum.Moon },
//            new DestinationModel { OperationType = OperationTypeEnum.Launch, TargetSpaceObject = TargetSpaceObjectEnum.Moon },
//            new DestinationModel { OperationType = OperationTypeEnum.Land, TargetSpaceObject = TargetSpaceObjectEnum.Earth },

//        };

//        int totalFuel = SolutionFuelShip.ProcessLaunchAndLand(shipMass, flightPath);
//        Console.WriteLine($"Total fuel ship required: {totalFuel} kg");
//    }

//}
//class Result
//{

//    public static void miniMaxSum(List<int> arr)
//    {
//        arr.Sort();
//        long  minSum = 0;
//        long  maxSum = 0;

//        for (int i = 0; i < arr.Count - 1; i++)
//        {
//            minSum += arr[i];
//            maxSum += arr[i + 1];
//        }
//        Console.WriteLine($"{minSum} {maxSum}");
//    }
//}


//class Solution
//{
//    public static void Main(string[] args)
//    {

//        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

//        Result.miniMaxSum(arr);
//    }
//}
//class Result
//{

/*
 * Complete the 'birthdayCakeCandles' function below.
 *
 * The function is expected to return an INTEGER.
 * The function accepts INTEGER_ARRAY candles as parameter.
 */

//    public static int birthdayCakeCandles(List<int> candles)
//    {
//        candles.Sort();
//        int max = candles.Max();
//        return candles.Count(c => c > max); 

//    }

//}

//class Solution
//{
//    public static void Main(string[] args)
//    {
//        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

//        int candlesCount = Convert.ToInt32(Console.ReadLine().Trim());

//        List<int> candles = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(candlesTemp => Convert.ToInt32(candlesTemp)).ToList();

//        int result = Result.birthdayCakeCandles(candles);

//        textWriter.WriteLine(result);

//        textWriter.Flush();
//        textWriter.Close();
//    }
//}
//using System;
//using System.Collections.Generic;

//class Program
//{
//    public static List<int> GradingStudents(List<int> grades)
//    {
//        List<int> gradesPlus = new List<int>();
//        foreach (int grad in grades)
//        {
//            if (grad >= 38 && grad % 5 >= 3)
//            {
//                gradesPlus.Add(grad + 5 - (grad % 5));
//            }
//            else
//            {
//                gradesPlus.Add(grad);
//            }
//        }
//        return gradesPlus;
//    }

//    static void Main(string[] args)
//    {
//        Console.WriteLine("Введите количество оценок:");
//        int n = int.Parse(Console.ReadLine());

//        List<int> grades = new List<int>();
//        Console.WriteLine("Введите оценки:");
//        for (int i = 0; i < n; i++)
//        {
//            grades.Add(int.Parse(Console.ReadLine()));
//        }

//        List<int> result = GradingStudents(grades);

//        Console.WriteLine("Округленные оценки:");
//        foreach (int grade in result)
//        {
//            Console.WriteLine(grade);
//        }
//    }
//}
//public class Solution
//{
//    private static readonly Dictionary<TargetSpaceObject, double> Gravity = new()
//    {
//        { TargetSpaceObject.Earth, 9.807 },
//        { TargetSpaceObject.Moon, 1.62 },
//        { TargetSpaceObject.Mars, 3.711 }
//    };

//    public static int Process(double mass, List<Destination> stations)
//    {
//        int totalFuel = 0;
//        double currentMass = mass;
//        stations.Reverse();
//        foreach (var station in stations)
//        {
//            double gravity = Gravity[station.TargetSpaceObject];
//            double fuel = station.OperationType switch
//            {
//                OperationType.Launch => CalculateFuel(currentMass, gravity, 0.042, -33),
//                OperationType.Land => CalculateFuel(currentMass, gravity, 0.033, -42),
//                _ => throw new InvalidOperationException("Unknown operation type")
//            };

//            totalFuel += (int)fuel;
//            currentMass += fuel; // Include fuel weight in the current mass for subsequent steps
//        }

//        return totalFuel;
//    }

//    private static double CalculateFuel(double mass, double gravity, double multiplier, int offset)
//    {
//        double totalFuel = 0;
//        double fuel = Math.Floor(mass * gravity * multiplier + offset);

//        while (fuel > 0)
//        {
//            totalFuel += fuel;
//            fuel = Math.Floor(fuel * gravity * multiplier + offset);
//        }

//        return totalFuel;
//    }
//}

//public enum TargetSpaceObject
//{
//    Earth,
//    Moon,
//    Mars
//}

//public enum OperationType
//{
//    Launch,
//    Land
//}

//public class Destination
//{
//    public OperationType OperationType { get; set; }
//    public TargetSpaceObject TargetSpaceObject { get; set; }
//}

//// Example usage
//public class Program
//{
//    public static void Main()
//    {
//        var stations = new List<Destination>
//        {
//            new Destination { OperationType = OperationType.Launch, TargetSpaceObject = TargetSpaceObject.Earth },
//            new Destination { OperationType = OperationType.Land, TargetSpaceObject = TargetSpaceObject.Moon },
//            new Destination { OperationType = OperationType.Launch, TargetSpaceObject = TargetSpaceObject.Moon },
//            new Destination { OperationType = OperationType.Land, TargetSpaceObject = TargetSpaceObject.Earth }
//        };

//        int result = Solution.Process(28801, stations);
//        Console.WriteLine($"Total fuel required: {result}");
//    }
//}

//public class Solution
//{
//    public static int Process(Ship ship, List<Destination> stations)
//    {
//        int totalFuel = 0;

//        foreach (var station in stations)
//        {
//            var planet = PlanetFactory.GetPlanet(station.TargetSpaceObject);
//            totalFuel += ship.CalculateFuel(station.OperationType, planet);
//        }

//        return totalFuel;
//    }
//}

//// Represents a Planet with its gravity
//public class Planet
//{
//    public string Name { get; }
//    public double Gravity { get; }

//    public Planet(string name, double gravity)
//    {
//        Name = name;
//        Gravity = gravity;
//    }
//}

//// Factory class to create Planet objects based on TargetSpaceObject
//public static class PlanetFactory
//{
//    public static Planet GetPlanet(TargetSpaceObject targetSpaceObject)
//    {
//        return targetSpaceObject switch
//        {
//            TargetSpaceObject.Earth => new Planet("Earth", 9.807),
//            TargetSpaceObject.Moon => new Planet("Moon", 1.62),
//            TargetSpaceObject.Mars => new Planet("Mars", 3.711),
//            _ => throw new ArgumentException("Unknown planet")
//        };
//    }
//}

//// Represents a spaceship and its fuel calculation logic
//public class Ship
//{
//    private double _mass;

//    public Ship(double mass)
//    {
//        _mass = mass;
//    }

//    public int CalculateFuel(OperationType operationType, Planet planet)
//    {
//        double totalFuel = 0;
//        double fuel = operationType == OperationType.Launch
//            ? Math.Floor(_mass * planet.Gravity * 0.042 - 33)
//            : Math.Floor(_mass * planet.Gravity * 0.033 - 42);

//        while (fuel > 0)
//        {
//            totalFuel += fuel;
//            _mass += fuel; // Add the calculated fuel to the ship's mass
//            fuel = operationType == OperationType.Launch
//                ? Math.Floor(fuel * planet.Gravity * 0.042 - 33)
//                : Math.Floor(fuel * planet.Gravity * 0.033 - 42);
//        }

//        return (int)totalFuel;
//    }
//}

//// Enums for target space objects and operation types
//public enum TargetSpaceObject
//{
//    Earth,
//    Moon,
//    Mars
//}

//public enum OperationType
//{
//    Launch,
//    Land
//}

//// Represents a destination with operation type and target space object
//public class Destination
//{
//    public OperationType OperationType { get; set; }
//    public TargetSpaceObject TargetSpaceObject { get; set; }
//}