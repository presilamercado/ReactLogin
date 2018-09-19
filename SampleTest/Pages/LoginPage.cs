using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using LoginTest.Global;
using System.Threading;
using static LoginTest.Global.GlobalDefinitions;
using static NUnit.Core.NUnitFramework;

namespace LoginTest.Pages
{
    public class LoginPage
    {
        
        public LoginPage()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }
        
        // Define IWebElements
        //Identity UserName
        [FindsBy(How =How.XPath, Using = "/html/body/div[1]/div/div/div/div/div/form/div[1]/input")]
        private IWebElement userName { get; set; }

        // Identy Password                 
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/div/div/div/div/form/div[2]/input")]
        private IWebElement password { get; set; }

         // Identy Login Button 
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/div/div/div/div/form/div[3]/button")]
        private IWebElement loginBtn { get; set; }

        // Click on Register Button 
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/div/div/div/div/form/div[3]/a")]
        private IWebElement RegBtn { get; set; }

        //Fill in 
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/div/div/div/div/form/div[1]/input")]
        private IWebElement FName { get; set; }
        //Fill in 
        [FindsBy(How = How.XPath, Using = " /html/body/div[1]/div/div/div/div/div/form/div[2]/input")]
        private IWebElement LName { get; set; }
        //Fill In
        [FindsBy(How = How.XPath, Using = " /html/body/div[1]/div/div/div/div/div/form/div[3]/input")]
        private IWebElement RUserName { get; set; }
        //Fill in
        [FindsBy(How = How.XPath, Using = " /html/body/div[1]/div/div/div/div/div/form/div[4]/input")]
        private IWebElement RPassword { get; set; }
        //Click on Registration button
        [FindsBy(How = How.XPath, Using = " /html/body/div[1]/div/div/div/div/div/form/div[5]/button")]
        private IWebElement PRegBtn { get; set; }
           
       
        //Starting loggin In
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/div/div/div[2]/div/form/div[1]/input")]
        private IWebElement username2 { get; set; }
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/div/div/div[2]/div/form/div[2]/input")]
        private IWebElement password2 { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/div/div/div[2]/div/form/div[3]/button")]
        private IWebElement Login2btn { get; set; }



        public void LoginStep()
        {

            Thread.Sleep(3000);

            
            //Popuate the Excel
            //  Global.GlobalDefinitions.ExcelLib.PopulateInCollection(@"C:\Users\Administrator\Documents\Visual Studio 2015\Projects\SampleTest\ExcelData.xlsx", "LoginPage");


            //ExcelLib.PopulateInCollection(Config.TurnUpResource.ExcelPath, "LoginPage");
            Thread.Sleep(1000);
            // Navigating to Login page using value from Excel
            // GlobalDefinitions.driver.Navigate().GoToUrl(GlobalDefinitions.ExcelLib.ReadData(2, "Url"));



            // userName.SendKeys(ExcelLib.ReadData(2, "UserName"));
            userName.SendKeys("presila.mercado");
            password.SendKeys("Moonwalker");
            //Read LastName
            // password.SendKeys(ExcelLib.ReadData(2, "Password"));

            loginBtn.Click();
            Thread.Sleep(2000);

            RegBtn.Click();
            Thread.Sleep(200);
            FName.SendKeys("Presila");
            LName.SendKeys("Valdez");
            RUserName.SendKeys("presilavaldez");
            RPassword.SendKeys("moonwalker");
            PRegBtn.Click();
            //Thread.Sleep(2000);
            userName.SendKeys("presilavaldez");
            password.SendKeys("moonwalker");
            loginBtn.Click();

            Thread.Sleep(2000);



            //Verification
            string msg = ("Registration successfull");
            string actualMsg = GlobalDefinitions.driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div[1]")).Text;

            if (msg == actualMsg)
            {
                Console.WriteLine("Test Pass");
                GlobalDefinitions.SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "SuccessRegistration");
            }

            Thread.Sleep(3000);
            username2.SendKeys("presilavaldez");
            password2.SendKeys("moonwalker");
            Login2btn.Click();

            //Verification
            //string msg2 = ("Logout");       
            //string actualMsg2 = GlobalDefinitions.driver.FindElement(By.CssSelector("html body div#app div.jumbotron div.container div.col-sm-8.col-sm-offset-2 div div.col-md-6.col-md-offset-3 p a")).Text;

           
            //Assert.AreEqual(msg2.Substring(6), actualMsg2);

        }


        }
    }


