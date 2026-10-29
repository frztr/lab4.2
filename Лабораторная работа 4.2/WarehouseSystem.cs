namespace Лабораторная_работа_4._2;

public class WarehouseSystem
{
    public static object AddProduct()
    {
        throw new Exception("Нельзя выполнить добавление без товара");
    }
    
    private static bool APassed;
    
    public static object AddProduct(object o)
    {
        if (o == null)
            throw new Exception("При добавлении товара, товар не может быть null");

        if (o == "")
            throw new Exception("При добавлении товара, имя товара не может быть пустым");

        if (APassed)
            return null;
            APassed = true;
        
        return o;
    }
}