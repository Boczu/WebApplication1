using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

[Table("Products")]
public class Product
{
    [Column("id")]
    public int Id { get; set; }
    [Column("name")]    
    public string Name { get; set; }
    [Column("price")]
    public float Price { get; set; }



    public Product() { }

    public Product(int id, string name, float price)
    {
        Id = id;
        Name = name;
        Price = price;

    }
}