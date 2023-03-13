using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace OAF.A3.UI.Lib.PmsPageObjects
{
    public class ExaminationPage : CommonPMSPage
    {
        #region Locators
        public string VisitTypeInput = "xpath=//label[contains(.,'Visit Type')]/following::input/following::div";
        public string ProviderInput = "xpath=//label[contains(.,'Provider')]/following::input";
        public string ExaminerInput = "xpath=//label[contains(.,'Examiner')]/following::input";
        public string PreTest = "xpath=//div[text() = 'Pre Test']";
        public string EyeHealth = "xpath=//div[text() = 'Eye Health']";
        public string Drops = "xpath=//div[text() = 'Drops']";
        public string EditableGridFieldTemplate = "xpath=//input[contains(@name,'";
        public string EditableGridTemplateStart = "xpath=//div[text() = '";
        public string EditableGridTemplateEnd = "']/following::div[contains(@class, 'rt-tbody')]";
        public string NewExam = "xpath=//div[contains(@data-test-el, 'new-visit-icon')]";
        public string PharmaDrops = "xpath=//input[@name='drops[0].pharmaceutical']";
        public string ReviewofSystemsContainerTitle = "xpath=//div[text()='Review of Systems']";
        public string BreadcrumbMenuOption = "xpath=//div[text() = '{0}']";
        public string EyeExamTitle = "xpath=//h2[text() = 'Eye Exam']";
        public string SearchPatientBreadcrumb = "xpath=//div[text() = 'Search Patient']";
        public string PanelElement = "xpath=//div[text()='{0}']/following::div[@data-test-el = 'EyeHealth-form']";
        public string PanelForScreenshot = "xpath=//div[text()='{0}']/ancestor::div[contains(@class, 'dynamic-exam_examContainer')]";
        public string ArrowUp = "xpath=//div[text()='{0}']/following::button[contains(@class, 'Increment')]";
        public string ArrowDown = "xpath=//div[text()='{0}']/following::button[contains(@class, 'Increment')]/following::button[contains(@class, 'numeric-input_spinBoxBtn')]";
        public string CalendarIcon = "xpath=//div[text()='{0}']/following::button[@data-testid = 'date-picker-calendar-icon']";
        public string Calendar = "xpath=//div[@class = 'react-datepicker-popper react-datepicker-time-with-dropdown']";
        public string NextMonthButton = "xpath=//button[@data-testid = 'date-picker-next-month']";
        public string PreviousMonthButton = "xpath=//button[@data-testid = 'date-picker-previous-month']";
        public string MonthArrow = "xpath=//div[@class = 'react-datepicker']/descendant::div[@data-testid = 'select-wrapper']";
        public string YearArrow = "xpath=//div[@class = 'react-datepicker']/descendant::div[@data-testid = 'select-wrapper'][2]";
        public string Month = "xpath=//div[@class = 'react-datepicker__month']";
        public string Days = "xpath=.//div[contains(@class,'react-datepicker__day')]";
        public string AddANewRecordIcon = "xpath=//div[text()='{0}']/following::button[@aria-label='Add']";
        public string EditableGrid = "xpath=//div[text()='{0}']/following::div[@data-testid = 'editable-grid']";
        public string NotesIcon = "xpath=//div[text()='{0}']/following::button[@aria-label = 'Add Notes']";
        public string NotesBox = "xpath=//div[text()='{0}']/following::div[text()='{1}']/following::div[contains(@class, 'rich-text-field')]";
        public string CloseHistoryModalButton = "xpath=//button[@data-testid = 'primary-button' and @name = 'cancel']";
        public string PanelLocator = "xpath=//div[text()='{0}']/following::div[contains(@class, 'collapse-custom_full')]";
        public string TableDropDownArrows = "xpath=.//div[contains(@class, 'buttonContainer')]";
        public string GroupLocator = "xpath=//div[text()='{0}']/following::div[text()='{1}']/following::div[@data-test-el = 'radio-btn-group']";
        public string GroupOptionsLocator = "xpath=.//label[contains(@class, 'radio-button_radio')]";
        public string CheckBox = "xpath=.//label[contains(@class, 'checkbox')]";
        public string CellWithRowAndColumn = "xpath=//div[text()='{0}']/following::div[text()='{1}']/following::input[contains(@name, '{2}')]";
        public string Firstcell = "xpath=//div[text()='{0}']/following::div[text()='{1}']/following::div[contains(@class, 'numeric-input_numericContainer')]";
        public string NormalValuesIcon = "xpath=.//button[@aria-label = 'Set normal values in empty fields']";
        public string HistoryIcon = "xpath=//div[text()='{0}']/following::button[@aria-label = 'Show History']";
        public string ExpandNotesIcon = "xpath=//div[text()='{0}']/following::div[text()='Notes']/following::div[contains(@class, 'rich-text-field')]/descendant::button[@aria-label = 'Expand']";
        public string ExpandNotesIconinVisualAcuity = "xpath=//form[@data-test-el = 'visual-acuities-form']/following::div[text()='Notes']/following::div[contains(@class, 'rich-text-field')]/descendant::button[@aria-label = 'Expand']";
        public string ModalCancel = "xpath=//button[@data-testid = 'modal-dismiss']";
        public string DropDownDeleteIcon ="xpath=//div[text()='{0}']/following::div[text()='{1}']/following::div[contains(@class, 'checklist-item-readings_Input')]/descendant::div[contains(@class, 'multi-select_buttonContainer')]/*[contains(@class, 'select_clearIndicator')]";
        public string FirstValueSelected = "xpath=//div[text()='{0}']/following::div[text()='{1}']/following::div[contains(@class, 'checklist-item-readings_Input')]/descendant::div[contains(@class, 'multi-select_multiSelect')]/descendant::div[contains(@class, 'multi-select_tagCover')]";
        public string DropDownArrowNewSelectSection = "xpath=//div[text()='{0}']/following::div[text()='{1}']/following::div[contains(@class, 'checklist-item-readings_Input')]/descendant::div[contains(@class, 'multi-select_multiSelect')]//descendant::div[contains(@class, 'multi-select_buttonContainer')]";
        public string DropDownListNewSelectSection = "xpath=//ul[@data-testid = 'select-menu']/descendant::li";
        public string DropDownArrowNewSecondSelectSection = "xpath=//div[text()='{0}']/following::div[text()='{1}']/following::div[contains(@class, 'checklist-item-readings_Input')]/following::div[contains(@class, 'checklist-item-readings_Input')]/descendant::div[contains(@class, 'multi-select_multiSelect')]//descendant::div[contains(@class, 'multi-select_buttonContainer')]";
        public string PanelOptionsList = "xpath=.//label[contains(@class, 'checklist-item-readings_alignLeft')]";
        public string FirstDropDown = "xpath=//div[text()='{0}']/following::div[@data-testid='select-wrapper']";
        public string SubpanelLocator = "xpath=//div[text()='{0}']/following::span[text()='{1}']/parent::div/parent::div";
        public string ReadingSubpanelLocator = "xpath=//div[text()='{0}']/following::div[text()='{1}']/parent::div";
        public string TodaysAppointmentHeader = "xpath=//div[@data-test-el='csp-panel-header']";
        #endregion

        private readonly IWebDriver _driver = A3UICommonSelenium.Driver;

        public HistoryPage EnterVisitType(string visitType)
        {
            ClickAndEnterText(VisitTypeInput, visitType);
            PressReturnKey();
            return new HistoryPage();
        }

        public HistoryPage EnterProvider(string provider)
        {
            if (IsElementVisible(ProviderInput))
            {
                ClickAndEnterText(ProviderInput, provider);
            }
            else
            {
                ClickAndEnterText(ExaminerInput, provider);
            }
            PressReturnKey();
            return new HistoryPage();
        }

        public HistoryPage SelectPreTest()
        {
            Click(EyeHealth, microPause);
            return new HistoryPage();
        }

        public HistoryPage SelectEyeHealth()
        {
            Click(EyeHealth, microPause);
            return new HistoryPage();
        }

        public HistoryPage SelectEditableGridItemAndEnterText(string field, string section)
        {
            string customEditableGridXpath = EditableGridTemplateStart + section + EditableGridTemplateEnd;
            string customEditableXpathField = EditableGridFieldTemplate + section.ToLower() + "[0]." + field.ToLower() + "')]/parent::div";

            WaitForElementToBeClickable(customEditableGridXpath, microPause);
            Click(customEditableGridXpath, microPause);
            Click(customEditableXpathField, microPause);

            return new HistoryPage();
        }

        public HistoryPage TabAndEnterText(string text)
        {
            TabToNextFieldAndEnterText(text);
            return new HistoryPage();
        }

        public HistoryPage SelectNewExam()
        {
            WaitForVisibilityOfElement(ReviewofSystemsContainerTitle, mediumPause);
            WaitForElementToBeClickable(NewExam, longPause);
            MoveToElementAndClick(NewExam, longPause);
            return new HistoryPage();
        }

        /// <summary>
        /// Goes to eye exam of a given patient if is not there with this patient:
        /// If it is not in Patient Dashboard, goes to homepage a selects Eye Exam feature
        /// If it is in Patient Dashboard, clicks PRescriptions in vertical menu to go to EyeExam
        /// </summary>
        /// <param name="patientName">
        public void OnEyeExam(string patientName, DateTime? PatientDateOfBirth)
        {
            if (!patientName.Equals(PmsPages.PatientDashboardPage.DisplayedPatientName()) || IsElementVisible(PmsPages.PatientSearchPage.AddPatientBtn))
            {
                if (IsElementVisible(A3UICommonLocators.ClosePatientButton, microPause))
                {
                    Click(A3UICommonLocators.ClosePatientButton, microPause);
                }
                PmsPages.HomePage.OnHomePage();
                PmsPages.HomePage.SelectFeature("Eye Exam");
                string PatientNameList = PmsPages.PatientSearchPage.GetPatientNameList(patientName);
                PmsPages.PatientSearchPage.EnterSearchTerm(patientName);
                PmsPages.PatientSearchPage.SelectPatient(PatientNameList, PatientDateOfBirth);
                if (!PanelIsDisplayedForThePatient("Patient Snapshot"))
                {
                    Assert.Inconclusive($"Eye Exam is not correctly displayed. Patient Snaphot panel is not visible.");
                }
            }
            else if (!IsElementVisible(EyeExamTitle, microPause))
            {
                PmsPages.PatientDashboardPage.SelectVerticalMenuOption("Prescriptions");
            }
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
        }

        /// <summary>
        /// Checks if the user is in the Eye Exam Patient Search Page:
        /// </summary>
        public bool IsOnEyeExamPatientSearch()
        {
            return (IsElementVisible(EyeExamTitle, microPause) && IsElementVisible(SearchPatientBreadcrumb, microPause));
        }
        public void SelectBreadcrumbMenuOption(string option)
        {
            WaitForElementToBeClickable(string.Format(BreadcrumbMenuOption, option), longPause);
            MoveToElementAndClick(string.Format(BreadcrumbMenuOption, option), longPause);
        }

        public void ScreenshotPanel(string panel, string title)
        {
            EyesCheckElement(string.Format(PanelForScreenshot, panel), title);
        }

        public void ScrollPanelIntoView(string panel)
        {
            WaitForVisibilityOfElement(string.Format(PanelForScreenshot, panel), longPause);
            ScrollElementIntoView(string.Format(PanelForScreenshot, panel), longPause);
        }

        /// <summary>
        /// Updates a spinner playing around with the arrows to test them too
        /// </summary>
        public void ChangeSpinner(string panel)
        {
            int up = RandomNumber.Next(4, 7);
            while (up > 0)
            {
                Click(string.Format(ArrowUp, panel), mediumPause);
                up--;
            }
            int down = RandomNumber.Next(0, 3);
            while (down > 0)
            {
                Click(string.Format(ArrowDown, panel), mediumPause);
                down--;
            }
        }

        /// <summary>
        /// Updates a date in the panel playing around with the calendar element
        /// </summary>
        public void SelectRandomDateInCalendar(string panel)
        {
            Click(string.Format(CalendarIcon, panel), longPause);

            //random clicking in next and previous months pickers
            int rigth = RandomNumber.Next(1, 3);
            while (rigth > 0)
            {
                Click(string.Format(NextMonthButton, panel), microPause);
                rigth--;
            }
            int left = RandomNumber.Next(3, 5);
            while (left > 0)
            {
                Click(string.Format(PreviousMonthButton, panel), microPause);
                left--;
            }

            //random month
            Click(MonthArrow, microPause);
            PressArrowDownKey();
            ExtractListAndClickRandomOption(panel, Calendar, MonthArrow);
            
            //random year
            Click(YearArrow, microPause);
            PressArrowDownKey();
            ExtractListAndClickRandomOption(panel, Calendar, YearArrow);
            
            //random day
            ExtractListAndClickRandomOption(panel, Month, Days);
        }

        public void ClickAddANewRecord(string panel)
        {
            WaitForVisibilityOfElement(string.Format(EditableGrid, panel), longPause);
            Click(string.Format(AddANewRecordIcon, panel), longPause);
        }

        public void InsertUpdateNote(string panel, string note)
        {
            if (IsElementVisible(string.Format(NotesBox, panel, "Notes")))
            {
                Click(string.Format(NotesBox, panel, "Notes"), microPause);
                DeleteText(string.Format(NotesBox, panel, "Notes"), mediumPause);
            }
            else
            {
                Click(string.Format(NotesIcon, panel), microPause);
            }
            SendText(note);
        }

        public void OpenNotesBox(string panel)
        {
            if (!IsElementVisible(string.Format(NotesBox, panel, "Notes")))
            {
                Click(string.Format(NotesIcon, panel), microPause);
            }
        }

        public void DeleteNote(string panel)
        {
            if (IsElementVisible(string.Format(NotesBox, panel, "Notes")))
            {
                Click(string.Format(NotesBox, panel, "Notes"), microPause);
                DeleteText(string.Format(NotesBox, panel, "Notes"), mediumPause);
            }
        }

        public void ChangeValueDropdowns(string panel)
        {
            var CellsDropDownList = ExtractIWebElementsList(string.Format(PanelLocator, panel), TableDropDownArrows);
            foreach (IWebElement DropDownCell in CellsDropDownList)
            {
                if (IsWebElementClickable(DropDownCell, microPause))
                {
                    ClickRandomOptioninCommonDropDown();
                }
                //sometimes selecting a value in a dropdowns makes the element to be created new as the tab title changes, we need to retrieve again the elements in the list.
                CellsDropDownList = ExtractIWebElementsList(string.Format(PanelLocator, panel), TableDropDownArrows);
            }
        }

        public void ChangeValueDropdownsSubpanel(string panel, string subpanel)
        {
            var CellsDropDownList = ExtractIWebElementsList(string.Format(SubpanelLocator, panel, subpanel), TableDropDownArrows);
            foreach (IWebElement DropDownCell in CellsDropDownList)
            {
                if (IsWebElementClickable(DropDownCell, microPause))
                {
                    ClickRandomOptioninCommonDropDown();
                }
            }
        }

        public void ChangeValueDropdownsReadingsSubpanel(string panel, string subpanel)
        {
            var CellsDropDownList = ExtractIWebElementsList(string.Format(ReadingSubpanelLocator, panel, subpanel), TableDropDownArrows);
            foreach (IWebElement DropDownCell in CellsDropDownList)
            {
                if (IsWebElementClickable(DropDownCell, microPause))
                {
                    ClickRandomOptioninCommonDropDown();
                }
            }
        }

        public void SelectRandowValueInGroupinEMRpanel(string panel, string row)
        {
            var GroupOptionsList = ExtractIWebElementsList(string.Format(GroupLocator, panel, row), GroupOptionsLocator);
            ClickRandomRowsInIwebElementList(GroupOptionsList);
        }

        public void SelectSpecificValueInGroupinEMRpanel(string panel, string row, string value)
        {
            var GroupOptionsList = ExtractIWebElementsList(string.Format(GroupLocator, panel, row), GroupOptionsLocator);
            if (!ClickSpecificOptioninAList(GroupOptionsList, value))
            {
                Console.WriteLine($"The value {value} is not in the group {row} in the panel {panel}");
            }
        }

        /// <summary>
        /// Clicks every CheckBox in a panel
        /// </summary>
        public void ClickCheckBoxes(string panel)
        {
            var CheckBoxList = ExtractIWebElementsList(string.Format(PanelLocator, panel), CheckBox);
            foreach (IWebElement CheckBox in CheckBoxList)
            {
                CheckBox.Click();
            }
        }

        public void ClickFirstCell(string panel, string row)
        {
            Click(string.Format(Firstcell, panel, row), microPause);
        }

        public void ClickOnCellWithRowAndColumn(string panel, string row, string column)
        {
            Click(string.Format(CellWithRowAndColumn, panel, row, column), microPause);
        }

        /// <summary>
        /// Clicks every botton to set normals in a panel
        /// </summary>
        public void SetNormalValues(string panel)
        {
            PmsPages.ExaminationPage.ScrollPanelIntoView(panel);
            var NormalIconsList = ExtractIWebElementsList(string.Format(PanelForScreenshot, panel), NormalValuesIcon);
            foreach (IWebElement NormalIcon in NormalIconsList)
            {
                NormalIcon.Click();
            }
        }

        public void ClickShowHistoryIcon(string panel)
        {
            Click(string.Format(HistoryIcon, panel), longPause);
        }

        public void ClickExpandNotesIcon(string panel)
        {
            Click(string.Format(ExpandNotesIcon, panel), longPause);
        }

        public void ClickExpandNotesIconinVisualAcuity(string panel)
        {
            Click(string.Format(ExpandNotesIconinVisualAcuity, panel), microPause);
        }

        public void ExpandNotesModal(string panel)
        {
            if (!IsElementVisible(string.Format(NotesBox, panel, "Notes")))
            {
                Click(string.Format(NotesIcon, panel), microPause);
            }
            ClickExpandNotesIcon(panel);
        }

        public void CloseNotesModal()
        {
            if (IsElementVisible(ModalCancel))
            {
                Click(ModalCancel);
            }
            else
            {
                Assert.Inconclusive("Error : Expand Notes Modal is not open");
            }
        }

        public bool IsConfirmationModalDisplayed()
        {
            if (IsElementVisible(A3UICommonLocators.ConfirmModalYesButton, microPause))
            {
                EyesCheckScreen("ERROR: Expand Notes Modal is asking for confirmation despite no changes have been done.");
                return true;
            }
            EyesCheckScreen("OK: Expand Notes Modal closed when no changes have been done.");
            return false;
        }

        public void HoverMouseOverPanelHeader(string panel)
        {
            MouseHoverElement(string.Format(PanelLocator, panel), microPause);
        }

        /// <summary>
        /// Clicks the X in dropdown to clean options selected
        /// </summary>
        public void DeleteValuesinDropDown(string dropdown, string panel)
        {
            Click(string.Format(DropDownDeleteIcon, panel, dropdown), microPause);
        }

        public void SetSeverity(string panel, string dropdown, int clickingTimes)
        {
            while (clickingTimes > 0)
            {
                Click(string.Format(FirstValueSelected, panel, dropdown), microPause);
                clickingTimes--;
            }
        }

        public void SelectOptionInDropdownInNewSelectSection(string panel, string optionSelected, string dropDown, int section = 1)
        {
            ScrollElementIntoView(string.Format(PanelElement, panel), longPause);

            if (section == 2)
            {
                DropDownArrowNewSelectSection = DropDownArrowNewSecondSelectSection;
            }
            Click(string.Format(DropDownArrowNewSelectSection, panel, dropDown), xLongPause);
            IList<IWebElement> Options = GetElements(string.Format(DropDownListNewSelectSection, dropDown), mediumPause);
            if (!ClickSpecificOptioninAList(Options, optionSelected))
            {
                Assert.Inconclusive("The option " + optionSelected + " was not found in dropdown " + dropDown);
            }
            Click(string.Format(DropDownArrowNewSelectSection, panel, dropDown), xLongPause);
        }

        /// <summary>
        /// Selects numberValuesSelected random values in numberDropdownsSelected random dropdowns in a panel
        /// </summary>
        public IList<IWebElement> SelectValuesInNewSelectDropdownsInPanel(int numberValuesSelected, int numberDropdownsSelected, string panel)
        {
            ScrollElementIntoView(string.Format(PanelElement, panel), longPause);

            var dropdownList = ExtractIWebElementsList(string.Format(PanelElement, panel), PanelOptionsList);
            numberDropdownsSelected = Math.Min(numberDropdownsSelected, dropdownList.Count);
            dropdownList = dropdownList.OrderBy(x => RandomNumber.Next()).Take(numberDropdownsSelected).ToList();

            SelectValuesinEveryNewSelectDropdown(panel, numberValuesSelected, dropdownList);

            return dropdownList;
        }

        public void SelectValuesinSecondSection(string panel, int numberValuesSelected, IList<IWebElement> dropdownList)
        {
            SelectValuesinEveryNewSelectDropdown(panel, numberValuesSelected, dropdownList, 2);
        }

        /// <summary>
        /// Selects numberValuesSelected options in a list of dropdown elements (dropdownList)
        /// </summary>
        public void SelectValuesinEveryNewSelectDropdown(string panel, int numberValuesSelected, IList<IWebElement> dropdownList, int section = 1)
        {
            if (section == 2)
            {
                DropDownArrowNewSelectSection = DropDownArrowNewSecondSelectSection;
            }
            foreach (var DropDownElement in dropdownList)
            {
                WaitForIWebElementToBeClickable(DropDownElement, microPause);
                string dropDownName = DropDownElement.GetAttribute("innerText");

                Click(string.Format(DropDownArrowNewSelectSection, panel, dropDownName), longPause);

                IList<IWebElement> optiondropdownList = GetElements(string.Format(DropDownListNewSelectSection, dropDownName), mediumPause);
                int numberValues = Math.Min(numberValuesSelected, optiondropdownList.Count);
                ClickRandomRowsInIwebElementList(optiondropdownList, numberValues);

                Click(string.Format(DropDownArrowNewSelectSection, panel, dropDownName), longPause);
            }
        }

        public void ClickFirstDropDown(string panel)
        {
            Click(string.Format(FirstDropDown, panel), microPause);
        }

        public void ClickTodaysAppointmentHeader()
        {
            Click(TodaysAppointmentHeader, microPause);
            WaitUntilSpinnerNonVisible(3);
        }
    }
}
