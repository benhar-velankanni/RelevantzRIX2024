using System;
using System.Collections.Generic;
using Bookings;
using Cleaner;
using Customers;
using ServiceType;
using Scedule;

namespace C_Sharp_Assessment
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("\n+===================================================================================================================================================+");
                Console.WriteLine("|                                            Home Cleaning Service Scheduler                                                                         |");
                Console.WriteLine("+===================================================================================================================================================+");
                Console.WriteLine("\n1. Bookings\n2. Cleaners\n3. Customers\n4. ServiceTypes\n5. Schedules\n6. Exit");
                Console.WriteLine("Choose an option: ");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        BookingMenu();
                        break;
                    case "2":
                        CleanerMenu();
                        break;
                    case "3":
                        CustomerMenu();
                        break;
                    case "4":
                        ServiceTypeMenu();
                        break;
                    case "5":
                        ScheduleMenu();
                        break;
                    case "6":
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        static void BookingMenu()
        {
            while (true)
            {
                 Console.WriteLine("\n+===================================================================================================================================================+");
                Console.WriteLine("|                                            BOOKINGS                                                                                                 |");
                Console.WriteLine("+===================================================================================================================================================+");
                Console.WriteLine("\n1. Add Booking\n2. View Booking\n3. Update Booking\n4. Delete Booking\n5. Back");
                Console.WriteLine("Choose an option: ");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        BookingMain.AddBooking();
                        break;
                    case "2":
                        BookingMain.ViewBookings();
                        break;
                    case "3":
                        BookingMain.UpdateBooking();
                        break;
                    case "4":
                        BookingMain.DeleteBooking();
                        break;
                    case "5":
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        static void CleanerMenu()
        {
            while (true)
            {
                 Console.WriteLine("\n+===================================================================================================================================================+");
                Console.WriteLine("|                                            CLEANERS                                                                                                 |");
                Console.WriteLine("+===================================================================================================================================================+");
                Console.WriteLine("\n1. Add Cleaner\n2. View Cleaners\n3. Update Cleaner\n4. Delete Cleaner\n5. Back");
                Console.WriteLine("Choose an option: ");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        CleanerMain.AddCleaner();
                        break;
                    case "2":
                        CleanerMain.ViewCleaners();
                        break;
                    case "3":
                        CleanerMain.UpdateCleaner();
                        break;
                    case "4":
                        CleanerMain.DeleteCleaner();
                        break;
                    case "5":
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        static void CustomerMenu()
        {
            while (true)
            {
                 Console.WriteLine("\n+===================================================================================================================================================+");
                Console.WriteLine("|                                            CUSTOMERS                                                                                                |");
                Console.WriteLine("+===================================================================================================================================================+");
                Console.WriteLine("\n1. Add Customer\n2. View Customers\n3. Update Customer\n4. Delete Customer\n5. Back");
                Console.WriteLine("Choose an option: ");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        CustomerMain.AddCustomer();
                        break;
                    case "2":
                        CustomerMain.ViewCustomers();
                        break;
                    case "3":
                        CustomerMain.UpdateCustomer();
                        break;
                    case "4":
                        CustomerMain.DeleteCustomer();
                        break;
                    case "5":
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        static void ServiceTypeMenu()
        {
            while (true)
            {
                 Console.WriteLine("\n+===================================================================================================================================================+");
                Console.WriteLine("|                                            SERVICE TYPES                                                                                            |");
                Console.WriteLine("+===================================================================================================================================================+");
                Console.WriteLine("\n1. Add ServiceType\n2. View ServiceTypes\n3. Update ServiceType\n4. Delete ServiceType\n5. Back");
                Console.WriteLine("Choose an option: ");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        ServiceTypeMain.AddServiceType();
                        break;
                    case "2":
                        ServiceTypeMain.ViewServiceTypes();
                        break;
                    case "3":
                        ServiceTypeMain.UpdateServiceType();
                        break;
                    case "4":
                        ServiceTypeMain.DeleteServiceType();
                        break;
                    case "5":
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        static void ScheduleMenu()
        {
            while (true)
            {
                Console.WriteLine("\n+===================================================================================================================================================+");
                Console.WriteLine("|                                            SCHEDULES                                                                                                  |");
                Console.WriteLine("+===================================================================================================================================================+");
                Console.WriteLine("\n1. Add Schedule\n2. View Schedules\n3. Update Schedule\n4. Delete Schedule\n5. Back");
                Console.WriteLine("Choose an option: ");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        ScheduleMain.AddSchedule();
                        break;
                    case "2":
                        ScheduleMain.ViewSchedules();
                        break;
                    case "3":
                        ScheduleMain.UpdateSchedule();
                        break;
                    case "4":
                        ScheduleMain.DeleteSchedule();
                        break;
                    case "5":
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }
    }
}

