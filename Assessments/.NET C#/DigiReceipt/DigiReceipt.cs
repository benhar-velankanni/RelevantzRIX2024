// CREATE TABLE DIGIRECEIPT ( 
//     ID INT AUTO_INCREMENT PRIMARY KEY,
//     RECEIPTNAME VARCHAR(50),
//     RECEIPTAMOUNT DECIMAL(10,2),
//     CATEGORY VARCHAR(50),
//     DATE VARCHAR(10),
//     ADDITIONALNOTES VARCHAR(500));

using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;

namespace DigiReceiptApp
{
    public class DigiReceipt
    {
        public int? ID { get; set; }
        public string? RECEIPTNAME { get; set; }
        public decimal? RECEIPTAMOUNT { get; set; }
        public string? CATEGORY { get; set; }
        public string? DATE { get; set; }
        public string? ADDITIONALNOTES { get; set; }
    }

    public interface IDigiReceiptService
    {
        void AddReceipt(DigiReceipt digiReceipt);
        DigiReceipt GetDigiReceiptByID(int id);
        List<DigiReceipt> GetAllDigiReceipts();
        bool UpdateDigiReceipt(int id, DigiReceipt digiReceipt);
        bool DeleteDigiReceipt(int id);
        bool TruncateDigiReceipt();
    }

    public class DigiReceiptService : IDigiReceiptService
    {
        private readonly string _connectionString;

        public DigiReceiptService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddReceipt(DigiReceipt digiReceipt)
        {
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    using (var command = new MySqlCommand("INSERT INTO DIGIRECEIPT (RECEIPTNAME, RECEIPTAMOUNT, CATEGORY, DATE, ADDITIONALNOTES) VALUES (@name, @amount, @category, @date, @notes)", connection))
                    {
                        command.Parameters.AddWithValue("@name", digiReceipt.RECEIPTNAME);
                        command.Parameters.AddWithValue("@amount", digiReceipt.RECEIPTAMOUNT);
                        command.Parameters.AddWithValue("@category", digiReceipt.CATEGORY);
                        command.Parameters.AddWithValue("@date", digiReceipt.DATE);
                        command.Parameters.AddWithValue("@notes", digiReceipt.ADDITIONALNOTES);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding receipt: {ex.Message}", ex);
            }
        }

