
# Key Learnings

## Value Types

- Value types store actual data.
- Assignment creates a copy.
- Changes do not affect the original variable.
- Common examples include int, bool, double, and struct.
- Typically stored on the stack.

---

## Reference Types

- Reference types store memory references.
- Objects are stored on the heap.
- Assignment copies references.
- Multiple variables can reference the same object.
- Changes to the object are visible through all references.

---

## Method Parameter Behavior

- Value types are passed by value by default.
- Reference types pass a copy of the reference.
- Value type modifications do not affect originals.
- Reference type modifications affect the underlying object.

---

## Stack Memory

- Stores local variables and method data.
- Fast allocation and deallocation.
- Automatically released when methods complete.
- Suitable for temporary data.
- Used heavily during method execution.

---

## Heap Memory

- Stores dynamically allocated objects.
- Used by classes and arrays.
- Managed by Garbage Collection.
- Supports larger memory allocations.
- Objects remain until no references exist.

---

## Performance Considerations

- Stack operations are generally faster.
- Heap allocations involve more overhead.
- Excessive heap allocations increase garbage collection activity.
- Efficient memory usage improves performance.
- Understanding memory allocation helps write optimized applications.

---

## Memory Profiling

- Profiling tools help visualize memory usage.
- Heap memory growth can be monitored.
- Allocation patterns can be analyzed.
- Memory-intensive operations can be identified.
- Profiling aids performance optimization.

