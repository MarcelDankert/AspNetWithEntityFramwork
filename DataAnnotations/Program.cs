using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

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
                #region Create
                // create some entities
                Author tomate = new Author() { FirstName = "Tom", LastName = "Ate" };
                Author marcel = new Author() { FirstName = "Marcel", LastName = "Dankert" };
                Author albertros = new Author() { FirstName = "Albert", LastName = "Tross" };
                Author samurai = new Author() { FirstName = "Sam", LastName = "Urai" };
                Author vielfrass = new Author() { FirstName = "Phil", LastName = "Frass" };
                Author marterpfahl = new Author() { FirstName = "Marta", LastName = "Pfahl" };
                List<Author> authors = new List<Author> { albertros, samurai, vielfrass, marterpfahl };

                List<string> creativeBookTitles = new List<string> {
                    "Lorem","ipsum","dolor","sit","amet, ","consetetur","sadipscing","elitr, ","sed",
                    "diam","nonumy","eirmod","tempor","invidunt","ut","labore","et","dolore","magna",
                    "aliquyam","erat, ","sed","diam","voluptua.","At","vero","eos","et","accusam","et",
                    "justo","duo","dolores","et","ea","rebum.","Stet","clita","kasd","gubergren, ","no",
                    "sea","takimata","sanctus","est","Lorem","ipsum","dolor","sit","amet.","Lorem","ipsum",
                    "dolor","sit","amet, ","consetetur","sadipscing","elitr, ","sed","diam","nonumy","eirmod",
                    "tempor","invidunt","ut","labore","et","dolore","magna","aliquyam","erat, ","sed","diam",
                    "voluptua.","At","vero","eos","et","accusam","et","justo","duo","dolores","et","ea","rebum.",
                    "Stet","clita","kasd","gubergren, ","no","sea","takimata","sanctus","est","Lorem","ipsum",
                    "dolor","sit","amet." };

                Author author = new Author() 
                { 
                    FirstName = "Ned", 
                    LastName = "Flenders", 
                    Books =  new List<Book>
                    {

                        new Book { BookName = "Intro to Java", PricePerUnit = new Random().Next(100, 10000) / 100 },
                        new Book { BookName = "Intro to PHP", PricePerUnit = new Random().Next(100, 10000) / 100 },
                        new Book { BookName = "Intro to Python", PricePerUnit = new Random().Next(100, 10000) / 100 }
                    }
                };

                Author author1 = shopDbContext.Authors.Find(6);

                author1.Books.AddRange(new List<Book>
                    {

                        new Book { BookName = "Intro to Java", PricePerUnit = new Random().Next(100, 10000) / 100 },
                        new Book { BookName = "Intro to PHP", PricePerUnit = new Random().Next(100, 10000) / 100 },
                        new Book { BookName = "Intro to Python", PricePerUnit = new Random().Next(100, 10000) / 100 }
                    }
                );

                // add entities to database like this
                shopDbContext.Authors.Add(tomate);
                shopDbContext.SaveChanges();
                // or like this
                shopDbContext.Add<Author>(author1);
                shopDbContext.AddRange(authors);
                shopDbContext.SaveChanges();
                #endregion

                #region Read

                #endregion

                #region Update
                //Author author4 = shopDbContext.Authors.Find(4);
                //author4.FirstName = "Marty";
                //author4.LastName = "McFly";
                //shopDbContext.Update<Author>(author4);
                //shopDbContext.SaveChanges(); 
                #endregion

                #region Delete
                //// read entities from database
                //Author author0 = shopDbContext.Authors.Find(1);
                //Author author1 = shopDbContext.Authors.Find(2);

                //// remove entities from database like this
                //shopDbContext.Authors.Remove(author0);
                ////shopDbContext.SaveChanges();
                //// or like this
                //shopDbContext.Remove<Author>(author1);
                //shopDbContext.SaveChanges(); 
                #endregion





            }

        }
    }
}
