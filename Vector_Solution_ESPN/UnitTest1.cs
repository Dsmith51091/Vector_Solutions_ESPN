using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using System.IO;
using System.Collections.Generic;
using System.Threading;


namespace Vector_Solution_ESPN
{
    public class Tests
    {
        public IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
        }

        [Test]
        
        public void ESPN_Headline()
        {
            //Navigate to ESPN.com and maximize the browswer
            driver.Navigate().GoToUrl("https://www.espn.com/");
            driver.Manage().Window.Maximize();

            //Capture the to headline and save it to a text file
            String ESPN_Top_Headline = driver.FindElement(By.XPath("//*[@id='main-container']/div/section[3]/div[1]/section/ul/li[1]/a")).Text;
            File.WriteAllText("ESPN_Headline.txt", ESPN_Top_Headline);

            //Take a screenshot of the homepage of ESPN and save the screenshot
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile("ESPN_Home_Page.png");

            //Exit the application
            driver.Quit();
            

            Assert.Pass();
        }

        [Test]

        public void ESPN_Favorite_Sport()
        {
            //Navigate to ESPN.com and maximize the browswer
            driver.Navigate().GoToUrl("https://www.espn.com/");
            driver.Manage().Window.Maximize();

            //Select the User Icon in the Top Right of the Page
            driver.FindElement(By.Id("global-user-trigger")).Click(); 
            
            //Select the "Add to Favorties" Button
            driver.FindElement(By.XPath("//*[@id='global-header']/div[2]/ul/li[2]/div/div/ul[2]/li/div/div/a")).Click();

            //Add NHL to your Favorties by clicking the follow button 
            Thread.Sleep(5000);
            driver.SwitchTo().ParentFrame();
            driver.SwitchTo().Frame("favorites-manager-iframe");
            IWebElement follow = driver.FindElement(By.XPath("//*[@id='fittPortal_0']/div/div/section/div/div/section/div/section/section[1]/div/ul/li[5]/div[2]/div/button"));
            follow.GetAttribute("text");
            follow.Click();
            
            //verify that NHL has been added to your Favorites
            bool isSportFollowed = driver.FindElement(By.XPath("//*[@id='fittPortal_0']/div/div/section/div/div/section/div/section/section[2]/div[1]/ul[3]/li[2]/div[1]")).Displayed;
            
            //Exit the application
            driver.Quit();

            Assert.Pass();
        }
    }
}