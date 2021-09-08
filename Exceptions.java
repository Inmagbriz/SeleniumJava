package automationFramework;

import java.util.concurrent.TimeUnit;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.logging.LogEntry;
import org.openqa.selenium.support.ui.Wait;

public class Exceptions {

	public static void main(String[] args) throws InterruptedException{
		// TODO Auto-generated method stub

		System.out.println("Exceptions");
		WebDriver driver = new ChromeDriver();
		driver.navigate().to("https://demoqa.com/login");
		driver.manage().window().maximize();
		
		//location of elements successful
		try {
			WebElement uName = driver.findElement(By.xpath("//input[@id='userName']")); 
			System.out.println(uName);
		}
		catch (Exception e){
			System.out.println("Element not found");
		}
		//location of elements failed
		try {
			WebElement uName = driver.findElement(By.xpath("//input[@id='serName']")); 
			System.out.println(uName);
		}
		catch (Exception e){
			System.out.println("Element not found");
			//throw(e);		//throws the exception back to the system so that the test case can be terminated (self print logs in Selenium Automation Framework)
		}
//TIMEOUTS
		
		try {
			//Timeout for an ELEMENT it doesn't find
			driver.get("https://www.ebay.com/");
			//driver.get("http://10.255.255.255/");					//This page gives a timeout, so it doesn't find the element, goes to catch
	
			// Implicit wait timeout for 20seconds
			driver.manage().timeouts().implicitlyWait(20, TimeUnit.SECONDS);
	
			driver.findElement(By.xpath("//input[@id='gh-ac']")).sendKeys("Mobile");
	
			//xpath for search button
			WebElement search = driver.findElement(By.xpath("//input[@id='gh-btn']"));
	
			search.click();
		}catch (Exception  toe){
			System.out.println("Timeout searching the element");
		}
		
		try {
			//Timeout for an PAGE that doesn't load
			driver.get("https://www.ebay.com/");
			//driver.get("http://10.255.255.255/");					//This page gives a timeout, so goes to catch
	
			//Wait timeout for 20seconds
			driver.manage().timeouts().pageLoadTimeout(20, TimeUnit.SECONDS);
			
			System.out.println("Page loaded succefully");

		}catch (Exception  toe){
			System.out.println("Timeout loading the page");
		}

		
		Thread.sleep(1000);
	    driver.quit();								
		System.out.println("Execution complete");
	
	
	}
	
}
