package automationFramework;

import java.util.List;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.chrome.ChromeDriver;


public class FindElement_s {

	public static void main(String[] args) throws InterruptedException{
		// TODO Auto-generated method stub
		
		System.out.println("FindElement_Commands");
		WebDriver driver = new ChromeDriver();
		driver.get("https://demoqa.com/text-box/");
		driver.manage().window().maximize();
		try {
		
			//FindElementS
			System.out.println("	FindElementS");
			// Find all the elements with tag name "input"
			List<WebElement> allInputElements = driver.findElements(By.tagName("input"));
			if (allInputElements.size() != 0) {
				System.out.println(allInputElements.size() + " elements found with TagName 'input'");
				for (WebElement InputElement : allInputElements) {
					System.out.println ("id: " + InputElement.getAttribute("id"));
				}
			}	
			//Another example looking for elements with Class name "element-group"
			List<WebElement> allClassElements = driver.findElements(By.className("element-group"));
			if (allClassElements.size() != 0) {
				System.out.println(allClassElements.size() + " elements found with ClassName as 'element-group'");
				for (WebElement ClassElement : allClassElements) {
					System.out.println ("Element displayed: " + ClassElement.isDisplayed());
				}
			}
			
			//Using Link Text/Partial Link Text
			System.out.println("	LINK/PARTIAL LINK");
			driver.get("https://demoqa.com/links");
			driver.findElement (By.linkText("Home")).click();
			Thread.sleep(2000);
			driver.findElement (By.partialLinkText("Hom")).click();
			Thread.sleep(2000);			
		
		
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
