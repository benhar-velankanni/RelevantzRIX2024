using Microsoft.EntityFrameworkCore;
using ArtCodefirst.Models;

namespace ArtCodefirst
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var context = new ArtCodefirstDbContext();
            context.Database.EnsureCreated();

            Console.WriteLine("Welcome to the Art Learning Platform!");

            int choice;
            do
            {
                Console.WriteLine("Enter your choice:");
                Console.WriteLine("1. User Menu");
                Console.WriteLine("2. Lesson Menu");
                Console.WriteLine("3. Challenge Menu");
                Console.WriteLine("4. Exit");

                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        UserMenu(context);
                        break;
                    case 2:
                        LessonMenu(context);
                        break;
                    case 3:
                        ChallengeMenu(context);
                        break;
                    case 4:
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            } while (choice != 4);
        }

        private static void UserMenu(ArtCodefirstDbContext context)
        {
            int choice;
            do
            {
                Console.WriteLine("User Menu:");
                Console.WriteLine("1. Create a new user");
                Console.WriteLine("2. Display all users");
                Console.WriteLine("3. Update a user");
                Console.WriteLine("4. Delete a user");
                Console.WriteLine("5. Back to main menu");

                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter your First name:");
                        var firstName = Console.ReadLine();

                        Console.WriteLine("Enter your Last name:");
                        var lastName = Console.ReadLine();

                        Console.WriteLine("Enter your Email:");
                        var email = Console.ReadLine();

                        Console.WriteLine("Enter your Password:");
                        var password = Console.ReadLine();

                        var user = new User
                        {
                            FirstName = firstName,
                            LastName = lastName,
                            Email = email,
                            Password = password
                        };

                        context.Users.Add(user);
                        context.SaveChanges();

                        Console.WriteLine("User created successfully!");
                        break;

                    case 2:
                        var users = context.Users.ToList();
                        foreach (var User in users)
                        {
                            Console.WriteLine($"User ID: {User.UserId}, First Name: {User.FirstName}, Last Name: {User.LastName}, Email: {User.Email}, Password: {User.Password}");
                        }
                        break;

                    case 3:
                        Console.WriteLine("Enter the ID of the user you want to update:");
                        var userIdToUpdate = int.Parse(Console.ReadLine());

                        var userToUpdate = context.Users.Find(userIdToUpdate);
                        if (userToUpdate != null)
                        {
                            Console.WriteLine("Enter the new First name:");
                            userToUpdate.FirstName = Console.ReadLine();

                            Console.WriteLine("Enter the new Last name:");
                            userToUpdate.LastName = Console.ReadLine();

                            Console.WriteLine("Enter the new Email:");
                            userToUpdate.Email = Console.ReadLine();

                            Console.WriteLine("Enter the new Password:");
                            userToUpdate.Password = Console.ReadLine();

                            context.SaveChanges();
                            Console.WriteLine("User updated successfully!");
                        }
                        else
                        {
                            Console.WriteLine("User not found.");
                        }
                        break;

                    case 4:
                        Console.WriteLine("Enter the ID of the user you want to delete:");
                        var userIdToDelete = int.Parse(Console.ReadLine());

                        var userToDelete = context.Users.Find(userIdToDelete);
                        if (userToDelete != null)
                        {
                            context.Users.Remove(userToDelete);
                            context.SaveChanges();
                            Console.WriteLine("User deleted successfully!");
                        }
                        else
                        {
                            Console.WriteLine("User not found.");
                        }
                        break;

                    case 5:
                        Console.WriteLine("Returning to main menu...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            } while (choice != 5);
        }

        private static void LessonMenu(ArtCodefirstDbContext context)
        {
            int choice;
            do
            {
                Console.WriteLine("Lesson Menu:");
                Console.WriteLine("1. Add a lesson");
                Console.WriteLine("2. Display all lessons");
                Console.WriteLine("3. Update a lesson");
                Console.WriteLine("4. Delete a lesson");
                Console.WriteLine("5. Back to main menu");

                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter the title of the lesson:");
                        var title = Console.ReadLine();

                        Console.WriteLine("Enter the description of the lesson:");
                        var description = Console.ReadLine();

                        var lesson = new Lesson
                        {
                            Title = title,
                            Description = description
                        
                        };

                        context.Lessons.Add(lesson);
                        context.SaveChanges();

                        Console.WriteLine("Lesson added successfully!");
                        break;

                    case 2:
                        var lessons = context.Lessons.ToList();
                        foreach (var Lesson in lessons)
                        {
                            Console.WriteLine($"Lesson ID: {Lesson.LessonId}, Title: {Lesson.Title}, Description: {Lesson.Description}");
                        }
                        break;

                    case 3:
                        Console.WriteLine("Enter the ID of the lesson you want to update:");
                        var lessonIdToUpdate = int.Parse(Console.ReadLine());

                        var lessonToUpdate = context.Lessons.Find(lessonIdToUpdate);
                        if (lessonToUpdate != null)
                        {
                            Console.WriteLine("Enter the new title:");
                            lessonToUpdate.Title = Console.ReadLine();

                            Console.WriteLine("Enter the new description:");
                            lessonToUpdate.Description = Console.ReadLine();

                            context.SaveChanges();
                            Console.WriteLine("Lesson updated successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Lesson not found.");
                        }
                        break;

                    case 4:
                        Console.WriteLine("Enter the ID of the lesson you want to delete:");
                        var lessonIdToDelete = int.Parse(Console.ReadLine());

                        var lessonToDelete = context.Lessons.Find(lessonIdToDelete);
                        if (lessonToDelete != null)
                        {
                            context.Lessons.Remove(lessonToDelete);
                            context.SaveChanges();
                            Console.WriteLine("Lesson deleted successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Lesson not found.");
                        }
                        break;

                    case 5:
                        Console.WriteLine("Returning to main menu...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            } while (choice != 5);
        }

        private static void ChallengeMenu(ArtCodefirstDbContext context)
        {
            int choice;
            do
            {
                Console.WriteLine("Challenge Menu:");
                Console.WriteLine("1. Add a challenge");
                Console.WriteLine("2. Display all challenges");
                Console.WriteLine("3. Update a challenge");
                Console.WriteLine("4. Delete a challenge");
                Console.WriteLine("5. Back to main menu");

                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter the title of the challenge:");
                        var challengeTitle = Console.ReadLine();

                        Console.WriteLine("Enter the description of the challenge:");
                        var challengeDescription = Console.ReadLine();

                        var challenge = new Challenge
                        {
                            Title = challengeTitle,
                            Description = challengeDescription
                        };

                        context.Challenges.Add(challenge);
                        context.SaveChanges();

                        Console.WriteLine("Challenge added successfully!");
                        break;

                    case 2:
                        var challenges = context.Challenges.ToList();
                        foreach (var Challenge in challenges)
                        {
                            Console.WriteLine($"Challenge ID: {Challenge.ChallengeId}, Title: {Challenge.Title}, Description: {Challenge.Description}");
                        }
                        break;

                    case 3:
                        Console.WriteLine("Enter the ID of the challenge you want to update:");
                        var challengeIdToUpdate = int.Parse(Console.ReadLine());

                        var challengeToUpdate = context.Challenges.Find(challengeIdToUpdate);
                        if (challengeToUpdate != null)
                        {
                            Console.WriteLine("Enter the new title:");
                            challengeToUpdate.Title = Console.ReadLine();

                            Console.WriteLine("Enter the new description:");
                            challengeToUpdate.Description = Console.ReadLine();

                            context.SaveChanges();
                            Console.WriteLine("Challenge updated successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Challenge not found.");
                        }
                        break;

                    case 4:
                        Console.WriteLine("Enter the ID of the challenge you want to delete:");
                        var challengeIdToDelete = int.Parse(Console.ReadLine());

                        var challengeToDelete = context.Challenges.Find(challengeIdToDelete);
                        if (challengeToDelete != null)
                        {
                            context.Challenges.Remove(challengeToDelete);
                            context.SaveChanges();
                            Console.WriteLine("Challenge deleted successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Challenge not found.");
                        }
                        break;

                    case 5:
                        Console.WriteLine("Returning to main menu...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            } while (choice != 5);
        }
    }
}

