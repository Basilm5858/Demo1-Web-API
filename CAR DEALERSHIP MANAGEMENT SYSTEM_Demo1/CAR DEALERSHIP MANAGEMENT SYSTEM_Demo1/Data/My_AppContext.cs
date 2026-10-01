using System.ComponentModel;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.Models;
using Microsoft.EntityFrameworkCore;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.Data
{
    public class My_AppContext : DbContext
    {
        public My_AppContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerProfile> CustomerProfiles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Sale> Sales { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Vehicle>().HasIndex(c => c.VIN).IsUnique();
            modelBuilder.Entity<Customer>().HasIndex(c => c.Email).IsUnique();
            modelBuilder.Entity<Customer>().HasIndex(c => c.DriverLicenseNumber).IsUnique();
            modelBuilder.Entity<Employee>().HasIndex(c => c.Email).IsUnique();
            modelBuilder.Entity<Vehicle>().Property(v => v.Price).HasPrecision(12,2);
            modelBuilder.Entity<Sale>().Property(v => v.SalePrice).HasPrecision(12,2);
            modelBuilder.Entity<Vehicle>().Property(v => v.Status).HasDefaultValue("Available");

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Vehicles)
                .WithOne(v => v.Category)
                .HasForeignKey(v => v.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Sales)
                .WithOne(s => s.Customer)
                .HasForeignKey(s => s.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Employee>()
               .HasMany(e => e.Sales)
               .WithOne(s => s.Employee)
               .HasForeignKey(x => x.EmployeeId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Vehicle>()
                .HasOne(x => x.Sale)
                .WithOne(s => s.Vehicle)
                .HasForeignKey<Sale>(s => s.VehicleId);

            modelBuilder.Entity<Customer>()
               .HasOne(x => x.CustomerProfile)
               .WithOne(s => s.Customer)
               .HasForeignKey<CustomerProfile>(s => s.CustomerId);

            modelBuilder.Entity<Category>().HasData(new Category { Id = 1, Name = "Sedan", Description = "Comfortable passenger cars" });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 2, Name = "SUV", Description = "Sport utility vehicles" });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 3, Name = "Hatchback", Description = "Compact practical cars" });

            modelBuilder.Entity<Vehicle>().HasData(new Vehicle { Id = 1, Make = "Toyota", Model = "Corolla", Year = 2024, Color = "White", Price = 650000, Mileage = 12000, VIN = "VIN00000000000001", FuelType = "Petrol", Transmission = "Automatic", Status = "Available", CategoryId = 1 });
            modelBuilder.Entity<Vehicle>().HasData(new Vehicle { Id = 2, Make = "Hyundai", Model = "Elantra", Year = 2023, Color = "Black", Price = 590000, Mileage = 18000, VIN = "VIN00000000000002", FuelType = "Petrol", Transmission = "Automatic", Status = "Available", CategoryId = 2 });
            modelBuilder.Entity<Vehicle>().HasData(new Vehicle { Id = 3, Make = "Kia", Model = "Sportage", Year = 2024, Color = "Gray", Price = 980000, Mileage = 9000, VIN = "VIN00000000000003", FuelType = "Petrol", Transmission = "Automatic", Status = "Available", CategoryId = 3 });

            modelBuilder.Entity<Customer>().HasData(new Customer { Id = 1, FullName = "Ahmed Hassan", Email = "ahmed.hassan@example.com", PhoneNumber = "01010000001", DriverLicenseNumber = "DL100001" });
            modelBuilder.Entity<Customer>().HasData(new Customer { Id = 2, FullName = "Mona Adel", Email = "mona.adel@example.com", PhoneNumber = "01010000002", DriverLicenseNumber = "DL100002" });
            modelBuilder.Entity<Customer>().HasData(new Customer { Id = 3, FullName = "Omar Khaled", Email = "omar.khaled@example.com", PhoneNumber = "01010000003", DriverLicenseNumber = "DL100003" });


            modelBuilder.Entity<CustomerProfile>().HasData(new CustomerProfile { Id = 1, Address = "12 Nile St.", City = "Cairo", Nationality = "Egyptian", DateOfBirth = DateTime.Now.AddDays(1992 - 03 - 12), CustomerId = 1 });
            modelBuilder.Entity<CustomerProfile>().HasData(new CustomerProfile { Id = 2, Address = "25 Tahrir St.", City = "Giza", Nationality = "Egyptian", DateOfBirth = DateTime.Now.AddDays(1995 - 07 - 24), CustomerId = 2 });
            modelBuilder.Entity<CustomerProfile>().HasData(new CustomerProfile { Id = 3, Address = "12 Nile St.", City = "Cairo", Nationality = "Egyptian", DateOfBirth = DateTime.Now.AddDays(1988 - 11 - 05), CustomerId = 3 });

            modelBuilder.Entity<Employee>().HasData(new Employee { Id = 1, FullName = "Mostafa Nabil", Position = "Sales Manager", Email = "mostafa.nabil@autodrive.com", Phone = "01020000001", HireDate = DateTime.Now.AddDays(2021 - 01 - 10) });
            modelBuilder.Entity<Employee>().HasData(new Employee { Id = 2, FullName = "Aya Emad", Position = "Sales Consultant", Email = "aya.emad@autodrive.com", Phone = "01020000002", HireDate = DateTime.Now.AddDays(2021 - 01 - 10) });
            modelBuilder.Entity<Employee>().HasData(new Employee { Id = 3, FullName = "Hassan Ali", Position = "Sales Consultant", Email = "hassan.ali@autodrive.com", Phone = "01020000003", HireDate = DateTime.Now.AddDays(2021 - 01 - 10) });


            modelBuilder.Entity<Sale>().HasData(new Sale { Id = 1, SaleDate = DateTime.Now.AddDays(2026 - 08 - 15), SalePrice = 1750000, PaymentMethod = "Bank Transfer", Notes = "Completed sale.", CustomerId = 1, EmployeeId = 1, VehicleId = 1 });
            modelBuilder.Entity<Sale>().HasData(new Sale { Id = 2, SaleDate = DateTime.Now.AddDays(2026 - 08 - 22), SalePrice = 1850000, PaymentMethod = "Bank Transfer", Notes = "Completed sale.", CustomerId = 2, EmployeeId = 2, VehicleId = 2 });
            modelBuilder.Entity<Sale>().HasData(new Sale { Id = 3, SaleDate = DateTime.Now.AddDays(2026 - 09 - 05), SalePrice = 510000, PaymentMethod = "Cash", Notes = "Completed sale.", CustomerId = 3, EmployeeId = 3, VehicleId = 3 });

            base.OnModelCreating(modelBuilder);
        }
    }
}
