using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        IWebDriver driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        
        try
        {
            // Visit Register Page
            driver.Navigate().GoToUrl("http://localhost:3000/register");
            Thread.Sleep(2000);
            
            // Click 'Old User? Login.' to go to Login Page
            driver.FindElement(By.XPath("//button[text()='Old User? Login.']")).Click();
            Thread.Sleep(2000);

            // Login as Admin
            driver.FindElement(By.XPath("//input[@placeholder='Username']")).SendKeys("Admin");
            driver.FindElement(By.XPath("//input[@placeholder='Password']")).SendKeys("Admin@123");
            driver.FindElement(By.XPath("//button[text()='Login']")).Click();
            Thread.Sleep(2000);

            // Create Shipment
            driver.FindElement(By.XPath("//input[@placeholder='Name']")).SendKeys("Test Shipment");
            driver.FindElement(By.XPath("//input[@placeholder='Type']")).SendKeys("Electronics");
            driver.FindElement(By.XPath("//input[@placeholder='Address']")).SendKeys("Bangalore");
            driver.FindElement(By.XPath("//button[text()='Add Shipment']")).Click();
            Thread.Sleep(2000);

            // Edit Shipment
            driver.FindElement(By.XPath("//button[text()='Edit']")).Click();
            Thread.Sleep(1000);
            var typeInput = driver.FindElement(By.XPath("//input[@placeholder='Type']"));
            typeInput.Clear();
            typeInput.SendKeys("Updated Electronics");
            driver.FindElement(By.XPath("//button[text()='Update Shipment']")).Click();
            Thread.Sleep(2000);

            // Search Shipment
            var searchInput = driver.FindElement(By.XPath("//input[@placeholder='Search by name, type, or address']"));
            searchInput.SendKeys("Updated");
            Thread.Sleep(2000);

            // Delete Shipment
            driver.FindElement(By.XPath("//button[text()='Delete']")).Click();
            Thread.Sleep(2000);

            // Logout
            driver.FindElement(By.XPath("//button[text()='Logout']")).Click();
            Thread.Sleep(2000);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            driver.Quit();
        }
    }
}
