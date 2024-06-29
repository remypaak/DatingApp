﻿namespace API.Entities;

using Microsoft.AspNetCore.Identity;

public class AppUserRole : IdentityUserRole<int>
{
    public AppUser User  { get; set; } = null!;
    public AppRole Role { get; set; } = null!;
}
