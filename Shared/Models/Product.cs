using System.ComponentModel.DataAnnotations.Schema;

namespace AgroStore.Shared;

public class Product
{
    [Column("id")] 
    public int id { get; set; } 
    public string name { get; set; }
    [Column("description")] 
    public string description { get; set; }
    public int quantity{get;set;}
    public double price{get; set;}
    public string image { get; set; }  // Propiedad de navegación

    public Product(){}

    public Product(string Name, string Description, int Quantity, string Image, float Price)
    {
        
        name = Name;
        description = Description;
        quantity = Quantity;
        image = Image;
        price = Price;
    }


}
