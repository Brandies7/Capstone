﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FamilyPlanner.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public byte[] UserPhoto { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Events> Events { get; set; }
        public DbSet<Parent> Parent { get; set; }
        public DbSet<Child> Child { get; set; }
        public DbSet<ToDoList> ToDo { get; set; }
        public DbSet<ShoppingList> ShoppingList { get; set; }
        public DbSet<Chores> Chores { get; set; }
        public DbSet<SendEmail> SendEmail { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Inbox> Inbox { get; set; }

    }
}