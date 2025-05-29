namespace AzBina.Domain.Entities;

public class Type:BaseEntity
{
    public string Name { get; set; } = null!;

    public Guid ParentTypeId { get; set; }

   
    public Type? ParentType { get; set; }

   
    public ICollection<Type> SubTypes { get; set; } = new List<Type>();
    public ICollection<Ad> Ads { get; set; }
}
