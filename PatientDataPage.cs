using NUnit.Framework;
using OAF.A3.UI.Lib.Actions;
using OAF.Common.Test.Common.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace OAF.A3.UI.Lib.PmsPageObjects
{
    public class PatientDataPage : CommonPMSPage
    {
        #region Locators
        public string PatientDOB = "xpath=//input[contains(@name,'dateOfBirth')]";
        public string PatientFirstName = "xpath=//input[contains(@name,'firstName')]";
        public string SaveBtn = "xpath=//button[text()='OK']";
        public string InputField = "xpath=//div[text() = '{0}']/following::input[contains(@id,'field')]";
        public string MembershipNo = "xpath=//input[@name = 'patientIdentifiers[0].patientIdentifier']";
        public string CorrespondencePreferencesPanel = "xpath=//div[@data-testid='correspondence-preferences-panel']";
        public string ContactDetailsAddress = "xpath=//div[@data-test-el='contact-preferences-panel']/descendant::div[@data-test-el='address-lookup']/descendant::input[@name='contacts[0].contactReference']";
        public string AddressDisableButton = "xpath=//div[@data-test-el='contact-preferences-panel']/descendant::button[@data-testid='disable-icon-button']";
        public string MobileDisableButton = "xpath=//div[@data-test-el='contact-preferences-panel']/descendant::button[@data-testid='disable-icon-button'][2]";
        public string EmailDisableButton = "xpath=//div[@data-test-el='contact-preferences-panel']/descendant::button[@data-testid='disable-icon-button'][3]";
        public string AddContactButton = "xpath=//div[@data-test-el='contact-preferences-panel']/descendant::div[@data-testid='menu-trigger']";
        public string ContactDetailsAddList = "xpath=//div[@data-test-el='contact-preferences-panel']/descendant::ul[@class='rc-menu-item-group-list']/li";
        public string NewContactDetail = "xpath=//div[@data-test-el='contact-preferences-panel']/descendant::div[text() = '{0}'][{1}]/following::input[contains(@name, 'contactReference')]";
        public string HamburguerNewContactDetail = "xpath=//div[@data-test-el='contact-preferences-panel']/descendant::div[text() = '{0}'][{1}]/preceding::div[contains(@class, 'patient-contact-preferences_hamburgerColumn')][2]";
        public string ExpandAddressButton = "xpath=//div[@data-test-el='contact-preferences-panel']/descendant::div[@data-testid='tooltip-target'][2]";
        public string ExpandSecondAddressButton = "xpath=//div[@data-test-el='contact-preferences-panel']/descendant::div[@data-testid='tooltip-target'][5]";
        public string AddressFloatingPanel = "xpath=//div[@data-test-el='contact-preferences-panel']//descendant::div[@data-testid='floating-panel-container']";
        public string AddressInFirstAddressFloatingPanel = "xpath=//div[@data-test-el='contact-preferences-panel']//descendant::div[@data-testid='floating-panel-container']//descendant::input[contains(@name, 'address.address1')]";
        public string DetailInAddressFloatingPanel = "xpath=//div[@data-test-el='contact-preferences-panel']//descendant::div[@data-testid='floating-panel-container']//descendant::input[contains(@name, 'address.{0}')]";
        public string CountryInAddressFloatingPanel = "xpath=//div[@data-test-el='contact-preferences-panel']//descendant::div[@data-testid='floating-panel-container']//descendant::div[@data-testid='country-select']";
        public string CountryList = "xpath=//div[@data-test-el = 'contact-preferences-panel']//descendant::div[@data-testid='floating-panel-container']//descendant::ul[@data-testid = 'select-menu']/div/li";
        public string FloatingPanelOKButton = "xpath=//div[@data-test-el = 'contact-preferences-panel']//descendant::div[@data-testid='floating-panel-container']//following::button[@data-testid='floating-panel-ok']";
        public string GeneralConsentToggles = "xpath=//div[@data-test-el='contact-preferences-panel']/descendant::div[contains(@class, 'horizontal-split-container_side')][2]/descendant::div[contains(@class, 'checkbox-switch_switch')]";
        public string ContactConsentToggles = "xpath=//div[@data-test-el='contact-preferences-panel']/descendant::div[contains(@class, 'patient-panel_panel')]/descendant::div[contains(@class, 'checkbox-switch_switch')]";
        public string PriorityAddressBinButton = "xpath=//div[@data-test-el='contact-preferences-panel']/descendant::div[@data-testid='patient-contact-preference-Address']/descendant::div[@data-test-el='contact-preferences-row-delete']";
        public string PriorityAddress = "xpath=//div[@data-test-el='contact-preferences-panel']/descendant::div[@data-testid='patient-contact-preference-Address']";
        public string PriorityMobileBinButton = "xpath=//div[@data-test-el='contact-preferences-panel']/descendant::div[@data-testid='patient-contact-preference-Mobile']/descendant::div[@data-test-el='contact-preferences-row-delete']";
        public string PriorityMobile = "xpath=//div[@data-test-el='contact-preferences-panel']/descendant::div[@data-testid='patient-contact-preference-Mobile']";
        public string DeliveryAddress = "xpath=//div[@data-testid='correspondence-preferences-panel']/descendant::input[@name='deliveryAddress']/ancestor::div[@data-testid='select-wrapper']";
        public string DeliveryAddressList = "xpath=//ul[@data-testid = 'select-menu']/div/li";
        public string NoteAddress = "xpath=//div[@data-test-el='contact-preferences-panel']/descendant::div[@data-testid='patient-contact-preference-Address']/descendant::button[@name='notes']";
        public string GroupLocator = "xpath=//div[@data-test-el='contact-preferences-panel']//descendant::div[@data-testid='floating-panel-container']//following::div[text()='{0}']/following::div[@data-test-el = 'radio-btn-group']";
        public string GroupOptionsLocator = "xpath=.//label[contains(@class, 'radio-button_radio')]";
        #endregion

        public void UpdateDOBPatient()
        {
            ClearText(PatientDOB, microPause);
            ClickAndEnterText(PatientDOB, DateTime.Today.AddYears(-20).AddDays(10).ToString(), microPause);
            Click(SaveBtn, microPause);
            PmsPages.PatientDashboardPage.OnPatientDashboardPage();
        }

        public string UpdateNamePatient(string patientName)
        {
            string newFirstName = patientName.Split(" ")[0] + "s";
            ClickAndEnterText(PatientFirstName, "s", microPause);
            EnterValueInMembership();
            Click(SaveBtn, microPause);
            patientName = newFirstName + " " + patientName.Split(" ")[1];
            return patientName;
        }

        public void EnterValueInMembership(string membershipNo = "12345")
        {
            if (IsElementVisible(MembershipNo, microPause) && string.IsNullOrEmpty(GetElementText(MembershipNo)))
            {
                ClickAndEnterText(MembershipNo, membershipNo);
                PressReturnKey();
            }
        }

        public void EnterValueInField(string inputfield, string value)
        {
            ClearText(string.Format(InputField, inputfield), longPause);
            EnterText(string.Format(InputField, inputfield), value, longPause);
            EnterValueInMembership();
        }

        public string ExtractPatientAddressInContactDetails()
        {
            return GetElement(ContactDetailsAddress, microPause).GetAttribute("value");
        }

        public void ClickDisableButtonAddressInContactDetails()
        {
            Click(AddressDisableButton, microPause);
        }

        public void ClickDisableButtonMobileInContactDetails()
        {
            Click(MobileDisableButton, microPause);
        }

        public void ClickDisableButtonEmailInContactDetails()
        {
            Click(EmailDisableButton, microPause);
        }

        public void ScreenshotContactDetailsPanelInPatientData(string title)
        {
            EyesCheckElement(A3UICommonLocators.ContactDetailsPanelInDataPatientPage, title);
        }

        public void ScreenshotCorrespondencePreferencesPanel(string title)
        {
            EyesCheckElement(CorrespondencePreferencesPanel, title);
        }

        public void ClickOKButtonInPatientDataPage()
        {
            Click(SaveBtn, microPause);
        }

        public void InsertNewDataInContactPanel(string contactType, string contactDetail, string contactPositionInPanel)
        {
            OpenANewContactInformation(contactType);
            InsertAContactInBox(contactType, contactDetail, contactPositionInPanel);
        }

        public void InsertAContactInBox(string contactType, string contactDetail, string contactPositionInPanel)
        {
            Click(string.Format(NewContactDetail, contactType, (NumbersUtils.GetIndexFromOrdinal(contactPositionInPanel) + 1).ToString()));
            DeleteTextInValueAttribute(string.Format(NewContactDetail, contactType, (NumbersUtils.GetIndexFromOrdinal(contactPositionInPanel) + 1).ToString()));
            SendText(contactDetail);
            PressTabKey(); //triggers validation of new contact
        }

        public void OpenANewContactInformation(string contactType)
        {
            Click(AddContactButton, microPause);

            IList<IWebElement> ContactDetailsAddOptions = GetElements(ContactDetailsAddList, microPause);
            if (!ClickSpecificOptioninAList(ContactDetailsAddOptions, contactType))
            {
                Console.WriteLine($"{contactType} is not in Add Contact list in Contact Details panel");
            }
        }
        public void SwapDataInContactPanel(string contactType, string contactPositionInPanel)
        {
            IWebElement webElementFrom = GetElement(string.Format(HamburguerNewContactDetail, contactType, (NumbersUtils.GetIndexFromOrdinal(contactPositionInPanel) + 1).ToString()), microPause);
            DragAndDropWithPreactivationDroppableArea(webElementFrom, 0, NumberPixelsItem*2);
        }

        public void ClickExpandAddress()
        {
            Click(ExpandAddressButton, microPause);
        }

        public void ClickExpandSecondAddress()
        {
            Click(ExpandSecondAddressButton, microPause);
        }

        public void ScreenshotAddressFloatingPanel(string title)
        {
            EyesCheckElement(AddressFloatingPanel, title);
        }

        public void ChangeAddressInAddressFloatingPanel(string newAddress)
        {
            Click(AddressInFirstAddressFloatingPanel);
            DeleteTextInValueAttribute(AddressInFirstAddressFloatingPanel);
            SendText(newAddress);
        }

        public void IntroduceDetailInAddressFloatingPanel(string addressDetail, string addressDetailValue)
        {
            addressDetail = addressDetail.Replace(" ", string.Empty);
            Click(string.Format(DetailInAddressFloatingPanel, addressDetail), microPause);
            SendText(addressDetailValue);
        }

        public void ChangeCountryInAddressFloatingPanel(string newCountry)
        {
            Click(CountryInAddressFloatingPanel, microPause);
            SendText(newCountry.Substring(0, 4));

            IList<IWebElement> CountryOptions = GetElements(CountryList, microPause);
            if (!ClickSpecificOptioninAList(CountryOptions, newCountry))
            {
                Console.WriteLine($"{newCountry} is not in the Countries list");
            }
        }

        public void ClickOKButtonInAddressFloatingPanel()
        {
            Click(FloatingPanelOKButton);
        }

        public void ClickConsentToggles(string togglesType)
        {
            string togglesTypeLocator;
            switch (togglesType)
            {
                case "General":
                    togglesTypeLocator = GeneralConsentToggles;
                    break;
                default:
                    togglesTypeLocator = ContactConsentToggles;
                    break;
            }

            IList<IWebElement> togglesList = GetElements(togglesTypeLocator, microPause);
            foreach (IWebElement toggle in togglesList)
            {
                toggle.Click();
            }
        }

        public void ClickPriorityAddressBinButtonContactPanel()
        {
             Click(PriorityAddressBinButton);
        }

        public bool IsPriorityAddressInContactDetailsPanel(int timeout = 0)
        {
            if (IsElementVisible(PriorityAddress, timeout))
            {
                return true;
            }
            return false;
        }

        public void ClickPriorityMobileBinButtonContactPanel()
        {
            Click(PriorityMobileBinButton);
        }

        public bool IsPriorityMobileInContactDetailsPanel(int timeout = 0)
        {
            if (IsElementVisible(PriorityMobile, timeout))
            {
                return true;
            }
            return false;
        }

        public void SelectADifferentDeliveryAddress()
        {
            Click(DeliveryAddress, microPause);
            PressArrowDownKey();

            IList <IWebElement> DeliveryAddressOptions = GetElements(DeliveryAddressList, microPause);
            if (DeliveryAddressOptions.Count<2)
            {
                Assert.Inconclusive("Funcionality couldn't be tested. There is only one address");
            }

            DeliveryAddressOptions[1].Click();
        }

        public void InsertFirstAddressNote(string addressNote)
        {
            Click(NoteAddress, microPause);
            Click(A3UICommonLocators.ModalBody, microPause);
            SendText(addressNote);
            Click(A3UICommonLocators.SaveModalButton, microPause);
        }

        public void SelectSpecificValueInAddressFloatingPanel(string row, string value)
        {
            var StatusOptionsList = ExtractIWebElementsList(string.Format(GroupLocator, row), GroupOptionsLocator);
            if (!ClickSpecificOptioninAList(StatusOptionsList, value))
            {
                Console.WriteLine($"The value {value} is not in the group {row}");
            }
        }

        public string getActualInformationInAddedContact(string contactType, string contactPositionInPanel)
        {
            return FindElement(ByLocator(string.Format(NewContactDetail, contactType, (NumbersUtils.GetIndexFromOrdinal(contactPositionInPanel) + 1).ToString()))).GetAttribute("value");
        }

        public void WaitForParentGuardianContact(string contactType, string contactPositionInPanel)
        {
            WaitForVisibilityOfElement(string.Format(NewContactDetail, contactType, (NumbersUtils.GetIndexFromOrdinal(contactPositionInPanel) + 1).ToString()), microPause);
        }
    }
}
