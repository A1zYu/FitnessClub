using System.ComponentModel.DataAnnotations;

namespace FitnessClub.Domain;

public class Membership
{
    //efCore
    public Membership()
    {
        
    }
    private Membership(string name, string description, decimal price, TypeOfMembership type, int days)
    {
        Name = name;
        Description = description;
        Price = price;
        Type = type;
        Days = days;
    }
    public Guid Id { get;}
    public string Name { get; private set; }
    public string Description { get;private set; }
    public decimal Price { get; private set; }
    public TypeOfMembership Type { get; private set; }
    //public IReadOnlyList<Club> Clubs { get; }
    public int Days { get; private set; }

    public void Update(string name, string description, decimal price, TypeOfMembership type, int days)
    {
        Name = name;
        Description = description;
        Price = price;
        Type = type;
        Days = days;
    } 

    public static Membership Create(
        string name, 
        string description,
        decimal price,
        TypeOfMembership type,
        int days)
    {
        var membership = new Membership(name, description, price, type, days);
        return membership;
    }
}


public enum TypeOfMembership
{
    Free
}