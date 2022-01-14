using System;
using Microsoft.EntityFrameworkCore;

namespace MississaugaDbService
{
    public class PetLicensingContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Breed> Breeds { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Pet> Pets { get; set; }

        public string DbPath { get; }

        public PetLicensingContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "petlicensing.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");        
    }
}