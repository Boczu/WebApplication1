using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

[Table("Transaction")]
public class Transaction
{
    [Column("id")]
    public int Id { get; set; }
    [Column("customer_id")]
    public int Customerid { get; set; }
    [Column("product_id")]
    public int Productid { get; set; }
    [Column("quantity")]
    public int Quantity { get; set; }
    



    public Transaction() { }

    public Transaction(int id, int customerId, int productId, int quantity)
    {
        Id = id;
        Customerid = customerId;
        Productid = productId;
        Quantity = quantity;
    }   
}