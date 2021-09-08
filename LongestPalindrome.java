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

public class LongestPalindrome {

	public static void main(String[] args) throws InterruptedException{
		// TODO Auto-generated method stub
		
		System.out.println("Longest palindrome challenge");

		System.out.println("Given a string, find the longest substring which is palindrome");
		//ESTA MAL, SOLO FUNCIONA PARA PALINDROMES CON NUMERO DE LETRAS IMPAR 
/*		
		Input: Given string :"forgeeksskeegfor", 
		Output: "geeksskeeg"
*/
		//String text = "Where is the madam";
		//String text = "";
		//String text = ".asljk";
		//String text = "maam hio";
		String text = "dabale arroz a la zorra el abad madam dad anna";

		if (text.length()!=0) {
			String longpal = longestpalin (text);
			if (longpal.length()!=0) {
				System.out.println (longpal);
			}else {
				System.out.println ("There is no palindrome in the text");
			}
		}else {
			System.out.println ("Empty text");
		}
		
				
	}

	public static String longestpalin (String text){

		String clear = text.replaceAll("\\s+", "").toLowerCase();
		int maxlen = 1;
		int maxpos = 0;
		for (int i = 0; i<clear.length(); i++){
			//char current = clear.charAt(i);
			int n = 1;
			int pos = 0;	//by defect the first letter will be the longest palindrome (length 1)
			int len = 1;
			//for every char we compare left and right ((clear.charAt(i-n) == clear.charAt(i+n) )
			//taking care of not having overflow ((i-n)>=0 && (i+n)<=clear.length()-1)
		 	while (((i-n)>=0 && (i+n)<=clear.length()-1) && (clear.charAt(i-n) == clear.charAt(i+n))){
				//char previous = clear.charAt(i-n);
				//char posterior = clear.charAt(i+n);
				pos = i-n;
				len = 2*n+1;   //(i+n)-(i-n)+1=2n+1
				if (maxlen < len){
					maxlen = len;
					maxpos = pos;
				}	
			n++;
			}
		}
		return clear.substring(maxpos, maxpos+maxlen);
		}


}

