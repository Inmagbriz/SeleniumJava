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

public class RadioButton {
	public static void main(String[] args) throws InterruptedException{
		// TODO Auto-generated method stub
		
		//Type in HTML is "radio". It is an HTML element
		System.out.println("RadioButton");
		WebDriver driver = new ChromeDriver();
		driver.get("https://www.demoqa.com/radio-button");
		driver.manage().window().maximize();

		try {


			 
			 /**
			 * Find radio button using ID, Validate isSelected and then click to select
			 */
			 //WebElement radioEle = driver.findElement(By.id("yesRadio"));
			 WebElement radioEle = driver.findElement(By.cssSelector("label[for='yesRadio']"));
					 //.id("yesRadio"));
			 boolean select = radioEle.isSelected();
			 System.out.print(select);
			 // performing click operation if element is not already selected
			 if (select == false) {
			 radioEle.click();
			 }
			 
			 /**
			 * Find radio button using Xpath, Validate isDisplayed and click to select
			 */
			 WebElement radioElem = driver.findElement(By.cssSelector("label[for='impressiveRadio']"));
			 boolean sel = radioElem.isDisplayed();
			 
			 // performing click operation if element is displayed
			 if (sel == true) {
			 radioElem.click();
			 }
			 
			 /**
			 * Find radio button using CSS Selector, Validate isEnabled and click to select
			 */
			 WebElement radioNo = driver.findElement(By.cssSelector("input[id='noRadio']"));
			 boolean selectNo = radioNo.isDisplayed();
			 
			 // performing click operation if element is enabled
			 if (selectNo == true) {
			 radioNo.click();
			 }
			  
			
			
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
