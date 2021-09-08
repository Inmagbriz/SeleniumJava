package automationFramework;

import java.util.concurrent.TimeUnit;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.logging.LogEntry;
import org.openqa.selenium.support.ui.Wait;

public class Browser_Commands {

	public static void main(String[] args) throws InterruptedException{
		// TODO Auto-generated method stub

		System.out.println("Browser_Commands");
		WebDriver driver = new ChromeDriver();
		String url = "https://demoqa.com"; 
		//driver.navigate().to(url);		//opens the page. Waits till page load
		driver.get(url);				 //Opens the page. Does not wait to page load
		driver.manage().window().maximize();
		
		String title = driver.getTitle();
		int lengthTitle = driver.getTitle().length();
		System.out.println("The page title is : " + title + ". Its length is " + lengthTitle);
		
		String CurrentUrl = driver.getCurrentUrl();
		System.out.println("The page URL is : " + CurrentUrl);
		
		String PageSource = driver.getPageSource();
		int pageSourceLength = PageSource.length(); 
		System.out.println("The page source length is : " + pageSourceLength);
		
		Thread.sleep(1000);
	    driver.quit();		//Closes all windows opened by the WebDriver.
	    //driver.close();			//Closes only the current window the WebDriver is currently controlling
		System.out.println("Execution complete");
	
	
	}
	
}
