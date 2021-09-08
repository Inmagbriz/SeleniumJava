package Exercices;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
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

public class Countduplicated {

	public static void main(String[] args) throws InterruptedException{
		// TODO Auto-generated method stub
		
		System.out.println("Count duplicated challenge");

		System.out.println(" Write code to count the duplicate characters in a given string (just appears twice.");

		//We will count only those that appear twice in the string and they are not spaces
		
		//Test cases
		//String text = "aa b Cc dd";    //result 3
		String text = "aaabb";
		//String text = "aa";				//result 1
		//Boundary text: duplicate characters at the beginning and at the end of text
		//String text = "ThIs is a nOrmal teXt to test our program 55";    //result 4
		//String text = "11 2 333";	//result 1
		//String text = "       ";	//result text empty
		//String text = "";		//result text empty
		//String text = "[{}}[[";	//result 1

		//Clean and remove spaces in text. All in lower case
		String clean = text.replaceAll("\\s", "").toLowerCase();

		if (clean == "") System.out.println ("Text empty"); 
		else{
			int result = countrep (clean);
			System.out.println (result);
		}
	}
	
	
	public static int countrep (String clean){

		char [] atext = clean.toCharArray();
		Arrays.sort(atext);
		char antch = '\0';
		int countrep = 0;
		int cont = 0;
		for (int i=0; i<atext.length;i++) {
			//if the char is the same that late char, we keep counting
			if (atext[i]==antch) {
				cont ++;
			}
			else{
			//otherwise, we count it if it was twice.
			//As we add1 to count every time is repeated, when count is 1 it has appeared twice
				if (cont == 1) countrep ++;
				cont = 0;
			}
		antch = atext[i];
		//Last element validation just in case the last char was duplicated
		if (i==atext.length-1 && cont == 1) countrep ++;
		}
		return countrep;
	}
	
	
}

