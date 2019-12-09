namespace Data.Migrations
{
    using Data.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.ExaminationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Data.ExaminationContext context)
        {
            context.Topic.AddOrUpdate(
                  t => t.Id,
                  new Topic { Name = "Programming" },
                  new Topic { Name = "DB" },
                  new Topic { Name = "Web" },
                  new Topic { Name = "Operating System" },
                  new Topic { Name = "Design" }
                );

            context.SaveChanges();

            context.Course.AddOrUpdate(
                  c => c.Id,
                  new Course { Name = "HTML", Topic_Id = 3 },
                  new Course { Name = "C Progamming", Topic_Id = 1 },
                  new Course { Name = "OOP", Topic_Id = 1 },
                  new Course { Name = "Unix", Topic_Id = 4 },
                  new Course { Name = "SQL Server", Topic_Id = 2 },
                  new Course { Name = "C#", Topic_Id = 1 },
                  new Course { Name = "Web Service", Topic_Id = 3 },
                  new Course { Name = "Java", Topic_Id = 1 },
                  new Course { Name = "Oracle", Topic_Id = 2 },
                  new Course { Name = "ASP.Net", Topic_Id = 3 },
                  new Course { Name = "Win_XP", Topic_Id = 4 },
                  new Course { Name = "Photoshop", Topic_Id = 5 }
                );
            context.Department.AddOrUpdate(
                d => d.Id,
                  new Department { Name = "SD", Desc = "System Development", Location = "Cairo" },
                  new Department { Name = "EL", Desc = "E-Learning", Location = "Cairo" },
                  new Department { Name = "Java", Desc = "Java", Location = "Cairo" },
                  new Department { Name = "MM", Desc = "Multimedia", Location = "Cairo" },
                  new Department { Name = "Unix", Desc = "Unix", Location = "Cairo" },
                  new Department { Name = "NC", Desc = "Network", Location = "Cairo" },
                  new Department { Name = "EB", Desc = "E-Business", Location = "Cairo" }
                );
            context.Question.AddOrUpdate(
                q => q.Id,
                      new Question
                      {
                          Content = " Martha ,Mary, May, Made Marvelous Milk. In that sentence who made the milk? This is an easy and dumb question!",
                          Answers = new List<Answer>() {
                                                    new Answer{ Content = "Martha" },
                                                    new Answer{ Content = "Mary" },
                                                    new Answer{ Content = "Martha, Mary, May" },
                                                    new Answer{ Content = "May" },
                          }
                      },
                      new Question
                      {
                          Content = "Think Of your favorite animal, place, and color now say one of them! What Did you say?",
                          Answers = new List<Answer>() {
                                                    new Answer{ Content = "Animal" },
                                                    new Answer{ Content = "Place" },
                                                    new Answer{ Content = "Color" },
                                                    new Answer{ Content = "One of them" },
                          }
                      },
                      new Question
                      {
                          Content = "3 people go onto a bus, 3 more people come off, 6 people com on. 3 more people come on. How people are in the bus if 3 come on?",
                          Answers = new List<Answer>() {
                                                    new Answer{ Content = "8" },
                                                    new Answer{ Content = "6" },
                                                    new Answer{ Content = "12" },
                                                    new Answer{ Content = "3" },
                          }
                      },
                      new Question
                      {
                          Content = "Let's say you eat half of a waffle and then eat another half how much have you eaten if you've eaten none?",
                          Answers = new List<Answer>() {
                                                    new Answer{ Content = "1/2" },
                                                    new Answer{ Content = "1" },
                                                    new Answer{ Content = "0" },
                                                    new Answer{ Content = "None of the above" },
                          }
                      },
                      new Question
                      {
                          Content = "What is -100,000 - -100,000? Is it 200,000? And how?",
                          Answers = new List<Answer>() {
                                                    new Answer{ Content = "No this doesn't make any sense! It's 0!" },
                                                    new Answer{ Content = "Oh yes this makes sense because negative minus negative equals positive. " },
                                                    new Answer{ Content = "Correct!" },
                                                    new Answer{ Content = "What Kind of question is this?" },
                          }
                      },
                      new Question
                      {
                          Content = "What is your favorite animal? And now say it.* Hint Hint * This is basically the same question as the other one.",
                          Answers = new List<Answer>() {
                                                    new Answer{ Content = "(Anything)" },
                                                    new Answer{ Content = "(Furry animals)" },
                                                    new Answer{ Content = "It" },
                                                    new Answer{ Content = "(Amphibians,Reptiles, Seal Animals)" },
                          }
                      },
                      new Question
                      {
                          Content = "Where are you?",
                          Answers = new List<Answer>() {
                                                    new Answer{ Content = "Somewhere" },
                                                    new Answer{ Content = "in the U.S" },
                                                    new Answer{ Content = "Here now" },
                                                    new Answer{ Content = "China" },
                          }
                      },
                      new Question
                      {
                          Content = "Here's an easy but dumb riddle. If you sit here, and live here then where do you stand?",
                          Answers = new List<Answer>() {
                                                    new Answer{ Content = "I'm nowhere" },
                                                    new Answer{ Content = "Nowhere" },
                                                    new Answer{ Content = "Here" },
                                                    new Answer{ Content = "I'm not interested" },
                          }
                      },
                      new Question
                      {
                          Content = "Here is another question you will answer correctly!!! ",
                          Answers = new List<Answer>() {
                                                    new Answer{ Content = "Wrong" },
                                                    new Answer{ Content = "Correct" },
                                                    new Answer{ Content = "Correctly" },
                                                    new Answer{ Content = "Wrong" },
                          }
                      },
                      new Question
                      {
                          Content = "Riddle: My shirt is red, my fur is yellow I have no head and I like something sweet! Who am I?",
                          Answers = new List<Answer>() {
                                                    new Answer{ Content = "Dumbo" },
                                                    new Answer{ Content = "Padding ton" },
                                                    new Answer{ Content = "Other" },
                                                    new Answer{ Content = "Yogy bear" },
                          }
                      }
                  );

            context.SaveChanges();
        }
    }
}
