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

public class Anagram {

	public static void main(String[] args) throws InterruptedException{
		// TODO Auto-generated method stub
		
		System.out.println("Anagram challenge");

		try {

			System.out.println("Write an algorithm that find a word’s anagrams");
			System.out.println("The algorithm will tell you that the word car can be rearranged as arc and the word iceman as cinema");

			
			String text1 = "Mother in law";
			//String text1 = "";			//empty text
			String text2 = "Hitler woman";
			if (text1 != "" && text2!= "") {
				boolean isAn;
				isAn = isAnagram(text1, text2);
				System.out.println (isAn);
			}
			else System.out.println ("One or both texts are empty");
		}
					
		catch (Exception e){
			System.out.println("Error");
		}

		System.out.println("Execution complete");
	
	
	}

/*	
	public static boolean isAnagram(String text1, String text2) {
		String clean1 = text1.replaceAll("\\s+", "").toLowerCase();
		String clean2 = text2.replaceAll("\\s+", "").toLowerCase();
	
		if (clean1.length() != clean2.length()){
			return false;
		}else {
			char[] Aclean1 = clean1.toCharArray();
			char[] Aclean2 = clean2.toCharArray();
			Arrays.sort(Aclean1);
			Arrays.sort(Aclean2);
			for (int i=0; i<clean1.length()-1; i++) {
				if (Aclean1[i]!= Aclean2[i]) return false;
			}
		}
		return true;
	}
*/	

	public static boolean isAnagram(String text1, String text2) {
		String clean1 = text1.replaceAll("\\s+", "").toLowerCase();
		String clean2 = text2.replaceAll("\\s+", "").toLowerCase();
	
		if (clean1.length() != clean2.length())return false;
		char[] Aclean1 = clean1.toCharArray();
		char[] Aclean2 = clean2.toCharArray();
		Arrays.sort(Aclean1);
		Arrays.sort(Aclean2);
		return Arrays.equals(Aclean1, Aclean2);
	}
}
