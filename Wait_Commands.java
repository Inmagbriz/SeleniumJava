package automationFramework;

import java.util.concurrent.TimeUnit;
import java.awt.Color;
import java.time.Duration;

import org.openqa.selenium.Alert;
import org.openqa.selenium.By;
import org.openqa.selenium.NoSuchElementException;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.logging.LogEntry;
import org.openqa.selenium.support.ui.Wait;
import org.openqa.selenium.support.ui.WebDriverWait;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.FluentWait;

import com.google.common.base.Function;
import com.google.common.base.Predicate;

public class Wait_Commands {

	public static void main(String[] args) throws InterruptedException{
		// TODO Auto-generated method stub

		System.out.println("Wait_Commands");

		//Launch new Browser
		WebDriver driver = new ChromeDriver();
        //A generic wait 
        driver.manage().timeouts().implicitlyWait(1, TimeUnit.SECONDS);
		
//NORMAL WAIT
/*
 		String url = "https://demoqa.com/alerts"; 
		driver.get(url);
		
		//Amount of time to wait for a page-load to complete before throwing an error
		driver.manage().timeouts().pageLoadTimeout(100, TimeUnit.SECONDS);
		driver.manage().window().maximize();
		
		try {
			driver.findElement(By.id("timerAlertButton")).click();  //This button opens an alert after 5 seconds
			//driver.findElement(By.id("alertButton")).click();		//This button opens an alert immediately
			
			WebDriverWait wait = new WebDriverWait(driver, 10);
	
			Alert myAlert = wait.until(ExpectedConditions.alertIsPresent());
	
			 // Accept the Alert
	
	        myAlert.accept();
			
	        System.out.println("Alert Accepted");

		}
		catch (Exception e){
			System.out.println("Element not found");
		}

//FLUENT WAIT WITH NORMAL UNTIL
  
 		String url = "https://demoqa.com/alerts"; 
		driver.get(url);
		
		//Amount of time to wait for a page-load to complete before throwing an error
		driver.manage().timeouts().pageLoadTimeout(100, TimeUnit.SECONDS);
		driver.manage().window().maximize(); 
  
		try {
			driver.findElement(By.id("timerAlertButton")).click();  //This botton opens an alert after 5 seconds
			//driver.findElement(By.id("alertButton")).click();		//This botton opens an alert immediately

			//Declare and initialise a fluent wait			
	         Wait<WebDriver> wait = new FluentWait<WebDriver>(driver)
	                 .withTimeout(Duration.ofSeconds(30))		//Specify the timeout of the wait
	                 .pollingEvery(Duration.ofMillis(500))		//Specify polling time
	                 .ignoring(NoSuchElementException.class);	//Specify what exceptions to ignore

			//Specify the condition to wait on.
			Alert myAlert = wait.until(ExpectedConditions.alertIsPresent());
	
			 // Accept the Alert
	        myAlert.accept();
			
	        System.out.println("Alert Accepted");

		}
		catch (Exception e){
			System.out.println("Element not found");
		}
*/
//FLUENT WAIT WITH FUNCTION
		
		String url = "https://demoqa.com/dynamic-properties"; 
		driver.get(url);
		
		//Amount of time to wait for a page-load to complete before throwing an error
		driver.manage().timeouts().pageLoadTimeout(100, TimeUnit.SECONDS);
		driver.manage().window().maximize();
					
		try {

			//Declare and initialise a fluent wait			
	         Wait<WebDriver> wait = new FluentWait<WebDriver>(driver)
	                 .withTimeout(Duration.ofSeconds(30))		//Specify the timeout of the wait
	                 .pollingEvery(Duration.ofMillis(500))		//Specify polling time
	                 .ignoring(NoSuchElementException.class);	//Specify what exceptions to ignore

	 		Function<WebDriver, Boolean> function = new Function<WebDriver, Boolean>()
			{
				public Boolean apply(WebDriver driver) {
					WebElement element = driver.findElement(By.id("colorChange"));	//colour changes after 5 seconds
					String red = "rgba(220, 53, 69, 1)";
					String color = element.getCssValue("color");
					System.out.println("The color of the text the button is " + color);
					if(color.equals(red))
					{
						return true;
					}
					return false;
				}
			};
			wait.until(function);
/*        
			//We can do the wait and the function at the same time
	         Boolean function = wait.until(new Function<WebDriver, Boolean>() {
	             public Boolean apply(WebDriver driver) {
	            	 WebElement element = driver.findElement(By.id("colorChange"));
	            	 String red = "rgba(220, 53, 69, 1)";
						String color = element.getCssValue("color");
						System.out.println("The color of the text the button is " + color);
						if(color.equals(red))
						{
							return true;
						}
						return false;
	             }
	         });
*/			
			//Non boolean function
	 		Function<WebDriver, WebElement> function2 = new Function<WebDriver, WebElement>()
			{
				public WebElement apply(WebDriver driver) {
					WebElement element = driver.findElement(By.id("colorChange"));	//colour changes after 5 seconds
					if(element != null)
					{
						System.out.println("Target element found");
					}
					return element;
				}
			};
			wait.until(function2);

/*
//FLUENT WAIT WITH PREDICATE (ALWAYS RETURNS A BOOLEAN)
			//Declare and initialise a fluent wait			
	         Wait<WebDriver> wait = new FluentWait<WebDriver>(driver)
	                 .withTimeout(Duration.ofSeconds(30))		//Specify the timeout of the wait
	                 .pollingEvery(Duration.ofMillis(500))		//Specify polling time
	                 .ignoring(NoSuchElementException.class);	//Specify what exceptions to ignore

	 		Predicate<WebDriver> predicate = new Predicate<WebDriver>()
			{
				public boolean apply(WebDriver driver) {			//in predicate boolean with b lowercase
					WebElement element = driver.findElement(By.id("colorChange"));	//colour changes after 5 seconds
					String red = "rgba(220, 53, 69, 1)";
					String color = element.getCssValue("color");
					System.out.println("The color of the text the button is " + color);
					if(color.equals(red))
					{
						return true;
					}
					return false;
				}
			};
			wait.until(predicate);  //not compiling. Until not applicable for predicates 
*/
	 	}
		catch (Exception e){
			System.out.println("Element not found");
		}
		
	    driver.quit();		//Closes all windows opened by the WebDriver.
	    //driver.close();			//Closes only the current window the WebDriver is currently controlling
		System.out.println("Execution complete");
	
	
	}
	
}
