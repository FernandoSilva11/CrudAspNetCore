﻿using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;


namespace Selenium.Utils
{
    public static class WebDriverFactory
    {
        public static IWebDriver CreateWebDriver(
            Browser browser, string pathDriver)
        {
            IWebDriver webDriver = null;

            switch (browser)
            {
                case Browser.Firefox:
                    FirefoxDriverService service =
                        FirefoxDriverService.CreateDefaultService(pathDriver);

                    webDriver = new FirefoxDriver(service);

                    break;
                case Browser.Chrome:
                    webDriver = new ChromeDriver(pathDriver);

                    break;
            }

            return webDriver;
        }
    }
}
