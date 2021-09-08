package Exercices;

import java.util.ArrayList;
import java.util.Arrays;
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

public class ExtractNumber {

	public static void main(String[] args) throws InterruptedException{
		// TODO Auto-generated method stub
		
		System.out.println("Extracting numbers challenge");

		System.out.println("Write a script to extract numbers from a String and sort them.");

		String text = "Thi87s text5 h3as s426om5e num7b8e2rs";
		//String text = "This text has some numbers";		//Without numbers
		//String text = "";									//Text empty
		//String text = "8753426782";						//Only numbers. Just sorts
		//String text = "182text";							//numbers at the beginning
		//String text = "text528";							//numbers at the end
		if (text != "") {
			System.out.println (text);
			StringBuilder SBnumbers = new StringBuilder();
			SBnumbers = extractnumbers (text);				//Extracts numbers
			if (SBnumbers.length() != 0) {
				String Snumbers = SBnumbers.toString();
				char[] Anumbers = Snumbers.toCharArray();
				Arrays.sort(Anumbers);							//Orders numbers
				System.out.println (SBnumbers);
				System.out.println (Anumbers);
			}
			else System.out.println ("There is no number in the text");
		}
		else System.out.println ("Text is empty");
	
}
	public static StringBuilder extractnumbers(String text){

	 	StringBuilder SBnumbers = new StringBuilder();

		char[] Atext = text.toCharArray();
		for (int i=0;i<Atext.length;i++) if (Character.isDigit(Atext[i]))	SBnumbers.append(Atext[i]);
		
		return SBnumbers; 
	}
	
	/*A different why to do it (I think better)
	public static void main(String[] args) throws InterruptedException{
	
		String text = "Th52is77 3is t652he t4ext";
		//String text = "";
		//String text = "6357";
		//String text = "354iksurhg";
		//String text = "lkduhfg4547";
		//String text = "$%^^£$&";
		//String text = "lksdjfgh";

		//Initial validations
		if (text.isBlank()){
			System.out.println ("Text is blank or empty");
		}else{
			char[] result = extnum (text);
			if (result.length!=0) {
				System.out.println(result);
			}else{
				System.out.println("There is no number in the text");
			}
		}
}	
		public static char[] extnum (String text){

			String Snumber = text.replaceAll("[^0-9]","");
			char [] result = Snumber.toCharArray();
			Arrays.sort(result);
			return result;

	 */

}

