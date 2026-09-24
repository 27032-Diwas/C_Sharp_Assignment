# Advanced C# Concepts

## Introduction

This assignment demonstrates several advanced C# concepts including:

- Events and Delegates
- `var` and `dynamic`
- Anonymous Methods
- Lambda Expressions and LINQ
- Custom Delegates for Sorting
- Records
- Pattern Matching

The project contains practical examples that showcase how these features are used in modern C# development.

---

# Task 1: Events and Delegates

## Objective

Understand how delegates and events work together to provide a notification mechanism between objects.

## Concepts Covered

### Delegate

A delegate is a type that represents references to methods with a specific parameter list and return type.

In this project:

```csharp
public delegate void Notify(object sender, string message);
```

The delegate can reference any method that accepts:

- `object sender`
- `string message`

and returns `void`.

### Event

Events provide a safe way for a class to notify subscribers when something happens.

```csharp
public event Notify? OnAction;
```

Only the owning class can raise the event, while other classes can subscribe or unsubscribe.

### Event Subscription

```csharp
this._notifier.OnAction += this.Display;
```

### Event Unsubscription

```csharp
this._notifier.OnAction -= this.Display;
```

### Event Invocation

```csharp
this.OnAction?.Invoke(this, message);
```

The null conditional operator prevents exceptions when no subscribers exist.

## Output

![Event](Docs/Assets/Task1.png)

## Learning Outcomes

- Created and used custom delegates.
- Implemented events using delegates.
- Subscribed and unsubscribed event handlers.
- Raised events safely using null propagation.

---

# Task 2: Understanding var and dynamic

## Objective

Learn the differences between compile-time typing and runtime typing.

---

## var

The `var` keyword allows the compiler to infer the type during compilation.

```csharp
var variable1 = 2;
```

Compiler interprets this as:

```csharp
int variable1 = 2;
```

After initialization, the type cannot change.

### Invalid Example

```csharp
var value = 10;
value = "Hello";
```

Compilation error:

```text
Cannot implicitly convert type 'string' to 'int'
```

---

## dynamic

The `dynamic` keyword postpones type checking until runtime.

```csharp
dynamic variable2 = 3;
```

Later:

```csharp
variable2 = "Hello";
```

This is allowed because the runtime determines the actual type.

---

## Output

![Event](Docs/Assets/Task2.png)

---

## Key Differences

| Feature | var | dynamic |
|----------|------|----------|
| Type Resolution | Compile Time | Runtime |
| Type Change Allowed | No | Yes |
| IntelliSense Support | Yes | Limited |
| Performance | Faster | Slight overhead |
| Compile-Time Safety | Yes | No |

---

## Learning Outcomes

- Understood type inference.
- Learned runtime type resolution.
- Compared strongly typed and dynamically typed variables.
- Identified advantages and limitations of `dynamic`.

---

# Task 3: Anonymous Methods

## Objective

Use anonymous methods to perform sorting without creating a separate comparison method.

## Anonymous Method

An anonymous method is a method without a name.

```csharp
delegate(int number1, int number2)
{
    if (number1 > number2)
    {
        return 1;
    }
    else if (number1 < number2)
    {
        return -1;
    }

    return 0;
}
```

The method is passed directly to `Array.Sort()`.

---

## Sorting Process

Input Array:

```text
3 2 1 8 5 6 7
```

Sorted Array:

```text
1 2 3 5 6 7 8
```

---

## Output

![Event](Docs/Assets/Task3.png)

---

## Learning Outcomes

- Implemented anonymous methods.
- Passed methods as parameters.
- Sorted arrays using custom comparison logic.
- Reduced code by avoiding separate comparison methods.

---

# Task 4: Lambda Expressions and Statements

## Objective

Use LINQ with lambda expressions to filter and transform collections.

---

## Filtering Even Numbers

```csharp
numbers.Where(number => number % 2 == 0)
```

This expression returns only even numbers.

Result:

```text
2 4 6 8 10
```

---

## Squaring Numbers

```csharp
evenNumbers.Select(number => number * number)
```

Result:

```text
4 16 36 64 100
```

---

## Output

![Event](Docs/Assets/Task4.png)

---

## Lambda Expression

Single expression lambda:

```csharp
number => number % 2 == 0
```

---

## Lambda Statement

Lambda expressions can also contain blocks:

```csharp
number =>
{
    return number * number;
}
```

---

## Learning Outcomes

- Used LINQ extension methods.
- Filtered collections using `Where()`.
- Projected data using `Select()`.
- Applied lambda expressions and lambda statements.
- Improved code readability and maintainability.

---

# Task 5: Advanced Delegates for Sorting

## Objective

Use delegates to dynamically control sorting behavior.

---

## Product Class

Each product contains:

