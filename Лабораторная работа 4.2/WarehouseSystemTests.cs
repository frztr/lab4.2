using System.Reflection;
using Лабораторная_работа_4._2;

public class WarehouseSystemTests
{
    public WarehouseSystemTests()
    {
        typeof(WarehouseSystem)
            .GetField("APassed", BindingFlags.Static | BindingFlags.NonPublic)!
            .SetValue(null, false);
    }
    
    [Fact]
    public void CorrectBuild()
    {
    }
    
    [Fact]
    public void AddProductExists()
    {
        WarehouseSystem.AddProduct("A");
    }
    
    [Fact]
    public void AddProductCannotReturnsNothing()
    {
         MethodInfo method = typeof(WarehouseSystem).GetMethod("AddProduct", Type.EmptyTypes);
         Assert.NotEqual(typeof(void),method.ReturnType);
    }
    
    [Fact]
    public void AddProductReturnsProduct()
    {
        Assert.Equal(WarehouseSystem.AddProduct("Milk"), "Milk");
    }
    
    [Fact]
    public void AddProductReturnsProductBread()
    {
        Assert.Equal(WarehouseSystem.AddProduct("Bread"), "Bread");
    }
    
    [Fact]
    public void AddProductPassSugarReturnsSugar()
    {
        Assert.Equal(WarehouseSystem.AddProduct("Sugar"), "Sugar");
    }
    
    [Fact]
    public void AddProductPassButterReturnsButter()
    {
        Assert.Equal(WarehouseSystem.AddProduct("Butter"), "Butter");
    }
    
    [Fact]
    public void AddProductCannotAddNothing()
    {
        Object product = null;
        try
        {
            product = WarehouseSystem.AddProduct();
        }
        catch
        {
            
        }
        Assert.Null(product);
    }
    
    [Fact]
    public void AddProductMustThrowExceptionOnAddNothing()
    {
        Assert.Throws<Exception>(()=>WarehouseSystem.AddProduct());
    }
    
    [Fact]
    public void AddProductMustThrowExceptionWithReasonOnAddNothing()
    {
        Exception ex = Assert.Throws<Exception>(()=>WarehouseSystem.AddProduct());
        Assert.Equal("Нельзя выполнить добавление без товара", ex.Message);
    }
    
    [Fact]
    public void AddProductThrowsExceptionOnAddNull()
    {
        Exception ex = Assert.Throws<Exception>(()=>WarehouseSystem.AddProduct(null));
    }
    
    [Fact]
    public void AddProductThrowsExceptionWithMessageOnAddNull()
    {
        Exception ex = Assert.Throws<Exception>(()=>WarehouseSystem.AddProduct(null));
        Assert.Equal("При добавлении товара, товар не может быть null", ex.Message);
    }
    
    [Fact]
    public void AddProductThrowsExceptionOnAddProductEmptyString()
    {
        Assert.Throws<Exception>(()=>WarehouseSystem.AddProduct(""));
    }
    
    [Fact]
    public void AddProductThrowsExceptionWithMessageOnAddProductEmptyString()
    {
        Exception ex = Assert.Throws<Exception>(()=>WarehouseSystem.AddProduct(""));
        Assert.Equal("При добавлении товара, имя товара не может быть пустым", ex.Message);
    }
    
    [Fact]
    public void AddProductCannotAddProductTwice()
    {
        Assert.NotNull(WarehouseSystem.AddProduct("A"));
        Assert.Null(WarehouseSystem.AddProduct("A"));
    }
}