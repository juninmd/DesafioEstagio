# Contributing to DesafioEstagio

## Development Workflow

1. Fork the repository
2. Create a feature branch from `main`
3. Make your changes
4. Run tests locally
5. Submit a pull request

## CI/CD Pipeline

This project uses GitHub Actions for CI/CD.

### Pipeline Stages

| Stage | Description | Required |
|-------|-------------|----------|
| Lint | Code style and static analysis | Yes |
| Test | Unit, integration, and E2E tests | Yes |
| Security | Vulnerability and secret scanning | Yes |
| Build | Release build with optimizations | Yes |
| Deploy (Staging) | Auto-deploy on PR/develop | Conditional |
| Deploy (Production) | Manual approval required | Conditional |
| Notify | Status notifications | Yes |

### Before Submitting a PR

- [ ] Run `msbuild DesafioEstagio.sln /t:Build` to verify the build
- [ ] Run all tests with `vstest.console.exe DesafioEstagio.Tests\bin\Debug\DesafioEstagio.Tests.dll`
- [ ] Ensure code coverage is above 80%
- [ ] Follow the coding style defined in `.editorconfig`
- [ ] Keep files under 180 lines of code
- [ ] Update documentation if needed

### Code Quality Gates

- All linting checks must pass
- All tests must pass
- No security vulnerabilities in dependencies
- Code coverage >= 80%
- No secrets committed to the repository

### Testing Requirements

- Write unit tests for all new business logic
- Add integration tests for API interactions
- Include E2E tests for critical user flows
- Use mocks/stubs instead of real implementations

### Deployment

- **Staging**: Automatically deployed on PR merge to `develop`
- **Production**: Requires manual approval via GitHub Environments

### Environment Variables

See `.env.example` for required environment variables.

### Getting Help

Open an issue on GitHub for questions or concerns.
