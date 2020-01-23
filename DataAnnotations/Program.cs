using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAnnotations
{
    [Table("Author")]//Custum Tablename, if different from Classname
    class Author
    {
        public int AuthorId { get; set; }

        [MaxLength(15)]
        [MinLength(5)]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(15)]
        [Required]
        public string LastName { get; set; }

        [NotMapped]
        public string FullName { get { return FirstName + " " + LastName; } }
        public List<Book> Books { get; set; }
    }

    [Table("Book")]
    class Book
    {
        [Key, Column(Order = 0)]
        public int BookId { get; set; }

        [Column(Order = 1)]
        public string BookName { get; set; }

        [Column(Order = 2)]
        [ConcurrencyCheck]
        [Required]
        public double PricePerUnit { get; set; }

        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedOn { get; set; }

        [Column(Order = 4)]
        [ForeignKey("BookAuthor")]
        public int AuthorId { get; set; }

        public Author Author { get; set; }

    }

    /// <summary>
    /// This class handles the database connection and is performing the crud operations
    /// </summary>
    class ShopDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Connection string for database
            optionsBuilder.UseSqlServer(@"Server=MCL-DESKTOP-HOM\SQLEXPRESS;Database=BookShopDb;Trusted_Connection=True;");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //// create context object
            //ShopDbContext shopDbContext = new ShopDbContext();

            //// release blocked resources after finished, same as closing streams or reader. better write this into using block
            //shopDbContext.Dispose();

            using (ShopDbContext shopDbContext = new ShopDbContext())
            {
                // create some entities
                Author tomate = new Author() { FirstName = "Tom", LastName = "Ate" };
                Author marcel = new Author() { FirstName = "Marcel", LastName = "Dankert" };

                // add entities to database like this
                shopDbContext.Authors.Add(tomate);
                shopDbContext.SaveChanges();
                // or like this
                shopDbContext.Add<Author>(marcel);
                shopDbContext.SaveChanges();

                // read entities from database
                shopDbContext.Authors.Find(3);
            }

        }
    }
}
