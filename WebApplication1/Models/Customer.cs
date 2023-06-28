using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

[Table("Customers")]
public class Customer
{
    [Column("id")]
    public int Id { get; set; }
    [Column("first_name")]
    public string FirstName { get; set; }
    [Column("last_name")]
    public string LastName { get; set; }
    [Column("email")]
    public string Email { get; set; }



    public Customer() { }

    public Customer(int id, string firstName, string lastName, string email)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName; 
        Email = email;  
    }
}