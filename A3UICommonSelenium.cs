using Applitools.Selenium;
using Microsoft.Win32;
using OAF.A3.UI.Lib.PmsPageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using OAF.A3.UI.Lib.Actions;
using OAF.Common.Test.Common.Utils;
using OAF.Common.UI;

namespace OAF.A3.UI
{
    public class A3UICommonSelenium : UICommonSelenium
    {
        
        public static IWebDriver Driver { get; private set; }
        public static Eyes Eyes { get; set; }
        public static UIRunOptions UIRunOptions;
        public static SeleniumSettings SeleniumSettings;
        public static AppliToolsEyesSettings AppliToolsEyesSettings;
        public static Size Resolution898P => new Size(898, 806);
        public static Size Resolution1536P => new Size(1536, 806);

        public static string url;
        public static string username;
        public static string password;
        public static string tenant;

        protected static string DriversPath =
            (AppContext.BaseDirectory).Split(new[] { "bin" }, StringSplitOptions.None)[0] + "src" +
            Path.DirectorySeparatorChar + "Drivers" + Path.DirectorySeparatorChar;

        protected static string EdgeDriversPath = DriversPath + "EdgeDrivers" + Path.DirectorySeparatorChar;
        public static bool loginFlag = false;
        public A3UICommonActions CommonActions { get; set; }
        
        public A3UICommonSelenium()
        {
            CommonActions = new A3UICommonActions();
        }


        public static void LaunchBrowser(string browserName)
        {
            ChromeOptions options = new ChromeOptions();
            switch (browserName)
            {
                case "Firefox":
                    var service = FirefoxDriverService.CreateDefaultService(DriversPath);
                    service.FirefoxBinaryPath = GetFirefoxPath();
                    Driver = new FirefoxDriver(service);
                    break;

                case "Edge":
                    Driver = new EdgeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                    break;

                case "Chrome":
                    options.AddArgument(A3UICommonActions.language);
                    Driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), options);
                    break;

                case "Safari":
                    Driver = new SafariDriver();
                    break;

                case "Headless":
                    options.AddArgument("--headless");
                    options.AddArgument("no-sandbox");
                    options.AddArgument(A3UICommonActions.language);
                    Driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), options);
                    break;

                default:
                    throw new WebDriverException($"Cannot process driver with name {browserName}");
            }

            Driver.Manage().Window.Size = new Size(1800,1200);
        }

        public static string GetFirefoxPath()
        {
            var path = Path.DirectorySeparatorChar + @"Mozilla Firefox" +
                       Path.DirectorySeparatorChar + "firefox.exe";

            return File.Exists(@Environment.GetEnvironmentVariable("SystemDrive") + Path.DirectorySeparatorChar + "Program Files" + path)
                ? @Environment.GetEnvironmentVariable("SystemDrive") + Path.DirectorySeparatorChar + "Program Files" +
                  path
                : @Environment.GetEnvironmentVariable("SystemDrive") + Path.DirectorySeparatorChar +
                  "Program Files (x86)" + path;
        }


        public static string GetMsEdgeVersion()
        {
            var edgeVersion = string.Empty;

            var reg = Registry.ClassesRoot.OpenSubKey(
                @"Local Settings\Software\Microsoft\Windows\CurrentVersion\AppModel\PackageRepository\Packages");

            if (reg == null)
            {
                return edgeVersion;
            }

            foreach (var subkey in reg.GetSubKeyNames())
            {
                if (!subkey.StartsWith("Microsoft.MicrosoftEdge"))
                {
                    continue;
                }

                var rxEdgeVersion = Regex.Match(subkey,
                    @"(Microsoft.MicrosoftEdge_)(?<version>\d+\.\d+\.\d+\.\d+)(_neutral__8wekyb3d8bbwe)");
                if (rxEdgeVersion.Success)
                {
                    edgeVersion = rxEdgeVersion.Groups["version"].Value;
                }
            }

            return edgeVersion.Substring(3, 5);
        }

        public static void IsloggedIn()
        {
            if (!loginFlag)
            {
                PmsPages.LoginPage.NavigateToAcuitas3(url).OnLoginPage();
                PmsPages.LoginPage.EnterUserName(username).EnterPassword(password).EnterTenant(tenant);
                PmsPages.LoginPage.ClickLoginBtnAndCheckLoggedIn();
            }
        }

        /// <summary>
        /// This method logs in A3 with user data from param if not logged already.
        /// If logged with different user, logs out and log in with user data from param.
        /// </summary>
        /// <param name="username">
        /// <param name="password">
        /// <param name="tenant"> 
        public void LogInWithUserData(string username, string password, string tenant)
        {
            if (!loginFlag)
            {
                Console.WriteLine("User not logged in. Need to login");
                PmsPages.LoginPage.NavigateToAcuitas3(url).OnLoginPage();
                PmsPages.LoginPage.EnterUserName(username).EnterPassword(password).EnterTenant(tenant);
                PmsPages.LoginPage.ClickLoginBtnAndCheckLoggedIn();
            }
            if (!username.ConvertEmailToFirstNameLastName()
                .Contains((CommonActions.GetElementText(CommonActions.A3UICommonLocators.userName, A3UICommonActions.microPause).ToLower())))
            {
                // how to check tenant is correct??
                Console.WriteLine("Username changed. Need to log out");
                PmsPages.LogoutPage.ClickLogoutBtnAndCheckLoggedOut();
                PmsPages.LoginPage.EnterUserName(username).EnterPassword(password).EnterTenant(tenant);
                PmsPages.LoginPage.ClickLoginBtnAndCheckLoggedIn();
            }
        }

        public static void SwitchWindow()
        {
            var mainHandle = Driver.CurrentWindowHandle;
            var handles = Driver.WindowHandles;

            foreach (var handle in handles)
            {
                if (mainHandle == handle)
                {
                   
                    continue;
                }
              
                Driver.SwitchTo().Window(handle);
                break;
                
            }
        }

        public static void CloseNewTab()
        {
            var handles = Driver.WindowHandles;
            foreach (var handle in handles)
            {
                Driver.SwitchTo().Window(handle);
                break;
            }
        }
     }
}
