# Project, Solution, and Build Order

This assignment demonstrates a multi-project .NET solution where multiple projects are connected through project references. It showcases how **MSBuild** automatically determines the correct build sequence by analyzing project dependencies.

---

## Solution Structure

### Solution Name

- **CSharpConsoleSolution**

### Projects Included

- **Project A** - GreetingsApp
- **Project B** - MathApp
- **Project C** - DisplayApp
- **Project D** - UtilityApp
- **Project E** - Project E

---
 
## Project Dependencies

The projects have the following dependency relationships:

- **GreetingsApp** depends on **MathApp**
- **MathApp** depends on **DisplayApp**
- **DisplayApp** depends on **UtilityApp**
- **Project E** depends on **DisplayApp**

---

## Dependency Diagram

```text
GreetingsApp (Project A)
        |
        v
MathApp (Project B)
        |
        v
DisplayApp (Project C)
        |
        v
UtilityApp (Project D)

Project E (Project E)
        |
        v
DisplayApp (Project C)
```

---

## Build Sequence

When the solution is built, **MSBuild** evaluates all project references and compiles the projects in an order that satisfies their dependencies.

### Observed Build Order

1. UtilityApp (Project D)
2. DisplayApp (Project C)
3. MathApp (Project B)
4. GreetingsApp (Project A)
5. Project E (Project E)

---

## Build Order Analysis

### Step 1: Build UtilityApp (Project D)

UtilityApp has no dependencies on any other project. Therefore, it is built first and provides the required functionality for dependent projects.

### Step 2: Build DisplayApp (Project C)

DisplayApp depends on UtilityApp. Once UtilityApp is successfully built, DisplayApp can be compiled.

### Step 3: Build MathApp (Project B)

MathApp depends on DisplayApp. Since DisplayApp is already available, MathApp is built next.

### Step 4: Build GreetingsApp (Project A)

GreetingsApp depends on MathApp. After MathApp is successfully compiled, GreetingsApp becomes eligible for compilation.

### Step 5: Build Project E (Project E)

Project E depends on DisplayApp. Since DisplayApp has already been built, this project can be compiled successfully. In the observed build process, MSBuild scheduled it after GreetingsApp.

---

## Key Takeaways

- MSBuild automatically resolves project dependencies before starting the build process.
- Projects without dependencies are built first.
- Dependent projects are compiled only after all referenced projects have been successfully built.
- Build order is determined by dependency relationships rather than the order in which projects appear in Solution Explorer.
- Proper dependency management ensures a reliable and error-free build process.

---

## Conclusion

This assignment demonstrates how project dependencies influence the build process within a .NET solution. By analyzing project references, MSBuild ensures that prerequisite projects are built before dependent projects. This dependency-driven approach results in a successful, consistent, and maintainable build process.

---

# Screenshots

## Build Order


![build](Docs/buildOrder.png)

## Display App

![Display](Docs/DisplayApp.png)

## Greeting App

![Greeting](Docs/GreetingApp.png)

## Math Operations

![Math](Docs/MathApp.png)

## Project E

![Project E](Docs/ProjectE.png)
