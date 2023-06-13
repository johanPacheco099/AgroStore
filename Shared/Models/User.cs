using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;


namespace AgroStore.Shared;

public class User 
{
    [Column("id")] 
    public int id {get; set;} 

    public string name {get;set;}

    public string email {get;set;}

    public string password{get;set;}

    public string? cedula{get;set;}

    public string role {get;set;}

    public User()
    {
        
    }

    public User(string Name,string Email,string Password,string Cedula,string Role)
    {
        name = Name;
        email = Email;
        password = Password;
        cedula = Cedula;
        role = Role;
    }
    
    
}