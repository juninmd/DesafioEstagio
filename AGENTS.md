```markdown
# AGENTS.md - Coding Guidelines

These guidelines are designed to ensure a consistent, well-structured, and maintainable codebase for all AGENTS.md development. Adherence to these principles is crucial for the long-term health and success of the repository.

**1. DRY (Don't Repeat Yourself)**

*   **Module Design:** Each module (e.g., `agents_management`, `agents_logic`, `agents_data`) should focus on a single, well-defined responsibility.
*   **Abstraction:** Identify common patterns and create reusable abstractions. Avoid redundant code.
*   **Single Responsibility Principle:** Each function/class/module should have one clear, well-defined purpose.

**2. KISS (Keep It Simple, Stupid)**

*   **Code Clarity:** Prioritize readability and ease of understanding.  Avoid overly complex logic.
*   **Minimalism:**  Keep code concise and to the point.  Remove unnecessary complexity.
*   **Understandable Names:** Use descriptive names for variables, functions, and classes.

**3. SOLID Principles**

*   **Single Responsibility Principle (SRP):** Classes should have one reason to change.
*   **Open/Closed Principle:** Classes should be open for extension but closed for modification. (Abstraction via interfaces).
*   **Liskov Substitution Principle (LSP):**  Subclasses should be substitutable for their base classes without altering the correctness of the program.
*   **Interface Segregation Principle (ISP):** Clients should not be forced to implement interfaces they don't use.
*   **Dependency Inversion Principle (DIP):** High-level modules should be dependent on low-level modules, not vice versa.

**4. YAGNI (You Aren't Gonna Need It)**

*   **Future-Proofing:** Avoid adding features or code that is not currently required.  Don't implement solutions based on assumptions about future needs.
*   **Iterative Development:**  Progress incrementally.  Add functionality gradually as needed.

**5. Development Workflow**

*   **Pull Requests:** All code changes must be submitted via a well-defined pull request workflow.
*   **Code Reviews:**  All code changes must be reviewed by at least one other developer before merging.
*   **Unit Tests:**  Comprehensive unit tests should be written for all functions and classes.  Aim for >80% test coverage.
*   **Integration Tests:**  Unit tests should be expanded to include integration tests that verify the interaction of multiple components.
*   **Automated Build & Test:** Ensure a consistent and automated build and test process.

**6. Code Formatting & Style**

*   **Consistent Formatting:** Use a consistent code style (e.g., PEP 8 for Python).
*   **Indentation:**  Use 4 spaces for indentation.
*   **Line Length:** Keep lines under 120 characters.
*   **Comments:**  Write clear, concise comments explaining complex logic or non-obvious sections of code. Avoid adding unnecessary comments.

**7.  File Size Limits**

*   **Maximum Code:** 180 lines of code.
*   **File Size:**  Maximum file size of 10MB.

**8. Testing – Focus on Mocking**

*   **No Real Implementations:** All testing must be performed using mocks, stubs, and test frameworks.  Do not use real implementations.
*   **Test Coverage:** Target >80% test coverage.

**9.  File Structure (Example - Adapt to Specific Needs)**

*   `src/agents/management/` -  Core management logic.
*   `src/agents/logic/` -  Agent-specific logic.
*   `src/agents/data/` -  Data handling and storage.
*   `src/utils/` -  Utility functions and helper methods.
*   `src/tests/` -  Unit and integration tests.

**10.  Reporting & Monitoring**

*   **Code Quality Metrics:** Track code complexity, lines of code, and test coverage.
*   **Bug Tracking:**  Maintain a bug tracking system to report and resolve issues.
*   **Code Review History:**  Track code review history for each pull request.

**11.  Documentation**

*   **README.md:**  Provide a README file describing the project, its purpose, and how to run the code.
*   **API Documentation (if applicable):** Document any APIs or interfaces used in the project.

These guidelines are to be interpreted and enforced consistently throughout the project.  Any deviations from these guidelines will be subject to review and potential revision.  All developers are expected to comply with these standards.
```