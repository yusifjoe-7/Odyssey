# Design Decisions

This document summarizes a few important design decisions and the
reasoning behind them.

## 1. Integer IDs Instead of UUIDs

All entities use `int` IDs instead of UUIDs.

**Reasoning:**
- The project does not use a Microservices architecture, so globally unique IDs across independent services are not a requirement.
- Integer IDs are simple and suitable for the project's needs.
- They generally require less storage than UUIDs.

## 3. `User` as a Base Class

`User` is the base class for: - `Customer` - `Owner` - `Admin`

This keeps shared user data in one place while allowing each derived
type to have its own properties and behavior.

The application can work with a person as a `Customer`, `Owner`, or
`Admin` when role-specific information or behavior is needed, instead of
always treating them only as a generic `User`.

## 4. `Review` as a Base Class

`Review` is the base class for: - `CustomerReview` - `HostReview` -
`OwnerReview`

The base class contains the common review information, while each
derived review type can have its own additional details.

This also allows shared review-related logic to work with the base
`Review` type without needing to know the exact review type in every
case.

There are currently no admin reviews.

## 5. Separate Review Types

I chose to keep the review types separate because I expect each type to
need different properties and details as the project evolves.

The table below shows who writes each review:

  Review Type        Written By   About
  ------------------ ------------ -----------
  `CustomerReview`   Owners       Customers
  `HostReview`       Customers    Hosts
  `OwnerReview`      Customers    Owners

Keeping these types separate makes their differences explicit and gives
each type room to evolve independently.

## 6. EF Core Inheritance Mapping: TPC

The project uses **Table-per-Concrete-Type (TPC)** inheritance mapping
in Entity Framework Core.

With TPC, each concrete entity type has its own database table. The
tables contain the properties declared by the base class as well as the
properties declared by that concrete type.

This fits the decision to keep the different review types in separate
tables while still sharing common properties through the `Review` base
class.

------------------------------------------------------------------------

## Summary

-   Use `int` IDs instead of UUIDs.
-   Do not use Microservices.
-   Use `User` as the base class for `Customer`, `Owner`, and `Admin`.
-   Use `Review` as the base class for `CustomerReview`, `HostReview`,
    and `OwnerReview`.
-   Keep review types separate because they may require different
    details.
-   Use EF Core with TPC inheritance mapping.
