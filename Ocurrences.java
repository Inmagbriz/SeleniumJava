package Exercices;

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

public class Ocurrences {

	public static void main(String[] args) throws InterruptedException{
		// TODO Auto-generated method stub
		
		System.out.println("Ocurrences challenge");

		try {

			System.out.println("Write a script to count the number of occurrences of the given element in an array.");
			System.out.println("For example, find 'i' in a text.");
			
			char tofind = 'i';
			//char tofind = '\0';		//empty char
			String text = "This Is thE text to work With";
			//String text = "";

			if (tofind== '\0') System.out.println("We need a character to look for");
			else if (text=="") System.out.println("The text is empty");
			else {
				int numocur = num_ocur(text, tofind);
				System.out.println(numocur);
			}	
		}
					
		catch (Exception e){
			System.out.println("Error");
		}

		System.out.println("Execution complete");
	
	
	}
	public static int num_ocur (String text, char tofind){

		int numocur = 0;
		//optional
		String textLC = text.toLowerCase();
		//If applying toLowerCase to the text, we have to apply it to the character
		tofind = Character.toLowerCase(tofind);
		char[] Atext = textLC.toCharArray();
		//for (int i=0; i<= Atext.length-1; i++){
		//	if (Atext[i] == tofind) numocur++;
		//}
		for (char c : Atext ) {
			if (c == tofind) numocur++;
		}
		return numocur;
	}

}

