using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TextStory.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace TextStory.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Story> Stories { get; set; }
        public DbSet<Collection> Collections { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Message>().ToTable("Message");
            builder.Entity<Story>().ToTable("Story")
                .HasMany(m => m.Messages)
                .WithOne(s => s.Story);
            builder.Entity<Collection>().ToTable("Collection");
        }

        


    }

    
    
}
