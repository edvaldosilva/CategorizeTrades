## CategorizeTrades
Categorize trades in a bank's portfolio

## Object Oriented Programming (OOP) concepts applied:
1. Encapsulation

   Classes like `Trade` encapsulate data `(Value, ClientSector, NextPaymentDate)`, allowing them to be accessed only through public methods or properties, ensuring data integrity.

2. Abstraction
   
   The `ITrade` interface defines the abstraction of what a trade is, without exposing the internal implementation. This allows any class that implements the interface to be treated as a `Trade`, keeping the focus on what the trade does, not how it works.

3. Polymorphism
   
   Using the `ICategory` interface allows you to implement different categories `(ExpiredCategory, HighRiskCategory, MediumRiskCategory)`. The `Classify` method is polymorphic, meaning it can be invoked regardless of the specific type of the category.

4. Inheritance
   
   Although there is no explicit class inheritance, polymorphism is based on the inheritance of the `ICategory` interface. Any new category only needs to implement this interface to be compatible with the categorization system.

5. Inversion of Control (IoC) and Dependency Injection (DI)
    
   `TradeCategorizer` does not create category instances directly, it receives a collection of categories via constructor. This allows flexibility to add new rules without modifying the main class, promoting a more flexible design.

## Design and Architecture Patterns

1. Open/Closed Principle (OCP)
   
   The system is open for extension, but closed for modification. New categories can be added by implementing the `ICategory` interface, without changing the existing code in `TradeCategorizer`.

2. Single Responsibility Principle (SRP)
   
   Each class has a single responsibility. For example, the `Trade` class only handles trade data, and each category implements specific classification logic.

3. Strategy Pattern
   
   Using different category implementations through the `ICategory` interface is an example of a *Strategy Pattern*, where the categorization logic is dynamically selected at runtime.

4. Chain of Responsibility
   
   Categorization follows a chain-like flow, where each category attempts to classify the trade. The loop in the `TradeCategorizer` of the `Categorize` method reflects this pattern, as rules are applied sequentially until a match is found.

5. SOLID
   
   All SOLID principles are applied in the design:

   - SRP: Classes focused on a single responsibility.
   - OCP: Extensible without modifying the code base.
   - LSP (Liskov Substitution Principle): Each `ICategory` implementation can replace the interface without changing the expected behavior.
   - ISP (Interface Segregation Principle): `ICategory` is small and focused on a single functionality.
   - DIP (Dependency Inversion Principle): `TradeCategorizer` depends on abstractions (`ICategory`), not on concrete implementations.
  
## Extensibility and Maintenance

- Extensibility: To add new categories, simply implement `ICategory` and add it to the set of categories in `TradeCategorizer`. This avoids modifications to the core system.
- Maintainability: The system is modular, making it easy to update and fix isolated bugs without affecting the rest of the code.
- Testability: The clear separation between business logic and classification allows for precise and specific unit testing.
  
This approach promotes a clean, flexible design that is prepared for continuous evolution.
