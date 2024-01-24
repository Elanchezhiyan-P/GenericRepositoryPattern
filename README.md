# GenericRepositoryPattern
 The Generic repository pattern is commonly used for data access in C# applications. It provides a generic way to interact with different entities in a database. In this project, I have implemented a separate class library project where I have used the **"Code First"** development approach and created a database from a model, using migration.

# Repository pattern
The repository pattern is intended to create an Abstraction layer between the Data Access layer and the Business Logic layer of an Application. It is a data access pattern that prompts a more loosely coupled approach to data access. We create a generic repository, which queries the data source for the data, maps the data from the data source to a business entity, and persists changes in the business entity to the data source.
