package automationFramework;

import java.util.List;
import java.util.concurrent.TimeUnit;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.logging.LogEntry;
import org.openqa.selenium.support.ui.Wait;
import org.openqa.selenium.support.ui.Select;
import org.openqa.selenium.interactions.Actions;
import org.openqa.selenium.Dimension;
import org.openqa.selenium.Point;

public class CheckBox {
	public static void main(String[] args) throws InterruptedException{
		// TODO Auto-generated method stub
		
		////Type in HTML is "checkbox". It is a GUI element
		System.out.println("CheckBox");
		WebDriver driver = new ChromeDriver();
		driver.get("http://www.demoqa.com/automation-practice-form");
		driver.manage().window().maximize();

		try {

			/**
			 * Validate isSelected and click
			 */
			 
			 WebElement checkBoxSelected = driver.findElement(By.cssSelector("label[for='hobbies-checkbox-1']"));
			 boolean isSelected = checkBoxSelected.isSelected();
			 
			 // performing click operation if element is not selected 
			 if(isSelected == false) checkBoxSelected.click();
			 
			 /**
			 * Validate isDisplayed and click
			 */
			 WebElement checkBoxDisplayed = driver.findElement(By.xpath("//label[text()='Reading']"));
			 boolean isDisplayed = checkBoxDisplayed.isDisplayed();
			 
			 // performing click operation if element is displayed
			 if (isDisplayed == true) checkBoxDisplayed.click();
			 
			 /**
			 * Validate isEnabled and click
			 */
			 WebElement checkBoxEnabled = driver.findElement(By.cssSelector("label[for='hobbies-checkbox-3']"));
			 boolean isEnabled = checkBoxEnabled.isDisplayed();
			 
			 // performing click operation if element is enabled
			 if (isEnabled == true) checkBoxEnabled.click();
			 
			
			
		}
		catch (Exception e){
			System.out.println("Element not found");
		}
		
		Thread.sleep(2000);
	    driver.quit();		//Closes all windows opened by the WebDriver.
	    //driver.close();			//Closes only the current window the WebDriver is currently controlling
		System.out.println("Execution complete");
	
	
	}
	
}
