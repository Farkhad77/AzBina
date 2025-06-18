using Microsoft.AspNetCore.Identity;

namespace AzBina.Domain.Entities;

public class AppUser : IdentityUser
{
    public string FullName { get; set; } = null!;
}
