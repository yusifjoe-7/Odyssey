# Registering Design

The Registering process uses a Strategy-like approach to handle user registration based on the selected role.

- **RegisteringCommand:** Holds the registration data.
- **RegisteringCommandHandler:** Hashes the password, creates the base `User` object, and selects the appropriate commit based on the requested role.
- **IDbRegisteringCommit:** Defines a shared contract for persisting users.
- **Role-specific Commits:** Each implementation handles role assignment and saving the user into its corresponding DbSet.
- **CheckNameAndEmailOwner:** Checks whether the owner's email or username already exists before registration.
- **ExistChecks:** Reuses the existence-checking logic and throws the appropriate exception when a duplicate is found.

## Registration Flow

```mermaid
flowchart TD
    A[RegisteringCommand] --> B[RegisteringCommandHandler]
    B --> C[Hash Password & Create User]
    C --> D{Select Role}

    D -->|Customer| E[CustomerDbRegisteringCommit]
    D -->|Owner| F[OwnerDbRegisteringCommit]
    D -->|Admin| G[AdminDbRegisteringCommit]

    F --> H[CheckNameAndEmailOwner]
    H --> I[ExistChecks]
    I -->|No duplicates| J[Save Owner]

    E --> K[Save Customer]
    G --> L[Save Admin]

    J --> M[Return User ID]
    K --> M
    L --> M
