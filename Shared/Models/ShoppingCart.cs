namespace AgroStore.Shared;

public class ShoppingCart
{
    public int id { get; set; }
    public int id_product { get; set; }
    public int id_user { get; set; }

    public double price { get; set; }

    public int quantity { get; set; }
    public User? user { get; set; }
    public Product product { get; set; }

    public ShoppingCart() { }

    public ShoppingCart(int Id_product, int Id_user, int Quantity, double Price)
    {
        id_product = Id_product;
        id_user = Id_user;
        price = Price;
        quantity = Quantity;
    }
}
