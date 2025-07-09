# Library Management System (C# OOP & LINQ Demo)

This project demonstrates fundamental concepts of Object-Oriented Programming (OOP) in C#, including abstraction, inheritance, polymorphism, interfaces, and working with collections using LINQ.

## Project Structure

The solution is organized into the following main parts:

-   *Models*: Contains the core data structures for library items.
    -   `Item.cs`: An abstract base class defining common properties (Id, Title, Year) and an abstract method `DisplayInfo()`.
    -   `Book.cs`: A concrete class inheriting from `Item`, adding `Author` and `ISBN`. It also implements `ICheckable` and `IReservable` interfaces.
    -   `Magazine.cs`: A concrete class inheriting from `Item`, adding `IssueNumber`. It also implements `ICheckable` and `IReservable` interfaces.

-   *Interfaces*: Defines contracts for item behavior.
    -   `ICheckable.cs`: Interface for items that can be checked out and returned, with a property `IsCheckedOut`.
    -   `IReservable.cs`: Interface for items that can be reserved, with a property `IsReserved`.

-   *Services*: Contains business logic for managing the library.
    -   `Library.cs`: Manages a collection of `Item` objects, providing methods for adding, removing, searching, filtering, and grouping items using LINQ.

-   *Program.cs*: The entry point of the application, demonstrating the usage of all classes and interfaces.

## Features

1.  *Basic Classes & OOP*:
    *   Abstract `Item` class.
    *   `Book` and `Magazine` classes inheriting from `Item` and overriding `DisplayInfo()`.

2.  *Interfaces & Polymorphism*:
    *   `ICheckable` and `IReservable` interfaces.
    *   `Book` and `Magazine` implement these interfaces, demonstrating polymorphic behavior (e.g., treating a `Book` as an `ICheckable`).
    *   State management for `IsCheckedOut` and `IsReserved` with basic validation (e.g., cannot check out if reserved).

3.  *Collections & LINQ*:
    *   `Library` class using `List<Item>` to store library items.
    *   Methods for `AddItem()`, `RemoveItem()`.
    *   `SearchByTitle(string keyword)`: Uses LINQ's `Where()` and `Contains()` for case-insensitive search.
    *   `GetItemsByYear(int year)`: Uses LINQ's `Where()` for filtering.
    *   `GroupItemsByYear()`: Uses LINQ's `GroupBy()` for grouping items.

## How to Run

1.  *Clone the repository:*
bash
    git clone https://github.com/YourUsername/LibraryManagementSystem.git
    cd LibraryManagementSystem

2.  *Open in Visual Studio:* Open the `LibraryManagementSystem.sln` file.

3.  *Build and Run:* Press `F5` or click "Start" to run the console application.

Alternatively, using .NET CLI:

1.  *Navigate to the project directory:*
bash
cd LibraryManagementSystem/LibraryManagementSystem

2.  *Run the application:*
bash
dotnet run


## Contributing

Feel free to fork the repository, open issues, or submit pull requests. Comments and suggestions for improvement are welcome!



