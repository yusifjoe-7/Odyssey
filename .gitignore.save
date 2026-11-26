# Design Decisions

This document summarizes selected design decisions and the reasoning behind them.

## 1. Integer IDs Instead of UUIDs

All entities use `int` IDs instead of UUIDs.

**Reasoning:**
- The project does not use a Microservices architecture, so globally unique IDs across independent services are not required.
- Integer IDs are simple and suitable for the project's needs.
- They generally require less storage than UUIDs.

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

---

## Summary

- Use `int` IDs instead of UUIDs; the project does not use Microservices.
- Use `User` as the base class for `Client` and `Admin`.
- Use `Client` as the base class for `Customer` and `Owner`.
- Use `Review` as the base class for `CustomerReview`, `HostReview`, and `OwnerReview`.
- Use EF Core with TPC inheritance mapping for both hierarchies.
- Keep review types separate because they may require different properties and behavior.
