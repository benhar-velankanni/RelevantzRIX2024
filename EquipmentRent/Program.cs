using System;
using MySql.Data.MySqlClient;

namespace EquipmentRental
{
    class Program
    {
        static string connectionString = "Server=localhost;Database=rental;user=root;Password=root;";


        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Menu");
                Console.WriteLine("1. Add a new equipment");
                Console.WriteLine("2. View all equipment");
                Console.WriteLine("3. Update an equipment");
                Console.WriteLine("4. Delete an equipment");
                Console.WriteLine("5. Search an equipment");
                Console.WriteLine("6. Rent an Equipment");
                Console.WriteLine("7. View Rented Details");
                Console.WriteLine("9. Maintanence");
                Console.WriteLine("8. Exit");
                Console.WriteLine("Enter your choice: ");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddEquipment();
                        break;
                    case "2":
                        ViewAllEquipment();
                        break;
                    case "3":
                        UpdateEquipment();
                        break;
                    case "4":
                        DeleteEquipment();
                        break;
                    case "5":
                        SearchEquipment();
                        break;
                    case "6":
                        RentEquipment();
                        break;
                    case "7":
                        ViewRentedDetails();
                        break;
                    case "9":
                        Maintanence();
                        break;
                    case "8":
                        Console.WriteLine("Thankyou Visit Again! :)");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }


        static void AddEquipment()
        {
            Console.WriteLine("Enter the name of the equipment: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the description of the equipment: ");
            string description = Console.ReadLine();
            Console.WriteLine("Enter the price of the equipment: ");
            string price = Console.ReadLine();
            Console.WriteLine("Enter the quantity of the equipment: ");
            string quantity = Console.ReadLine();
            Console.WriteLine("Enter the category of the equipment: ");
            string category = Console.ReadLine();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO equipment (name, description, price, quantity, category) VALUES (@name, @description, @price, @quantity, @category)";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@description", description);
                    command.Parameters.AddWithValue("@price", price);
                    command.Parameters.AddWithValue("@quantity", quantity);
                    command.Parameters.AddWithValue("@category", category);
                    command.ExecuteNonQuery();
                }
            }
            Console.WriteLine("Equipment added successfully!");
        }

        static void SearchEquipment()
        {
            Console.WriteLine("Enter the name of the equipment to search: ");
            string name = Console.ReadLine();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM equipment WHERE name LIKE @name";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", "%" + name + "%");
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(reader["name"] + " - " + reader["description"]);
                        }
                    }
                }
            }
        }
        static void ViewAllEquipment()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM equipment";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        Console.WriteLine("Inventory:");
                        while (reader.Read())
                        {

                            Console.WriteLine(reader["name"] + " - " + reader["description"] + " - " + reader["price"] + " - " + reader["quantity"]);
                            Console.WriteLine("-----------------------------");
                        }
                    }
                }
            }
        }
        static void UpdateEquipment()
        {
            Console.WriteLine("Enter the name of the equipment to update: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the new price: ");
            int price = Convert.ToInt32(Console.ReadLine());
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE equipment SET price = @price WHERE name = @name";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@price", price);
                    command.Parameters.AddWithValue("@name", name);
                    command.ExecuteNonQuery();
                }
            }
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM equipment";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        Console.WriteLine("Inventory:");
                        while (reader.Read())
                        {

                            Console.WriteLine(reader["name"] + " - " + reader["description"] + " - " + reader["price"] + " - " + reader["quantity"]);
                            Console.WriteLine("-----------------------------");
                        }
                        Console.WriteLine("Equipment updated successfully!");
                    }
                }
            }

        }

        static void DeleteEquipment()
        {
            Console.WriteLine("Enter the name of the equipment to delete: ");
            string name = Console.ReadLine();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM equipment WHERE name = @name";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", name);
                    command.ExecuteNonQuery();
                }
            }
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM equipment";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        Console.WriteLine("Inventory:");
                        while (reader.Read())
                        {

                            Console.WriteLine(reader["name"] + " - " + reader["description"] + " - " + reader["price"] + " - " + reader["quantity"]);
                            Console.WriteLine("-----------------------------");
                        }
                        Console.WriteLine("Equipment Deleted successfully!");
                    }
                }
            }

        }
        static void RentEquipment()
        {
            Console.WriteLine("Enter the name of the equipment to rent: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the Customer name:");
            string customerName = Console.ReadLine();
            Console.WriteLine("Enter the Customer Number:");
            string customerNumber = Console.ReadLine();
            Console.WriteLine("Enter the Quantity:");
            int rquantity = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Number of Days:");
            int days = Convert.ToInt32(Console.ReadLine());

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO details (equipment_name, customer_name, contact_no, rented_quantity, no_of_days) VALUES (@equipment_name, @customer_name, @contact_no, @rented_quantity, @no_of_days)";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@equipment_name", name);
                    command.Parameters.AddWithValue("@customer_name", customerName);
                    command.Parameters.AddWithValue("@contact_no", customerNumber);
                    command.Parameters.AddWithValue("@rented_quantity", rquantity);
                    command.Parameters.AddWithValue("@no_of_days", days);
                    command.ExecuteNonQuery();
                }
                Console.WriteLine("Equipment rental data saved successfully!");

            }

        }
        static void ViewRentedDetails()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM details";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        Console.WriteLine("Rented Records:");
                        Console.WriteLine("---------------");
                        while (reader.Read())
                        {

                            Console.WriteLine(reader["equipment_name"] + " - " + reader["customer_name"] + " - " + reader["contact_no"] + " - " + reader["rented_quantity"] + " - " + reader["no_of_days"]);
                            Console.WriteLine("------------------------------------");
                        }
                    }
                }
            }


        }
    }
}





