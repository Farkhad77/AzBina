namespace AzBina.Domain.Entities;

public class Favorite : BaseEntity
{
    public Guid AdId { get; set; }
    public Ad Ad { get; set; }   
}
