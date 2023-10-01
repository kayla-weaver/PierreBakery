using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pierre.Models;

namespace Pierre.Tests
{
  [TestClass]
  public class VendorTests : IDisposable
  {
    public void Dispose()
    {
      Vendor.ClearAll();
    }
    [TestMethod]
    public void VendorConstructor_CreatesInstanceOfVendor_Vendor()
    {
      Vendor newVendor = new Vendor("test", "test");
      Assert.AreEqual(typeof(Vendor), newVendor.GetType());
    }
    [TestMethod]
    public void GetName_ReturnsName_String()
    {
      //Arrange
      string name = "Test name";
      Vendor newVendor = new Vendor(name, "test");

      //Act
      string result = newVendor.Name;

      //Assert
      Assert.AreEqual(name, result);
    }
    [TestMethod]
    public void GetAll_ReturnsCategoryObjects_Category()
    {
      //Arrange
      string name01 = "taco";
      string name02 = "corndog";
      Vendor newVendor1 = new Vendor(name01, "Tacostore");
      Vendor newVendor2 = new Vendor(name02, "corndog store");
      List<Vendor> newList = new List<Vendor> { newVendor1, newVendor2 };

      //Act
      List<Vendor> newResult = Vendor.GetAll();
      //Assert
      CollectionAssert.AreEqual(newList, newResult);
    }
    [TestMethod]
    public void FindVendor_ReturnCorrectVendor_Vendor()
    {
      //Arrange
      string name01 = "bobs cookhouse";
      string name02 = "sauage palace";
      Vendor newVendor1 = new Vendor(name01, "test");
      Vendor newVendor2 = new Vendor(name02, "test");
      //Act
      Vendor result = Vendor.Find(2);
      //Assert
      Assert.AreEqual(newVendor2, result);
    }
    [TestMethod]
    public void AddOrder_VendorOrderListShowsOrder_Vendor()
    {
      //Arrange
      string name01 = "bobs smokehouse";
      Vendor newVendor1 = new Vendor(name01, "Test");
      Order newOrder1 = new Order("bob", "12dozen", 20, 1, "bob", DateTime.Now, 1);
      List<Order> newVendorOrders = new List<Order> { newOrder1 };
      newVendor1.AddOrder(newOrder1);

      //Act
      List<Order> result = newVendor1.GetOrders();
      //Arrange
      CollectionAssert.AreEqual(newVendorOrders, result);
    }
    [TestMethod]
  public void GetOrders_ReturnsOrderList_Vendor()
  {
    //Arrange
    string name01 = "bobs smokehouse";
    Vendor newVendor1 = new Vendor(name01,"Test");
    Order newOrder1 = new Order ("bob","12dozen",20,1,"bob", DateTime.Now, 1);
    List<Order> newVendorOrders= new List<Order> {newOrder1};
    newVendor1.AddOrder(newOrder1);
    
    //Act
    List<Order> result = newVendor1.GetOrders();
    
    //Assert
     CollectionAssert.AreEqual(newVendorOrders, result);
  }
  [TestMethod]
  public void GetOrderCOunt_ReturnsTheNumberOfOrdersInList_Vendor()
  {
    //Arrange
    string name01 = "bobs smokehouse";
    Vendor newVendor1 = new Vendor(name01,"Test");
    Order newOrder1 = new Order ("bob","12dozen",20,1,"bob", DateTime.Now, 1);
    newVendor1.AddOrder(newOrder1);
    
    
    //Act
    int result = newVendor1.GetOrderCount();
    
   
    //Assert
     Assert.AreEqual(1, result);
  }
  [TestMethod]
  public void GetVendorWithId_returnsCorrectVendor_vendor()
  {
    //Arrange
    string name01 = "bobs smokehouse";
    string name02 = "Suasage Palace";
    Vendor newVendor1 = new Vendor(name01,"Test");
    Vendor newVendor2 = new Vendor(name02,"test");
    List<Vendor> newVendor = new List<Vendor>(){newVendor1,newVendor2};
    
    //Act
    Vendor result = Vendor.GetVendorWithId(1);

    //Assert
    Assert.AreEqual(result, newVendor2);
  }
  [TestMethod]
  public void SearchVendor_returnsCorrectVendor_vendor()
  {
    //Arrange
    string name01 = "Bobs Smokehouse";
    string name02 = "Sausage Palace";
    Vendor newVendor1 = new Vendor(name01,"Test");
    Vendor newVendor2 = new Vendor(name02,"test");

    //Act
    Vendor result = Vendor.SearchVendor("Bobs Smokehouse");

    //Assert
    Assert.AreEqual(newVendor1, result);
  }

  }
}