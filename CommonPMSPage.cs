using NUnit.Framework;
using OAF.A3.UI.Lib.Actions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace OAF.A3.UI.Lib.PmsPageObjects
{

    public class CommonPMSPage : A3UICommonActions
    {
        //This class will contain methods that:
        // * can be used in any feature but don't belong in any other page class
        // * are not common actions (e.g. click, wait for element)
        // * are not common methods used by selenium (e.g. launch browser, SwitchWindow)
        // Locators used here are in A3UICommonLocatorsPage

        public string TitleLocator { get; set; }
        public string BreadcrumbLocator { get; set; }
        public string MainAreaScrolledLocator { get; set; }
        public string ListElementLocator { get; set; }
        public string DropDownList { get; set; }
        public string DropDownArrow { get; set; }

        private readonly IWebDriver _driver = A3UICommonSelenium.Driver;

        public List<string> CloseModalButtonList = new List<string>();

        /// <summary>
        /// Builds the List of different buttons to close modals (close or cancel).
        /// </summary>
        /// <returns>List<string></returns>
        public List<string> BuildCloseModalButtonList()
        {
            CloseModalButtonList.Add(A3UICommonLocators.CancelButtonModalWithNameAttribute);
            CloseModalButtonList.Add(A3UICommonLocators.CancelButtonModalWithoutTextAttribute);
            CloseModalButtonList.Add(A3UICommonLocators.CancelButton);
            CloseModalButtonList.Add(A3UICommonLocators.CancelButtonModal);
            CloseModalButtonList.Add(PmsPages.ExaminationPage.CloseHistoryModalButton);
            CloseModalButtonList.Add(PmsPages.PatientDashboardPage.CloseTemplateModal);
            return CloseModalButtonList;
        }

        public bool IsUserPasswordWindowDisplayed(int timeout = 0)
        {
            if (IsElementVisible(A3UICommonLocators.PINfield, timeout))
            {
                PmsPages.CommonButtonsPage.CancelButtonModal();
                return true;
            }
            return false;
        }

        public bool IsUnsavedChangesWindowDisplayed(int timeout = 0)
        {
            if (IsElementVisible(A3UICommonLocators.UnsavedChangesWindow, timeout))
            {
                PmsPages.CommonButtonsPage.CancelButtonModal();
                return true;
            }
            return false;
        }

        public void UnlockStation(string pin)
        {
            if (IsElementVisible(A3UICommonLocators.LockedStationMessageBox, microPause))
            {
                PressReturnKey();
                Console.WriteLine($"Prepared to introduce {pin}");
                EnterText(A3UICommonLocators.PINfield, pin, microPause);
                Console.WriteLine($"{pin} introduced");
                Click(A3UICommonLocators.OKButton);
                WaitUntilElementNonVisible(A3UICommonLocators.PINfield, 5);
            }
        }

        public bool IsLockedStationBoxDisplayed()
        {
            return IsElementVisible(A3UICommonLocators.LockedStationMessageBox, microPause);
        }

        public void EyesCheckEyeExamMainArea(string direction, int scrollTimes)
        {
            EyesCheckLargeElements(A3UICommonLocators.MainAreaVerticalContainer, direction, scrollTimes);
        }

        public void ScreenshotModal(string title)
        {
            EyesCheckElement(A3UICommonLocators.Modal, title);
        }

        public void ClickChangeLocation(int timeout = 0)
        {
            MouseHoverAndClickSubMenu(A3UICommonLocators.userName, A3UICommonLocators.ChangeLocationButton, timeout);
        }

        public string SelectRandomLocation()
        {
            Click(A3UICommonLocators.LocationinModal, microPause);
            PressArrowDownKey();
            IList<IWebElement> locationsList = GetElements(A3UICommonLocators.OptionsinDropDown, microPause);
            string newLocation = ClickRandomRowsInIwebElementListReturnText(locationsList)[0];

            Click(A3UICommonLocators.OKButton, microPause);
            PmsPages.HomePage.FeaturesValidation();
            return newLocation;
        }


        public void IntroducePin(string pin)
        {
            EnterText(A3UICommonLocators.PINfield, pin, microPause);
            Click(A3UICommonLocators.OKButton, microPause);
            WaitUntilElementNonVisible(A3UICommonLocators.PINfield, 5);
        }

        public string CurrentUser()
        {
            WaitForElementToBeClickable(A3UICommonLocators.userName, longPause);
            return GetElementText(A3UICommonLocators.userName, microPause).ToLower();
        }

        public string CurrentLocation()
        {
            WaitForElementToBeClickable(A3UICommonLocators.userName, longPause);
            return GetElementText(A3UICommonLocators.location, microPause);
        }

        public void ClickLock()
        {
            if (IsElementVisible(A3UICommonLocators.LockButton, mediumPause))
            {
                Click(A3UICommonLocators.LockButton);
            }
        }

        public bool PanelIsDisplayedForThePatient(string panelName)
        {
            return IsElementVisible(string.Format(A3UICommonLocators.PanelName, panelName), longPause);
        }

        public void SelectVerticalOption(string verticalOption)
        {
            WaitForElementToBeClickable(string.Format(A3UICommonLocators.VerticalOption, verticalOption), longPause);
            Click(string.Format(A3UICommonLocators.VerticalOption, verticalOption), microPause);
        }

        public bool IsMainAreaDisplayed()
        {
            return IsElementVisible(A3UICommonLocators.MainAreaVerticalContainer, longPause);
        }

        public bool IsTitleDisplayed()
        {
            return IsElementVisible(TitleLocator, microPause);
        }

        public bool IsBreadcrumbDisplayed()
        {
            return IsElementVisible(BreadcrumbLocator, microPause);
        }

        public void ScrollInMainArea(string direction, int scrollTimes)
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
                ScrollInElement(MainAreaScrolledLocator, xcoordinate, ycoordinate, mediumPause);
            }
        }

        public bool SelectOptionInDropdown(string dropDown, string optionSelected)
        {
            Click(string.Format(DropDownArrow, dropDown), xLongPause);
            IList<IWebElement> Options = GetElements(string.Format(DropDownList, dropDown), mediumPause);
            return ClickSpecificOptioninAList(Options, optionSelected);
        }

        public void CollapseDropdown(string dropDown, string optionSelected)
        {
            if (IsElementVisible(string.Format(DropDownArrow, dropDown)))
            {
                Click(string.Format(DropDownArrow, dropDown), microPause);
            }
        }

        /// <summary>
        /// Clear the selected options in a dropdown by clicking the option to clear in dropdown
        /// <param name="arrowLocator">locator of the arrow that displayes its elements
        /// </summary>
        public void ClearSelectedOptionsInDropdown(string arrowLocator)
        {
            Click(arrowLocator, microPause);
            if (IsElementVisible(A3UICommonLocators.ClearSelectedOption, microPause))
            {
                Click(A3UICommonLocators.ClearSelectedOption, microPause);
            }
            Click(arrowLocator, microPause);
        }

        /// Returns the list of clicked elements (empty is list empty)
        public IList<IWebElement> ClickARandomRowInIList()
        {
            IList<IWebElement> IList = GetElements(ListElementLocator, microPause);
            if (IList.Count > 0)
            {
                return ClickRandomRowsInIwebElementList(IList);
            }
            return IList;
        }

        /// Returns the list of doubleclicked elements (empty is list empty)
        public IList<IWebElement> DoubleClickARandomRowInIList()
        {
            IList<IWebElement> IList = GetElements(ListElementLocator, microPause);
            if (IList.Count > 0)
            {
                return DoubleClickRandomRowsInIwebElementList(IList);
            }
            return IList;
        }

        ///This method clicks the DropDownArrow in a DropDown, which displayes a DropDownList of options and selects numberOptionsSelected among them
        public IList<IWebElement> ClickRandomOptionsInDropDown(int numberOptionsSelected)
        {
            if (IsElementVisible(DropDownArrow))
            {
                Click(DropDownArrow);
            }
            else
            {
                Assert.Inconclusive("Functionality not tested. Dropdown options couldn't be displayed");
            }
            IList<IWebElement> OptionList = GetElements(DropDownList, microPause);
            if (OptionList.Count < numberOptionsSelected)
            {
                Assert.Inconclusive("There is not enough options in dropdown");
            }
            else
            {
                ClickRandomRowsInIwebElementList(OptionList, numberOptionsSelected);
            }
            return OptionList;
        }

        //Clicks random options in dropdown with a common locator (A3UICommonLocatorsPage.OptionsinDropDown)
        public void ClickRandomOptioninCommonDropDown(int numberRowsClicked = 1)
        {
            IList<IWebElement> OptionList = GetElements(A3UICommonLocators.OptionsinDropDown, microPause);
            if (OptionList.Count>0)
            {
                ClickRandomRowsInIwebElementList(OptionList, numberRowsClicked);
            }
        }

        /// <summary>
        /// In elements like calendars, we have elements inside others. This method extract lists in elements that are located in bigger elements and selects onwe random option
        /// </summary>        
        public void ExtractListAndClickRandomOption(string panel, string elementLocator, string subElementLocator, int numberRowsClicked = 1)
        {
            IWebElement element = GetElement(string.Format(elementLocator, panel), microPause);
            IWebElement subElement = element.FindElement(ByLocator(subElementLocator));
            subElement.Click();

            ClickRandomOptioninCommonDropDown(numberRowsClicked);
        }

        /// <summary>
        /// Checks for the presence of Cancel/Close buttons and clicks them to close modals 
        /// </summary>
        /// <returns>List<string></returns>
        public void CloseModals()
        {
            if (CloseModalButtonList.Count == 0)
            {
                CloseModalButtonList = BuildCloseModalButtonList();
            }

            foreach (string closeModalButton in CloseModalButtonList)
            {
                if (IsElementVisible(closeModalButton))
                {
                    IsElementClickable(closeModalButton);
                    if (IsElementVisible(A3UICommonLocators.ConfirmModalYesButton, microPause))
                    {
                        IsElementClickable(A3UICommonLocators.ConfirmModalYesButton);
                    }
                    break;
                }
            }
        }

        public void WaitUntilSpinnerNonVisible(int waitingSeconds = 0)
        {
            WaitUntilElementNonVisible(A3UICommonLocators.Spinner, waitingSeconds);
        }
    }
}
