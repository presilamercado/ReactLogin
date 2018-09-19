using System;
using OpenQA.Selenium;

namespace LoginTest.Pages
{
    public class TimeandMaterial
    {
        public void AddTandM(IWebDriver driver)
        {
            //Click on the Administration Menu button
            driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a")).Click();
            Console.WriteLine("Clicked on the Administration button");

            //Verification
            string msgC = "Customers";
            string actualMsge = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[1]/a")).Text;

            if (msgC == actualMsge)
            {
                Console.WriteLine("Test Pass");
            }
            //Click on Time&Materials drop down tab
            driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a")).Click();
            Console.WriteLine("Clicked on the Time and Materials button");

         
        }
    }
}
