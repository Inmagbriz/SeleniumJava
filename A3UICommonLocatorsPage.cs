using System;
using System.Collections.Generic;
using System.Text;

namespace OAF.A3.UI.Lib.PmsPageObjects
{
    public class A3UICommonLocatorsPage
    {
        public string Menu = "xpath=//ul[contains(@class,'app-nav-home')]/li/a[contains(text(),'{0}')]";
        public string TopMenu = "xpath=//ul[contains(@class,'app-nav-home')]";
        public string Feature = "xpath=//div[@data-testid='homeMenuItems']/div/div/div/a/div[text()='{0}']";
        public string errorOrigin = "xpath=(//div[contains(@class,'errorOrigin')])[1]";
        public string errorDate = "xpath=(//div[contains(@class,'errorDate')])[1]";
        public string errorMessage = "xpath=(//div[contains(@class,'errorDate')]/following-sibling::div)[1]";
        public string YesButton = "xpath=//button[text() = 'Yes']";
        public string ChangeUserButton = "xpath=//button[contains(@value,'change-user')]";
        public string ChangeLocationButton = "xpath=//button[contains(@value,'change-location')]";
        public string CancelButtonModal = "xpath=//div[@data-testid='modal-header']//following::button[text() = 'Cancel']";
        public string CancelButtonModalWithoutTextAttribute = "xpath=//div[@class='modal-content']/descendant::button[@data-testid = 'secondary-button']";
        public string CancelButtonModalWithNameAttribute = "xpath=//div[@class='modal-content']/descendant::button[@name = 'import-cancel']";
        public string CancelButton = "xpath=//button[text() = 'Cancel']";
        public string okButton = "xpath=//button[@name='ok']";
        public string OKButton = "xpath=//button[@data-testid = 'primary-button']";
        public string userName = "xpath=//div[contains(@data-test-el,'username')]";
        public string location = "xpath=//div[@data-test-el ='practice']";
        public string PINfield = "xpath=//input[@name='identification.pin']";
        public string UnsavedChangesWindow = "xpath=//div[contains(.,'unsaved changes')]";
        public string LockButton = "xpath=//button[text() = 'Lock']";
        public string LockedStationMessageBox = "xpath=//div[contains(.,'station is locked')]";
        public string MainAreaVerticalContainer = "xpath=//div[@id='mainAreaVerticalContainer']";
        public string PanelName = "xpath=//div[contains(text(), '{0}')]";
        public string LocationinModal = "xpath=//input[@name = 'tenantName']";
        public string OptionsinDropDown = "xpath=//li[@data-testid = 'select-menu-item']";
        public string VerticalOption = "xpath=//div[text() = '{0}']";
        public string ClearSelectedOption = "xpath=//div[contains(@data-testid,'clear-selected')]";
        public string WarningYesButton = "xpath=//button[@data-testid = 'modal-confirm']";
        public string ConfirmModalYesButton = "xpath=//h5[text()='Confirm']/following::button[@data-testid = 'modal-confirm']";
        public string TopMenuFirstOption = "xpath=//a[@data-test-el = 'nav-link']";
        public string ClosePatientButton = "xpath=//button[@data-testid = 'breadcrumb-nav-bar-close']";
        public string Modal = "xpath=//div[@class = 'modal-content']";
        public string Spinner = "xpath=//div[contains(@class, 'spinner_overlay')]";
        public string ModalBody = "xpath=//div[@data-testid='modal-body']";
        public string SaveModalButton = "xpath=//div[@class='modal-content']/descendant::button[@data-testid = 'primary-button']";
        public string ContactDetailsPanelInDataPatientPage = "xpath=//div[@data-test-el='contact-preferences-panel']";
    }
}
