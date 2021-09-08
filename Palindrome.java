package Exercices;

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

public class Palindrome {

	public static void main(String[] args) throws InterruptedException{
		// TODO Auto-generated method stub
		
		System.out.println("Palindrome challenge");

		try {

			System.out.println("Write an algorithm that checks if a word is a palindrome");
			System.out.println("a word or phrase that is spelled the same forward and backward, such as madam or dad");
			System.out.println("by reversing all the letters in the word and then checking to see if it remains the same.");
/*			

			String text = "DABALE arroz a la zorra el abad";
		
			StringBuilder reverse = new StringBuilder();
			String clean = text.replaceAll("\\s+", "").toLowerCase();	//removing spaces and chenging to loercase

			char[] plain = clean.toCharArray();							//clean string has to be an array to run through it

			for (int i = plain.length - 1; i >= 0; i--) { 				//appending to reverse every element of the array
				reverse.append(plain[i]);
			}

			boolean isPal = reverse.toString().equals(clean);			//comparing initial and final strngs
			System.out.println (isPal);
*/		

			String text = "dad";
			//String text = "";
			if (text !="") {
				StringBuilder backward = new StringBuilder();

				String clean = text.replaceAll("\\s+", "").toLowerCase();
				char[] Aclean = clean.toCharArray();
				
				for (int i = Aclean.length - 1; i>=0; i--){
					backward.append(Aclean[i]);
				}
	
				boolean isPal = (backward.toString()).equals(clean);
				//We could have used an equalsIgnoreCase that compares innoring if there is any lower case and upper case discrepancy
				//instead of use the toLowerCase function when creating String clean.
				System.out.println(isPal);
			
			}
			else System.out.println("Text empty"); 
		}
					
		catch (Exception e){
			System.out.println("Error");
		}

		System.out.println("Execution complete");
	
	
	}
	/*
	A different way
		public static void main(String[] args) throws InterruptedException{
	
		String text = "madam";
		//String text = "";
		//String text = "  ";
		//String text = "l";
		//String text = "jj";
		if(text.isBlank() || text.isEmpty()) System.out.println("Text blank or empty");
		else{
			boolean bPal = EsPal(text);
			System.out.println("Text is a palindrome? " + bPal);
		}
}	
	public static boolean 	EsPal(String text){

		String clear = text.replaceAll("\\s+","").toLowerCase();
		StringBuilder backwards = new StringBuilder();

		for (int i=clear.length()-1;i>=0;i--){
			backwards.append(clear.charAt(i));
		}
		return (clear.equals(backwards.toString()));

	}
	*/
	
}
