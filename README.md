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