        public DigiReceipt GetDigiReceiptByID(int id)
        {
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    using (var command = new MySqlCommand("SELECT * FROM DIGIRECEIPT WHERE ID = @id", connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new DigiReceipt
                                {
                                    ID = reader.GetInt32("ID"),
                                    RECEIPTNAME = reader.GetString("RECEIPTNAME"),
                                    RECEIPTAMOUNT = reader.GetDecimal("RECEIPTAMOUNT"),
                                    CATEGORY = reader.GetString("CATEGORY"),
                                    DATE = reader.GetString("DATE"),
                                    ADDITIONALNOTES = reader.GetString("ADDITIONALNOTES")
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting receipt by ID: {ex.Message}", ex);
            }
            return null;
        }

        public List<DigiReceipt> GetAllDigiReceipts()
        {
            var digiReceipts = new List<DigiReceipt>();

            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    using (var command = new MySqlCommand("SELECT * FROM DIGIRECEIPT", connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    digiReceipts.Add(new DigiReceipt
                                    {
                                        ID = reader.GetInt32("ID"),
                                        RECEIPTNAME = reader.GetString("RECEIPTNAME"),
                                        RECEIPTAMOUNT = reader.GetDecimal("RECEIPTAMOUNT"),
                                        CATEGORY = reader.GetString("CATEGORY"),
                                        DATE = reader.GetString("DATE"),
                                        ADDITIONALNOTES = reader.GetString("ADDITIONALNOTES")
                                    });
                                }

                                return digiReceipts;
                            }
                            else
                            {
                                return null;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting all receipts: {ex.Message}", ex);
            }
        }

        public bool UpdateDigiReceipt(int id, DigiReceipt digiReceipt)
        {
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    using (var command = new MySqlCommand("UPDATE DIGIRECEIPT SET RECEIPTNAME = @name, RECEIPTAMOUNT = @amount, CATEGORY = @category, DATE = @date, ADDITIONALNOTES = @notes WHERE ID = @id", connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@name", digiReceipt.RECEIPTNAME);
                        command.Parameters.AddWithValue("@amount", digiReceipt.RECEIPTAMOUNT);
                        command.Parameters.AddWithValue("@category", digiReceipt.CATEGORY);
                        command.Parameters.AddWithValue("@date", digiReceipt.DATE);
                        command.Parameters.AddWithValue("@notes", digiReceipt.ADDITIONALNOTES);
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating receipt: {ex.Message}", ex);
            }
        }

        public bool DeleteDigiReceipt(int id)
        {
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    using (var command = new MySqlCommand("DELETE FROM DIGIRECEIPT WHERE ID = @id", connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting receipt: {ex.Message}", ex);
            }
        }

        public bool TruncateDigiReceipt()
        {
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    using (var command = new MySqlCommand("TRUNCATE TABLE DIGIRECEIPT", connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n====================================================\nERROR IN TRUNCATING RECEIPT: {ex.Message} \n====================================================");
            }
            return false;
        }

    }

    public class DigiReceiptUI
    {
        public static IDigiReceiptService _digiReceiptService;

        public DigiReceiptUI(IDigiReceiptService digiReceiptService)
        {
            _digiReceiptService = digiReceiptService;
        }

        public static void AddReceiptUI()
        {
            Console.WriteLine("\n====================================================\nADD RECEIPT:\n====================================================");

            var name = GetValidName();
            Console.WriteLine();
            var amount = GetValidAmount();
            Console.WriteLine();
            var category = GetValidCategory();
            Console.WriteLine();
            var date = GetValidDate();
            Console.WriteLine();
            var notes = GetValidNotes();
            Console.WriteLine();

            Console.WriteLine("====================================================");

            var digiReceipt = new DigiReceipt
            {
                RECEIPTNAME = name,
                RECEIPTAMOUNT = amount,
                CATEGORY = category,
                DATE = date,
                ADDITIONALNOTES = notes
            };

            try
            {
                _digiReceiptService.AddReceipt(digiReceipt);
                Console.WriteLine("\n====================================================\nRECEIPT ADDED SUCCESSFULLY.\n====================================================");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n====================================================\nERROR: {ex.Message} \n====================================================");
            }
        }

        public static void GetAllReceiptsUI()
        {
            Console.WriteLine("\n====================================================\nGET ALL RECEIPTS:\n====================================================");
            Console.WriteLine();

            try
            {
                var digiReceipts = _digiReceiptService.GetAllDigiReceipts();
                if (digiReceipts != null)
                {
                    foreach (var digiReceipt in digiReceipts)
                    {
                        Console.WriteLine($"Receipt ID: {digiReceipt.ID}");
                        Console.WriteLine($"Receipt Name: {digiReceipt.RECEIPTNAME}");
                        Console.WriteLine($"Receipt Amount: {digiReceipt.RECEIPTAMOUNT}");
                        Console.WriteLine($"Category of Expenditure: {digiReceipt.CATEGORY}");
                        Console.WriteLine($"Date of Expenditure: {digiReceipt.DATE}");
                        if (digiReceipt.ADDITIONALNOTES != "")
                        {
                            Console.WriteLine($"Additional Notes: {digiReceipt.ADDITIONALNOTES}");
                        }
                        else
                        {
                            Console.WriteLine($"Additional Notes: N/A");
                        }
                        Console.WriteLine("====================================================");
                    }
                }
                else
                {
                    Console.WriteLine("\n====================================================\nNO RECEIPTS FOUND.\n====================================================");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n====================================================\nERROR: {ex.Message} \n====================================================");
            }
        }

        public static void GetReceiptByIdUI()
        {
            Console.WriteLine("\n====================================================\nGET RECEIPT BY ID:\n====================================================");
            Console.WriteLine();

            if (int.TryParse(Console.ReadLine(), out int id))
            {
                try
                {
                    var digiReceipt = _digiReceiptService.GetDigiReceiptByID(id);
                    if (digiReceipt != null)
                    {
                        Console.WriteLine($"Receipt ID: {digiReceipt.ID}");
                        Console.WriteLine($"Receipt Name: {digiReceipt.RECEIPTNAME}");
                        Console.WriteLine($"Receipt Amount: {digiReceipt.RECEIPTAMOUNT}");
                        Console.WriteLine($"Category of Expenditure: {digiReceipt.CATEGORY}");
                        Console.WriteLine($"Date of Expenditure: {digiReceipt.DATE}");
                        if (digiReceipt.ADDITIONALNOTES != "")
                        {
                            Console.WriteLine($"Additional Notes: {digiReceipt.ADDITIONALNOTES}");
                        }
                        else
                        {
                            Console.WriteLine($"Additional Notes: N/A");
                        }
                        Console.WriteLine("====================================================");
                    }
                    else
                    {
                        Console.WriteLine("\n====================================================\nNO RECEIPT FOUND WITH THE GIVEN ID.\n====================================================");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\n====================================================\nERROR: {ex.Message} \n====================================================");
                }
            }
            else
            {
                Console.WriteLine("\n====================================================\nINVALID ID FORMAT. PLEASE ENTER A NUMBER.\n====================================================");
            }
        }

        public static void UpdateDigiReceiptUI()
        {
            Console.WriteLine("\n====================================================\nUPDATE RECEIPT: ENTER RECIEPT ID:\n====================================================");
            Console.WriteLine();

            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var digiReceipt = _digiReceiptService.GetDigiReceiptByID(id);
                if (digiReceipt != null)
                {
                    Console.WriteLine("\n====================================================\nENTER NEW RECEIPT DETAILS:\n====================================================");
                    var name = GetValidName();
                    Console.WriteLine();
                    var amount = GetValidAmount();
                    Console.WriteLine();
                    var category = GetValidCategory();
                    Console.WriteLine();
                    var date = GetValidDate();
                    Console.WriteLine();
                    var notes = GetValidNotes();
                    Console.WriteLine();

                    Console.WriteLine("====================================================");

                    digiReceipt.RECEIPTNAME = name;
                    digiReceipt.RECEIPTAMOUNT = amount;
                    digiReceipt.CATEGORY = category;
                    digiReceipt.DATE = date;
                    digiReceipt.ADDITIONALNOTES = notes;

                    try
                    {
                        bool result = _digiReceiptService.UpdateDigiReceipt(id, digiReceipt);
                        if (result)
                        {
                            Console.WriteLine("\n====================================================\nRECEIPT UPDATED SUCCESSFULLY.\n====================================================");
                        }
                        else
                        {
                            Console.WriteLine("\n====================================================\nRECEIPT UPDATED FAILED.\n====================================================");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"\n====================================================\nERROR: {ex.Message} \n====================================================");
                    }
                }
                else
                {
                    Console.WriteLine("\n====================================================\nNO RECEIPT FOUND WITH THE GIVEN ID.\n====================================================");
                }
            }
        }

        public static void DeleteDigiReceiptUI()
        {
            Console.WriteLine("\n====================================================\nDELETE RECEIPT: ENTER RECIEPT ID:\n====================================================");

            if (int.TryParse(Console.ReadLine(), out int id))
            {
                try
                {
                    bool result = _digiReceiptService.DeleteDigiReceipt(id);
                    if (result)
                    {
                        Console.WriteLine("\n====================================================\nRECEIPT DELETED SUCCESSFULLY.\n====================================================");
                    }
                    else
                    {
                        Console.WriteLine("\n====================================================\nRECEIPT DELETED FAILED.\n====================================================");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\n====================================================\nERROR: {ex.Message} \n====================================================");
                }
            }
            else
            {
                Console.WriteLine("\n====================================================\nINVALID ID FORMAT. PLEASE ENTER A NUMBER.\n====================================================");
            }
        }

        public static void TruncateDigiReceiptUI()
        {
            Console.WriteLine("\n====================================================\nTRUNCATE RECEIPT:\n====================================================");

            Console.Write("Confirmation: All existing data will be deleted. Press Y to continue: ");
            string? choice = Console.ReadLine().ToUpper();

            if (choice == "Y")
            {
                try
                {
                    _digiReceiptService.TruncateDigiReceipt();
                    Console.WriteLine("\n====================================================\nRECEIPT TRUNCATED SUCCESSFULLY.\n====================================================");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\n====================================================\nERROR: {ex.Message} \n====================================================");
                }
            }
            else
            {
                Console.WriteLine("\n====================================================\nOPERATION CANCELLED.\n====================================================");
            }
        }

        private static string GetValidName()
        {
            while (true)
            {
                Console.WriteLine("Enter a valid name:");
                var name = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(name))
                {
                    return name;
                }
                Console.WriteLine("Invalid name. Please try again.");
            }
        }

        private static decimal GetValidAmount()
        {
            while (true)
            {
                Console.WriteLine("Enter a valid amount (INR):");
                decimal amount = decimal.Parse(Console.ReadLine());
                if (amount == null)
                {
                    Console.WriteLine("Invalid amount. Please try again.");
                    continue;
                }
                if (amount >= 0)
                {
                    return Math.Round(amount, 2);
                }
                Console.WriteLine("Invalid amount. Please try again.");
            }
        }

        private static string GetValidCategory()
        {
            while (true)
            {
                Console.WriteLine("Enter a valid category:");
                var category = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(category))
                {
                    return category;
                }
                Console.WriteLine("Invalid category. Please try again.");
            }
        }

        private static string GetValidDate()
        {
            while (true)
            {
                Console.WriteLine("Enter a valid date (DD/MM/YYYY):");
                var date = Console.ReadLine();
                string dateRegex = @"^(0[1-9]|[12][0-9]|3[01])\/(0[1-9]|1[0-2])\/[0-9]{4}$";
                if (date == null)
                {
                    Console.WriteLine("Invalid date. Please try again.");
                    continue;
                }
                if (Regex.IsMatch(date, dateRegex))
                {
                    return date;
                }
                Console.WriteLine("Invalid date. Please try again.");
            }
        }

        private static string GetValidNotes()
        {
            while (true)
            {
                Console.WriteLine("Enter a valid notes:");
                var notes = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(notes))
                {
                    return notes;
                }
                else
                {
                answerme1:
                    Console.WriteLine("No Additional Notes? (Y/N)");
                    var answer = Console.ReadLine();
                    if (answer == null)
                    {
                        Console.WriteLine("Invalid answer. Please try again.");
                        goto answerme1;
                    }
                    if (answer.ToUpper() == "Y")
                    {
                        return "";
                    }
                }
            }
        }
    }
}