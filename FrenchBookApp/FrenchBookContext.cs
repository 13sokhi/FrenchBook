using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrenchBookApp
{
    internal class FrenchBookContext: DbContext
    {
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Sentence> Sentences { get; set; }
        public DbSet<Paragraph> Paragraphs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(@"server=localhost;port=3306;database=frenchbook;user id=root;password=1234", new MySqlServerVersion(new Version(8, 0, 37)));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Topic>().HasData(
                    new Topic { TopicId = 1, TopicName = "-er Verbs" },
                    new Topic { TopicId = 2, TopicName = "Aller" },
                    new Topic { TopicId = 3, TopicName = "Avoir" }
                );

            modelBuilder.Entity<Sentence>().HasData(
                    new Sentence { SentenceId = 1, EnglishText = "I am speaking to my friend", FrenchText = "Je parle à mon ami", TopicId = 1 },
                    new Sentence { SentenceId = 2, EnglishText = "He is eating apples", FrenchText = "Il mange des pommes", TopicId = 1 },
                    new Sentence { SentenceId = 3, EnglishText = "I am going to school", FrenchText = "Je vais à l'école" , TopicId = 2},
                    new Sentence { SentenceId = 4, EnglishText = "We are going to the beach", FrenchText = "Nous allons à la plage", TopicId = 2 },
                    new Sentence { SentenceId = 5, EnglishText = "I have a car", FrenchText = "j'ai une voiture", TopicId = 3 }, 
                    new Sentence { SentenceId = 6, EnglishText = "They have a dog", FrenchText = "Ils ont un chien", TopicId = 3 }
                );
        }
    }
}
