using Microsoft.AspNetCore.Identity;

namespace AzBina.Domain.Entities;

public class AppUser : IdentityUser
{
    public string Fullname { get; set; } = null!;
    public string? RefreshToken { get; set; }
    public DateTime ExpiryDate { get; set; }
}
