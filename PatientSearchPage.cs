using NUnit.Framework;
using OAF.A3.UI.Lib.Actions;
using OAF.Common.Test.Common.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace OAF.A3.UI.Lib.PmsPageObjects
{
    public class PatientSearchPage : CommonPMSPage
    {
        #region Locators
        public string PatientSearchPageTitle = "xpath=//span[text()='Patient Search']";
        public string PatientSearchTermTxt = "xpath=//input[@name = 'query-term']";
        public string AddPatientBtn = "xpath=//button[@data-testid= 'add-patient-button']";
        public string CancelBtn = "xpath=//a/span[text()='Cancel']";
        public string SelectBtn = "xpath=//a/span[text()='Select']";
        public string PatientSearchResult = "xpath=//div[@data-test-el='grid-cell-full-name']";
        public string PatientSearchResultLink = "xpath=//div[@data-test-el='grid-cell-full-name']/a[contains(text(),'{0}')]";
        public string PatientPreviewBar = "xpath=//span[text()='Patient preview']";
        public string NewPatientPopUp = "xpath=//h5[@class='modal-title']/span";
        public string OKButton = "xpath=//button[@type='submit']/span";
        public string SuggestedPatientList = "xpath=//div[@data-testid= 'suggested-patients-list']";
        public string firstPatient = "xpath=//div[@data-test-el='grid-cell-full-name']/a";
        public string PatientDoBList = "xpath=//div[@data-testid='unpinned-items-container']//descendant::div[@data-test-el='grid-cell-dob']";
        public string PatientSearchResultLinkDisplayId = "xpath=//div[@data-test-el='grid-cell-patient-id']";
        #endregion

        private readonly IWebDriver _driver = A3UICommonSelenium.Driver;

        public PatientSearchPage()
        {
            TitleLocator = "xpath=//h1[text() = 'Patient Search']";
        }

        public PatientSearchPage OnPatientSearchPage()
        {
            if (!IsElementVisible(PatientSearchPageTitle, microPause))
                PmsPages.NavigatePage.SelectMenu(MenuItems.Search);

            return new PatientSearchPage();
        }

        public PatientSearchPage EnterSearchTerm(string searchTerm)
        {
            ClearText(PatientSearchTermTxt, microPause);
            Console.WriteLine($"Cleared {PatientSearchTermTxt}");
            WaitUntilSpinnerNonVisible(shortPause);
            Click(PatientSearchTermTxt, microPause);
            SendText(searchTerm);
            Console.WriteLine($"Sent {searchTerm} in {PatientSearchTermTxt}");
            Console.WriteLine($"Written {GetElementText(PatientSearchTermTxt)} in {PatientSearchTermTxt}");
            return new PatientSearchPage();
        }

        public bool IsPatientListDisplayed()
        {
            return IsElementVisible(PatientSearchResult, shortPause);
        }

        public PatientSearchPage SelectPatient(string patientName, DateTime? PatientDateOfBirth = null)
        {
            WaitForElementToBeClickable(string.Format(PatientSearchResultLink, patientName), longPause);
            Console.WriteLine($"The patient shown is {GetElementText(firstPatient, mediumPause)}");
            Console.WriteLine($"The patient {patientName} with doB {PatientDateOfBirth} will be selected");
            WaitUntilSpinnerNonVisible(6);
            bool patientFound = false;
            if (PatientDateOfBirth != null)
            {
                IList<IWebElement> DoBList = GetElements(PatientDoBList, mediumPause);
                if (DoBList.Count == 1)
                {
                    patientFound = true;
                    PressReturnKey();
                }
                if (DoBList.Count > 1)
                {
                    string doBSelected = DateTimeUtils.GenerateDateFromString(PatientDateOfBirth.ToString()).Value.ToString(dateFormat).ToString();
                    foreach (var dob in DoBList)
                    {
                        if (dob.GetAttribute("innerText").Contains(doBSelected))
                        {
                            Console.WriteLine($"Ready to click on {dob.GetAttribute("innerText")}");
                            dob.Click();
                            patientFound = true;
                            PressReturnKey();
                            break;
                        }
                    }
                }
            }
            else
            {
                if (IsElementVisible(string.Format(PatientSearchResultLink, patientName)))
                {
                    Click(string.Format(PatientSearchResultLink, patientName), microPause);
                    patientFound = true;
                }
            }
            if (!patientFound)
            {
                Assert.Inconclusive($"The patient with name {patientName} and date of birth {PatientDateOfBirth} is not in the patient list in Search Patient page");
            }
            ErrorPopUp();
            return new PatientSearchPage();
        }

        public void SelectPatientWithDisplayIdentifierInPatientSearchModal(string patientDisplayId)
        {
            if (IsElementVisible(PatientSearchResultLinkDisplayId, microPause))
            {
                Click(PatientSearchResultLinkDisplayId);
                Click(A3UICommonLocators.SaveModalButton);
            }
            else
            {
                Assert.Inconclusive($"The patient with display Id {patientDisplayId} is not in the patient list in Patient Search");
            }
        }

        public void SearchAndSelectPatient(string patientName, DateTime? PatientDateOfBirth)
        {
            OnPatientSearchPage();
            string PatientNameList = GetPatientNameList(patientName);
            EnterSearchTerm(patientName);
            SelectPatient(PatientNameList, PatientDateOfBirth);
        }

        public void SearchAndSelectPatientWithDisplayIdentifierInPatientSearchModal(string patientDisplayId)
        {
            EnterSearchTerm(patientDisplayId);
            WaitUntilSpinnerNonVisible(3);
            SelectPatientWithDisplayIdentifierInPatientSearchModal(patientDisplayId);
        }

        public PatientSearchPage AddNewPatientFeature()
        {
            WaitUntilSpinnerNonVisible(6);
            WaitForElementToBeClickable(AddPatientBtn, microPause);
            Click(AddPatientBtn, microPause);
            return new PatientSearchPage();
        }

        public PatientSearchPage AddNewPatientPopUp()
        {
            if (IsElementVisible(NewPatientPopUp, microPause))
            {
                Click(OKButton, microPause);
            }
            return new PatientSearchPage();
        }

        /// <summary>
        /// Convers patient name to search page list items format. 
        /// </summary>
        /// <param name="patientName">
        public string GetPatientNameList(string patientName)
        {
            string lastName = patientName.Split(" ")[1];
            if (lastName.Contains("'"))
            {
                lastName = lastName.Split("'")[1];
            }
            return lastName + ", " + patientName.Split(" ")[0];
        }

        public void ClickCancelInNewPatientModal()
        {
            WaitForElementToBeClickable(SuggestedPatientList, longPause);
            PmsPages.CommonButtonsPage.ClickCancelButton();
        }
    }
}
