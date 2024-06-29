﻿namespace API.Entities;

using Microsoft.AspNetCore.Identity;

public class AppRole : IdentityRole<int>
{
    public ICollection<AppUserRole> UserRoles { get; set; } = [];
}
