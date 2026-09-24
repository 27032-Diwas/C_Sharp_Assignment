# ValueAndReferenceTypes

## Objective

The objective of this task is to understand the differences between **Value Types** and **Reference Types** in C#, how they behave when passed to methods, and how memory is allocated and managed using the **Stack** and the **Heap**.

---

# Introduction

C# provides two primary categories of data types:

1. Value Types
2. Reference Types

Understanding the differences between in aspects such as:

- Memory allocation
- Performance
- Application behavior
- Parameter passing
- Memory management

This project demonstrates how value types and reference types behave differently when modified inside methods and how they are stored in memory.

---

# Task 1: Understanding and Using Value Types and Reference Types

## Task Description

In this task:

1. Create a Console Application named **ValueAndReferenceTypes**.
2. Define a value type and a reference type in the `Main` method.
3. Create a method that accepts both types as parameters.
4. Modify both values inside the method.
5. Print the values after the method call.
6. Observe the differences in behavior.

---

# What are Value Types?

A value type directly stores its data.

When a value type variable is assigned to another variable, a copy of the value is created.

Examples:

- int
- float
- double
- bool
- char
- decimal
- struct
- enum

### Characteristics of Value Types

 - Store actual data directly.

 - Usually allocated on the stack.

 - Assignment creates a copy.

 - Each variable maintains its own value.

 - Changes to one copy do not affect another.

---

# What are Reference Types?

A reference type stores a reference (memory address) that points to an object stored in memory.

When a reference type variable is assigned to another variable, both variables refer to the same object.

Examples:

- class
- string
- array
- object
- interface
- delegate

### Characteristics of Reference Types

 - Store references to objects.

 - Objects are allocated on the heap.

 - Assignment copies the reference.

 - Multiple variables can point to the same object.

 - Changes through one reference are visible through others.

---

# Value Type Behavior

When a value type is passed to a method:

- A copy of the value is passed.
- The original value remains unchanged.
- Modifications occur only on the copied value.

### Observation

The value type retains its original value after the method call.

### Reason

Because a separate copy is created when the value is passed to the method.

---

# Reference Type Behavior

When a reference type is passed to a method:

- The reference is copied.
- Both references point to the same object.
- Changes made to the object affect the original object.

### Observation

The reference type reflects modifications made inside the method.

### Reason

Because both references access the same object in memory.

---

# Value Types vs Reference Types

| Feature | Value Types | Reference Types |
|----------|------------|----------------|
| Stores | Actual data | Memory reference |
| Memory Allocation | Usually Stack | Heap |
| Assignment Behavior | Copies value | Copies reference |
| Multiple Variables Share Data | No | Yes |
| Modification Effect | Independent | Shared |
| Performance | Generally Faster | Slightly More Overhead |

---

# Expected Outcome for Task 1

After invoking the method:

### Value Type

- Original value remains unchanged.
- Changes made inside the method affect only the local copy.

### Reference Type

- Original object gets modified.
- Changes made inside the method remain visible after the method returns.

---

# Understanding Memory: Stack and Heap

Memory management in C# primarily involves two memory regions:

1. Stack Memory
2. Heap Memory

Understanding both helps explain the behavior of value and reference types.

---

# What is the Stack?

The stack is a fast memory area used for:

- Method calls
- Local variables
- Value types
- Function parameters

Whenever a method is called:

1. A stack frame is created.
2. Local variables are stored.
3. When the method exits, the stack frame is removed automatically.

### Characteristics of Stack Memory

 - Fast allocation and deallocation.

 - Automatically managed.

 - Stores method execution data.

 - Ideal for short-lived data.

 - Memory is released immediately when the method finishes.

---

# What is the Heap?

The heap is a memory area used for storing dynamically allocated objects.

Reference type objects are created on the heap.

### Characteristics of Heap Memory

 - Stores objects and arrays.

 - Supports dynamic memory allocation.

 - Larger than stack memory.

 - Managed by Garbage Collection.

 - Memory is released when objects become unreachable.

---

# Task 2: Working with the Stack and the Heap

## Task Description

Extend the **ValueAndReferenceTypes** project by creating:

### Method 1

A method that creates a large array of integers.

### Method 2

A method that performs calculations using many local variables.

Observe memory usage using a profiling tool.

---

# Large Array Method

The large integer array is a reference type.

When the array is created:

- Memory is allocated on the heap.
- Heap usage increases significantly.
- The array remains in memory while being referenced.

### Observation

Heap memory usage increases noticeably.

### Reason

Arrays are reference types and are allocated on the heap.

---

# Large Local Variable Method

The calculation method contains a large number of local variables.

These variables are value types.

When the method executes:

- Variables are stored in the stack frame.
- Stack usage increases.
- Memory is released automatically after method completion.

### Observation

Stack memory usage increases during execution.

### Reason

Local value type variables are typically stored on the stack.

---

# Stack vs Heap

| Feature | Stack | Heap |
|-----------|---------|---------|
| Storage Type | Value Types, Local Variables | Objects, Arrays |
| Allocation Speed | Very Fast | Slower |
| Memory Management | Automatic | Garbage Collected |
| Lifetime | Method Scope | Object Lifetime |
| Size | Smaller | Larger |
| Access Speed | Faster | Slower |

---

# Profiling Memory Usage

Memory consumption can be observed using:

- Visual Studio Diagnostic Tools
- Visual Studio Performance Profiler

These tools help visualize:

- Heap allocations
- Memory growth
- Object lifetime
- Garbage collection activity

---

# Expected Outcome for Task 2

When running the application:

### Large Array Method

- Heap memory increases significantly.
- More managed memory is allocated.

### Local Variable Method

- Stack memory usage increases during execution.
- Memory is automatically released when the method exits.

### Profiling Results

You should observe:

- Arrays consume heap memory.
- Local value-type variables consume stack memory.
- Heap allocations persist longer.
- Stack allocations are short-lived and automatically cleaned up.

---

# Conclusion

Value types and reference types behave differently because of how they are stored and managed in memory. Value types store actual data and are typically allocated on the stack, resulting in independent copies when passed to methods. Reference types store references to objects located on the heap, allowing multiple references to access and modify the same object. Through profiling, it becomes clear that arrays consume heap memory while local value-type variables use stack memory. Understanding these concepts is fundamental for writing efficient, high-performance C# applications.