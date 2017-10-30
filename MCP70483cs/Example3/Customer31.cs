using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace MCP70483cs.Example3
{
    public class Customer31
    {
        public int Id { get; set; }

        [Required, MaxLength(20)]
        public string FirstName { get; set; }

        [Required, MaxLength(20)]
        public string LastName { get; set; }

        [Required]
        public Address31 ShippingAddress { get; set; }

        [Required]
        public Address31 BillingAddress { get; set; }


    }

    public class Address31
    {
        public int Id { get; set; }

        [Required, MaxLength(20)]
        public string AddressLine1 { get; set; }

        [Required, MaxLength(20)]
        public string AddressLine2 { get; set; }

        [Required, MaxLength(20)]
        public string City { get; set; }

        [RegularExpression(@"^[1-9][0-9]{3}\s?[a-zA-Z]{2}$")]
        public string ZipCode { get; set; }
    }

    public class ShopContext : DbContext
    {
        public IDbSet<Customer31> Customer31s { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Console.WriteLine("on model creating event !!");

            // make sure the database knows how to handle the duplicate address property
            modelBuilder.Entity<Customer31>().HasRequired(bm => bm.BillingAddress)
                .WithMany()
                .WillCascadeOnDelete(false);
        }
    }

    public class Example3_2
    {
        public static void DoProc()
        {
            using (ShopContext ctx = new ShopContext())
            {
                Address31 a = new Address31()
                {
                    AddressLine1 = "somewhere 1",
                    AddressLine2 = "at some floor",
                    City = "some city",
                    ZipCode = "0999aZ",
                };
                Customer31 c = new Customer31()
                {
                    FirstName = "John",
                    LastName = "Doe",
                    BillingAddress = a,
                    ShippingAddress = a,
                };
                var results = GenericValidator<Customer31>.Validate(c);
                foreach (var result in results)
                {
                    Console.WriteLine(result.ToString());
                }
                // regex could not be an error, required could be an error.
                // what is difference?
                results = GenericValidator<Address31>.Validate(a);
                foreach (var result in results)
                {
                    Console.WriteLine(result.ToString());
                }
                ctx.Customer31s.Add(c);
                ctx.SaveChanges();
            }
        }
    }

    public static class GenericValidator<T>
    {
        public static IList<ValidationResult> Validate(T entity)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(entity, null, null);
            Validator.TryValidateObject(entity, context, results);
            return results;
        }
    }
}
