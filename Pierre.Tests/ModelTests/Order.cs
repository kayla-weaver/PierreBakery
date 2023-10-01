using System.Collections.Generic;
using Pierre.Models;

namespace Pierre.Tests
{
  [TestClass]
  public class OrderTests
  {
    public class OrderTest : IDisposable
    {
      public void Dispose()
      {
        Order.ClearAll(); // Tests go here
      }
    }

    [TestMethod]
    public void OrderConstructor_CreatesInstanceOfOrder_Order()
    {
      Order newOrder = new Order("test", "test", 5, 1, "bob",DateTime.Now, 1);
      Assert.AreEqual(typeof(Order), newOrder.GetType());
    }

    [TestMethod]
    public void GetTitle_ReturnsTitle_String()
    {
      //Arrange
      string title = "bob's smokehouse";

      //Act
      Order newVendor = new Order(title, "order Pickles", 30, 1, "bob",DateTime.Now, 1);
      string result = newVendor.Title;

      //Assert
      Assert.AreEqual(title, result);
    }

    [TestMethod]
    public void SetDescription_SetDescription_String()
    {
      //Arrange
      string description = "Pickles.";
      Order newOrder = new Order("bobs Store", description, 30, 1, "bob",DateTime.Now, 1);

      //Act
      string updatedDescription = "Turkey leg";
      newOrder.Description = updatedDescription;
      string result = newOrder.Description;

      //Assert
      Assert.AreEqual(updatedDescription, result);
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyList_OrderList()
    {
      // Arrange
      Order.ClearAll();
      List<Order> newList = new List<Order> { };

      // Act
      List<Order> result = Order.GetAll();

      // Assert
      CollectionAssert.AreEqual(newList, result);
    }
    [TestMethod]
    public void GetId_OrdersInstantiateWithAnIdAndGetterReturns_Int()
    {
      //Arrange
      string description = "sourdough bread and cookies.";
      Order newOrder = new Order("bob", description, 15, 1, "bob",DateTime.Now, 1);

      //Act
      int result = newOrder.Id;

      //Assert
      Assert.AreEqual(1, result);
    }
  }
}