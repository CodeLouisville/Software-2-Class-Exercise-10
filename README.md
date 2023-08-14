# Software 2 - Class Exercise 10
# Goals
- Add a new relationship to your database
- Add a unit test

# Instructions
## Database Relationship
1. Add a new entity called Order.  Give it the following properties:
   - OrderId of type `int`
   - OrderDate of type `Datetime`
   - Products of type `ICollection<Product>`
1. Add a `DbSet` property in the `DbContext` class.
1. Add a new property to `Product` of type `Order` and `OrderId` of type `int`
1. Run a migration and database update.  This is where you could have some errors.  If you have trouble with this part, ask for help from your mentors.
1. Add functionality in to add and view an order.  Be sure to add a new Order repository class.  When adding the code to get an order, don't forget to add `.Include(x=>x.Products)` to make sure that the the code knows to get the products for the order.
1. Here's some JSON you can use to test adding an order with:
	```
	{ "Products": [ {"ProductId": 2, "Name": "Dog bowl", "Description": "A thing that holds food", "Price": 8.99}, {"ProductId": 2, "Name": "Chew toy", "Description": "A thing that dogs chew", "Price": 2.89} ] }
	```

## Unit Testing
1. Create a new project in the solution called `PetStore.Tests`.  When creating this project, you can search for the test template in the dialog, this will make things easier.  Use the "MSTest" project, not the "NUnit".
1. Add the `Moq` nuget package to the test project.
1. Add project references from the test project to the other projects.
1. Add a new class called `ProductLogicTests`.
1. Add a method called `GetProductById_CallsRepo`.  This is a pretty standard test naming convention: the name of the method and what it's passing condition.  In this case, it will pass if it calls the repo.  In this test, that's all we really need to test since it's a pretty simple one.
1. Add the following comments: 
	```
	// Arrange 

	// Act 

	// Assert
	```  
	You don't need these, but they help with organization.
1. In the arrange section. Add variables of type `Mock<IProductRepository>` and `Mock<IOrderRepository>`.
1. "New" up these 2 variables in the constructor of the class.
1. Create a new variable of type `ProductLogic` and use the Mock objects from the previous steps to pass into the constructor of `ProductLogic`.  What you will pass into the constructor are not the mock objects themselves, but the `Object` properties of each. Like this:
	```
	_productLogic = new ProductLogic(_productRepositoryMock.Object, _orderRepositoryMock.Object);
	```
1. Now that you've setup the test class, it's time to set up the individual test.
1. You will need to setup the the repo to retun fake data.  In the arrange section of the test add the following code:
	```
	_productRepositoryMock.Setup(x => x.GetProductById(10))
		.Returns(new Product { ProductId = 10, Name = "test product" });
	```
1. Next in the act section, make the code call the product logic's `GetProductById` and pass in `10`. 
1. In the assert, add the following line of code:
	```
	_productRepositoryMock.Verify(x => x.GetProductById(10), Times.Once);
	```
1. Run the test.  It should pass.
