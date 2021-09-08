package automationFramework;


import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.chrome.ChromeDriver;


//LOCATORS, CSS SELECTOR AND XPATHS

public class Locators_and_XPaths {
		
		public static void main(String[] args) throws InterruptedException{
			 
			 System.out.println("Using Locators, CSS Selectors ans XPath");
			 WebDriver driver = new ChromeDriver();
			 driver.navigate().to("https://demoqa.com");    //A method to navigate
	//once the driver opens a web (with get or navigate) it remains open and we can change the web by
	//by doing get or navigate as many times as we need. It is not necessary closing, and even it won't work
			 Thread.sleep(1000);
			 driver.get("https://demoqa.com/login");
			 driver.manage().window().maximize();
			 Thread.sleep(1000);
			 String title = driver.getTitle();
			 System.out.println("The page title is : " + title);
			 
			 driver.get("https://www.google.ie/");
			 Thread.sleep(1000);
			 driver.findElement(By.linkText("Gmail"));				//Must be unique. If not, will take the first
			 driver.findElement(By.partialLinkText("Gma"));			//Must be unique. If not, will take the first

			 driver.get("https://demoqa.com/automation-practice-form");
			 Thread.sleep(1000);
			 
			 driver.findElement(By.id("firstName"));   //ID is reliable if it is not a dynamic web page
			 driver.findElement(By.name("gender"));   //Must be unique. If not, will take the first
			 driver.findElement(By.className("practice-form-wrapper"));   //Must be unique. If not, will take the first
			 driver.findElements(By.tagName("a"));					//Finds all the elements with <a>

	//SEE FindElement_s CLASS FOR MORE
	//CSS SELECTORS
			 
			 driver.findElement(By.cssSelector("input[id='firstName']"));		//Input is the tag name 

			 driver.findElement(By.cssSelector("textarea[class='form-control']")); 	//A different attribute of the tag (node)
			 driver.findElement(By.cssSelector("textarea.form-control"));  			//we can write this way the identification by class

			 driver.findElement(By.cssSelector("textarea[placeholder='Current Address']")); //tag textarea identified by placeholder attribute 
			 driver.findElement(By.cssSelector("textarea[id='currentAddress']"));				//tag textarea identified by placeholder id
			 driver.findElement(By.cssSelector("textarea#currentAddress"));					//we can write this way the identification by id
			 driver.findElement(By.cssSelector("textarea#currentAddress[placeholder='Current Address']"));	//We can combine id and other attributes
			 driver.findElement(By.cssSelector("textarea.form-control[placeholder='Current Address']"));	//We can combine class and other attributes
			 driver.findElement(By.cssSelector("input[id^='firstN']"));		//Locates input using the id starting text
			 driver.findElement(By.cssSelector("input[id$='Name']"));		//Locates input using the id ending text
			 driver.findElement(By.cssSelector("input[id*='stNa']"));		//Locates input using the id contains text

			 
	   //using a CSS selector for locating dynamic web elements with hierarchy
			 driver.findElement(By.cssSelector("div>textarea[placeholder='Current Address']"));		//Locates textArea from its parent div. This can be concatenated

			 driver.get("https://www.demoqa.com/select-menu");
			 driver.findElement(By.cssSelector("select#oldSelectMenu>option:nth-of-type(2)"));		//Locates the child element 2 in an "ul" HTML tag father ul:Unordered List
			 
	//XPATHS		 
			 driver.get("https://demoqa.com/text-box");
			 Thread.sleep(1000);
			 driver.findElement(By.xpath("//input[@id='userName']"));	//  Matches the attribute id of the given node with 'userName'	
			 driver.findElement(By.xpath("/html"));						//Selects the first available node. In this case it'll look for the HTML element
			 driver.findElement(By.xpath("//input[contains(@id, 'serN')]"));  //Part of the id string (it can be start or end too)
			 driver.findElement(By.xpath("//input[starts-with(@id,'userN')]")); //Locate the id with the start
			 driver.findElement(By.xpath("//input[contains(@id, 'serN')]/."));	//dot selects the current node.
			 driver.findElement(By.xpath("//input[@placeholder ='Full Name' and @type = 'text']")); //AND operator locates with two attributes
			 driver.findElement(By.xpath("//input[@placeholder ='Full Name' or @type = 'text']"));	//OR operator locates with one of two attributes
			 driver.findElement(By.xpath("//div/input/.."));			//Selects the parent of the current node.
			 //Gettext trae el texto
			 String text = driver.findElement(By.xpath("//label[text()='Email']")).getText();
			 System.out.println(text);
			 String label = driver.findElement(By.xpath("//input[contains(@id, 'userN')]/../../div/label")).getText(); // Double dot “..” - Full name label
			 System.out.println("The label of full text is : " + label);

			 //SendKeys fills fields
			 driver.findElement(By.xpath("//div[contains(@id, 'userName-wrapper')]/div[2]/*")).sendKeys("Full Name"); 		//* selects any element present in the node, i.e. Full name
			 driver.findElement(By.xpath("//input[@*= 'userName']")).sendKeys("Full Name");		//  “@*” matched any attribute of the given node with 'userName'
			 driver.findElements(By.xpath("//label[@*= 'userName-label']|//label[@*= 'userEmail-label']")); //| Selects two paths, both of them
			 driver.get("https://www.demoqa.com/webtables");
			 //PREDICATES
			 boolean lstCol = driver.findElement(By.xpath("//div[@class='rt-tr -odd']/div[last()]")).isDisplayed();  // Get the last node - Last value in table
			 System.out.println("The last table element is displayed : " + lstCol);
			 
			 boolean positionCol = driver.findElement(By.xpath("//div[@class='rt-tr -odd']/div[position()='2']")).isDisplayed(); 		 // Get the 2 node - validate 2 position in table
			 System.out.println("The 2nd table element is displayed : " + positionCol);
			 
			 //ABSOLUTE AND RELATIVE PATH
	 	     driver.get("https://demoqa.com");
		      
		     WebElement headerImage = driver.findElement(By.xpath("/html/body/div/header/a/img")); //Locate the web element using absolute xpath
		     System.out.println("The image is displayed : " + headerImage.isDisplayed());  // Validate that the header image is displayed on the web page
		     
		     headerImage = driver.findElement(By.xpath("//img[@src = '/images/Toolsqa.jpg']")); //Locate the web element using relative xpath
		     System.out.println("The image is displayed : " + headerImage.isDisplayed());  // Validate that the header image is displayed on the web page
	 

	//XPATHS AXIS
			 driver.get("https://demoqa.com/text-box");
			 //using ancestor to locate upper hierarchical nodes
			 driver.findElement(By.xpath("//label[text()='Full Name']/ancestor::form"));  // if there is more than one parent node with the same tag, then this same XPath will identify several different elements
			 //using child to find all the children in a node
			 label = driver.findElement(By.xpath("//form[@id='userForm']/child::div[1]//label")).getText(); //div[1] strats from the first div. //, as we wanted to escape the next div to directly move to label tag
			 System.out.println("The label text is : "+ label);	
			 //using descendent. Recognizing the parent tag, we can locate the radio button
			 driver.get("https://www.demoqa.com/radio-button");
			 driver.findElement(By.xpath("//div[@class= 'custom-control custom-radio custom-control-inline']/descendant::input"));
			 //using parent to only locate the immediate parent node.
			 boolean bo = driver.findElement(By.xpath("//input[@id='yesRadio']/parent::div")).isSelected(); //isSelected allows to know if a button is selected
			 System.out.println("The Yes radio is selected : "+bo);
			 //using following to locate the element after de current node
			 driver.get("https://demoqa.com/text-box");
			 driver.findElement(By.xpath("//input[@id=\"userName\"]/following::textarea")).sendKeys("Text Area locate following");
			//using following sibling to locate sibling nodes
			 driver.findElement(By.xpath("(//div[@class='col-md-3 col-sm-12']/following-sibling::div/input)[2]")).sendKeys("abc@xyz.com");// if there are various siblings it locates all of them
			//using preceding-axis to locate all the nodes before the current node
			 String preceding = driver.findElement(By.xpath("//input[@id='userName']/preceding::label")).getText(); //, if there is more than one element with the same node above the current element, XPath will return multiple elements
			 System.out.println("The value of preceding : "+preceding);
			 
			 
			 
//SOME ACLARATIONS
				driver.navigate().to("https://demoqa.com/login");
				driver.findElement(By.id("userName"));
				WebElement uName = driver.findElement(By.xpath("//input[@id='userName']")); //selects the node called input that has an attribute
																							//id that matches the string 'userName'
				System.out.println(uName);
				 uName = driver.findElement(By.xpath("//input[@*= 'userName']")); //selects the node called input with any attribute that matches 
				 																 //with the string 'userName'
				System.out.println(uName);
				 uName = driver.findElement(By.xpath("//*[@id='userName']"));	//selects any node that has an attribute id that matches with 
				 																//the string 'userName'
				System.out.println(uName);
				 
			 
		     //driver.quit();									//It releases the driver
		     driver.close();	
			 System.out.println("Execution complete");
			 
		}
		// TODO Auto-generated method stub

}
