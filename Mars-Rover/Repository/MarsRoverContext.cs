using Mars_Rover.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mars_Rover.Repository
{
    public class MarsRoverContext : DbContext
    {
        public MarsRoverContext(DbContextOptions<MarsRoverContext> options) : base(options)
        {

        }

        public MarsRoverContext()
        {


        }

        public DbSet<RoverLog> RoverLog { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoverLog>(entity =>
            {
                entity.ToTable("RoverLog", "public");
                entity.Property(e => e.Id)
                                    .HasColumnName("Id");
                entity.Property(e => e.LogLevel).HasColumnName("LogLevel");
                entity.Property(e => e.Message)
                                    .HasColumnName("Message");
            });
           

        }


    }
}
