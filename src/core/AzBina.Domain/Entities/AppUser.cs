using Microsoft.AspNetCore.Identity;

namespace AzBina.Domain.Entities;

public class AppUser : IdentityUser
{
    public string Fullname { get; set; } = null!;
}
