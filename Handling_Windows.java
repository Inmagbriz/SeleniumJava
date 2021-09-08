package automationFramework;

import java.util.concurrent.TimeUnit;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.logging.LogEntry;
import org.openqa.selenium.support.ui.Wait;
import java.util.Iterator;
import java.util.Set;


public class Handling_Windows {

	public static void main(String[] args) throws InterruptedException{
		// TODO Auto-generated method stub

		System.out.println("Handling Windows");
		WebDriver driver = new ChromeDriver();
		driver.get("https://demoqa.com/browser-windows");
		driver.manage().window().maximize();

		try {

			//Opens all the window children
			//driver.findElement(By.id("tabButton")).click();
			driver.findElement(By.id("windowButton")).click();
			//driver.findElement(By.id("messageWindowButton")).click();
			
			//Collects all handles
			String mainWindow = driver.getWindowHandle();
			Set<String> children = driver.getWindowHandles(); 
			Iterator<String> i = children.iterator();
			
			while (i.hasNext()) {		
				String ChildWindow = i.next();
				if (!mainWindow.equalsIgnoreCase(ChildWindow)) {
					//Changing window
					driver.switchTo().window(ChildWindow);
					WebElement text = driver.findElement(By.id("sampleHeading"));
	                System.out.println("Heading of child window is " + text.getText());
	                driver.close();
	                System.out.println("Child window closed");
				}
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
