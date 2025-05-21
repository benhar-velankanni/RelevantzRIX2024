using MySql.Data.MySqlClient;
namespace internApp
{
    public class InternApp
    {
        string conn = "server=localhost;user=root;Password=Password@12345;database=internApp;port=3306;SslMode=None";
        public void addIntern()
        {
            Console.WriteLine("Adding Intern");
            Console.WriteLine("Enter ID : ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Name : ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Qualification : ");
            string qualification = Console.ReadLine();
            Console.WriteLine("SSLC Marks : ");
            int sslc = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("HSLC Marks : ");
            int hslc = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter CGPA : ");
            decimal cgpa = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Enter Native : ");
            string native = Console.ReadLine();
            Console.WriteLine("Enter PhoneNO :");
            long phoneNo = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Enter Resume Link : ");
            string resumeLink = Console.ReadLine();
            using var con = new MySqlConnection(conn);
            con.Open();
            using var cmd = new MySqlCommand("INSERT INTO Interns(id,name,qualification,10thmark,12thmark,cgpa,native,phoneno,resumelink) VALUES(@id,@name,@qualification,@10thmark,@12thmark,@cgpa,@native,@phoneno,@resumelink)", con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@qualification", qualification);
            cmd.Parameters.AddWithValue("@10thmark", sslc);
            cmd.Parameters.AddWithValue("@12thmark", hslc);
            cmd.Parameters.AddWithValue("@cgpa", cgpa);
            cmd.Parameters.AddWithValue("@native", native);
            cmd.Parameters.AddWithValue("@phoneno", phoneNo);
            cmd.Parameters.AddWithValue("@resumelink", resumeLink);
            cmd.ExecuteNonQuery();
            con.Close();
            Console.WriteLine("Intern Added Successfully");



        }

        public void updateIntern()
        {
            Console.WriteLine("Update Intern");
            Console.WriteLine("Enter ID : ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Name : ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Qualification : ");
            string qualification = Console.ReadLine();
            Console.WriteLine("SSLC Marks : ");
            int sslc = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("HSLC Marks : ");
            int hslc = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter CGPA : ");
            decimal cgpa = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Enter Native : ");
            string native = Console.ReadLine();
            Console.WriteLine("Enter PhoneNO :");
            long phoneNo = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Enter Resume Link : ");
            string resumeLink = Console.ReadLine();
            using var con = new MySqlConnection(conn);
            con.Open();
            using var cmd = new MySqlCommand("UPDATE Interns SET name=@name,qualification=@qualification,10thmark=@10thmark,12thmark=@12thmark,cgpa=@cgpa,native=@native,phoneno=@phoneno,resumelink=@resumelink WHERE id=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@qualification", qualification);
            cmd.Parameters.AddWithValue("@10thmark", sslc);
            cmd.Parameters.AddWithValue("@12thmark", hslc);
            cmd.Parameters.AddWithValue("@cgpa", cgpa);
            cmd.Parameters.AddWithValue("@native", native);
            cmd.Parameters.AddWithValue("@phoneno", phoneNo);
            cmd.Parameters.AddWithValue("@resumelink", resumeLink);
            cmd.ExecuteNonQuery();
            con.Close();
            Console.WriteLine("Intern Updated Successfully");
        }

        public void deleteIntern()
        {
            Console.WriteLine("Delete Intern");
            Console.WriteLine("Enter ID : ");
            int id = Convert.ToInt32(Console.ReadLine());
            using var con = new MySqlConnection(conn);
            con.Open();
            using var cmd = new MySqlCommand("DELETE FROM Interns WHERE id=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            con.Close();
            Console.WriteLine("Intern Deleted Successfully");
        }

        public void searchIntern()
        {
            Console.WriteLine("Search Intern");
            Console.WriteLine("Enter ID : ");
            int id = Convert.ToInt32(Console.ReadLine());
            using var con = new MySqlConnection(conn);
            con.Open();
            using var cmd = new MySqlCommand("SELECT * FROM Interns WHERE id=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            if (cmd.ExecuteNonQuery() == 0)
            {
                Console.WriteLine(">>>>>>> Intern Not Found <<<<<<<");

                return;
            }
            else
            {
                Console.WriteLine(">>>>>>> Intern Found <<<<<<<<<");
            }
            using var reader = cmd.ExecuteReader();
            while (reader.Read() == true)
            {
                Console.WriteLine($"ID : {reader["id"]}");
                Console.WriteLine($"Name : {reader["name"]}");
                Console.WriteLine($"Qualification : {reader["qualification"]}");
                Console.WriteLine($"SSLC Marks : {reader["10thmark"]}");
                Console.WriteLine($"HSLC Marks : {reader["12thmark"]}");
                Console.WriteLine($"CGPA : {reader["cgpa"]}");
                Console.WriteLine($"Native : {reader["native"]}");
                Console.WriteLine($"PhoneNO : {reader["phoneno"]}");
                Console.WriteLine($"Resume Link : {reader["resumelink"]}");
            }
            con.Close();
        }

        public void showAllIntern()
        {
            using var con = new MySqlConnection(conn);
            con.Open();
            using var cmd = new MySqlCommand("SELECT * FROM Interns", con);
            using var reader = cmd.ExecuteReader();
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");
            while (reader.Read() == true)
            {
                Console.WriteLine(reader[0] + "  |  " + reader[1] + "  |  " + reader[2] + "  |  " + reader[3] + "  |  " + reader[4] + "  |  " + reader[5] + "  |  " + reader[6] + "  |  " + reader[7] + "  |  " + reader[8]);
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");
            }
            con.Close();
        }
    }
}

