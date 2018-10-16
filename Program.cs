using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace create_a_user
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://horse-dev.azurewebsites.net");

            //inter the username
            IWebElement UserName = driver.FindElement(By.XPath("//*[@id='UserName']"));

            UserName.SendKeys("hari");

            //inter the password
            IWebElement PassWord = driver.FindElement(By.XPath("//*[@id='Password']"));

            PassWord.SendKeys("123123");

            //click the Login button
            IWebElement Login = driver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]"));

            Login.Click();

            //click Administration button
            IWebElement AdminisButton = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            AdminisButton.Click();

            //click the employee button
            IWebElement EmployeesButton = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[2]/a"));

            EmployeesButton.Click();

            //click the create button

            IWebElement CreateButton = driver.FindElement(By.XPath("//*[@id='container']/p/a"));

            CreateButton.Click();

            //create the Name
            String NameT = "testers";
            IWebElement CreateName = driver.FindElement(By.XPath("//*[@id='Name']"));
            CreateName.SendKeys(NameT);

            //create the username
            
            IWebElement CreateUserName = driver.FindElement(By.XPath("//*[@id='Username']"));
            CreateUserName.SendKeys("testerss");

            //create the contact
            IWebElement CreateContact = driver.FindElement(By.XPath("//*[@id='ContactDisplay']"));
            CreateContact.SendKeys("1234");

            //create the password
            IWebElement CreatePassword = driver.FindElement(By.XPath("//*[@id='Password']"));
            CreatePassword.SendKeys("Sa1234567");

            //retypepassword
            IWebElement RetypePassword = driver.FindElement(By.XPath("//*[@id='RetypePassword']"));
            RetypePassword.SendKeys("Sa1234567");

            //click the Save button
            IWebElement SaveButton = driver.FindElement(By.XPath("//*[@id='SaveButton']"));
            SaveButton.Click();

            //back to the previous page
            IWebElement BackToList = driver.FindElement(By.XPath("//*[@id='container']/div/a"));
            BackToList.Click();

            Thread.Sleep(2000);

            //checking the new user is created
            if(driver.FindElement(By.XPath("//*[@id='usersGrid']/div[3]/table/tbody/tr[1]/td[1]")).Text == NameT)
            {
                Console.WriteLine("the new user is located in the first page");
            }
            else
            {
                IWebElement BackToLastPage = driver.FindElement(By.XPath("//*[@id='usersGrid']/div[4]/a[4]/span"));
                BackToLastPage.Click();

                if(driver.FindElement(By.XPath("//*[@id='usersGrid']/div[3]/table/tbody/tr[6]/td[1]")).Text== NameT)
                {
                    Console.WriteLine("the new user is created succefully");
                }
                else
                {
                    Console.WriteLine("the new user is not existing, the test faild");
                }


            }



        }
    }
}
