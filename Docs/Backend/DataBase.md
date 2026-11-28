# Design Decisions

This document summarizes selected design decisions and the reasoning behind them.

## 1. UUIDs Instead of Integer IDs

All entities use `Guid` (UUID) IDs instead of integer IDs.

**Reasoning:**
- UUIDs provide non-sequential identifiers.
- Integer IDs are sequential, which can make ordering by ID closely related to insertion order.
- UUIDs make the ordering less predictable and less dependent on record creation time.
- UUIDs also provide flexibility when generating identifiers outside the database.

Although the project does not use a Microservices architecture, I chose UUIDs because their characteristics better suit the project's needs.

## 2. User Inheritance Structure

The user hierarchy is organized as follows:

- `User` is the base class for `Client` and `Admin`.
- `Client` is the base class for `Customer` and `Owner`.

This structure keeps properties shared by all users in `User`, while properties shared only by customers and owners are defined in `Client`.

For example, `OpenIssues` is defined in `Client`, allowing both `Customer` and `Owner` to inherit it without making it available to `Admin`.

## 3. Review Inheritance Structure

`Review` is the base class for:

- `CustomerReview`
- `HostReview`
- `OwnerReview`

The base class contains common review information, while each derived review type can have its own additional properties.

This allows shared review-related logic to work with the base `Review` type without needing to know the exact review type in every case.

There are currently no admin reviews.

## 4. EF Core Inheritance Mapping: TPC

The project uses **Table-per-Concrete-Type (TPC)** inheritance mapping in Entity Framework Core for both the User and Review hierarchies.

With TPC, each concrete entity type has its own database table. Each table includes the properties inherited from its base classes, along with properties declared by that concrete type.

**User tables:**

- `Admin` — properties inherited from `User`.
- `Customer` — properties inherited from `Client` and `User`.
- `Owner` — properties inherited from `Client` and `User`.

**Review tables:**

- `CustomerReview` — properties inherited from `Review` and its own properties.
- `HostReview` — properties inherited from `Review` and its own properties.
- `OwnerReview` — properties inherited from `Review` and its own properties.

The base classes (`User`, `Client`, and `Review`) do not have their own tables when they are abstract.

## 5. Separate Review Types

I chose to keep the review types separate because I expect each type to require different properties and details as the project evolves.

The following table shows who writes each review and who it is about:

| Review Type | Written By | About |
|---|---|---|
| `CustomerReview` | Owners | Customers |
| `HostReview` | Customers | Hosts |
| `OwnerReview` | Customers | Owners |

Keeping these types separate makes their differences explicit and allows each type to evolve independently.

## 6. Cursor-Based Pagination

The project uses an optional `LastElement` value to determine whether a pagination request is the first request or a subsequent request.

Instead of duplicating pagination conditions, a boolean variable determines whether the cursor filter should be applied.

```csharp
bool IsNotNew = !(request.LastElement is null);

.Where(h => IsNotNew ? h.Id > request.LastElement : true)
```

**Reasoning:**
- Keeps the pagination query reusable for both initial and subsequent requests.
- Avoids applying the cursor condition when no previous element exists.
- Provides a simple way to implement cursor-based pagination.

## 7. Validation with FluentValidation

The project uses FluentValidation to define validation rules separately from application logic.

For example, the minimum number of pages for a book is defined as:

```csharp
RuleFor(q => q.NumberOfPages)
    .GreaterThanOrEqualTo(5)
    .WithMessage("NumberOfPages must be >= 5");
```

**Reasoning:**
- Keeps validation rules organized and separate from business operations.
- Makes validation rules reusable and easier to maintain.
- Provides clear and specific validation error messages.

## 8. Unified User Lookup with TPC

Although users are stored in separate tables because of TPC inheritance mapping, the project provides a unified method to find users by username.

`FindUserByUserNameAsync` searches the concrete user sets (`Admins`, `Customers`, and `Owners`) and returns the matching user as the base `User` type.

**Reasoning:**
- Allows application logic to work with different user types through a single method.
- Avoids duplicating user lookup logic across the application.
- Makes operations such as authentication easier without requiring separate endpoints for each user type.

This is particularly useful because TPC does not provide a single physical `Users` table containing all user records.

---

## Summary

- Use `Guid` IDs instead of sequential integer IDs.
- Use `User` as the base class for `Client` and `Admin`.
- Use `Client` as the base class for `Customer` and `Owner`.
- Use `Review` as the base class for `CustomerReview`, `HostReview`, and `OwnerReview`.
- Use EF Core with TPC inheritance mapping for both hierarchies.
- Keep review types separate because they may require different properties and behavior.
- Use optional cursor-based pagination through `LastElement`.
- Use FluentValidation for validation rules.
- Provide a unified user lookup method to search across concrete TPC tables.