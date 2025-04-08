# 🚀 SpaceFuelCalculator

**To The Moon :)** is a console application written in C# that calculates the amount of fuel required for launching and landing a spaceship between planets in the Solar System (Earth, Moon, Mars). The program takes into account the equipment mass, gravitational force of each planet, and additional fuel needed to carry the fuel itself.

---

## 📐 Fuel Calculation Algorithm

Fuel formulas depend on the operation:

- **Launch:**  
  `fuel = mass * gravity * 0.042 - 33` (rounded down)

- **Land:**  
  `fuel = mass * gravity * 0.033 - 42` (rounded down)

⚠️ Because fuel has mass too, the program recursively calculates additional fuel until it becomes zero or negative. Each step of the route is calculated in reverse order to ensure that the total mass includes all upcoming fuel needs.

**Important:** Fuel must be calculated for each operation using the total mass at that point — this includes both the initial ship mass and all fuel required for the remaining steps.

🔺 **Note:** The calculated fuel is an approximate value due to the recursive rounding and simplification in the formula.

---

## 🌍 Supported Planets and Gravity

| Planet | Gravity (m/s²) |
|--------|----------------|
| Earth  | 9.807          |
| Moon   | 1.62           |
| Mars   | 3.711          |

---

## 🧑‍💻 How to Use

1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/SpaceFuelCalculator.git
   cd SpaceFuelCalculator
   ```

2. Build and run using Visual Studio or .NET CLI:
   ```bash
   dotnet build
   dotnet run
   ```

3. Follow console instructions:
   - Enter ship mass (kg)
   - Enter number of route steps
   - For each step, specify:
     - Planet: `0 - Earth`, `1 - Moon`, `2 - Mars`
     - Operation: `0 - Launch`, `1 - Land`

---

## 🧪 Example

**Input:**
```
Enter the ship's mass:
28801
Enter the number of route steps:
4
Choose the object (0 - Earth, 1 - Moon, 2 - Mars):
0
Choose the operation (0 - Launch, 1 - Land):
0
...
```

**Output:**
```
Operation: Launch, Fuel required for this step: 51618
Total fuel: 51618, Total ship mass with fuel: 80419
...
Route completed.
```

---

## 📂 Project Structure

```
├── Program.cs              // Entry point and user interaction
├── SolutionFuelShip.cs     // Route and fuel calculation logic
├── Ship.cs                 // Ship class with recursive fuel logic
├── Destination.cs          // Route steps definition
├── Enums.cs                // Enum definitions for planets and operations
├── Gravitys.cs             // Planet gravity values
```

---

## ✅ Test Routes

> All tests take fuel mass into account when calculating the required amount. Values are approximate due to recursive fuel logic.

| Route                                                  | Equipment Mass | Total Fuel   | Total Mass |
|--------------------------------------------------------|----------------|--------|-------------|
| Launch Earth → Land Moon → Launch Moon → Land Earth    | 28801 kg       | 51618  | 80699 kg    |
| Launch Earth → Land Mars → Launch Mars → Land Earth    | 14606 kg       | 19533  | 47994 kg    |
| Launch Earth → Land Moon → Launch Moon → Land Mars → Launch Mars → Land Earth | 75432 kg | 118155 | 287593 kg  |

---

## 📜 License

MIT License. Feel free to use it for learning and personal projects 🚀

---

