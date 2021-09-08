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
import org.openqa.selenium.OutputType;
import org.openqa.selenium.Point;
import java.io.File;						//to take screenshots
import org.openqa.selenium.TakesScreenshot; //to take screenshots
import org.apache.commons.io.FileUtils;		//to take screenshots
import java.text.DateFormat;				//to obtain date/time
import java.text.SimpleDateFormat;			//to obtain date/time
import java.util.Date;						//to obtain date/time

public class Screenshots {

	public static void main(String[] args) throws InterruptedException{
		// TODO Auto-generated method stub
		
		System.out.println("Screenshots");
		WebDriver driver = new ChromeDriver();
		//driver.get("http://demo.guru99.com/test/web-table-element.php");
		driver.get("https://www.reddit.com/r/crochet/comments/mrddk5/lettuce_leaves_for_my_children_to_play_in_a/");
		
		driver.manage().window().maximize();
		
		//https://www.guru99.com/take-screenshot-selenium-webdriver.html

		try {

			// Create object of SimpleDateFormat class and decide the format
			 DateFormat dateFormat = new SimpleDateFormat("MMddyyyyHHmmss");
			 //get current date time with Date()
			 Date date = new Date();
			 // Now format the date
			 String date1= dateFormat.format(date);
			//Path for Screenshots
			String fileWithPath = "C:\\Users\\Arundel_2\\eclipse-workspace\\Screenshots\\" + date1 + ".png";
			//Convert web driver object to TakeScreenshot
			TakesScreenshot scrShot=((TakesScreenshot)driver);
			//Call getScreenshotAs method to create image file
			File SrcFile = scrShot.getScreenshotAs(OutputType.FILE);
			//Move image file to new destination
			File DestFile = new File(fileWithPath);
			//Copy file at destination
			FileUtils.copyFile(SrcFile, DestFile);
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
