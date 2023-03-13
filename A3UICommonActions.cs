using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using JavascriptExecutor = OpenQA.Selenium.IJavaScriptExecutor;
using Action = OpenQA.Selenium.Interactions.Actions;
using System.Collections.Generic;
using System.Linq;
using OAF.Common.Test.Common.Utils;
using OAF.A3.UI.Lib.PmsPageObjects;
using TechTalk.SpecFlow;
using System.Data;
using OAF.Common.UI;
using System.Threading;

namespace OAF.A3.UI.Lib.Actions
{
    public class A3UICommonActions : UICommonActions
    {
        private readonly IWebDriver _driver = A3UICommonSelenium.Driver;

        #region Global values for wait
        public static int microPause => A3UICommonSelenium.SeleniumSettings.MicroTimeout.Value;
        public static int shortPause => A3UICommonSelenium.SeleniumSettings.ShortTimeout.Value;
        public static int longPause => A3UICommonSelenium.SeleniumSettings.HighTimeout.Value;
        public static int mediumPause => A3UICommonSelenium.SeleniumSettings.MediumTimeout.Value;
        public static int xLongPause => A3UICommonSelenium.SeleniumSettings.XHighTimeout.Value;
        #endregion

        #region Other Global values
        public static int NumberPixelsItem => A3UICommonSelenium.SeleniumSettings.NumberPixelsItem.Value;
        public static int NumberPixelsMainAreaVerticalContainer => A3UICommonSelenium.SeleniumSettings.NumberPixelsMainAreaVerticalContainer.Value;
        public static string language => A3UICommonSelenium.SeleniumSettings.Language;
        public static string dateFormat => A3UICommonSelenium.SeleniumSettings.DateFormat;
        public static string timeFormat => A3UICommonSelenium.SeleniumSettings.TimeFormat;
        #endregion
        public List<string> errorOKButtonList = new List<string>();
        public int counterForError = 0;
        public Random RandomNumber = new Random();

        /// <summary>
        /// Create the object with Locators.
        /// </summary>
        public A3UICommonLocatorsPage A3UICommonLocators;
        public A3UICommonActions()
        {
            A3UICommonLocators = new A3UICommonLocatorsPage();
        }

        public enum ClickType
        {
            Click,
            JSClick,
            BrowserBasedClick
        }

        /// <summary>
        /// Builds the List of different Error Buttons.
        /// </summary>
        /// <returns>List<string></returns>
        public List<string> BuildErrorOKButtonList()
        {
            //currently there is no error to skip but I'm keeping this as commented to restore it easily or search for a similar error if necessary in a future
            //errorOKButtonList.Add("xpath=//button[@data-testid='global-error-modal-ok-btn']");
            return errorOKButtonList;
        }

        /// <summary>
        /// Navigate To Application Url
        /// </summary>
        /// <param name="url"></param>
        public void NavigateToApplicationUrl(string url) => _driver.Navigate().GoToUrl(url);

        /// <summary>
        /// Maximizes windows
        /// </summary>
        /// <returns></returns>
        public void MaximizeWindow() => _driver.Manage().Window.Maximize();

        /// <summary>
        /// Get "By" object to locate element
        /// </summary>
        /// <param name="locator">locator of element in xpath=locator; css=locator etc.</param>
        /// <returns>By</returns>
        public By ByLocator(string locator)
        {
            var prefix = locator.Substring(0, locator.IndexOf('='));
            var suffix = locator.Substring(locator.IndexOf('=') + 1);

            switch (prefix)
            {
                case "xpath":
                    return By.XPath(suffix);
                case "css":
                    return By.CssSelector(suffix);
                case "link":
                    return By.LinkText(suffix);
                case "partLink":
                    return By.PartialLinkText(suffix);
                case "id":
                    return By.Id(suffix);
                case "name":
                    return By.Name(suffix);
                case "tag":
                    return By.TagName(suffix);
                case "class":
                    return By.ClassName(suffix);
                default:
                    return By.Id(suffix);
            }
        }

        /// <summary>
        /// This method is to get IWebElement based on locator
        /// </summary>
        /// <param name="locator">locator of element in xpath=locator; css=locator etc.</param>
        /// <param name="timeout"></param>
        /// <returns>IWebElement</returns>
        public IWebElement GetElement(string locator, int timeout = 0)
        {
            WaitForVisibilityOfElement(locator, timeout);
            return FindElement(ByLocator(locator));
        }

