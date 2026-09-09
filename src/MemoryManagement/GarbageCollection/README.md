# GarbageCollection

## Objective

The objective of this task is to understand how Garbage Collection (GC) works in C#, how memory is managed by the .NET runtime, and how garbage collection affects application performance.

---

# Introduction

Memory management is one of the key responsibilities of the .NET Runtime. Instead of manually allocating and deallocating memory, developers create objects, and the Garbage Collector automatically identifies and removes objects that are no longer needed.

Garbage Collection helps:

- Prevent memory leaks.
- Automatically reclaim unused memory.
- Improve application reliability.
- Simplify memory management for developers.

However, garbage collection also consumes system resources and can impact application performance when it runs.

---

# Task Description

In this project:

1. Create a C# Console Application named **GarbageCollection**.
2. Create a method that generates a large number of objects inside a loop.
3. Observe memory usage using a profiling tool.
4. Trigger garbage collection manually using `GC.Collect()`.
5. Compare memory usage before and after garbage collection.
6. Observe the performance impact when garbage collection occurs.

---

# How Garbage Collection Works

When an object is created using the `new` keyword, memory is allocated on the managed heap.

Example Process:

1. Object is created.
2. Application uses the object.
3. Object reference is removed or goes out of scope.
4. Object becomes unreachable.
5. Garbage Collector identifies the object as unused.
6. Memory occupied by the object is reclaimed.

---

# Reachable vs Unreachable Objects

## Reachable Objects

A reachable object is an object that still has at least one active reference pointing to it.

Example scenario:

- Object stored in a variable.
- Object stored in a list.
- Object referenced by another object.

These objects are still in use and **cannot be removed by the Garbage Collector**.

### Important Learning

 - GC cannot collect objects that are still referenced.

 - As long as a reference exists, the object remains in memory.

---

## Unreachable Objects

An unreachable object is an object that no longer has any valid references.

Examples:

- Variable goes out of scope.
- Reference is assigned to `null`.
- Temporary objects created inside loops.

These objects become eligible for garbage collection.

### Important Learning

 - GC can collect objects that no longer have references.

 - Unreachable objects are removed automatically when GC runs.

---

# Memory Usage Observation

When a large number of objects are created:

- Memory usage increases.
- Managed heap size grows.
- More memory is allocated to store objects.

After garbage collection:

- Unused memory is reclaimed.
- Memory usage drops.
- Heap becomes cleaner and more efficient.

---

# Manual Garbage Collection

The .NET runtime automatically decides when garbage collection should occur.

However, garbage collection can also be triggered manually using:

```csharp
GC.Collect();
```

This forces the runtime to perform garbage collection immediately.

### Observation

After executing `GC.Collect()`:

- Unused objects are removed.
- Memory consumption decreases.
- Application may pause briefly while collection occurs.

---

# Performance Impact of Garbage Collection

Garbage collection helps free memory, but it is not free in terms of performance.

## Positive Impact

- Frees unused memory.
- Prevents memory exhaustion.
- Reduces memory leaks.
- Improves long-term application stability.
- Simplifies development by handling memory automatically.

## Negative Impact

- Consumes CPU resources.
- Can temporarily pause application execution.
- Frequent collections can slow the application.
- Excessive object creation leads to more garbage collection cycles.
- Manual calls to `GC.Collect()` may negatively affect performance.

---

# Best Practices

### Good Practices

 - Let the .NET runtime handle garbage collection automatically.

 - Reuse objects whenever possible.

 - Dispose unmanaged resources properly.

 - Minimize unnecessary object creation.

 - Monitor memory usage using profiling tools.

 - Use `using` statements for disposable resources.

---

### Practices to Avoid

 - Calling `GC.Collect()` repeatedly.

 - Creating excessive temporary objects.

 - Holding references to unused objects.

 - Assuming garbage collection happens instantly after an object becomes unused.

---

# Profiling Tools

Memory usage can be observed using:

- Visual Studio Diagnostic Tools
- Visual Studio Performance Profiler
- JetBrains dotMemory
- PerfView
- Windows Task Manager

These tools help analyze:

- Heap memory usage
- Object allocations
- Garbage collection frequency
- Performance bottlenecks

---

# Key Learnings

### Memory Management

- .NET uses automatic memory management.
- Objects are stored in managed memory.
- Garbage Collector manages unused memory automatically.
- Developers do not manually free memory.

### Garbage Collection

- Garbage Collection reclaims memory from unreachable objects.
- GC runs automatically when required.
- GC can be triggered manually using `GC.Collect()`.
- Garbage collection is performed by the CLR (Common Language Runtime).

### Object References

- Objects with active references cannot be collected.
- Objects without references become eligible for collection.
- Holding unnecessary references increases memory consumption.
- Removing references helps GC reclaim memory.

### Performance

- Garbage collection improves memory availability.
- Garbage collection consumes CPU resources.
- Frequent collections may reduce performance.
- Excessive temporary object creation increases GC activity.
- Manual GC should be used only when necessary.

### Profiling and Monitoring

- Memory usage should be monitored using profiling tools.
- Profilers help identify memory-intensive operations.
- Profilers help detect allocation patterns.
- Performance analysis helps optimize applications.

### Development Best Practices

- Create only necessary objects.
- Reuse objects whenever possible.
- Dispose resources correctly.
- Avoid unnecessary calls to `GC.Collect()`.
- Allow the runtime to manage memory efficiently.

---

# Conclusion

Garbage Collection is a fundamental feature of .NET that automatically manages memory by reclaiming objects that are no longer referenced. Objects with active references remain in memory, while unreachable objects are eligible for collection. Although garbage collection reduces memory usage and prevents memory leaks, it introduces some performance overhead. Therefore, developers should rely on the .NET runtime's automatic garbage collection mechanism and follow memory-efficient coding practices to build performant and scalable applications.