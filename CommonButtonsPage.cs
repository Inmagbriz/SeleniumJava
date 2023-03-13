using OAF.A3.UI.Lib.Actions;
using OpenQA.Selenium;
using System;

namespace OAF.A3.UI.Lib.PmsPageObjects
{
    public class CommonButtonsPage : CommonPMSPage
    {
        public void ClickOKButton()
        {
            if (IsElementVisible(A3UICommonLocators.OKButton, microPause))
            {
                Click(A3UICommonLocators.OKButton);
            }
        }

        public void ClickOKButtonInModal()
        {
            if (IsElementVisible(A3UICommonLocators.OKButton, microPause))
            {
                Click(A3UICommonLocators.SaveModalButton);
            }
        }

        public void ClickCancelButton()
        {
            if (IsElementVisible(A3UICommonLocators.CancelButton, microPause))
            {
                Click(A3UICommonLocators.CancelButton);
            }
        }

        public void CancelButtonModal()
        {
            if (IsElementVisible(A3UICommonLocators.CancelButtonModal, microPause))
            {
                Click(A3UICommonLocators.CancelButtonModal);
            }
        }
    }
}
