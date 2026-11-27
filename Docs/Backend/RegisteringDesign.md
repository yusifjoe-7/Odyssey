# Registering Design

The Registering process uses a Strategy-like approach to handle user registration based on the selected role.

- **RegisteringCommand:** Holds the registration data.
- **RegisteringCommandHandler:** Hashes the password, creates the base User object, and selects the appropriate commit based on the requested role.
- **IDbRegisteringCommit:** Defines a shared contract for persisting users.
- **Role-specific Commits:** Each implementation handles assigning the role and saving the user into its corresponding DbSet (Customer, Owner, or Admin).

## Registration Flow

```mermaid
flowchart TD
    A[RegisteringCommand] --> B[RegisteringCommandHandler]
    B --> C[Hash Password & Create User]
    C --> D{Select Role}
    D -->|Customer| E[CustomerDbRegisteringCommit]
    D -->|Owner| F[OwnerDbRegisteringCommit]
    D -->|Admin| G[AdminDbRegisteringCommit]
    E --> H[Save Changes]
    F --> H
    G --> H
    H --> I[Return User ID]
