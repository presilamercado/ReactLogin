using System;
using OpenQA.Selenium;

namespace LoginTest.Pages
{
    public class LoginPage
    {
        public void LoginStep(IWebDriver driver)
        {

            //Navigate to the Url
            driver.Navigate().GoToUrl("http://horse-dev.azurewebsites.net/");
            //Identify username textbox
            var Username = driver.FindElement(By.Id("UserName"));
            //Send the data to Username
            Username.SendKeys("ray");
            Console.WriteLine("Username Entered");

            //Identify password textbox
            IWebElement Password = driver.FindElement(By.Id("Password"));
            //send data to Password textbox
            Password.SendKeys("123123");
            Console.WriteLine("Password Entered");

            //Click on Login button
            driver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]")).Click();
            Console.WriteLine("Clicked on Login button ");

            //Verification
            string msg = "Add New Job";
            string actualMsg = driver.FindElement(By.XPath("//*[@id='addnewjob']")).Text;

            if (msg == actualMsg)
            {
                Console.WriteLine("Test Pass");
            }


        }
    }
}
