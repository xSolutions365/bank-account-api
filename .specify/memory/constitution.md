<!--
Sync Impact Report (2026-01-13)

Version change: 1.0.0 → 1.1.0 (MINOR: Enhanced technology stack documentation)
Modified principles:
- None (all core principles remain unchanged)
Enhanced sections:
- Technology Stack Requirements: Added specific package dependencies (Swashbuckle, EF Core InMemory, FluentAssertions)
- Technology Stack Requirements: Clarified multi-project solution structure (API + UI + Tests)
- Development Workflow: Added OpenAPI/Swagger documentation requirement
Templates requiring updates:
✅ plan-template.md (constitution check aligns with principles)
✅ spec-template.md (user story prioritization aligns with MVP delivery)
✅ tasks-template.md (user story grouping aligns with independent testing)
⚠ commands/*.md (directory does not exist - no updates needed)
Follow-up TODOs:
None (all placeholders resolved)
-->

# Bank Account Solution Constitution

## Core Principles

### I. API-First
All business logic and data access MUST be exposed via RESTful API endpoints. Endpoints MUST be documented via OpenAPI/Swagger, independently testable, and versioned. No feature is considered complete unless accessible via the API and documented in the Swagger UI.

**Rationale:** Ensures modularity, enables UI and external integrations, supports automated testing, and provides self-documenting API contracts.

### II. Test-First (NON-NEGOTIABLE)
Test-driven development is mandatory. All features MUST have unit and integration tests written before implementation. Red-Green-Refactor cycle is strictly enforced. No code is merged without passing tests.

**Rationale:** Guarantees reliability, prevents regressions, and enables safe refactoring.

### III. UI Integration
The front-end (Razor Pages) MUST consume API endpoints for all user-facing data. UI changes MUST be independently testable and validated via automated UI tests (e.g., Selenium).

**Rationale:** Ensures separation of concerns, enables end-to-end validation, and supports multiple clients.

### IV. Simplicity & Observability
Code and architecture MUST remain simple and maintainable. Structured logging is required for all critical operations. Errors MUST be surfaced clearly to both API and UI clients.

**Rationale:** Reduces technical debt, improves debuggability, and supports rapid onboarding.

### V. Integration Testing
Critical workflows (e.g., account creation, withdrawal, transfer, UI/API sync) MUST have integration tests. Contract changes and inter-service communication MUST be validated before release.

**Rationale:** Ensures system-level reliability and prevents breaking changes.

## Technology Stack Requirements

- **Language**: C# (.NET 8)
- **Solution Structure**: Multi-project solution (BankAccountAPI, BankAccountUI, BankAccountAPI.Tests, BankAccountUI.Tests)
- **API**: ASP.NET Core Web API with Swashbuckle.AspNetCore (OpenAPI/Swagger documentation)
- **UI**: ASP.NET Core Razor Pages
- **Testing**: NUnit, Moq, Selenium WebDriver (UI automation), FluentAssertions
- **Storage**: Entity Framework Core InMemory provider (for demo/testing); production-ready persistence required before production deployment
- **Key Dependencies**: 
  - Microsoft.EntityFrameworkCore.InMemory (v6.0.0+)
  - Swashbuckle.AspNetCore (v6.0.0+)
  - Selenium.WebDriver + ChromeDriver
  - Microsoft.AspNetCore.Mvc.NewtonsoftJson
- All dependencies MUST be open source or approved by maintainers
- Code MUST run on Windows, macOS, and Linux

## Development Workflow

- All changes MUST pass code review and all tests before merge
- Features are developed in branches named `[###-feature-name]`
- User stories MUST be independently testable and delivered as MVP increments
- Edge cases and error scenarios MUST be documented and tested
- All PRs MUST verify compliance with this constitution
- Breaking changes require MAJOR version bump and migration plan

## Governance

- This constitution supersedes all other practices
- Amendments require documentation, approval, and migration plan
- **Versioning follows MAJOR.MINOR.PATCH**:
  - **MAJOR**: Breaking changes to principles or governance
  - **MINOR**: New principles/sections or expanded guidance
  - **PATCH**: Clarifications, typo fixes, non-semantic refinements
- Compliance is reviewed at every release and PR
- Use [README.md](../../README.md) and project docs for runtime development guidance

**Version**: 1.1.0 | **Ratified**: 2026-01-13 | **Last Amended**: 2026-01-13
