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

public class NonRepeated {
	
	public static void main(String[] args) throws InterruptedException{
		// TODO Auto-generated method stub
		
		System.out.println("First non Repeated challenge");

		System.out.println("Write a program to print the first non-repeated char "
				+ "in a string. e.g. A string “Is it your first company” returns ‘u’.");

		String input = "Is it your first company";
		//String input = "";				//Text empty
		//String input = "aabbcc";			//any non-repeated
		//String input = "aalgsekrgh";		//at the beginning
		//String input = "a;lsdkfrr";		//at the end
		//String input = "£$%^&";
		if (input.length()!=0) {
			char result = norep (input);
			if (result== '\0') {
				System.out.println("There is no non-repeated character");
			} else {
				System.out.println("First non Repeated: " + result);
			}
		}else {
			System.out.println("Text empty");
		}
		
	}
	public static char norep (String input){
		
		char result = '\0';
		//First of all, take away spaces that likely will be repeated
		//and lowercase if the char 'a' is considered the same as 'A'
		String clear = input.replaceAll("\\s+","").toLowerCase();
		for (int i = 0; i<clear.length() ; i++){
			boolean unique  = true;
			//for each character, we search again in the string, but just from the position we are in
			for (int j = 0; j<clear.length() ; j++){
				//char iii = clear.charAt(i);
				//char jjj = clear.charAt(j);
				if (i!=j && clear.charAt(i) == clear.charAt(j)){
					unique = false;
					break;
				}
			}
			if (unique) {
				return clear.charAt(i);
			}
		}
		return result;
	}	


}

