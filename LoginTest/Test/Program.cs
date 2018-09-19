using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;
using LoginTest.Pages;


namespace LoginTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initialize the browser
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            LoginPage obj = new LoginPage();
            obj.LoginStep(driver);

            TimeandMaterial obj1 = new TimeandMaterial();
            obj1.AddTandM(driver);
     
            //Click on Create new button
            driver.FindElement(By.XPath("//*[@id='container']/p/a")).Click();
            Console.WriteLine("Clicked on the Create button");

            //Default input datas
            string code = "xPrezila";
            string desc = "xPresilaDescription";
            string price = "55.00";


            //Identify Code textbox
            IWebElement codeElement = driver.FindElement(By.Id("Code"));
            codeElement.SendKeys(code);
            Console.WriteLine("Code Entered");


            //Identify Description textbox
            IWebElement descElement = driver.FindElement(By.Id("Description"));
            descElement.SendKeys(desc);
            Console.WriteLine("Description Entered");

            //Identify Price textbox
            IWebElement priceElement = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            //Send the data to Price textbox
            priceElement.SendKeys(price);
            Console.WriteLine("Price Entered");

            //Click on the Save button
            driver.FindElement(By.XPath("//*[@id='SaveButton']")).Click();
            Console.WriteLine("Clicked on Save button ");

            // to post execution for 2 seconds / enough time to wait for page to be rendered completly
            Thread.Sleep(2000);

            // wait until the page has completely rendered
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10000));
            wait.Until(d => d.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]")));

            // to click last button page of pagination   
            driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]")).Click();


            // to post execution for 2 seconds / enough time to wait for page to be rendered completly
            Thread.Sleep(2000);

            Console.WriteLine("Clicked on the last pagination button");

            IWebElement table = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table"));

            // getting the list table and loop through the rows and then compare the cells with the new added record.
            // and return success if the record is found.
            ReadOnlyCollection<IWebElement> allRows = table.FindElements(By.TagName("tr"));

            // flag if created
            bool isFound = false;

            foreach (IWebElement row in allRows)
            {
                ReadOnlyCollection<IWebElement> cells = row.FindElements(By.TagName("td"));

                if (code == cells[0].Text && desc == cells[2].Text && ("$" + price) == cells[3].Text)
                {
                    isFound = true;

                    break;
                }
            }
            if (isFound)
            {
                Console.WriteLine("Record successfully added");
            }
            else
            {
                Console.WriteLine("Record not added");
            }


            Thread.Sleep(3000);
            //Click on the Edit button
            driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[5]/td[5]/a[1]")).Click();



            //Default input edit datas
            string editcode = "Editpresila";
            string editdesc = "Edit Description";
            string editprice = "888.00";




            //Identify Edit Code textbox
            IWebElement editcodeElement = driver.FindElement(By.Id("Code"));
            editcodeElement.Clear();
            editcodeElement.SendKeys(editcode);
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine(" Edit Code Entered");




            //Identify Description textbox
            IWebElement editdescElement = driver.FindElement(By.Id("Description"));
            editdescElement.Clear();
            editdescElement.SendKeys(editdesc);
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Edit Decription Entered ");


            //Identify Price textbox
            IWebElement editpriceElement = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
             editpriceElement.Clear();
            //Send the data to Price textbox
            editpriceElement.SendKeys(editprice);
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Edit Price Entered");



            //Thread.Sleep(5000);
            //IWebElement element = driver.FindElement(By.Id("//*[@id='files']"));
            //element.SendKeys("file:///Users/presila/Desktop/presila.jpg");
            //driver.FindElement(By.XPath("//*[@id='files']")).Click();
            //IWebElement fileUpload = driver.FindElement(By.XPath("//*[@id='files']"));
            // Runtime.getRuntime().exec("");
            // driver.FindElement(By.xpath("//*[@id='files']")).click();
            // fileUpload.SendKeys("file:///Users/presila/Desktop/presila.jpg");

            // Console.WriteLine("Selected file uploaded");

            Thread.Sleep(3000);
            //Click on the Save button
            driver.FindElement(By.XPath("//*[@id='SaveButton']")).Click();
            Console.WriteLine("Clicked on Save button ");

            // to post execution for 2 seconds / enough time to wait for page to be rendered completly
            Thread.Sleep(2000);

            // wait until the page has completely rendered
            var iwait = new WebDriverWait(driver, TimeSpan.FromSeconds(10000));
            wait.Until(d => d.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]")));



            IWebElement edittable = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table"));
            // getting the list table and loop through the rows and then compare the cells with the new added record.
            // and return success if the record is found.
            ReadOnlyCollection<IWebElement> allEditRows = edittable.FindElements(By.TagName("tr"));

            // flag if created
            bool isEditFound = false;

            foreach (IWebElement row in allEditRows)
            {
                ReadOnlyCollection<IWebElement> editcells = row.FindElements(By.TagName("td"));

                if (editcode == editcells[0].Text && editdesc == editcells[2].Text)
                {
                    isEditFound = true;

                    break;
                }
            }
            if (isEditFound)
            {
                Console.WriteLine("Edit record successfully added");
            }
            else
            {
                Console.WriteLine("Edit record unsuccess");
            }


            Thread.Sleep(2000);
            //Delete Button
            driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[5]/a[2]")).Click();
            IAlert deleteConfirmation = driver.SwitchTo().Alert();
            String alerText = deleteConfirmation.Text;
            Console.WriteLine("Delete button " + alerText);
            deleteConfirmation.Accept();
            //for Dismiss
            //deleteConfirmation.Dismiss();



                            
            Thread.Sleep(2000);
      
           //Quitting the Chrome
            ChromeOptions options = new ChromeOptions();
            System.Threading.Thread.Sleep(2000);
            driver.Close();
            driver.Quit();

        }
    }
}
