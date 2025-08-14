using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

class Program
{
    public static void Main(string[] args)
    {
        //SetUp
        IWebDriver driver = new ChromeDriver();
        driver.Manage().Window.Maximize();

        //Admin Side Preset.
        try
        {
            //Start from Login Page.
            driver.Navigate().GoToUrl("http://localhost:3000/");
            Thread.Sleep(2000);

            //Login as an "Admin" User.
            driver.FindElement(By.XPath("//input[@placeholder='Username']")).SendKeys("Admin");
            driver.FindElement(By.XPath("//input[@placeholder='Password']")).SendKeys("Admin@123");
            driver.FindElement(By.XPath("//button[text()='Login']")).Click();
            Thread.Sleep(2000);

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
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        SubmitEmptyRegisterFom(driver);

        RegisterAsUser(driver);

        SubmitEmptyLoginForm(driver);

        SubmitInvalidCredentials(driver);

        LoginAsUser(driver);

        SearchBarTest_ByName(driver);

        SearchBarTest_ByType(driver);

        SearchBarTest_ByAddress(driver);

        //TearDown.
        try
        {
            //End from Login Page.
            driver.Navigate().GoToUrl("http://localhost:3000/");
            Thread.Sleep(2000);

            //Login as an "Admin" User.
            driver.FindElement(By.XPath("//input[@placeholder='Username']")).SendKeys("Admin");
            driver.FindElement(By.XPath("//input[@placeholder='Password']")).SendKeys("Admin@123");
            driver.FindElement(By.XPath("//button[text()='Login']")).Click();
            Thread.Sleep(2000);

            //Delete sample data.
            driver.FindElement(By.XPath("//button[text()='Delete']")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//button[text()='Delete']")).Click();
            Thread.Sleep(2000);
        } 
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

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
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static void RegisterAsUser(IWebDriver driver)
    {
        try
        {
            //Start from Register Page.
            driver.Navigate().GoToUrl("http://localhost:3000/register");
            Thread.Sleep(2000);

            //Submit Valid Credentials.
            driver.FindElement(By.XPath("//input[@placeholder='Username']")).SendKeys("Someone");
            driver.FindElement(By.XPath("//input[@placeholder='Password']")).SendKeys("Somebody@123");
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
        }
        catch (Exception ex)
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
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static void LoginAsUser(IWebDriver driver)
    {
        try
        {
            //Start from Login Page.
            driver.Navigate().GoToUrl("http://localhost:3000/");
            Thread.Sleep(2000);

            //Login as an "User" User.
            driver.FindElement(By.XPath("//input[@placeholder='Username']")).SendKeys("User306");
            driver.FindElement(By.XPath("//input[@placeholder='Password']")).SendKeys("User@123");
            driver.FindElement(By.XPath("//button[text()='Login']")).Click();
            Thread.Sleep(2000);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static void SearchBarTest_ByName(IWebDriver driver)
    {
        try
        {
            LoginAsUser(driver);

            //Send keys to search bar.
            driver.FindElement(By.XPath("//input[@placeholder='Search by name, type, or address']")).SendKeys("Box A");
            Thread.Sleep(2000);

            //Send keys to search bar.
            driver.FindElement(By.XPath("//input[@placeholder='Search by name, type, or address']")).Clear();
            driver.FindElement(By.XPath("//input[@placeholder='Search by name, type, or address']")).SendKeys("Box B");
            Thread.Sleep(2000);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static void SearchBarTest_ByType(IWebDriver driver)
    {
        try
        {
            LoginAsUser(driver);

            //Send keys to search bar.
            driver.FindElement(By.XPath("//input[@placeholder='Search by name, type, or address']")).SendKeys("Games");
            Thread.Sleep(2000);

            //Send keys to search bar.
            driver.FindElement(By.XPath("//input[@placeholder='Search by name, type, or address']")).Clear();
            driver.FindElement(By.XPath("//input[@placeholder='Search by name, type, or address']")).SendKeys("Movies");
            Thread.Sleep(2000);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static void SearchBarTest_ByAddress(IWebDriver driver)
    {
        try
        {
            LoginAsUser(driver);

            //Send keys to search bar.
            driver.FindElement(By.XPath("//input[@placeholder='Search by name, type, or address']")).SendKeys("123");
            Thread.Sleep(2000);

            //Send keys to search bar.
            driver.FindElement(By.XPath("//input[@placeholder='Search by name, type, or address']")).Clear();
            driver.FindElement(By.XPath("//input[@placeholder='Search by name, type, or address']")).SendKeys("456");
            Thread.Sleep(2000);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
