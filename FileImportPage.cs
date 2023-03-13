using NUnit.Framework;
using OAF.A3.Infra.Test;
using OAF.Common.Test.Common.Utils;
using OAF.Common.Test.Common.Utils.Models;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace OAF.A3.UI.Lib.PmsPageObjects
{
    public class FileImportPage : CommonPMSPage
    {
        #region Locators
        public string FileImportTitle = "xpath=//h5[text() = 'File Import']";
        public string FileInput = "xpath=//input[@type = 'file']";
        public string FileModal = "xpath=//div[@class = 'modal-content']";
        public string LateralityGroup = "xpath=//div[@class='modal-content']/descendant::div[@data-test-el = 'radio-btn-group']";
        public string LateralityGroupOptions = "xpath=.//label[contains(@class, 'radio-button_radio')]";
        public string DateInput = "xpath=//div[@class = 'modal-content']/descendant::input[@data-testid = 'datepicker-input']";
        public string TimeInput = "xpath=(//div[@class = 'modal-content']/descendant::input[@data-testid = 'datepicker-input'][2])";
        public string Modality = "xpath=(//div[@class = 'modal-content']/descendant::div[contains (@class, 'custom-grid_collapseRow')][2])";
        public string Tag = "xpath=(//div[@class = 'modal-content']/descendant::div[contains (@class, 'custom-grid_collapseRow')][3])";
        public string OptionsList = "xpath=//div[@class = 'modal-content']/descendant::ul[@data-testid = 'select-menu']/descendant::li";
        public string ExpandNotesModal = "xpath=//div[@class = 'modal-content']/descendant::button[contains(@class, 'rich-text-field')]";
        public string ThumbList = "xpath=//div[@class = 'modal-content']/descendant::div[@data-testid = 'thumbnail-item']";
        public string DeleteButton = "xpath=//div[@class = 'modal-content']/descendant::button[@id = 'file-delete-btn']";
        public string ConfirmDeleteButton = "xpath=//button[@data-testid = 'modal-confirm']";
        public string ZoomButton = "xpath=//div[@class = 'modal-content']/descendant::button[@id = 'attachment-tools-fit-btn']";
        public string ActiveImage = "xpath=//div[@class = 'modal-content']/descendant::div[@class = 'lt-item lt-item-active']";
        public string EffectButton = "xpath=//div[@class = 'modal-content']/descendant::button[@aria-label = '{0}']";
        public string PDFButton = "xpath=//div[@data-testid = 'modal-footer']/descendant::button[@data-testid = 'secondary-button']";
        public string DragButton = "xpath=//div[@class = 'modal-content']/descendant::span[@class = 'drag-button']";
        #endregion

        private readonly IWebDriver _driver = A3UICommonSelenium.Driver;
        public string FilePath = (AppContext.BaseDirectory).Split(new[] { Path.DirectorySeparatorChar + "OAF.A3.UI" }, StringSplitOptions.None)[0] + Path.DirectorySeparatorChar +
                                APIContext.PMSRunOptions.TestDataPath.Split("../../../../", StringSplitOptions.None)[1];

        public FileImportPage()
        {
            TitleLocator = FileImportTitle;
        }

        public void SelectFilesWithDetails(List<MedicalFileDetails> FileDetails)
        {
            IWebElement fileInputElement = _driver.FindElement(ByLocator(FileInput));
            foreach (var file in FileDetails)
            {
                SelectFile(FilePath, fileInputElement, file.FileName);
                SetDetails(file);
            }
        }

        public void SelectFilesAndSeeDetails(List<MedicalFileDetails> FileDetails)
        {
            WaitForVisibilityOfElement(FileInput, microPause);
            IWebElement fileInputElement = _driver.FindElement(ByLocator(FileInput));
            foreach (var file in FileDetails)
            {
                SelectFile(FilePath, fileInputElement, file.FileName);
                SetDetails(file);
                EyesCheckElement(FileModal, $"{file.FileName} selected to upload");
            }
        }

        public void FilesUploaded(List<MedicalFileDetails> FileDetails)
        {
            if (!PmsPages.MedicalImagesPage.IsImageViewerVisible())
            {
                WaitForInVisibilityOfElement(FileInput, microPause);
                IWebElement fileInputElement = _driver.FindElement(ByLocator(FileInput));
                foreach (var file in FileDetails)
                {
                    SelectFile(FilePath, fileInputElement, file.FileName);
                    SetDetails(file);
                }
                PmsPages.CommonButtonsPage.ClickOKButton();
                Thread.Sleep(4000);
            }
        }

        public void UpdateDetailsinFile(MedicalFileDetails FileDetails)
        {
            SetDetails(FileDetails);
        }

        public void SelectFile(string filePath, IWebElement fileInputElement, string fileName)
        {
            string file = filePath + Path.DirectorySeparatorChar + fileName;
            fileInputElement.SendKeys(file);
        }


        public void SetDetails(MedicalFileDetails FileDetails)
        {
            WaitForVisibilityOfElement(LateralityGroup, microPause);
            var GroupOptionsList = ExtractIWebElementsList(LateralityGroup, LateralityGroupOptions);
            if (!ClickSpecificOptioninAList(GroupOptionsList, FileDetails.Laterality))
            {
                Console.WriteLine($"{FileDetails.Laterality} is not in Laterality options");
            }
            SetDateTime(FileDetails);
            SetModality(FileDetails);
            SetTags(FileDetails);
            SetNotes(FileDetails);
        }

        public void SetDateTime(MedicalFileDetails FileDetails)
        {
            if (!string.IsNullOrEmpty(FileDetails.ImageUploadDate))
            {
                IWebElement dateInputElement = _driver.FindElement(ByLocator(DateInput));
                Click(DateInput, microPause);
                PressDelete();
                dateInputElement.SendKeys(DateTimeUtils.GenerateDateFromString(FileDetails.ImageUploadDate).Value.ToString(dateFormat));
                PressTabKey();
                IWebElement timeInputElement = _driver.FindElement(ByLocator(TimeInput));
                timeInputElement.SendKeys(DateTimeUtils.GenerateDateFromString(FileDetails.ImageUploadDate).Value.ToString(timeFormat));
            }
        }

        public void SetModality(MedicalFileDetails FileDetails)
        {
            if (!string.IsNullOrEmpty(FileDetails.Modality))
            {
                Click(Modality, microPause);
                PressArrowDownKey();

                IList<IWebElement> ModalityOptions = GetElements(OptionsList, mediumPause);
                if (!ClickSpecificOptioninAList(ModalityOptions, FileDetails.Modality))
                {
                    Console.WriteLine($"{FileDetails.Modality} is not in Modality options");
                }
            }
        }

        public void SetTags(MedicalFileDetails FileDetails)
        {
            if (!string.IsNullOrEmpty(FileDetails.Tag))
            {
                Click(Tag, microPause);
                PressArrowDownKey();

                IList<IWebElement> TagOptions = GetElements(OptionsList, mediumPause);
                if (!ClickSpecificOptioninAList(TagOptions, FileDetails.Tag))
                {
                    Console.WriteLine($"{FileDetails.Tag} is not in Tags options");
                }
                if (!string.IsNullOrEmpty(FileDetails.Tag2))
                {
                    if (!ClickSpecificOptioninAList(TagOptions, FileDetails.Tag2))
                    {
                        Console.WriteLine($"{FileDetails.Tag2} is not in Tags options");
                    }
                }
                if (!string.IsNullOrEmpty(FileDetails.Tag3))
                {
                    if (!ClickSpecificOptioninAList(TagOptions, FileDetails.Tag3))
                    {
                        Console.WriteLine($"{FileDetails.Tag3} is not in Tags options");
                    }
                }
                PressTabKey();
            }
        }

        public void SetNotes(MedicalFileDetails FileDetails)
        {
            if (!string.IsNullOrEmpty(FileDetails.Notes))
            {
                Click(ExpandNotesModal);
                if (!PmsPages.ImageNotesModalPage.IsTitleDisplayed() || !PmsPages.ImageNotesModalPage.IsToolBarDisplayed())
                {
                    Console.WriteLine("Notes couldn't be added. Notes of Images modal not displayed correctly");
                }
                SendText(FileDetails.Notes);
                PmsPages.ImageNotesModalPage.SaveNotes();
            }
        }

        public void SelectImageInFileModal(int imageNumber)
        {
            IList<IWebElement> Options = GetElements(ThumbList, microPause);
            Options[imageNumber - 1].Click();
        }

        public void RemoveImageSelectedInFileImportModal()
        {
            Click(DeleteButton, microPause);
            if (IsElementVisible(ConfirmDeleteButton, microPause))
            {
                Click(ConfirmDeleteButton, microPause);
            }
        }

        public void ZoomImageInFileModal()
        {
            Click(ZoomButton, microPause);
            DoubleClick(ActiveImage, microPause);
        }

        public void UnzoomImageInFileModal()
        {
            Click(ZoomButton, microPause);
        }

        public void ClickEffectButton(string effect)
        {
            Click(string.Format(EffectButton, effect), shortPause);
        }

        public void ClickUploadAsPDF()
        {
            Click(PDFButton, microPause);
        }

        public void ClickInFileImportModalTitle()
        {
            Click(FileImportTitle, microPause);
        }

        public void MoveDragButton(string direction)
        {
            if (!IsElementVisible(DragButton, microPause))
            {
                Assert.Inconclusive("Funcionality couldn't be tested. Drag button is not in the page");
            }

            IWebElement dragButtonElement = GetElement(DragButton, microPause);

            int xcoordinate = 0;
            int ycoordinate = 0;
            switch (direction)
            {
                case "right":
                    xcoordinate = NumberPixelsMainAreaVerticalContainer;
                    break;
                case "left":
                    xcoordinate = -1 * NumberPixelsMainAreaVerticalContainer;
                    break;
            }

            DragAndDropToOffset(dragButtonElement, xcoordinate, ycoordinate);
        }
    }
}