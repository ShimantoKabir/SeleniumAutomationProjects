using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace EspAuto
{
    public class ProductPreview
    {
        public IWebDriver webDriver;
        
        public ProductPreview(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public void run()
        {
            webDriver.Navigate().GoToUrl("http://espares.co.uk/");
            Console.WriteLine(webDriver.Title + " ~ loaded!");
                
            ReadOnlyCollection<IWebElement> megaMenuPanelElmLinks = webDriver
                .FindElements(By.CssSelector(".mobile-megamenu-panel>ul>li>a"));

            List<string> megaMenuPanelLinks = new List<string>();
            foreach (var link in megaMenuPanelElmLinks)
            {
                if (link.GetAttribute("href").Contains("search"))
                {
                    megaMenuPanelLinks.Add(link.GetAttribute("href"));   
                }

            }

            foreach (var link in megaMenuPanelLinks)
            {
                Console.WriteLine(link+" ~ mega men link");
                search(link);
            }
        }
        
        public void search(string url)
        {
            
            webDriver.Navigate().GoToUrl(url);
            Console.WriteLine(webDriver.Title + " ~ loaded!");

            preview();
            
            webDriver.Navigate().GoToUrl(url);
            Console.WriteLine(webDriver.Title + " ~ back!");
            
            IWebElement paginationLi = webDriver.FindElement(By.CssSelector(".pagination>li:last-child"));

            if (paginationLi.GetAttribute("class").Equals("disabled"))
            {
                Console.WriteLine("last page!");
            }
            else
            {
                IWebElement paginationLiLink = webDriver.FindElement(By.CssSelector(".pagination>li:last-child>a"));
                search(paginationLiLink.GetAttribute("href"));
            }

        }

        private void preview()
        {
            ReadOnlyCollection<IWebElement> productElmList = webDriver.FindElements(
                By.CssSelector(".product-listing>li>div.product-desktop>div.thumb.product-image-container-table>a"));
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