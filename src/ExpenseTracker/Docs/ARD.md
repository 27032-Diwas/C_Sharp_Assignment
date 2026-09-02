# ADR: Persist Expense Tracker Data Using JSON Files


## Context

The Expense Tracker application currently stores all transaction records in an in-memory collection within the repository layer.

Based on the current design:

- `ExpenseTrackerRepository` maintains a collection of `Transaction` objects.
- `JsonRepository` is responsible for persisting and retrieving data.
- Transactions consist of:
  - TransactionId
  - Amount
  - Date
  - Category
  - TransactionType
  - Description

At present, the domain model contains only flat transaction objects and does not require nested data structures.

However, future enhancements may introduce additional properties such as:

- User profiles
- Tags
- Budgets
- Transaction metadata
- Recurring transaction settings
- Category details

Therefore, the persistence format should support future growth while remaining simple to implement and maintain.

The following file formats were evaluated:

- JSON
- CSV
- XML
- Binary Files
- INI Files

---

## Decision

JSON will be used as the persistence format for storing transaction data.

JSON provides the best balance between:

- Simplicity
- Extensibility
- Maintainability
- Human readability
- Native .NET integration
- Sufficient performance for expected workloads

Although the current model is flat and could be represented using CSV, JSON was selected because it provides greater flexibility for future domain model evolution without requiring major redesign.

The implementation will use:

```csharp
System.Text.Json
```

for serialization and deserialization.

---

## Rationale

### 1. Supports Current Domain Model

The current domain model contains simple transaction records.

Example:

```json
{
  "transactionId": "a1b2c3",
  "amount": 500,
  "date": "2025-01-20",
  "category": "Food",
  "transactionType": "Expense",
  "description": "Lunch"
}
```

JSON maps directly to the `Transaction` class.

This enables straightforward serialization and deserialization with minimal implementation effort.

---

### 2. Better Support for Future Extension

The current application does not contain nested objects.

However, future requirements may require additional fields.

Current structure:

```json
{
  "category": "Food"
}
```

Future structure:

```json
{
  "category": {
    "name": "Food",
    "budgetLimit": 5000
  }
}
```

or

```json
{
  "transactionId": "a1b2c3",
  "amount": 500,
  "tags": ["Lunch", "Office"]
}
```

JSON can accommodate these changes without changing the storage mechanism.

CSV and INI formats would require significant redesign and custom parsing.

Therefore, JSON provides better long-term flexibility.

---

### 3. Easier Schema Evolution

Software requirements evolve over time.

New properties can be introduced without breaking existing files.

Current version:

```json
{
  "amount": 500
}
```

Future version:

```json
{
  "amount": 500,
  "currency": "INR"
}
```

Existing JSON files remain usable even when new properties are added.

This reduces maintenance effort and migration complexity.

---

### 4. Strong Data Type Representation

JSON supports:

- Strings
- Numbers
- Boolean values
- Arrays
- Objects
- Null values

Example:

```json
{
  "amount": 1500.50,
  "isRecurring": false
}
```

These map directly to .NET types.

CSV stores all values as text, requiring additional parsing and validation logic.

---

### 5. Native .NET Support

The .NET platform provides built-in JSON support through:

```csharp
System.Text.Json
```

Benefits include:

- No external dependencies
- Strong typing support
- Reduced custom code
- Easy maintenance
- High-performance serialization

This simplifies implementation of the `JsonRepository` class.

---

### 6. Human Readability

JSON files are easy to inspect and modify manually.

Example:

```json
{
  "category": "Food",
  "amount": 500
}
```

Benefits include:

- Easier debugging
- Easier testing
- Simpler troubleshooting
- Faster issue investigation

Developers can directly inspect persisted data without specialized tools.

---

### 7. Storage Efficiency

Storage efficiency was considered during evaluation.

For the same transaction dataset:

| Format | Relative File Size |
|----------|----------|
| Binary | Smallest |
| CSV | Small |
| JSON | Medium |
| XML | Largest |

Example for approximately 1,000 transactions:

| Format | Approximate Size |
|----------|----------|
| Binary | ~100 KB |
| CSV | ~110–130 KB |
| JSON | ~120–150 KB |
| XML | ~180–300 KB |

JSON consumes slightly more storage than CSV because property names are stored explicitly.

However, the increase is small for the expected scale of the application.

The additional storage cost is justified by improved maintainability and extensibility.

---

### 8. Retrieval and Processing Performance

Performance is not the primary concern because the application is intended for a single user and is expected to handle:

- Hundreds of records
- Thousands of records

rather than millions.

Approximate relative read/write performance:

| Format | Relative Performance |
|----------|----------|
| Binary | Fastest |
| CSV | Very Fast |
| JSON | Fast |
| XML | Slowest |

Example relative loading time:

| Format | Relative Read Time |
|----------|----------|
| Binary | 1x |
| CSV | 1.2x |
| JSON | 1.3 - 1.8x |
| XML | 3 - 6x |

Although JSON is marginally slower than CSV and Binary formats, the difference is negligible for the anticipated workload.

JSON still provides:

- Fast serialization
- Fast deserialization
- Low parsing overhead
- Acceptable memory usage

for an Expense Tracker application.

---

## Alternatives Considered

### CSV

#### Advantages

- Simple format
- Human readable
- Small file size
- Fast processing

#### Disadvantages

- Limited support for future expansion
- No object representation
- No nested structure support
- Schema changes require header modifications
- Additional parsing and conversion logic required

---

### XML

#### Advantages

- Structured format
- Supports validation
- Mature ecosystem

#### Disadvantages

- Verbose syntax
- Larger file sizes
- Higher parsing cost
- Unnecessary complexity for current application

---

### Binary Files

#### Advantages

- Smallest storage footprint
- Fastest read/write operations

#### Disadvantages

- Difficult to debug
- Not human readable
- Harder maintenance
- Difficult recovery from file corruption

---

### INI Files

#### Advantages

- Simple syntax
- Easy manual editing

#### Disadvantages

- Not suited for collections
- Limited scalability
- No structured object representation
- Requires custom conventions

---

## Consequences

### Positive Consequences

- Aligns with current architecture
- Integrates naturally with `JsonRepository`
- Native support in .NET
- Human readable
- Easy debugging
- Supports future enhancements
- Easy schema evolution
- Fast enough for expected workload
- Reasonable storage requirements
- Low implementation effort

### Negative Consequences

- Slightly larger files than CSV
- Larger files than Binary format
- Slightly slower than Binary and CSV
- No built-in schema enforcement

---

## Conclusion

JSON was selected as the persistence format because it provides the best balance between simplicity, maintainability, extensibility, readability, and performance. Although the current application stores only flat transaction data, JSON allows future expansion without requiring changes to the persistence mechanism. While CSV and Binary formats offer marginally better storage efficiency and retrieval speed, the difference is insignificant for the expected workload. The flexibility of JSON, combined with native .NET support through `System.Text.Json`, makes it the most suitable persistence solution for the Expense Tracker application.