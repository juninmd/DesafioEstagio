# Security Policy

## Supported Versions

| Version | Supported          |
| ------- | ------------------ |
| latest  | :white_check_mark: |

## Reporting a Vulnerability

We take the security of DesafioEstagio seriously. If you believe you have found a security vulnerability, please report it to us as described below.

**Please do not report security vulnerabilities through public GitHub issues.**

Instead, please report them via email to the repository owner.

You should receive a response within 48 hours. If you do not, please follow up to ensure your message was received.

## Security Measures

### Secrets Management
- No secrets, API keys, or credentials are stored in the repository
- All sensitive data must use environment variables
- `.env` files and secret patterns are excluded via `.gitignore`
- Gitleaks is integrated into CI to detect accidental secret commits

### Dependency Security
- Dependabot is configured for automated dependency updates
- Renovate is configured with vulnerability alerting
- Dependencies are scanned in CI/CD pipeline

### Static Analysis
- CodeQL (SAST) is integrated into CI for automated code security analysis
- All pull requests are scanned for security issues
- Security issues must be resolved before merging

### CI/CD Security
- GitHub Actions workflows use least-privilege `permissions:` declarations
- Production deployments require manual approval
- Secrets are stored in GitHub Secrets, never in code

## Security Checklist for Contributors

Before submitting a pull request, ensure:

- [ ] No secrets or credentials are included in the code
- [ ] All user inputs are validated
- [ ] No sensitive data is logged or exposed in error messages
- [ ] Dependencies are up to date (no known vulnerabilities)
- [ ] Code passes all security scans (Gitleaks, CodeQL)

## Vulnerability Disclosure Policy

We follow a coordinated disclosure process:

1. Reporter submits vulnerability details
2. We acknowledge receipt within 48 hours
3. We investigate and develop a fix
4. Fix is deployed and disclosed after a reasonable period
