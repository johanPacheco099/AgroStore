using System.ComponentModel.DataAnnotations.Schema;

namespace AgroStore.Shared;

[Table("shoppingCart", Schema = "public")]
public class ShoppingCart
{
    public int id { get; set; }
    [ForeignKey("Product")]
    public int id_product { get; set; }
    public Product Product { get; set; }

    [ForeignKey("User")]
    public int id_user { get; set; }
    public User User { get; set; }

    public double price { get; set; }

    public int quantity { get; set; }


    public ShoppingCart()
    {

    }
    public ShoppingCart(int id_product, int id_user, int quantity, double price)
    {
        this.id_product = id_product;
        this.id_user = id_user;
        this.quantity = quantity;
        this.price = price;
    }

}
