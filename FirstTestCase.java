/**
 * 
 */
package automationFramework;

import java.util.concurrent.TimeUnit;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.chrome.ChromeDriver;


public class FirstTestCase {

	public static void main(String[] args) throws InterruptedException{
	
		//Starting
		System.out.println("First case");
		WebDriver driver = new ChromeDriver();
		driver.navigate().to("https://demoqa.com/login");
		driver.manage().window().maximize();
		String title = driver.getTitle();
		System.out.println("The page title is : " +title);
		
		//location of elements
		WebElement uName = driver.findElement(By.xpath("//input[@id='userName']")); //selects the node called input that has an attribute
																					//id that matches the string 'userName'
		//WebElement uName = driver.findElement(By.id("userName")); //We could locate this way too
		WebElement pswd = driver.findElement(By.xpath("//input[@*= 'password']")); //selects the node called input with any attribute that matches 
		 																 		   //with the string 'password'
		WebElement loginBtn = driver.findElement(By.xpath("//*[@id='login']"));	//selects any node that has an attribute id that matches with 
		 																		//the string 'login'
	
		uName.sendKeys("testuser");
		pswd.sendKeys("Password@123");
		Thread.sleep(1000);
		loginBtn.click();
		Thread.sleep(1000);
		
		//location of logout in profile page
		try {
					//The pipe doen't work because it takes both paths and the second one exists in profile page
			//WebElement logoutBtn = driver.findElement(By.xpath("//button[@id='submit']|//button[@*='btn btn-primary']"));
					//Relative path works (in case only the id wasn't enough
			//WebElement logoutBtn = driver.findElement(By.xpath("//div[@class='text-right col-md-5 col-sm-12']//button[@id='submit']"));
			WebElement logoutBtn = driver.findElement(By.xpath("//button[@id='submit']"));
			if (logoutBtn.isDisplayed()) {
				logoutBtn.click();
				System.out.println("Logout succeful");
			}
		}
			catch (Exception e){
				System.out.println("Incorrect login....");
		}
		Thread.sleep(1000);
		
		 
	     driver.quit();								
		 System.out.println("Execution complete");
		
		
		
		
	}

		 
}