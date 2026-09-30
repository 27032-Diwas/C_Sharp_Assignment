# Async/Await, Task Parallel Library, and Multi-Threading in C#

## Overview

This project demonstrates the practical usage of asynchronous programming, the Task Parallel Library (TPL), multi-threading, deadlock prevention, `ConfigureAwait(false)`, and exception handling in asynchronous methods using C#.

The application consists of seven tasks designed to provide hands-on experience with modern concurrency and asynchronous programming concepts in .NET.

---

## Learning Objectives

By completing this assignment, the following concepts are demonstrated:

- Async and Await
- Task-based Asynchronous Programming
- HttpClient asynchronous operations
- Task Parallel Library (TPL)
- Multi-threading using Thread
- CPU-bound vs I/O-bound operations
- Multi-layered asynchronous operations
- Deadlock prevention
- ConfigureAwait(false)
- Exception handling in asynchronous methods
- Differences between `async void` and `async Task`

---

# Project Structure

```text
Assignments
│
├── Program.cs
│
AsynchronousProgramming
│
└── WebsiteContentExtractor.cs
```

---

# Task 1 - Async/Await with HttpClient

## Objective

Demonstrate asynchronous downloading of website content using `HttpClient`.

## Implementation

- Uses `HttpClient.GetStringAsync()`.
- Method is declared using `async`.
- `await` is used to avoid blocking the calling thread.
- Downloaded content is displayed in the console.

## Concepts Used

- Async/Await
- HttpClient
- Non-blocking I/O

## Sample Output

```text
TASK 1 : ASYNC / AWAIT

Downloading content...
Content extraction completed.

<html>
...
```

---

# Task 2 - Task Parallel Library (TPL)

## Objective

Use the Task Parallel Library to perform operations on a large collection in parallel.

## Implementation

- Creates an array containing numbers from 1 to 10,000.
- Uses `Parallel.ForEach` to square each number.
- Compares parallel execution time against sequential execution.

## Concepts Used

- Parallel.ForEach
- Data Parallelism
- Stopwatch Performance Measurement

## Sample Output

```text
Parallel execution time : 2 ms
Sequential execution time : 8 ms
```

## Benefits

- Utilizes multiple processor cores.
- Improves execution speed for CPU-intensive workloads.

---

# Task 3 - Multi-Threading

## Objective

Demonstrate concurrent execution using multiple threads.

## Operations Performed

### Thread 1

Sorts an integer array.

### Thread 2

Calculates the sum of all elements.

## Implementation

- Uses the `Thread` class.
- Executes operations simultaneously.
- Uses `Join()` to wait until both threads complete.

## Concepts Used

- Thread
- Thread Join
- Concurrent Execution

## Sample Output

```text
Sorting Thread Id : 4
Calculation Thread Id : 5

Sorted Values:
1 2 5 6 8 9 13

Sum = 44
```

---

# Task 4 - Multi-Layered Async/Await

## Objective

Simulate a real-world workflow where a CPU-bound operation triggers a series of asynchronous web requests.

## Workflow

### MethodA

Simulates a CPU-intensive analysis by:

```text
Task.Run()
        ↓
Large Calculation
        ↓
Returns URL
```

### MethodB

```text
Calls MethodA
      ↓
Awaits Result
      ↓
Makes HTTP Request
      ↓
Returns JSON Response
```

### MethodC

```text
Calls MethodB
      ↓
Awaits Result
      ↓
Parses JSON
      ↓
Counts Key-Value Pairs
```

## Concepts Used

- Task.Run
- CPU-bound operations
- Async/Await chaining
- JSON Processing
- Dependency between asynchronous operations

## Sample Output

```text
Analyzing large dataset...

Analysis Result: 4999999950000000

Total Key Value Pairs : 80
```

---

# Task 5 - Deadlock Prevention

## Objective

Understand and avoid deadlocks caused by blocking asynchronous code.

## Problem

Using:

```csharp
SomeAsyncOperation().Result
```

or

```csharp
SomeAsyncOperation().Wait();
```

can lead to deadlocks.

## Solution

Use:

```csharp
await SomeAsyncOperation();
```

## Implementation

```csharp
private static async Task DeadlockMethod()
{
    string result = await SomeAsyncOperation();
    Console.WriteLine(result);
}
```

## Sample Output

```text
Hello World!
```

---

# Task 6 - ConfigureAwait(false)

## Objective

Understand how `ConfigureAwait(false)` affects continuation execution.

## Implementation

MethodA:

```csharp
await Task.Delay(5000)
          .ConfigureAwait(false);
```

Thread IDs are printed before and after the await.

## Concepts Used

- Synchronization Context
- ConfigureAwait(false)
- Thread Pool Threads

## Sample Output

```text
Thread Before Await : 1
Thread After Await : 7
```

## Why Use ConfigureAwait(false)?

Benefits include:

- Reduces context switching.
- Improves performance.
- Avoids deadlocks in library code.
- Preferred in reusable .NET libraries.

---

# Task 7 - Async Void vs Async Task

## Objective

Compare exception handling behavior between `async void` and `async Task`.

## Async Void

```csharp
private static async void VoidMethod()
{
    await Task.Delay(1000);
    throw new Exception();
}
```

### Behavior

- Cannot be awaited.
- Exceptions cannot be caught by the caller.
- Can terminate the application.

---

## Async Task

```csharp
private static async Task TaskMethod()
{
    await Task.Delay(1000);
    throw new Exception();
}
```

### Behavior

- Can be awaited.
- Exceptions propagate to the caller.
- Can be handled using try-catch.

## Sample Output

```text
Calling async void method...
Unhandled Exception: Exception from async void.

Calling async Task method...
Caught exception from TaskMethod:
Exception from async Task.
```

---

# Error Handling

The application demonstrates:

- HttpRequestException handling
- Async exception handling
- Unhandled async void exceptions
- Safe task-based exception propagation

---

# Performance Observations

| Technique | Benefit |
|------------|----------|
| Async/Await | Non-blocking operations |
| Parallel.ForEach | Faster CPU-bound processing |
| Multi-Threading | Concurrent execution |
| ConfigureAwait(false) | Reduced context switching |
| Task-Based Programming | Better scalability |

---

# Technologies Used

- C#
- .NET
- HttpClient
- Task Parallel Library (TPL)
- Thread Class
- Task
- Async/Await
- JsonDocument
- Stopwatch

---

# Key Takeaways

### Async/Await

- Best suited for I/O-bound work.
- Improves application responsiveness.

### Task Parallel Library

- Ideal for CPU-bound operations.
- Efficiently utilizes multiple CPU cores.

### Multi-Threading

- Enables multiple operations to run simultaneously.
- Requires careful synchronization.

### ConfigureAwait(false)

- Avoids unnecessary synchronization context captures.
- Improves performance in library code.

### Async Task vs Async Void

- Prefer `async Task`.
- Use `async void` only for event handlers.

---

# Conclusion

This project demonstrates several advanced .NET programming concepts including asynchronous programming, task parallelism, multithreading, deadlock resolution, synchronization context management, and asynchronous exception handling. Together, these techniques help build responsive, scalable, and efficient applications that make optimal use of system resources.