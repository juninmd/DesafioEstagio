# DesafioEstagio

[![CI/CD Pipeline](https://github.com/juninmd/DesafioEstagio/actions/workflows/ci.yml/badge.svg)](https://github.com/juninmd/DesafioEstagio/actions/workflows/ci.yml)
[![Security Scan](https://github.com/juninmd/DesafioEstagio/actions/workflows/security.yml/badge.svg)](https://github.com/juninmd/DesafioEstagio/actions/workflows/security.yml)
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)
[![.NET Framework](https://img.shields.io/badge/.NET-Framework%204.6.1-blueviolet)](https://dotnet.microsoft.com/)

A .NET Framework console application with full CI/CD pipeline.

## Project Structure

```
DesafioEstagio/
├── DesafioEstagio/           # Main application
│   ├── Program.cs            # Entry point
│   ├── GreetingService.cs    # Greeting logic
│   ├── TimeCalculator.cs     # Time calculation logic
│   ├── App.config            # Application configuration
│   └── Properties/
├── DesafioEstagio.Tests/     # Test project
│   ├── UnitTests/            # Unit tests (business logic)
│   ├── IntegrationTests/     # Integration tests (full flow)
│   ├── E2ETests/             # End-to-end tests (console I/O)
│   └── Properties/
├── .github/workflows/        # GitHub Actions CI/CD
├── .editorconfig             # Code style rules
├── .env.example              # Environment variables template
└── CONTRIBUTING.md           # Contribution guidelines
```

## Prerequisites

- Windows 7+ or Windows Server 2012+
- Visual Studio 2015+ or MSBuild
- .NET Framework 4.6.1 SDK

## Build

```powershell
# Restore packages
nuget restore DesafioEstagio.sln

# Build
msbuild DesafioEstagio.sln /p:Configuration=Release

# Or open DesafioEstagio.sln in Visual Studio
```

## Test

```powershell
# Build tests
msbuild DesafioEstagio.sln /p:Configuration=Debug

# Run tests
vstest.console.exe DesafioEstagio.Tests\bin\Debug\DesafioEstagio.Tests.dll
```

## CI/CD Pipeline

| Stage | Description | Trigger |
|-------|-------------|---------|
| Lint | Code style and static analysis | Every push/PR |
| Test | Run unit, integration, and E2E tests | After lint |
| Security | Secret scanning and vulnerability check | After lint |
| Build | Release build with optimizations | After test |
| Deploy Staging | Auto-deploy to staging | PR to main or push to develop |
| Deploy Production | Manual approval required | Push to main |
| Notify | Build status summary | After all stages |

## Deployment

- **Staging**: Automatically deployed when PRs are merged to `develop`
- **Production**: Requires manual approval via GitHub Environments

## Quality Gates

- Code coverage >= 80%
- All tests must pass
- No security vulnerabilities
- Linting standards enforced
- Files under 180 lines

## Contributing

See [CONTRIBUTING.md](CONTRIBUTING.md) for detailed guidelines.
