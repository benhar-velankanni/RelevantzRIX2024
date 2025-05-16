using MySql.Data.MySqlClient;

namespace ConsoleAppRelevantz
{
    public class RelevantzProducts
    {
        static string connectionString = "Server=localhost;User=root;Password=root;Database=RELEVANTZ;Port=3306;";

        public static void AddProduct()
        {
            Console.WriteLine("\n======================================================\nENTER PRODUCT DETAILS:\n======================================================");
            Console.WriteLine("PRODUCT NAME:");
            string? productName = Console.ReadLine();
            Console.WriteLine("PRODUCT DESCRIPTION:");
            string? productDescription = Console.ReadLine();
            Console.WriteLine("PRODUCT PRICE:");
            string? productPrice = Console.ReadLine();
            Console.WriteLine("====================================================");

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (var command = new MySqlCommand("INSERT INTO PRODUCTS (PNAME, PDESCRIPTION, PPRICE) VALUES (@name, @description, @price)", connection))
                    {
                        command.Parameters.AddWithValue("@name", productName);
                        command.Parameters.AddWithValue("@description", productDescription);
                        command.Parameters.AddWithValue("@price", productPrice);
                        command.ExecuteNonQuery();
                    }
                }
                Console.WriteLine("\n====================================================\nPRODUCT ADDED SUCCESSFULLY.\n====================================================");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n====================================================\nERROR: {ex.Message} \n====================================================");
            }
        }

        public static void DeleteProduct()
        {
            Console.WriteLine("\n====================================================\nENTER THE PRODUCT ID TO DELETE:\n====================================================");
            string? productId = Console.ReadLine();
            Console.WriteLine("====================================================");

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (var command = new MySqlCommand("DELETE FROM PRODUCTS WHERE PID = @id", connection))
                    {
                        command.Parameters.AddWithValue("@id", productId);
                        command.ExecuteNonQuery();
                    }
                }
                Console.WriteLine("\n====================================================\nPRODUCT DELETED SUCCESSFULLY.\n====================================================");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n====================================================\nERROR: {ex.Message} \n====================================================");
            }
        }

        public static void UpdateProduct()
        {
            Console.WriteLine("\n====================================================\nENTER THE PRODUCT ID TO UPDATE:\n====================================================");
            string? productId = Console.ReadLine();
            Console.WriteLine("====================================================");

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (var command = new MySqlCommand("SELECT * FROM PRODUCTS WHERE PID = @id", connection))
                    {
                        command.Parameters.AddWithValue("@id", productId);
                        using (var reader = command.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                Console.WriteLine($"\n====================================================\nPRODUCT WITH ID {productId} DOES NOT EXIST.\n====================================================");
                                return;
                            }
                        }
                    }
                }

                Console.WriteLine("\n====================================================\n PRODUCT FOUND, ENTER NEW DETAILS:\n====================================================");
                Console.WriteLine("PRODUCT NAME:");
                string? productName = Console.ReadLine();
                Console.WriteLine("PRODUCT DESCRIPTION:");
                string? productDescription = Console.ReadLine();
                Console.WriteLine("PRODUCT PRICE:");
                string? productPrice = Console.ReadLine();
                Console.WriteLine("====================================================");

                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (var command = new MySqlCommand("UPDATE PRODUCTS SET PNAME = @name, PDESCRIPTION = @description, PPRICE = @price WHERE PID = @id", connection))
                    {
                        command.Parameters.AddWithValue("@id", productId);
                        command.Parameters.AddWithValue("@name", productName);
                        command.Parameters.AddWithValue("@description", productDescription);
                        command.Parameters.AddWithValue("@price", productPrice);
                        command.ExecuteNonQuery();
                    }
                }
                Console.WriteLine("\n====================================================\nPRODUCT UPDATED SUCCESSFULLY.\n====================================================");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n====================================================\nERROR: {ex.Message} \n====================================================");
            }
        }

        public static void SearchProduct()
        {
            Console.WriteLine("\n====================================================\nENTER THE PRODUCT ID TO SEARCH:\n====================================================");
            string? productId = Console.ReadLine();

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (var command = new MySqlCommand("SELECT * FROM PRODUCTS WHERE PID = @id", connection))
                    {
                        command.Parameters.AddWithValue("@id", productId);
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Console.WriteLine("\n====================================================\nPRODUCT FOUND:\n====================================================");
                                Console.WriteLine($"ID: {reader["PID"]}");
                                Console.WriteLine($"Name: {reader["PNAME"]}");
                                Console.WriteLine($"Description: {reader["PDESCRIPTION"]}");
                                Console.WriteLine($"Price: {reader["PPRICE"]}");
                            }
                            else
                            {
                                Console.WriteLine("\n====================================================\nPRODUCT NOT FOUND.\n====================================================");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n====================================================\nERROR: {ex.Message} \n====================================================");
            }
        }


        public static void ListProducts()
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (var command = new MySqlCommand("SELECT * FROM PRODUCTS", connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            if (!reader.HasRows)
                            {
                                Console.WriteLine("\n====================================================\nNO PRODUCTS FOUND.\n====================================================");
                                return;
                            }
                            Console.WriteLine("\n====================================================\nLIST OF PRODUCTS:\n====================================================");
                            while (reader.Read())
                            {
                                Console.WriteLine("ID: " + reader["PID"]);
                                Console.WriteLine("PRODUCT NAME: " + reader["PNAME"]);
                                Console.WriteLine("PRODUCT DESCRIPTION: " + reader["PDESCRIPTION"]);
                                Console.WriteLine("PRODUCT PRICE: " + reader["PPRICE"]);
                                Console.WriteLine("====================================================");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n====================================================\nERROR: {ex.Message}\n====================================================");
            }
        }

        public static void TruncateTable()
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (var command = new MySqlCommand("TRUNCATE TABLE PRODUCTS", connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                Console.WriteLine("\n====================================================\nTABLE TRUNCATED SUCCESSFULLY.\n====================================================");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n====================================================\nERROR: {ex.Message}\n====================================================");
            }
        }
    }
}
