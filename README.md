# Diamond Kata

The Diamond Kata is a .NET 6 console application designed to generate a diamond shape based on a given character from the alphabet. The application takes a character as input and prints a diamond with that character being the midpoint of the diamond.

## Key Components

- **`CharExtension`:** This extension class provides methods to get the index of a character in the alphabet and to get a character by its index.
- **`Diamond`:** This class encapsulates the logic for creating the diamond shape and converting it to a string representation.

## Solid Principles and Patterns

- **Single Responsibility Principle (SRP):** Each class has a single responsibility. For example, `CharExtension` is responsible for character-related operations, and `Diamond` is responsible for generating the diamond shape.
- **Open/Closed Principle (OCP):** The design is extensible without modifying existing code. For instance, new methods can be added to `CharExtension` without changing its existing methods.
- **Liskov Substitution Principle (LSP):** Subtypes can be substituted for their base types without affecting the correctness of the program. This is evident in the use of extension methods, which can be applied to any character or integer.
- **Interface Segregation Principle (ISP):** Clients should not be forced to depend on interfaces they do not use. This is why we have separate methods for different functionalities in `CharExtension`.
- **Dependency Inversion Principle (DIP):** High-level modules depend on abstractions, not on low-level modules. This is demonstrated by the use of extension methods, which abstract the operations on characters and integers.

## Test-Driven Development (TDD)

The application is developed using TDD principles. Unit tests are written for each method to ensure correctness and to facilitate future changes without breaking existing functionality.

## Solution Structure

- **Application: DiamondKata**
    - *Extensions*
        - `CharExtension.cs`
    - *DomainModels*
        - `Diamond.cs`

- **Unit tests project: DiamondKata.Tests**
    - *ExtensionsTests*
        - `CharExtensionTests.cs`
    - *DomainModelsTests*
        - `DiamondTests.cs`

## Getting Started

### Prerequisites
Make sure you have the [.NET SDK](https://dotnet.microsoft.com/download) version 6 or higher installed on your machine.

### Build and Run
- Run command:  `dotnet run --project DiamondKata`
- Test command: `dotnet test DiamondKata.Tests`
- Build command: `dotnet build`