        /// <summary>
        /// This method is used to click on webElement
        /// </summary>
        /// <param name="locator">locator of element in xpath=locator; css=locator etc</param>
        /// <param name="timeout"> wait for visibility of element in seconds</param>
        public void Click(string locator, int timeout = 0, ClickType clickType = ClickType.Click)
        {
            WaitForVisibilityOfElement(locator, timeout);
            switch (clickType)
            {
                case ClickType.Click:
                    FindElement(ByLocator(locator)).Click();
                    break;
                case ClickType.JSClick:
                    ((JavascriptExecutor)_driver).ExecuteScript("arguments[0].click();", GetElement(locator));
                    break;
            }
        }

        /// <summary>
        /// This method is used to doubleclick on webElement knowing its locator
        /// </summary>
        /// <param name="locator">locator of element in xpath=locator; css=locator etc</param>
        /// <param name="timeout"> wait for visibility of element in seconds</param>
        public void DoubleClick(string locator, int timeout = 0)
        {
            if (IsElementVisible(locator, timeout))
            {
                Action actions = new Action(_driver);
                actions.DoubleClick(GetElement(locator, microPause)).Perform();
            }
        }

        /// <summary>
        /// Wait until element is clickable on the page
        /// </summary>
        /// <param name="locator">locator of element in xpath=locator; css=locator etc</param>
        /// <param name="timeout"> wait for visibility of element in seconds</param>
        /// <returns>bool</returns>
        public bool WaitForElementToBeClickable(string locator, int timeout)
        {
            bool flag;
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeout));
            try
            {
                ErrorPopUp();
                var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(ByLocator(locator)));
                flag = true;
            }
            catch (Exception)
            {
                flag = false;
            }

            return flag;
        }

        /// <summary>
        /// Wait until IWebelement is clickable on the page
        /// </summary>
        /// <param name="iwebElement">IWebElement</param>
        /// <param name="timeout"> wait for visibility of element in seconds</param>
        /// <returns>bool</returns>
        public bool WaitForIWebElementToBeClickable(IWebElement iwebElement, int timeout)
        {
            bool flag;
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeout));
            try
            {
                ErrorPopUp();
                var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(iwebElement));
                flag = true;
            }
            catch (Exception)
            {
                flag = false;
            }

            return flag;
        }

        /// <summary>
        /// Using ElementToBeClickable is not always reliable. This method catches the exception triggered when element is not clickable
        /// </summary>
        /// <param name="locator">locator of element</param>
        /// <param name="timeout"></param>
        /// <returns>bool</returns>
        public bool IsElementClickable(string locator, int timeout = 0)
        {
            bool flag;
            try
            {
                Click(locator, timeout);
                flag = true;
            }
            catch (ElementClickInterceptedException)
            {
                flag = false;
            }
            return flag;
        }

        public bool IsWebElementClickable(IWebElement iwebElement, int timeout = 0)
        {
            bool flag;
            try
            {
                iwebElement.Click();
                flag = true;
            }
            catch (ElementClickInterceptedException)
            {
                flag = false;
            }
            //When DOM changes, an element not clickable may stay not available and
            //try click throws this exception instead of the previous one
            catch (StaleElementReferenceException)
            {
                flag = false;
            }
            return flag;
        }


        /// <summary>
        /// This method is used to enter text for the IWebElement
        /// </summary>
        /// <param name="locator">locator of element in xpath=locator; css=locator etc</param>
        /// <param name="value">text to be entered</param>
        /// <param name="timeout"> wait for visibility of element in seconds</param>
        public void EnterText(string locator, string value, int timeout = 0)
        {
            if (timeout != 0)
                WaitForVisibilityOfElement(locator, timeout);
            try
            {
                FindElement(ByLocator(locator)).SendKeys(value);
            }
            catch (Exception)
            {
                WaitForElementToBeClickable(locator, timeout);
                FindElement(ByLocator(locator)).SendKeys(value);
            }
        }

        /// <summary>
        /// Moves to the particular edit text field and clicks to Enter Text to the element
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="value"> text to be entered </param>
        /// <param name="timeout"> wait for visibility of element in seconds</param>
        public void ClickAndEnterText(string locator, string value, int timeout = 0)
        {
            if (timeout != 0)
            {
                WaitForVisibilityOfElement(locator, timeout);
            }

            var element = FindElement(ByLocator(locator));
            var action = new Action(_driver);
            action.MoveToElement(element);
            action.Click();
            action.SendKeys(value);
            action.Build().Perform();
        }

        /// <summary>
        /// This method is used to move to element and click on the element
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="timeout"></param>
        public void MoveToElementAndClick(string locator, int timeout)
        {
            if (timeout != 0)
                WaitForVisibilityOfElement(locator, timeout);
            var element = FindElement(ByLocator(locator));
            var action = new Action(_driver);
            action.MoveToElement(element).Click().Build().Perform();
        }

        /// <summary>
        /// This method is used to clear text inside text field.
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="timeout"> wait for visibility of element in seconds</param>
        public void ClearText(string locator, int timeout = 0)
        {
            if (timeout != 0)
                WaitForVisibilityOfElement(locator, timeout);
            FindElement(ByLocator(locator)).Clear();
        }

        /// <summary>
        /// This method is used check whether element is present on the page
        /// </summary>
        /// <param name="locator">locator of element in xpath=locator; css=locator etc</param>
        /// <param name="timeout"> wait for visibility of element in seconds</param>
        /// <returns>boolean- visible=true, invisible=false</returns>
        public bool IsElementVisible(string locator, int timeout = 0)
        {
            if (timeout != 0) WaitForVisibilityOfElement(locator, timeout);
            try
            {
                return FindElement(ByLocator(locator)).Displayed;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Check if the Alert is present
        /// </summary>
        /// <returns>bool</returns>
        public bool AcceptAlert()
        {
            var flag = false;

            try
            {
                // Check the presence of alert
                var alert = _driver.SwitchTo().Alert();

                // if present consume the alert
                alert.Accept();
                flag = true;
            }

            catch (NoAlertPresentException ex)
            {
                // Alert not present
                Console.WriteLine(ex.ToString());
                Console.Write(ex.StackTrace);
            }
            return flag;
        }

        /// <summary>
        /// This method is used to accept alert if present
        /// </summary>
        /// <returns>bool-true:if alert present,false:if alert not present</returns>
        public string GetAlertText()
        {
            string alertTxt = null;

            try
            {
                var alert = _driver.SwitchTo().Alert();
                alertTxt = alert.Text;
                alert.Accept();
            }
            catch (NoAlertPresentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return alertTxt;
        }

        /// <summary>
        /// Returns page title
        /// </summary>
        /// <returns></returns>
        public string GetPageTitle() => _driver.Title;

        /// <summary>
        /// Get text of the element
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="timeout">wait for visibility of element in seconds</param>
        /// <returns></returns>
        public string GetElementText(string locator, int timeout = 0)
        {
            WaitForVisibilityOfElement(locator, timeout);
            try
            {
                return FindElement(ByLocator(locator)).Text;
            }
            catch (Exception)
            {
                return "";
            }
        }

        public List<string> GetElementsListTexts(string locator, int timeout = 0)
        {
            WaitForVisibilityOfElement(locator, timeout);
            IList<IWebElement> iconsElements = new List<IWebElement>();
            iconsElements = GetElements(locator, microPause);
            List<string> iconsNameTexts = new List<string>();
            for (int i = 0; i < iconsElements.Count; i++)
            {
                iconsNameTexts.Add(iconsElements[i].GetAttribute("innerText"));
            }
            return iconsNameTexts;
        }

        public List<string> GetIWebElementsListTexts(IList<IWebElement> iWebElementList)
        {
            List<string> ListTexts = new List<string>();
            for (int i = 0; i < iWebElementList.Count; i++)
            {
                ListTexts.Add(iWebElementList[i].GetAttribute("innerText"));
            }
            return ListTexts;
        }

        /// <summary>
        /// Gets the state of the element Enable/Disabled
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="timeout"></param>
        /// <returns>bool</returns>
        public bool IsEnabled(string locator, int timeout = 0)
        {
            WaitForVisibilityOfElement(locator, timeout);
            return FindElement(ByLocator(locator)).Enabled;
        }

        /// <summary>
        /// Wait until element is visible/present on the page
        /// </summary>
        /// <param name="locator">locator of element in xpath=locator; css=locator etc</param>
        /// <param name="timeout">wait for visibility of element in seconds</param>
        /// <returns>bool</returns>
        public bool WaitForVisibilityOfElement(string locator, int timeout)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeout));
            try
            {
                ErrorPopUp();
                var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(ByLocator(locator)));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Switch To Frame By Index
        /// </summary>
        /// <param name="index"></param>
        public void SwitchToFrameByIndex(int index) => _driver.SwitchTo().Frame(index);

        /// <summary>
        /// Select Dropdown Item By Text
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="text"></param>
        /// <param name="timeout"></param>
        public void SelectDropdownItemByText(string locator, string text, int timeout = 0)
        {
            WaitForVisibilityOfElement(locator, timeout);
            var dropdown = new SelectElement(FindElement(ByLocator(locator)));
            dropdown.SelectByText(text);
        }

        /// <summary>
        /// Select Dropdown Item By Index
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="index"></param>
        /// <param name="timeout"></param>
        public void SelectDropdownItemByIndex(string locator, int index, int timeout)
        {
            WaitForVisibilityOfElement(locator, timeout);
            var dropdown = new SelectElement(FindElement(ByLocator(locator)));
            dropdown.SelectByIndex(index);
        }

        /// <summary>
        /// Get Selected Value From Dropdown
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="timeout"></param>
        /// <returns>string</returns>
        public string GetSelectedValueFromDropdown(string locator, int timeout)
        {
            WaitForVisibilityOfElement(locator, timeout);
            var dropdown = new SelectElement(FindElement(ByLocator(locator)));
            return dropdown.SelectedOption.Text;
        }

        /// <summary>
        /// Wait until element is not visible/present on the screen
        /// </summary>
        /// <param name="locator">locator of elements in xpath=locator; css=locator etc</param>
        /// <param name="timeout">time in seconds</param>
        /// <returns>boolean</returns>
        public bool WaitForInVisibilityOfElement(string locator, int timeout)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeout));

            try
            {
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(ByLocator(locator)));
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Scroll to particular element 
        /// </summary>
        /// <param name="locator">string</param>
        /// <param name="timeout">wait for visibility of element in seconds</param>
        public void ScrollElementIntoView(string locator, int timeout)
        {

            ((JavascriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", GetElement(locator, timeout));
        }

        /// <summary>
        /// Scroll to particular IWebelement 
        /// </summary>
        /// <param name="iWebElement">string</param>
        /// <param name="timeout">wait for visibility of element in seconds</param>
        public void ScrollIWebElementIntoView(IWebElement iWebElement)
        {
            ((JavascriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", iWebElement);
        }


        /// <summary>
        /// Scroll horizontally and vertically in an element
        /// </summary>
        /// <param name="locator">string</param> element locator
        /// <param name="xcoordinate">int</param>  horizontal pixel value to scroll
        /// <param name="ycoordinate">int</param>  vertical pixel value to scroll
        /// <param name="timeout">wait for visibility of element in seconds</param>
        public void ScrollInElement(string locator, int xcoordinate, int ycoordinate, int timeout = 0)
        {
            ((JavascriptExecutor)_driver).ExecuteScript($"arguments[0].scrollBy({xcoordinate}, {ycoordinate} )", GetElement(locator, timeout));
        }

        /// <summary>
        /// JS to disable mouse up. This will facilitate checkwindow
        /// </summary>
        public void DisableMouseUp()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript(@"window.disableEvent = function(event) {event.stopImmediatePropagation();};window.addEventListener('mouseup', disableEvent, true);");
        }

         /// <summary>
        /// JS to enable mouse up. To use after the action which needed disabled mouseup
        /// </summary>
        public void EnableMouseUp()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript(@"window.removeEventListener('mouseup', window.disableEvent, true);");
        }

        /// <summary>
        /// Returns IWebElement
        /// </summary>
        /// <param name="by"></param>
        /// <returns>IWebElement</returns>
        public IWebElement FindElement(By by)
        {
            var elem = _driver.FindElement(by);
            return elem;
        }

        /// <summary>
        /// Returns IWebElement and highlights the element
        /// </summary>
        /// <param name="by"></param>
        /// <returns>IWebElement</returns>
        public IWebElement FindAndHighlightElement(By by)
        {
            var elem = _driver.FindElement(by);

            // draw a border around the found element
            if (_driver is IJavaScriptExecutor executor)
            {
                executor.ExecuteScript("arguments[0].style.border='2px solid green'", elem);
            }
            return elem;
        }

        /// <summary>
        /// Removes the highlight from the element
        /// </summary>
        /// <param name="locator">locator of elements
        /// <param name="timeout"></param>
        public void UnhighlightElement(string locator, int timeout = 0)
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript($"arguments[0].removeAttribute('style')", GetElement(locator, timeout));
        }

        /// <summary>
        /// Binding to get IWebElements based on locator
        /// </summary>
        /// <param name="locator">locator of elements in xpath=locator; css=locator etc</param>
        /// <param name="timeout"></param>
        /// <returns>List<IWebElement />
        /// </returns>
        public IList<IWebElement> GetElements(string locator, int timeout = 0)
        {
            if (timeout != 0)
                WaitForVisibilityOfElement(locator, timeout);
            IList<IWebElement> elements = _driver.FindElements(ByLocator(locator));
            return elements;
        }

        /// <summary>
        /// This method is used to refresh the current page
        /// </summary>
        public void BrowserRefresh()
        {
            _driver.Navigate().Refresh();
            //SwitchToFrameByIndex(0);
        }

        /// <summary>
        /// Eyes checks element
        /// </summary>
        /// <param name="locator"></param>
        /// <returns>string</returns>
        public void EyesCheckElement(string locator, string tag = null)
        {
            A3UICommonSelenium.Eyes.CheckElement(ByLocator(locator), tag);
        }

        /// <summary>
        /// Eyes checks screen
        /// </summary>
        /// <param name></param>
        /// <returns>string</returns>
        public void EyesCheckScreen(string nameScreen)
        {
            A3UICommonSelenium.Eyes.WaitBeforeScreenshots = 2000;
            A3UICommonSelenium.Eyes.CheckWindow(nameScreen, false);
        }

        /// <summary>
        /// Takes several screenshots for applitools when element size makes it necessary  
        /// </summary>
        /// <param name="locator">string</param>
        /// <param name="direction">string</param> direction of scrolling in element: down/up/right/left
        /// <param name="scrollTimes">int</param> times scroll bar is moved (and extra screenshots needed)
        public void EyesCheckLargeElements(string locator, string direction, int scrollTimes)
        {
            int xcoordinate = 0;
            int ycoordinate = 0;
            switch (direction)
            {
                case "down":
                    ycoordinate = NumberPixelsMainAreaVerticalContainer;
                    break;
                case "up":
                    ycoordinate = -1 * NumberPixelsMainAreaVerticalContainer;
                    break;
                case "right":
                    xcoordinate = NumberPixelsMainAreaVerticalContainer;
                    break;
                case "left":
                    xcoordinate = -1 * NumberPixelsMainAreaVerticalContainer;
                    break;
            }
            for (int i = 1; i <= scrollTimes; i++)
            {
                ScrollInElement(locator, xcoordinate, ycoordinate, microPause);
                EyesCheckScreen("After " + i + " scroll " + direction);
            }
        }

        public void ErrorPopUp()
        {
            if (errorOKButtonList.Count == 0)
            {
                errorOKButtonList = BuildErrorOKButtonList();
            }
            bool flagError = false;
            foreach (string errorOKButton in errorOKButtonList)
            {
                if (flagError == false)
                {
                    try
                    {
                        flagError = FindElement(ByLocator(errorOKButton)).Displayed;
                        if (flagError == true)
                        {
                            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);


                            _driver.SwitchTo().Window(_driver.WindowHandles.Last());

                            Console.WriteLine($"Error Origin : {FindElement(ByLocator(A3UICommonLocators.errorOrigin)).Text}");
                            Console.WriteLine($"Error Date : {FindElement(ByLocator(A3UICommonLocators.errorDate)).Text}");
                            Console.WriteLine($"Error Message : {FindElement(ByLocator(A3UICommonLocators.errorMessage)).Text}");
                            ErrorAlertAccept(errorOKButton);
                        }
                        else
                        {
                            Console.WriteLine($"No Errors Present");
                        }

                    }
                    catch (NoSuchElementException)
                    {

                    }
                }
            }
        }

        public void ErrorAlertAccept(string errorOKButton)
        {
            Action actions = new Action(_driver);
            actions.DoubleClick(FindElement(ByLocator(errorOKButton))).Perform();
            counterForError = counterForError + 1;
            Console.WriteLine($"Number of Error popup present : {counterForError}");
        }

        public void MouseHoverAndClickSubMenu(string primaryMenu, string subMenu, int timeout)
        {

            if (timeout != 0)
                WaitForVisibilityOfElement(primaryMenu, timeout);

            //Doing a MouseHover  
            var element = FindElement(ByLocator(primaryMenu));
            var action = new Action(_driver);
            action.MoveToElement(element).Perform();

            //Clicking the SubMenu on MouseHover   
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            var menuelement = FindElement(ByLocator(subMenu));
            menuelement.Click();
            Console.WriteLine("");
        }

        public void MouseHoverElement(string locator, int timeout)
        {
            if (timeout != 0)
                WaitForVisibilityOfElement(locator, timeout);

            //Doing a MouseHover  
            var element = FindElement(ByLocator(locator));
            var action = new Action(_driver);
            action.MoveToElement(element).Perform();
        }

        public void PressReturnKey()
        {
            var action = new Action(_driver);
            action.SendKeys(Keys.Enter);
            action.Build().Perform();
        }

        public void PressTabKey()
        {
            var action = new Action(_driver);
            action.SendKeys(Keys.Tab);
            action.Build().Perform();
        }

        public void PressBackspaceKey()
        {
            var action = new Action(_driver);
            action.SendKeys(Keys.Backspace);
            action.Build().Perform();
        }

        public void PressArrowDownKey()
        {
            var action = new Action(_driver);
            action.SendKeys(Keys.ArrowDown);
            action.Build().Perform();
        }

        public void ClickInMousePosition()
        {
            var action = new Action(_driver);
            action.Click();
            action.Build().Perform();
        }

        public void PressDelete()
        {
            var action = new Action(_driver);
            action.SendKeys(Keys.Delete);
            action.Build().Perform();
        }

        public void TabToNextFieldAndEnterText(string value)
        {
            var action = new Action(_driver);
            action.SendKeys(Keys.Tab);
            action.SendKeys(value);
            action.Build().Perform();
        }

        //In EnterText method we use a locator. This method doesn't use it, but sends a value to whatever the focus is
        public void SendText(string value)
        {
            var action = new Action(_driver);
            action.SendKeys(value);
            action.Build().Perform();
        }

        public void TabToNextFieldAndSelectSingleDropdown(string value)
        {
            var action = new Action(_driver);
            action.SendKeys(Keys.Tab);
            action.SendKeys(value);
            action.SendKeys(Keys.ArrowDown);
            action.Build().Perform();
        }

        /// <summary>
        /// Sometimes ClearText doen't work. This method deletes a text with backspaces, so many as the text length
        /// </summary>
        public void DeleteText(string locator, int timeout = 0)
        {
            int oldTextSize = GetElementText(locator, timeout).Length;
            PressBackSpaceNtimes(oldTextSize);
        }

        /// <summary>
        /// This method deletes a text with backspaces, so many as the text length. Text extracted from the attribute value instead of being a text
        /// </summary>
        public void DeleteTextInValueAttribute(string locator)
        {
            int oldTextSize = FindElement(ByLocator(locator)).GetAttribute("value").Length;
            PressBackSpaceNtimes(oldTextSize);
        }

        /// <summary>
        /// This method presses BackSpace a number of times (paramater)
        /// </summary>
        public void PressBackSpaceNtimes(int numberTimes)
        {
            while (numberTimes > 0)
            {
                PressBackspaceKey();
                numberTimes--;
            }
        }

        public void ClickYesToPopup()
        {
            if(IsElementVisible(A3UICommonLocators.YesButton))
            {
                Click(A3UICommonLocators.YesButton, mediumPause);
            }
        }

        public void EnterTextAndSelectSingleDropdownResult(string value)
        {
            var action = new Action(_driver);
            action.SendKeys(value);
            action.SendKeys(Keys.ArrowDown);
            action.Build().Perform();
        }

        public bool IsSelected(string webElement)
        {
            return FindElement(ByLocator(webElement)).Selected;           
        }

        public void ClickEveryRowInIwebElementList(IList<IWebElement> iWebElementList)
        {
            foreach (var iWebElement in iWebElementList)
            {
                WaitForIWebElementToBeClickable(iWebElement, microPause);
                iWebElement.Click();
            }
        }

        public bool ClickSpecificOptioninAList(IList<IWebElement> Options, string optionSelected)
        {
            foreach (var option in Options)
            {
                 if (option.GetAttribute("innerText").Equals(optionSelected))
                {
                    Console.WriteLine($"Ready to click on {optionSelected}");
                    option.Click();
                    return true;
                }
            }
            return false;
        }

        public bool ClickSpecificOptioninAListContainingAText(IList<IWebElement> Options, string optionSelected)
        {
            foreach (var option in Options)
            {
                if (option.GetAttribute("innerText").Contains(optionSelected))
                {
                    Console.WriteLine($"Ready to click on {optionSelected}");
                    option.Click();
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Clicks randomly the number of different element asked and returns a Web element list with them.
        /// </summary>
        /// <param name="iWebElementList">IList<IWebElement></param> list among which we select the elements. By default 1
        /// <param name="numberRowsSelected">int</param> number of rows we want to click
        public IList<IWebElement> ClickRandomRowsInIwebElementList(IList<IWebElement> iWebElementList, int numberRowsClicked = 1)
        {
            Action actions = new Action(_driver);
            numberRowsClicked = Math.Min(numberRowsClicked, iWebElementList.Count);
            IList<IWebElement> RowClicked = iWebElementList.OrderBy(x => RandomNumber.Next()).Take(numberRowsClicked).ToList();
            foreach (var iWebElement in RowClicked)
            {
                WaitForIWebElementToBeClickable(iWebElement, longPause);
                iWebElement.Click();
            }
            return RowClicked;
        }


        /// <summary>
        /// Doubleclicks randomly the number of different element asked and returns a Web element list with them.
        /// </summary>
        /// <param name="iWebElementList">IList<IWebElement></param> list among which we select the elements. By default 1
        /// <param name="numberRowsSelected">int</param> number of rows we want to doubleclick
        public IList<IWebElement> DoubleClickRandomRowsInIwebElementList(IList<IWebElement> iWebElementList, int numberRowsClicked = 1)
        {
            Action actions = new Action(_driver);
            numberRowsClicked = Math.Min(numberRowsClicked, iWebElementList.Count);
            IList<IWebElement> RowClicked = iWebElementList.OrderBy(x => RandomNumber.Next()).Take(numberRowsClicked).ToList();
            foreach (var iWebElement in RowClicked)
            {
                WaitForIWebElementToBeClickable(iWebElement, longPause);
                actions.DoubleClick(iWebElement).Perform();
            }
            return RowClicked;
        }

        /// <summary>
        /// Clicks randomly the number of different element asked and returns a string list with their innertexts.
        /// </summary>
        /// <param name="iWebElementList">IList<IWebElement></param> list among which we select the elements. By default 1
        /// <param name="numberRowsSelected">int</param> number of rows we want to click
        public List<string> ClickRandomRowsInIwebElementListReturnText(IList<IWebElement> iWebElementList, int numberRowsClicked = 1)
        {
            Action actions = new Action(_driver);
            numberRowsClicked = Math.Min(numberRowsClicked, iWebElementList.Count);
            IList<IWebElement> RowClicked = iWebElementList.OrderBy(x => RandomNumber.Next()).Take(numberRowsClicked).ToList();
            List<string> TextRowClicked = new List<string>();

            foreach (var iWebElement in RowClicked)
            {
                WaitForIWebElementToBeClickable(iWebElement, microPause);
                TextRowClicked.Add(iWebElement.GetAttribute("innerText"));
                iWebElement.Click();
            }
            return TextRowClicked;
        }

        /// <summary>
        /// Doubleclick randomly the number of different element asked and returns a string list with their innertexts.
        /// </summary>
        /// <param name="iWebElementList">IList<IWebElement></param> list among which we select the elements. By default 1
        /// <param name="numberRowsSelected">int</param> number of rows we want to doubleclick
        public List<string> DoubleClickRandomRowsInIwebElementListReturnText(IList<IWebElement> iWebElementList, int numberRowsClicked = 1)
        {
            Action actions = new Action(_driver);
            numberRowsClicked = Math.Min(numberRowsClicked, iWebElementList.Count);
            IList<IWebElement> RowClicked = iWebElementList.OrderBy(x => RandomNumber.Next()).Take(numberRowsClicked).ToList();
            List<string> TextRowClicked = new List<string>();

            foreach (var iWebElement in RowClicked)
            {
                WaitForIWebElementToBeClickable(iWebElement, microPause);
                TextRowClicked.Add(iWebElement.GetAttribute("innerText"));
                actions.DoubleClick(iWebElement).Perform();
            }
            return TextRowClicked;
        }


        /// <summary>
        /// Method to inject a Javascript
        /// </summary>
        public void InjectJScript(string script)
        {
            ((JavascriptExecutor)_driver).ExecuteScript(script);
        }


        /// <summary>
        /// This method is used to drag and drop or to swap two elements
        /// </summary>
        public void DragAndDrop(IWebElement fromElement, IWebElement toElement)
        {
            var action = new Action(_driver);
            action.ClickAndHold(fromElement)
                                   .MoveToElement(toElement)
                                   .Release(toElement)
                                   .Build()
                                   .Perform();
        }

         /// <summary>
        /// Drag and drop an element to a position
        /// </summary>
        public void DragAndDropToOffset(IWebElement element, int xcoordinate, int ycoordinate)
        {
            var action = new Action(_driver);
            action.ClickAndHold(element)
                                   .DragAndDropToOffset(element, xcoordinate, ycoordinate)
                                   .Build()
                                   .Perform();
        }

        /// <summary>
        /// Drag and drop in an element droppable which needs be activated before drag and drop
        /// </summary>
        public void DragAndDropWithPreactivationDroppableArea(IWebElement element, int xcoordinate, int ycoordinate)
        {
            var action = new Action(_driver);
            
            action.ClickAndHold(element)
                                   .Build()
                                   .Perform();
            
            action.ClickAndHold(element).MoveByOffset(xcoordinate, ycoordinate)
                                        .Release(element)
                                        .Build()
                                        .Perform(); 
        }

        /// <summary>
        /// This method transform Table into DataTable (usually the Table commes from Scpeflow with parameters)
        /// </summary>
        public DataTable ToDataTable(Table table)
        {
            var dataTable = new DataTable();
            foreach (var header in table.Header)
            {
                dataTable.Columns.Add(header, typeof(string));
            }

            foreach (var row in table.Rows)
            {
                var newRow = dataTable.NewRow();
                foreach (var header in table.Header)
                {
                    newRow.SetField(header, row[header]);
                }
                dataTable.Rows.Add(newRow);
            }
            return dataTable;
        }

        /// <summary>
        /// Fills a grid in a page with values from a DataTable. Fills the first cell and from there clicks tab and fills the rest.
        /// Because of that, cells to fill must be reached with only one tab from the previous one.
        /// If there is any cell to be filled with relative dates (e.g. today), the header of that column must contain the word "date" to apply the method GenerateDateFromString
        /// If we need to skip any cell the value will be skip. Then, it only sends a tab.
        /// <param name="dataTable">DataTable</param> Table with data (including headers)
        /// <param name="dateFormat">string</param> Format for the date. By default US format
        /// </summary>
        public void FillDataTable(DataTable dataTable)
        {
            foreach (DataColumn column in dataTable.Columns)
            {
                for (int row = 0; row < dataTable.Rows.Count; row++)
                {
                    string valueToCell = dataTable.Rows[row][column].ToString();
                    if (valueToCell.Equals("skip"))
                    {
                        PressTabKey();
                    }
                    else
                    {
                        if (column.ColumnName.ToLower().Contains("date"))
                        {
                            valueToCell = DateTimeUtils.GenerateDateFromString(valueToCell).Value.ToString(dateFormat);
                        }
                        if (column.ColumnName.ToLower().Contains("time"))
                        {
                            valueToCell = DateTimeUtils.GenerateDateFromString(valueToCell).Value.ToString(timeFormat);
                        }
                        SendText(valueToCell);
                        if (column.Ordinal < dataTable.Columns.Count - 1)
                        {
                            PressTabKey();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Extract a list of elements that are inside a bigger element. e,g. List of items in a dropdown.
        /// <param name="MainElementLocator">locator of the main element (dropdown in our example)
        /// <param name="ListElementLocator">locator of the list element (important, the xpath will always start with . )
        /// </summary>
        public IList<IWebElement> ExtractIWebElementsList(string MainElementLocator, string ListElementLocator)
        {
            IWebElement MainElement = GetElement(MainElementLocator, microPause);
            IList<IWebElement> GroupOptionsList = MainElement.FindElements(ByLocator(ListElementLocator));
            return GroupOptionsList;
        }

        public void WaitUntilElementNonVisible(string locator, int waitingSeconds = 0)
        {
            if (IsElementVisible(locator, microPause))
            {
                Console.WriteLine($"Waiting for {locator} to be not visible");
                int waitingSecondsCont = waitingSeconds;
                while (IsElementVisible(locator) && waitingSecondsCont > 0)
                {
                    Thread.Sleep(1000);
                    waitingSecondsCont--;
                }
                if (waitingSecondsCont > 0)
                    Console.WriteLine($"{locator} not visible after {waitingSeconds - waitingSecondsCont} seconds");
                else
                    Console.WriteLine($"The element {locator} didn't get to be not visible after waiting {waitingSeconds} seconds");
            }
        }
    }
}