```csharp
Name
Category
Price
```

Example:

```csharp
new Product("Cake", "Food", 50)
```

---

## Custom Delegate

```csharp
public delegate int SortDelegate(Product product1, Product product2);
```

The delegate accepts:

- Product 1
- Product 2

Returns:

- Negative value
- Zero
- Positive value

similar to `IComparer<T>`.

---

## Sorting Methods

### Sort By Name

```csharp
SortByName()
```

Uses:

```csharp
string.Compare()
```

---

### Sort By Category

```csharp
SortByCategory()
```

Compares categories alphabetically.

---

### Sort By Price

```csharp
SortByPrice()
```

Uses:

```csharp
product1.Price.CompareTo(product2.Price);
```

---

## Generic Sorting Logic

```csharp
products.Sort(new Comparison<Product>(sortBy));
```

The appropriate comparison method is supplied through the delegate.

---

## Output

![Event](Docs/Assets/Task5.png)

---

## Learning Outcomes

- Created custom delegates.
- Passed delegates as method parameters.
- Dynamically changed sorting behavior.
- Reused sorting logic for multiple scenarios.
- Implemented flexible and maintainable code.

---

# Task 6: Records in C# 9.0

## Objective

Understand immutable reference types introduced in C# 9.

---

## Record Definition

A record is a reference type optimized for immutable data.

Example:

```csharp
public record Book(
    string title,
    string author,
    string isbn);
```

---

## Creating Records

```csharp
Book book1 = new (
    "The Pragmatic Programmer",
    "Andrew Hunt",
    "9780201616224");
```

---

## Value Equality

Unlike classes, records compare values instead of references.

```csharp
Book book1 = ...
Book book3 = ...
```

Comparison:

```csharp
book1 == book3
```

Result:

```text
True
```

---

## Immutability

Record properties are `init` only.

Invalid:

```csharp
book1.Title = "New Title";
```

Compilation Error:

```text
Init-only property can only be assigned during object initialization.
```

---

## Non-Destructive Mutation

The `with` expression creates a copy with modifications.

```csharp
Book updatedBook = book1 with
{
    title = "The Pragmatic Programmer - 20th Anniversary Edition",
    author = "Me"
};
```

Original record remains unchanged.

---

## Deconstruction

Records automatically provide deconstruction support.

```csharp
var (title, author, isbn) = book;
```

---

## Output

![Event](Docs/Assets/Task6.png)

---

## Benefits of Records

- Built-in value equality.
- Immutable by default.
- Concise syntax.
- Supports deconstruction.
- Supports non-destructive mutation.
- Ideal for DTOs and data models.

---

## Learning Outcomes

- Created records.
- Compared value equality.
- Demonstrated immutability.
- Used the `with` expression.
- Used deconstruction.

---

# Task 7: Advanced Pattern Matching

## Objective

Use pattern matching to identify object types and perform specific operations.

---

## Shape Hierarchy

### Base Class

```csharp
Shape
```

### Derived Classes

```csharp
Circle
Rectangle
Triangle
```

Each shape implements:

```csharp
CalculateArea()
```

---

## Area Calculations

### Circle

```csharp
Math.PI * Radius * Radius
```

### Rectangle

```csharp
Width * Height
```

### Triangle

```csharp
0.5 * Base * Height
```

---

## Pattern Matching

```csharp
switch (shape)
{
    case Circle circle:
    case Rectangle rectangle:
    case Triangle triangle:
}
```

The runtime type is identified and cast automatically.

---

## Null Handling

```csharp
case null:
```

Provides safe handling for null references.

---

## Default Handling

```csharp
default:
```

Handles unknown shape types.

---

## Example Output

![Event](Docs/Assets/Task7.png)

---

## Learning Outcomes

- Created inheritance hierarchies.
- Implemented polymorphism.
- Used type patterns.
- Used switch pattern matching.
- Handled null patterns.
- Improved readability over traditional type checking.

---

# Summary

This assignment explored several advanced C# features:

| Task | Concept |
|--------|----------|
| Task 1 | Events and Delegates |
| Task 2 | var and dynamic |
| Task 3 | Anonymous Methods |
| Task 4 | Lambda Expressions and LINQ |
| Task 5 | Custom Delegates for Sorting |
| Task 6 | Records and Immutable Data |
| Task 7 | Pattern Matching |

## Overall Learnings

- Built event-driven applications using delegates and events.
- Understood compile-time and runtime type resolution.
- Used anonymous methods for inline functionality.
- Applied LINQ with lambda expressions.
- Implemented reusable sorting mechanisms with delegates.
- Leveraged record types for immutable data models.
- Used pattern matching to simplify type-based logic.
- Improved code readability, maintainability, and flexibility using modern C# features.