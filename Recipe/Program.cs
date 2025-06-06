using System;
using MySql.Data.MySqlClient;
using MySql.Data.MySqlClient.Interceptors;

class Recipe
{
    static string connString = "server=localhost;user=root;password=nut@8397;database=recipe";
    public void AddRecipe()
    {
        Console.WriteLine("Enter the recipe id: ");
        int id = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter the recipe name: ");
        string name = Console.ReadLine();
        Console.WriteLine("Enter the recipe category: ");
        string category = Console.ReadLine();
        Console.WriteLine("Enter the recipe description: ");
        string description = Console.ReadLine();

        using var conn = new MySqlConnection(connString);
        conn.Open();
        using var cmd = new MySqlCommand("insert into recipe (id, name, category, description) values (@id, @name, @category, @description)", conn);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.Parameters.AddWithValue("@name", name);
        cmd.Parameters.AddWithValue("@category", category);
        cmd.Parameters.AddWithValue("@description", description);
        cmd.ExecuteNonQuery();
        Console.WriteLine("Recipe added successfully!");
        Console.WriteLine();
    }

    public void DeleteRecipe()
    {
        Console.WriteLine("Enter the recipe id to be deleted: ");
        int id = Convert.ToInt32(Console.ReadLine());
        using var conn = new MySqlConnection(connString);
        conn.Open();
        using var cmd = new MySqlCommand("delete from recipe where id = @id", conn);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
        Console.WriteLine("Recipe deleted successfully!");
        Console.WriteLine();
    }

    public void UpdateRecipe()
    {
        Console.WriteLine("Enter the recipe id to be updated: ");
        int id = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter the recipe name: ");
        string name = Console.ReadLine();
        Console.WriteLine("Enter the recipe category: ");
        string category = Console.ReadLine();
        Console.WriteLine("Enter the recipe description: ");
        string description = Console.ReadLine();

        using var conn = new MySqlConnection(connString);
        conn.Open();
        using var cmd = new MySqlCommand("update recipe set name = @name, category = @category, description = @description where id = @id", conn);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.Parameters.AddWithValue("@name", name);
        cmd.Parameters.AddWithValue("@category", category);
        cmd.Parameters.AddWithValue("@description", description);
        cmd.ExecuteNonQuery();
        Console.WriteLine("Recipe updated successfully!");
        Console.WriteLine();
    }

    public void ViewRecipe()
    {
        using var conn = new MySqlConnection(connString);
        conn.Open();
        using var cmd = new MySqlCommand("select * from recipe", conn);
        using var reader = cmd.ExecuteReader();
        Console.WriteLine("Displaying Recipe List:");
        while (reader.Read())
        {
            Console.WriteLine($"ID: {reader["id"]}");
            Console.WriteLine($"Name: {reader["name"]}");
            Console.WriteLine($"Category: {reader["category"]}");
            Console.WriteLine($"Description: {reader["description"]}");
            Console.WriteLine();
        }
    }

    public void SearchRecipe()
    {
        Console.WriteLine("Enter the recipe id to be searched: ");
        int id = Convert.ToInt32(Console.ReadLine());
        using var conn = new MySqlConnection(connString);
        conn.Open();
        using var cmd = new MySqlCommand("select * from recipe where id = @id", conn);
        cmd.Parameters.AddWithValue("@id", id);
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine("Displaying Recipe Details:");
            Console.WriteLine($"ID: {reader["id"]}");
            Console.WriteLine($"Name: {reader["name"]}");
            Console.WriteLine($"Category: {reader["category"]}");
            Console.WriteLine($"Description: {reader["description"]}");
            Console.WriteLine();
        }
    }
}

class Program
{
    public static void Main(string[] args)
    {
        Recipe recipe = new Recipe();
        while (true)
        {
            Console.WriteLine("Welcome to the Recipe Management System!");
            Console.WriteLine("1.Add new Recipe");
            Console.WriteLine("2.Delete Recipe");
            Console.WriteLine("3.Update Recipe");
            Console.WriteLine("4.View Recipe");
            Console.WriteLine("5.Search Recipe");
            Console.WriteLine("6.Exit");
            Console.WriteLine("Enter your choice: ");
            int ch = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            switch (ch)
            {
                case 1:
                    recipe.AddRecipe();
                    break;
                case 2:
                    recipe.DeleteRecipe();
                    break;
                case 3:
                    recipe.UpdateRecipe();
                    break;
                case 4:
                    recipe.ViewRecipe();
                    break;
                case 5:
                    recipe.SearchRecipe();
                    break;
                case 6:
                    Console.WriteLine("Thanks for visiting! Hope you got some useful info!!");
                    Console.WriteLine("Exiting..");
                    Environment.Exit(0);
                    break;
            }
        }
    }
}