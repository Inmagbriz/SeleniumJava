package automationFramework;

import java.util.concurrent.TimeUnit;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.logging.LogEntry;
import org.openqa.selenium.support.ui.Wait;

public class Navigation_Commands {

	public static void main(String[] args) throws InterruptedException{
		// TODO Auto-generated method stub

		System.out.println("Browser_Commands");
		WebDriver driver = new ChromeDriver();
		String url = "https://demoqa.com"; 
		driver.navigate().to(url);
		driver.manage().window().maximize();
		String title = driver.getTitle();
		System.out.println("The page title is : " + title);
		try {
			//two ways to locate click forms button
			driver.findElement(By.xpath(".//*[@viewBox='0 0 24 24']")).click();
			//driver.findElement(By.cssSelector("svg[viewBox='0 0 24 24']")).click();
			Thread.sleep(2000);
		}
		catch (Exception e){
			System.out.println("Element not found");
		}
		
		 // Go back to Home Page
		 driver.navigate().back();
		 Thread.sleep(2000);
		 
		 // Go forward to Registration page    
		 driver.navigate().forward();
		 Thread.sleep(2000);
	 
		 // Refresh browser
		 driver.navigate().refresh();

		Thread.sleep(2000);
	    driver.quit();	
		System.out.println("Execution complete");
	
	
	}
	
}
