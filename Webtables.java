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

public class Webtables {
	public static void main(String[] args) throws InterruptedException{
		// TODO Auto-generated method stub
		
		System.out.println("WebTables");
		WebDriver driver = new ChromeDriver();
		driver.get("http://demo.guru99.com/test/web-table-element.php");
		driver.manage().window().maximize();
		
		//https://www.guru99.com/handling-dynamic-selenium-webdriver.html

		try {
			
			//String sCellValue = driver.findElement(By.xpath(".//*[@class='rt-table']/table/tbody/tr[1]/td[2]")).getText();
			//System.out.println(sCellValue);
			driver.findElement(By.xpath("//*[@id=\"leftcontainer\"]/table/thead/tr/th[1]"));
			driver.manage().timeouts().implicitlyWait(2, TimeUnit.SECONDS);
			
			//No.of Columns
			List<WebElement> col = driver.findElements(By.xpath("//*[@id=\"leftcontainer\"]/table/thead/tr/th"));
			System.out.println("No of cols are : " +col.size()); 
			//No.of rows 
			List<WebElement> row = driver.findElements(By.xpath("//*[@id=\"leftcontainer\"]/table/tbody/tr/td[1]"));
			System.out.println("No of rows are : " + row.size());
			
			//Fetch row value
			WebElement tableRow = driver.findElement(By.xpath("//*[@id=\"leftcontainer\"]/table/tbody/tr[3]"));//third row
			String rowtext = tableRow.getText();
			System.out.println("Third row of table : "+rowtext);
			
			//Fetch cell value
			WebElement tablecell = driver.findElement(By.xpath("//*[@id=\"leftcontainer\"]/table/tbody/tr[3]/td[2]"));//third row
			String celltext = tablecell.getText();
			System.out.println("Third row, third column of table : "+celltext);
			
			//Get Maximum of all the Values in a Column of Dynamic Table
			double maxcolumn=0; 
			for (int i=1; i<= row.size(); i++ ) {
				WebElement value = driver.findElement(By.xpath("//*[@id=\"leftcontainer\"]/table/tbody/tr[" + (i)+ "]/td[3]"));
				double valcolumn = Double.parseDouble(value.getText());
				if (valcolumn >= maxcolumn) {
					maxcolumn = valcolumn;
				}
			}
			System.out.println("Maximum value on third column : "+maxcolumn);

			//Get all the values of a Dynamic Table
			driver.get("http://demo.guru99.com/test/table.html");
			driver.manage().window().maximize();
/*			
 			 * table			
			/html/body/table/tbody
			 * column
			/html/body/table/colgroup
			 * row
			/html/body/table/tbody/tr[1]
			 * cell
			/html/body/table/tbody/tr[1]/td[1]
*/			
	    	//To locate table.
	    	WebElement mytable = driver.findElement(By.xpath("/html/body/table/tbody"));
	    	//To locate rows of table. 
	    	List < WebElement > rows_table = mytable.findElements(By.tagName("tr"));
	    	//To calculate no of rows In table.
	    	int rows_count = rows_table.size();
	    	for (int rows=1; rows<=rows_count; rows++) {
	    		String row_text = driver.findElement(By.xpath("/html/body/table/tbody/tr[" + (rows)+ "]")).getText();
				System.out.println("Row "+ rows + ": " + row_text);
	    	}
	    	//If every element must be separated
	    	for (int rows=0; rows<rows_count; rows++) {
	    		//To locate columns(cells) of that specific row.
	    		List < WebElement > columns_row = rows_table.get(rows).findElements(By.tagName("td"));
	    		//To calculate no of columns (cells). In that specific row.
	    		int column_count = columns_row.size();
	    		System.out.println("Number of cells In Row " + rows + " are " + column_count);
	    		//Loop will execute till the last cell of that specific row.
	    		for (int column=0;column<column_count;column++) {
	    			// To retrieve text from that specific cell.
	    			String textcell = columns_row.get(column).getText();
	    			System.out.println("The element in row " + rows + " and column " +column + " is: " + textcell);
	    		}
	    		System.out.println("-------------------------------------------------- ");
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
