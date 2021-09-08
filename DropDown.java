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

public class DropDown {
	public static void main(String[] args) throws InterruptedException{
		// TODO Auto-generated method stub
		
		System.out.println("DropDown");
		WebDriver driver = new ChromeDriver();
		driver.get("https://demoqa.com/select-menu");
		driver.manage().window().maximize();

		try {

			/**
			  Syntax to  create a dropdown uses select class. It is different from creating a webelement (check box or radio button)
			  WebElement: WebElement webele = driver.findElement(By.id("firstName"));
			  Dropdown : Select select = new Select(driver.findElement(By.id("oldSelectMenu"))); Select class gives methods for dropdown operations
			*/
			//Drop box with one selection
			Select select = new Select(driver.findElement(By.id("oldSelectMenu")));
			select.selectByIndex(3);
			Thread.sleep(1000);
			select.selectByValue("red");
			Thread.sleep(1000);
			select.selectByVisibleText("Green");
			Thread.sleep(1000);
			
			List <WebElement> options = select.getOptions();
			System.out.println("Number of colors:" + options.size());

			
			//Drop box multiple selections
			select = new Select(driver.findElement(By.id("cars")));
			if (select.isMultiple()) {
				select.selectByIndex(0);
				select.selectByValue("saab");
				select.selectByVisibleText("Audi");
				System.out.println(select.getFirstSelectedOption().getText());
				options = select.getAllSelectedOptions();
				System.out.println("Number of selected: " + options.size());
				Thread.sleep(1000);
				
				select.deselectAll();
				Thread.sleep(1000);
				//no error even when is no selected
				select.selectByValue("saab");
				Thread.sleep(1000);
				select.deselectByValue("saab");
				Thread.sleep(1000);
				select.selectByIndex(0);
				Thread.sleep(1000);
				select.deselectByIndex(0);
				Thread.sleep(1000);
				select.selectByVisibleText("Audi");
				Thread.sleep(1000);
				select.deselectByVisibleText("Audi");
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
