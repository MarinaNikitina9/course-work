using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using kursach.Models;

public static class SeedData
{
    public static async Task InitializeAsync(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

        // Создание ролей, если они не существуют
        string[] roleNames = { "Admin", "Manager", "Client" };
        foreach (var roleName in roleNames)
        {
            var roleExist = await roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }

        // Создание администратора, если он не существует
        var adminUser = await userManager.FindByNameAsync("admin");
        if (adminUser == null)
        {
            var admin = new User
            {
                UserName = "admin",
                Email = "admin@example.com",
                Role = "Admin"
            };

            var createAdmin = await userManager.CreateAsync(admin, "Admin123!");
            if (createAdmin.Succeeded)
            {
                await userManager.AddToRoleAsync(admin, "Admin");
            }
        }

        // Создание менеджера, если он не существует
        var managerUser = await userManager.FindByNameAsync("manager");
        if (managerUser == null)
        {
            var manager = new User
            {
                UserName = "manager",
                Email = "manager@example.com",
                Role = "Manager"
            };

            var createManager = await userManager.CreateAsync(manager, "Manager123!");
            if (createManager.Succeeded)
            {
                await userManager.AddToRoleAsync(manager, "Manager");
            }
        }

        // Создание клиента, если он не существует
        var clientUser = await userManager.FindByNameAsync("client");
        if (clientUser == null)
        {
            var client = new User
            {
                UserName = "client",
                Email = "client@example.com",
                Role = "Client"
            };

            var createClient = await userManager.CreateAsync(client, "Client123!");
            if (createClient.Succeeded)
            {
                await userManager.AddToRoleAsync(client, "Client");
            }
        }
    }
}