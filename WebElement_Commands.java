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

public class WebElement_Commands {

	public static void main(String[] args) throws InterruptedException{
		// TODO Auto-generated method stub
		
		boolean status;
		WebElement element;
		String tagName;
		String Text;

		System.out.println("WebElement_Commands");
		WebDriver driver = new ChromeDriver();
		driver.get("https://demoqa.com/automation-practice-form");
		driver.manage().window().maximize();
		try {
			//A WebElement is any element in the web page
			//Fills name
			WebElement name = driver.findElement(By.id("firstName"));
			name.sendKeys("Inma Guerrero");
			Thread.sleep(2000);
			//Clears name
			name.clear();
			Thread.sleep(2000);
			//Clicks button
			WebElement BtnSubmit = driver.findElement(By.id("submit"));
			BtnSubmit.click();
			//BtnSubmit.submit();  //Similar to Click, but if this causes the current page to change, then this method will wait until the new page is loaded.
			Thread.sleep(2000);
			//Selects from the menu and the menu drops down
			//driver.findElement(By.xpath(".//*[starts-with(@*, 'M13')]"));	//It works but less reliable
			//The only way to locate this option is with its path
			WebElement option = driver.findElement(By.xpath(".//*[@*='M13 13v8h8v-8h-8zM3 21h8v-8H3v8zM3 3v8h8V3H3zm13.66-1.31L11 7.34 16.66 13l5.66-5.66-5.66-5.65z']"));
			Actions action = new Actions(driver);
			//It is not a normal click. The normal click doesn't work
			action.moveToElement(option).click().perform();
			Thread.sleep(2000);
			//menu folds
			action.moveToElement(option).click().perform();
			//An element is displayed
			status = name.isDisplayed();
			if(status) {
				System.out.println("Name box is displayed");
			}else {
				System.out.println("Name box is NOT displayed");
			}
			//An element is displayed
			status = name.isEnabled();
			if(status) {
				System.out.println("Name box is enabled");
			}else {
				System.out.println("Name box is NOT enabled");
			}
			//An element is selected
			WebElement GenderMale = driver.findElement(By.id("gender-radio-1"));
			status = GenderMale.isSelected();
			if(status) {
				System.out.println("Gender male is selected");
			}else {
				System.out.println("Gender male is NOT selected");
			}
			
			//getText obtains the inner text
			System.out.println("	GETTING INNER NAME");
			element = driver.findElement(By.xpath("//div[@class='practice-form-wrapper']"));
			Text = element.getText();
			System.out.println(Text);
			//For example in the node <label class="form-label" id="userName-label">Name</label>, it returns "Name"
			element = driver.findElement(By.xpath("//label[@id='userName-label']"));
			String InnerText = element.getText();
			System.out.println(InnerText);

			//Obtaining tagName
			System.out.println("	GETTING TAG NAME");
			element = driver.findElement(By.id("submit"));
			tagName = element.getTagName();
			System.out.println(tagName); 
			//Or can be written as
			tagName = driver.findElement(By.id("submit")).getTagName();
			System.out.println(tagName); 

			//Css Values
			System.out.println("	GETTING CSS VALUES");
			String color = driver.findElement(By.id("submit")).getCssValue("color");
			System.out.println("Color of Submit button: " + color); 
			String backgroundcolor = driver.findElement(By.id("submit")).getCssValue("background-color");
			System.out.println("Background color of Submit button: " + backgroundcolor); 
			String margin = driver.findElement(By.id("submit")).getCssValue("margin");
			System.out.println("Margin of Submit button: " + margin); 
			String width = driver.findElement(By.id("submit")).getCssValue("width");
			System.out.println("Width of Submit button: " + width); 
			String height = driver.findElement(By.id("submit")).getCssValue("height");
			System.out.println("Height of Submit button: " + height); 
			String display = driver.findElement(By.id("submit")).getCssValue("display");
			System.out.println("Display of Submit button: " + display); 
			
			//attributes
			System.out.println("	GETTING ATTRIBUTES");
			element = driver.findElement(By.xpath(".//*[@*='M13 13v8h8v-8h-8zM3 21h8v-8H3v8zM3 3v8h8V3H3zm13.66-1.31L11 7.34 16.66 13l5.66-5.66-5.66-5.65z']"));
			String attValue = element.getAttribute("d"); 
			System.out.println("attValue: " + attValue);
			element = driver.findElement(By.id("firstName"));
			String placeholder = element.getAttribute("placeholder");
			System.out.println("placeholder :" + placeholder);
			String type = element.getAttribute("type");
			System.out.println("type :" + type);
			String aclass = element.getAttribute("class");
			System.out.println("placeholder :" + aclass);
			
			//size
			System.out.println("	GETTING SIZE");
			element = driver.findElement(By.id("userEmail"));
			Dimension dimensions = element.getSize();		
			System.out.println("Height of Email box: " + dimensions.height); 
			System.out.println("Width of Email box: " + dimensions.width); 
			
			//location
			System.out.println("	GETTING LOCATION");
			element = driver.findElement(By.id("userNumber"));
			Point point = element.getLocation();
			System.out.println("X coordinate of Phone Numer box: " + point.x); 
			System.out.println("Y coordinate of Phone Numer box: " + point.y); 			
			
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
