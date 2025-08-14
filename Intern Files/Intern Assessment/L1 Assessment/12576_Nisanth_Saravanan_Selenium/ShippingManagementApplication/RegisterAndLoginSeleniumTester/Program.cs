using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

class Program
{
    public static void Main(string[] args)
    {
        //SetUp
        IWebDriver driver = new ChromeDriver();
        driver.Manage().Window.Maximize();

        SubmitEmptyRegisterFom(driver);

        SubmitEmptyLoginForm(driver);

        SubmitInvalidCredentials(driver);

        RegisterAsUser(driver);

        FailUserRegister(driver);

        LoginAsAdmin(driver);

        LoginAsUser(driver);

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
        }
        catch(Exception ex)
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
            driver.FindElement(By.XPath("//input[@placeholder='Username']")).SendKeys("Someone else");
            driver.FindElement(By.XPath("//input[@placeholder='Password']")).SendKeys("Somebody@123");
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

    static void RegisterAsUser(IWebDriver driver)
    {
        try
        {
            //Start from Register Page.
            driver.Navigate().GoToUrl("http://localhost:3000/register");
            Thread.Sleep(2000);

            //Submit Valid Credentials.
            driver.FindElement(By.XPath("//input[@placeholder='Username']")).SendKeys("Someone in the wind.");
            driver.FindElement(By.XPath("//input[@placeholder='Password']")).SendKeys("Somebody@123");
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

    static void FailUserRegister(IWebDriver driver)
    {
        try
        {
            //Start from Register Page.
            driver.Navigate().GoToUrl("http://localhost:3000/register");
            Thread.Sleep(2000);

            //Submit Valid Credentials.
            driver.FindElement(By.XPath("//input[@placeholder='Username']")).SendKeys("Someone in the wind.");
            driver.FindElement(By.XPath("//input[@placeholder='Password']")).SendKeys("Somebody@123");
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

            //Logout.
            driver.FindElement(By.XPath("//button[text()='Logout']")).Click();
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

            //Logout.
            driver.FindElement(By.XPath("//button[text()='Logout']")).Click();
            Thread.Sleep(2000);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
