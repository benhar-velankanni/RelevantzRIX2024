using Secure_Document_Organiser_DB_First.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Secure_Document_Organiser_DB_First
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DbFOrganiserDbContext>();
            var context = new DbFOrganiserDbContext(optionsBuilder.Options);
            // Ensure the database is created
            context.Database.EnsureCreated();

            while (true)
            {
                Console.WriteLine("=========================");
                Console.WriteLine("Secure Document Organiser");
                Console.WriteLine("=========================");
                Console.WriteLine("1. User");
                Console.WriteLine("2. Folder");
                Console.WriteLine("3. Document");
                Console.WriteLine("4. Exit");

                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        UserMenu(context);
                        break;
                    case 2:
                        FolderMenu(context);
                        break;
                    case 3:
                        DocumentMenu(context);
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }

        private static void UserMenu(DbFOrganiserDbContext context)
        {
            while (true)
            {
                Console.WriteLine("===========");
                Console.WriteLine("User Menu");
                Console.WriteLine("===========");
                Console.WriteLine("1. Add User");
                Console.WriteLine("2. Update User");
                Console.WriteLine("3. Delete User");
                Console.WriteLine("4. View Users");
                Console.WriteLine("5. Back");

                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddUser(context);
                        break;
                    case 2:
                        UpdateUser(context);
                        break;
                    case 3:
                        DeleteUser(context);
                        break;
                    case 4:
                        ViewUsers(context);
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }

        private static void FolderMenu(DbFOrganiserDbContext context)
        {
            while (true)
            {
                Console.WriteLine("=============");
                Console.WriteLine("Folder Menu");
                Console.WriteLine("=============");
                Console.WriteLine("1. Add Folder");
                Console.WriteLine("2. Update Folder");
                Console.WriteLine("3. Delete Folder");
                Console.WriteLine("4. View Folders");
                Console.WriteLine("5. Back");

                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddFolder(context);
                        break;
                    case 2:
                        UpdateFolder(context);
                        break;
                    case 3:
                        DeleteFolder(context);
                        break;
                    case 4:
                        ViewFolders(context);
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }

        private static void DocumentMenu(DbFOrganiserDbContext context)
        {
            while (true)
            {
                Console.WriteLine("==============");
                Console.WriteLine("Document Menu");
                Console.WriteLine("==============");
                Console.WriteLine("1. Add Document");
                Console.WriteLine("2. Update Document");
                Console.WriteLine("3. Delete Document");
                Console.WriteLine("4. View Documents");
                Console.WriteLine("5. Back");

                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddDocument(context);
                        break;
                    case 2:
                        UpdateDocument(context);
                        break;
                    case 3:
                        DeleteDocument(context);
                        break;
                    case 4:
                        ViewDocuments(context);
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }

        private static void AddUser(DbFOrganiserDbContext context)
        {
            Console.Write("Enter user id: ");
            int userId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter username: ");
            string? username = Console.ReadLine();
            Console.Write("Enter password: ");
            string? password = Console.ReadLine();

            var user = new User { Id = userId, Username = username, Password = password };
            context.Users.Add(user);
            context.SaveChanges();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("User added successfully");
            Console.ResetColor();
        }

        private static void UpdateUser(DbFOrganiserDbContext context)
        {
            Console.Write("Enter user id: ");
            int userId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter new username: ");
            string? newUsername = Console.ReadLine();
            Console.Write("Enter new password: ");
            string? newPassword = Console.ReadLine();

            var user = context.Users.Find(userId);
            if (user == null)
            {
                Console.WriteLine("User not found");
                return;
            }

            user.Username = newUsername;
            user.Password = newPassword;
            context.SaveChanges();
            Console.WriteLine("User updated successfully");
        } 

        private static void DeleteUser(DbFOrganiserDbContext context)
        {
            Console.Write("Enter user id: ");
            int userId = Convert.ToInt32(Console.ReadLine());

            var user = context.Users.Find(userId);
            if (user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("User deleted successfully");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("User not found");
            }
        }

        private static void ViewUsers(DbFOrganiserDbContext context)
        {
            var users = context.Users.ToList();
            Console.WriteLine(new string('=', 160));
            Console.WriteLine(String.Format("{0," + ((160 - "  USERS LIST".Length) / 2).ToString() + "}", "  USERS LIST"));
            Console.WriteLine(new string('=', 160));
            foreach (var user in users)
            {
                Console.WriteLine($"| Id: {user.Id,-4} | Username: {user.Username,-15} | Password: {user.Password,-15} |");
            }
            Console.WriteLine(new string('=', 160));
        }

        private static void AddFolder(DbFOrganiserDbContext context)
        {
            Console.Write("Enter folder id: ");
            int folderId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter user id: ");
            int userId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter folder name: ");
            string? folderName = Console.ReadLine();

            var folder = new Folder { Id = folderId, UserId = userId, Name = folderName };
            context.Folders.Add(folder);
            context.SaveChanges();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Folder added successfully");
            Console.ResetColor();
        }

        private static void UpdateFolder(DbFOrganiserDbContext context)
        {
            Console.Write("Enter folder id: ");
            int folderId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter new folder name: ");
            string newFolderName = Console.ReadLine();

            var folder = context.Folders.Find(folderId);
            if (folder != null)
            {
                folder.Name = newFolderName;
                context.SaveChanges();
                Console.WriteLine("Folder updated successfully");
            }
            else
            {
                Console.WriteLine("Folder not found");
            }
        }

        private static void DeleteFolder(DbFOrganiserDbContext context)
        {
            Console.Write("Enter folder id: ");
            int folderId = Convert.ToInt32(Console.ReadLine());

            var folder = context.Folders.Find(folderId);
            if (folder != null)
            {
                context.Folders.Remove(folder);
                context.SaveChanges();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Folder deleted successfully");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("Folder not found");
            }
        }

        private static void ViewFolders(DbFOrganiserDbContext context)
        {
            var folders = context.Folders.Include(f => f.User).ToList();
            Console.WriteLine(new string('=', 160));
            Console.WriteLine(String.Format("{0," + ((160 + "  FOLDERS LIST".Length) / 2).ToString() + "}", "  FOLDERS LIST"));
            Console.WriteLine(new string('=', 160));
            foreach (var folder in folders)
            {
                Console.WriteLine($"| Id: {folder.Id,-4} | Name: {folder.Name,-15} | Created By User: {folder.User.Username,-10} |");
            }
            Console.WriteLine(new string('=', 160));
        }

        private static void AddDocument(DbFOrganiserDbContext context)
        {
            Console.Write("Enter document id: ");
            int documentId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter folder id: ");
            int folderId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter document name: ");
            string? documentName = Console.ReadLine();
            Console.Write("Enter document content: ");
            string? documentContent = Console.ReadLine();

            var document = new Document { Id = documentId, FolderId = folderId, Name = documentName, EncryptedContent = documentContent };
            context.Documents.Add(document);
            context.SaveChanges();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Document added successfully");
            Console.ResetColor();
        }

        private static void UpdateDocument(DbFOrganiserDbContext context)
        {
            Console.Write("Enter document id: ");
            int documentId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter new document name: ");
            string? newDocumentName = Console.ReadLine();
            Console.Write("Enter new document content: ");
            string? newDocumentContent = Console.ReadLine();

            var document = context.Documents.Find(documentId);
            if (document != null)
            {
                document.Name = newDocumentName;
                document.EncryptedContent = newDocumentContent;
                context.SaveChanges();
                Console.WriteLine("Document updated successfully");
            }
            else
            {
                Console.WriteLine("Document not found");
            }
        }

        private static void DeleteDocument(DbFOrganiserDbContext context)
        {
            Console.Write("Enter document id: ");
            int documentId = Convert.ToInt32(Console.ReadLine());

            var document = context.Documents.Find(documentId);
            if (document != null)
            {
                context.Documents.Remove(document);
                context.SaveChanges();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Document deleted successfully");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("Document not found");
            }
        }

        private static void ViewDocuments(DbFOrganiserDbContext context)
        {
            var documents = context.Documents.Include(d => d.Folder).ThenInclude(f => f.User).ToList();
            Console.WriteLine(new string('=', 160));
            Console.WriteLine(String.Format("{0," + ((160 + "DOCUMENTS LIST".Length) / 2).ToString() + "}", "DOCUMENTS LIST"));
            Console.WriteLine(new string('=', 160));
            foreach (var document in documents)
            {
                Console.WriteLine($"| Id: {document.Id,-4} | Name: {document.Name,-15} | In the Folder of : {document.Folder.Name,-15} | Encrypted Content: {document.EncryptedContent,-30} | Created By User: {document.Folder.User.Username,-10} |");
            }
            Console.WriteLine(new string('=', 160));
        }
    }
}


