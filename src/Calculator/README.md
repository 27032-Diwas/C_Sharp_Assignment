# Understanding the .NET Platform

A C# console application that explores the fundamentals of the .NET platform through exploration and a practical implementation using a simple calculator application.

---

## Overview

This assignment consists of:

- Exploration questions covering core .NET concepts.
- A practical exercise using a `MathUtils` class.

---

## Exploration Topics

The following .NET concepts were researched and documented:

1. .NET Platform and its purpose
2. Key components of .NET
3. CLR and CTS
4. Global Assembly Cache (GAC)
5. Value Types and Reference Types
6. Garbage Collection
7. Globalization and Localization
8. CIL and JIT Compilation

---

## Practical Exercise

Implemented a `MathUtils` class containing methods to:

- Add two integers
- Subtract two integers
- Multiply two integers
- Divide two integers

The application:

- Accepts two integer inputs from the user.
- Performs arithmetic operations.
- Displays the results.

---

## Features

### MathUtils

- Add
- Subtract
- Multiply
- Divide

### Input Validation

- Ensures only valid integer values are accepted.
- Prevents invalid user input from causing runtime errors.

### User Interaction

- Supports multiple calculations in a single execution.
- Handles division-by-zero scenarios gracefully.

---

## Project Structure

```text
Calculator
├── Constants
│   ├── ErrorMessages.cs
│   ├── SuccessMessages.cs
│   └── UserPrompts.cs
├── Docs
│   ├── Assets
│   ├── Answers.md
│   └── README.md
├── Enums
│   └── MainMenu.cs
├── CalculatorController.cs
├── CalculatorView.cs
├── MathUtils.cs
├── Program.cs
└── .editorconfig
```

---

## Approach

- Explored and written the theoretical concepts related to the .NET platform.
- Implemented the calculator functionality using a separate utility class.

---

## Screenshots

### Calculator Output

![Main Menu](Docs/Assets/MainMenu.png)

![Addition](Docs/Assets/Addition.png)

![Subtraction](Docs/Assets/Subtraction.png)

![Multiplication](Docs/Assets/Multplication.png)

![Division](Docs/Assets/Division.png)
### Division by Zero Handling

![Divide By Zero](Docs/Assets/DivideByZero.png)

---

## Prerequisites

- .NET 6 SDK or later
- Visual Studio 2022 or later

---

## Author

**Diwas Thangarasu**