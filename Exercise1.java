package Exercices;

import java.util.List;
import java.util.ArrayList;
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

public class Exercise1 {

	public static void main(String[] args) throws InterruptedException{
		// TODO Auto-generated method stub
		
	
		try {
		
			String text = "This is the 100 text";
			//String text = "100";					//only numbers
			//String text = "";						//text empty
			//String text = "This is the text";		//no numbers in the text
			//String text = "100 This is the text";		//numbers at the beginning of the text
			//String text = "This is the text 100";		//numbers at the end of the text
			
			System.out.println("Parse a string, extract the number in that string, add 10% to that number ");
			System.out.println("then print the string with new value.");
			
			if (text != "") {
				//StringBuilder ftext = new StringBuilder();
				StringBuilder ftext = Dealtext(text);
				System.out.println(ftext);
			}
			else System.out.println("The text is empty");
	
		}
		catch (Exception e){
			System.out.println("Element not found");
		}
		
		System.out.println("Execution complete");
	
	}


	
	public static StringBuilder Dealtext (String text) {
		
		StringBuilder ftext = new StringBuilder();
		
		//Extracting the number
		String Snumber = text.replaceAll("[^0-9]", "");
		String Onlytext = text.replaceAll("[0-9]", "");
		if (Snumber == "") { 
			ftext.append("There is no number in the text");
			return ftext;   
		}			
		double number = Double.parseDouble(Snumber);
		number = number * 1.1;
		
		//In case there is no text, only number
		//if(Aonlytext.length == 0) ftext.append(number);
		if(Onlytext.length() == 0) {
			ftext.append(number);
			return ftext;
		}

/*		
		//We don't use here but this is to change number to String 
		String Strinumber = String.valueOf(number);
*/		
		//Position of number
		int pos = text.indexOf(Snumber);
		

		//if the number was at the end is quicker this way
		if (pos == Onlytext.length()) {
			ftext.append(Onlytext);
			ftext.append(" " + number);
			return ftext;
		}
	/*			
			char[] Aonlytext = Onlytext.toCharArray();
	  	//We don't use here but this is to change char[] to String 
			String cad = new String (Aonlytext);
			
			for (int i=0; i<=Onlytext.length()-1;i++) {
				if (i != pos) ftext.append(Aonlytext[i]);
				else {
					ftext.append(" ");
					ftext.append(number);
					ftext.append(" ");
				}
				
			}
	*/
			for (int i=0; i<=Onlytext.length()-1;i++) {
				if (i != pos) ftext.append(Onlytext.charAt(i));
				else {
					ftext.append(" " + number + " ");
				}
		}
		return ftext;
	}
	
	
	
}
