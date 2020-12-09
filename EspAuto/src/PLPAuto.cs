using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace EspAuto
{
    public class PLPAuto
    {
        public void run(IWebDriver webDriver)
        {
            webDriver.Navigate().GoToUrl("http://espares.co.uk/");
            Console.WriteLine(webDriver.Title + " ~ loaded!");
            IWebElement homePageQuery = webDriver.FindElement(By.CssSelector(".primary-navigation>li:nth-child(2)>a"));
            homePageQuery.Click();
            Console.WriteLine(webDriver.Title + " ~ loaded!");
            IWebElement brandPageQuery = webDriver.FindElement(By.ClassName("a-z-index-keys"));
            ReadOnlyCollection<IWebElement> aTozLinks = brandPageQuery.FindElements(By.CssSelector("li>a"));

            List<string> allBrandLinkTexts = new List<string>();
            foreach (var abLink in aTozLinks)
            {
                allBrandLinkTexts.Add(abLink.Text);
            }

            foreach (var b in allBrandLinkTexts)
            {
                webDriver.Navigate().GoToUrl("https://www.espares.co.uk/brands?facetstartswith=" + b);
                Console.WriteLine(webDriver.Url + " ~ loaded!");
                ReadOnlyCollection<IWebElement> allBrandsByText =
                    webDriver.FindElements(By.CssSelector(".split-list>li>a"));
                List<string> allBrandLinkByTexts = new List<string>();
                foreach (var abt in allBrandsByText)
                {
                    Console.WriteLine(abt.GetAttribute("href") + " ~ href");
                    allBrandLinkByTexts.Add(abt.GetAttribute("href"));
                }

                foreach (var ablt in allBrandLinkByTexts)
                {
                    webDriver.Navigate().GoToUrl(ablt);
                    Console.WriteLine(webDriver.Url + " ~ loaded!");

                    ReadOnlyCollection<IWebElement> productElmList = webDriver.FindElements(
                        By.CssSelector(
                            ".product-listing>li>div.product-desktop>div.thumb.product-image-container-table>a"));
                    List<string> productLinkList = new List<string>();
                    foreach (var pe in productElmList)
                    {
                        Console.WriteLine(pe.GetAttribute("href") + " ~ product href");
                        productLinkList.Add(pe.GetAttribute("href"));
                    }

                    foreach (var pl in productLinkList)
                    {
                        webDriver.Navigate().GoToUrl(pl);
                        Console.WriteLine(webDriver.Url + " ~ loaded!");
                    }
                }
            }
        }
    }
}