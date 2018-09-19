using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;
using LoginTest.Pages;
using AutoIt;
using LoginTest.Global;
using NUnit.Framework;

namespace LoginTest
{
    class Program
    {
        static void Main(string[] args)
        {

            Thread.Sleep(2000);

            //Quitting the Chrome
            // ChromeOptions options = new ChromeOptions();
           // System.Threading.Thread.Sleep(2000);
           // driver.Close();
            //driver.Quit();

        }
        [TestFixture]
         class React
        {
            //Preconditions
            [SetUp]
            public void setUp()
            {
                //Initialize the browser
                // IWebDriver driver = new ChromeDriver();

                GlobalDefinitions.driver = new ChromeDriver();
                GlobalDefinitions.driver.Manage().Window.Maximize();

              

            }
            //TestCases
            [Test]
            public void LoginTest()
            {

               GlobalDefinitions.driver.Url =" https://react-redux-registration-login-example.stackblitz.io/login";

                LoginPage loginPage = new LoginPage();
                loginPage.LoginStep();

            }
           


            //Consclusion 
            [TearDown]
            public void tearDown()
            {
               
                Global.GlobalDefinitions.driver.Close();
            }
        }
    }
}
