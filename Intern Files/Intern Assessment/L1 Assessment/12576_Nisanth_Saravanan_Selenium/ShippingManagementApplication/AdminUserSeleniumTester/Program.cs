using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

class Program
{
    public static void Main (string[] args)
    {
        //SetUp
        IWebDriver driver = new ChromeDriver();
        driver.Manage().Window.Maximize();

        SubmitEmptyRegisterFom(driver);

        SubmitEmptyLoginForm(driver);

        SubmitInvalidCredentials(driver);

        LoginAsAdmin(driver);

        SuccessAdminRun_AllValidInputs(driver);        

        AddShipment_SubmitIncompleteData(driver);

        SearchBarTest_ByName(driver);

        SearchBarTest_ByType(driver);

        SearchBarTest_ByAddress(driver);

        EditShipment_SubmitIncompleteData(driver);

        //TearDown.
        driver.Close();
        driver.Quit();
    }

    static void SubmitEmptyRegisterFom(IWebDriver driver)
    {
        try
        {
            //Start from Register Page.
            driver.Navigate().GoToUrl("http://localhost:3000/register");
            Thread.Sleep(2000);

            //Submit Empty Register Form.
            driver.FindElement(By.XPath("//button[text()='Register']")).Click();
            Thread.Sleep(2000);
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
            Thread.Sleep(2000);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static void SubmitEmptyLoginForm(IWebDriver driver)
    {
        try
        {
            //Start from Login Page.
            driver.Navigate().GoToUrl("http://localhost:3000/");
            Thread.Sleep(2000);

            //Submit Empty Login Form.
            driver.FindElement(By.XPath("//button[text()='Login']")).Click();
            Thread.Sleep(2000);
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
            Thread.Sleep(2000);
        } catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static void SubmitInvalidCredentials(IWebDriver driver)
    {
        try
        {
            //Start from Login Page.
            driver.Navigate().GoToUrl("http://localhost:3000/");
            Thread.Sleep(2000);

            //Submit Invalid Credentials.
            driver.FindElement(By.XPath("//input[@placeholder='Username']")).SendKeys("Someone Else");
            driver.FindElement(By.XPath("//input[@placeholder='Password']")).SendKeys("Somebody@123");
            driver.FindElement(By.XPath("//button[text()='Login']")).Click();
            Thread.Sleep(2000);
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
            Thread.Sleep(2000);
        }
        catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }

    static void LoginAsAdmin(IWebDriver driver)
    {
        try
        {
            //Start from Login Page.
            driver.Navigate().GoToUrl("http://localhost:3000/");
            Thread.Sleep(2000);

            //Login as an "User" User.
            driver.FindElement(By.XPath("//input[@placeholder='Username']")).SendKeys("Admin");
            driver.FindElement(By.XPath("//input[@placeholder='Password']")).SendKeys("Admin@123");
            driver.FindElement(By.XPath("//button[text()='Login']")).Click();
            Thread.Sleep(2000);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static void SuccessAdminRun_AllValidInputs(IWebDriver driver)
    {
        try
        {
            LoginAsAdmin(driver);

            //Add a shipment.
            driver.FindElement(By.XPath("//input[@placeholder='Name']")).SendKeys("Box A");
            driver.FindElement(By.XPath("//input[@placeholder='Type']")).SendKeys("Games");
            driver.FindElement(By.XPath("//input[@placeholder='Address']")).SendKeys("123 Avenue");
            driver.FindElement(By.XPath("//button[text()='Add Shipment']")).Click();
            Thread.Sleep(2000);

            //Edit a shipment.
            driver.FindElement(By.XPath("//button[text()='Edit']")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//input[@placeholder='Name']")).Clear();
            driver.FindElement(By.XPath("//input[@placeholder='Name']")).SendKeys("Updated Box A");
            driver.FindElement(By.XPath("//button[text()='Update Shipment']")).Click();
            Thread.Sleep(2000);

            //Delete a shipment.
            driver.FindElement(By.XPath("//button[text()='Delete']")).Click();
            Thread.Sleep(2000);

            //Logout.
            driver.FindElement(By.XPath("//button[text()='Logout']")).Click();
            Thread.Sleep(2000);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static void AddShipment_SubmitIncompleteData(IWebDriver driver)
    {
        try
        {
            LoginAsAdmin(driver);

            //Add a shipment.
            driver.FindElement(By.XPath("//input[@placeholder='Name']")).SendKeys("Box A");
            driver.FindElement(By.XPath("//input[@placeholder='Type']")).SendKeys("Games");
            driver.FindElement(By.XPath("//button[text()='Add Shipment']")).Click();
            Thread.Sleep(2000);
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
            Thread.Sleep(2000);
        }
        catch (Exception ex)
        { 
            Console.WriteLine(ex.Message);
        }
    }

    static void SearchBarTest_ByName(IWebDriver driver)
    {
        try
        {
            LoginAsAdmin(driver);

            //Add a shipment.
            driver.FindElement(By.XPath("//input[@placeholder='Name']")).SendKeys("Box A");
            driver.FindElement(By.XPath("//input[@placeholder='Type']")).SendKeys("Games");
            driver.FindElement(By.XPath("//input[@placeholder='Address']")).SendKeys("123 Avenue");
            driver.FindElement(By.XPath("//button[text()='Add Shipment']")).Click();
            Thread.Sleep(2000);

            //Add a shipment.
            driver.FindElement(By.XPath("//input[@placeholder='Name']")).SendKeys("Box B");
            driver.FindElement(By.XPath("//input[@placeholder='Type']")).SendKeys("Movies");
            driver.FindElement(By.XPath("//input[@placeholder='Address']")).SendKeys("456 Avenue");
            driver.FindElement(By.XPath("//button[text()='Add Shipment']")).Click();
            Thread.Sleep(2000);

            //Send keys to search bar and delete.
            driver.FindElement(By.XPath("//input[@placeholder='Search by name, type, or address']")).SendKeys("Box A");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//button[text()='Delete']")).Click();
            Thread.Sleep(2000);

            //Send keys to search bar and delete.
            driver.FindElement(By.XPath("//input[@placeholder='Search by name, type, or address']")).Clear();
            driver.FindElement(By.XPath("//input[@placeholder='Search by name, type, or address']")).SendKeys("Box B");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//button[text()='Delete']")).Click();
            Thread.Sleep(2000);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static void SearchBarTest_ByType(IWebDriver driver)
    {
        try
        {
            LoginAsAdmin(driver);

            //Add a shipment.
            driver.FindElement(By.XPath("//input[@placeholder='Name']")).SendKeys("Box A");
            driver.FindElement(By.XPath("//input[@placeholder='Type']")).SendKeys("Games");
            driver.FindElement(By.XPath("//input[@placeholder='Address']")).SendKeys("123 Avenue");
            driver.FindElement(By.XPath("//button[text()='Add Shipment']")).Click();
            Thread.Sleep(2000);

            //Add a shipment.
            driver.FindElement(By.XPath("//input[@placeholder='Name']")).SendKeys("Box B");
            driver.FindElement(By.XPath("//input[@placeholder='Type']")).SendKeys("Movies");
            driver.FindElement(By.XPath("//input[@placeholder='Address']")).SendKeys("456 Avenue");
            driver.FindElement(By.XPath("//button[text()='Add Shipment']")).Click();
            Thread.Sleep(2000);

            //Send keys to search bar and delete.
            driver.FindElement(By.XPath("//input[@placeholder='Search by name, type, or address']")).SendKeys("Games");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//button[text()='Delete']")).Click();
            Thread.Sleep(2000);

            //Send keys to search bar and delete.
            driver.FindElement(By.XPath("//input[@placeholder='Search by name, type, or address']")).Clear();
            driver.FindElement(By.XPath("//input[@placeholder='Search by name, type, or address']")).SendKeys("Movies");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//button[text()='Delete']")).Click();
            Thread.Sleep(2000);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static void SearchBarTest_ByAddress(IWebDriver driver)
    {
        try
        {
            LoginAsAdmin(driver);

            //Add a shipment.
            driver.FindElement(By.XPath("//input[@placeholder='Name']")).SendKeys("Box A");
            driver.FindElement(By.XPath("//input[@placeholder='Type']")).SendKeys("Games");
            driver.FindElement(By.XPath("//input[@placeholder='Address']")).SendKeys("123 Avenue");
            driver.FindElement(By.XPath("//button[text()='Add Shipment']")).Click();
            Thread.Sleep(2000);

            //Add a shipment.
            driver.FindElement(By.XPath("//input[@placeholder='Name']")).SendKeys("Box B");
            driver.FindElement(By.XPath("//input[@placeholder='Type']")).SendKeys("Movies");
            driver.FindElement(By.XPath("//input[@placeholder='Address']")).SendKeys("456 Avenue");
            driver.FindElement(By.XPath("//button[text()='Add Shipment']")).Click();
            Thread.Sleep(2000);

            //Send keys to search bar and delete.
            driver.FindElement(By.XPath("//input[@placeholder='Search by name, type, or address']")).SendKeys("123");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//button[text()='Delete']")).Click();
            Thread.Sleep(2000);

            //Send keys to search bar and delete.
            driver.FindElement(By.XPath("//input[@placeholder='Search by name, type, or address']")).Clear();
            driver.FindElement(By.XPath("//input[@placeholder='Search by name, type, or address']")).SendKeys("456");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//button[text()='Delete']")).Click();
            Thread.Sleep(2000);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static void EditShipment_SubmitIncompleteData(IWebDriver driver)
    {
        try
        {
            LoginAsAdmin(driver);

            //Add a shipment.
            driver.FindElement(By.XPath("//input[@placeholder='Name']")).SendKeys("Box A");
            driver.FindElement(By.XPath("//input[@placeholder='Type']")).SendKeys("Games");
            driver.FindElement(By.XPath("//input[@placeholder='Address']")).SendKeys("123 Avenue");
            driver.FindElement(By.XPath("//button[text()='Add Shipment']")).Click();
            Thread.Sleep(2000);

            //Edit a shipment.
            driver.FindElement(By.XPath("//button[text()='Edit']")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//input[@placeholder='Name']")).Clear();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//button[text()='Update Shipment']")).Click();
            Thread.Sleep(2000);
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
            Thread.Sleep(2000);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
