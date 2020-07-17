using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace TestProjects
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://localhost:50527/Employee/Modify/");
            driver.Manage().Window.Maximize();

            //Find the Element 
           // IWebElement element = driver.FindElement(By.Name("q"));

            //Apply the Operations 
           // element.SendKeys("C# Jobs");

            
            driver.Close();
            driver.Quit();
        }

       
        //[Test]
        //public void myTestMethod()
        //{
        //    IWebDriver mydd = new ChromeDriver();
        //    IWebDriver driver = new ChromeDriver();

        //    driver.Navigate().GoToUrl("https://www.google.ca/");
        //    driver.Manage().Window.Maximize();

        //    //Find the Element 
        //    IWebElement element = driver.FindElement(By.Name("q"));

        //    //Apply the Operations 
        //    element.SendKeys("C# Jobs");
        //}
    }
}
