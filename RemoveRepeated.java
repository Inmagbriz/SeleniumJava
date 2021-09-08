package Exercices;

import java.util.Arrays;
import java.util.Collections;
import java.util.ArrayList;
import java.util.List;
import java.util.Stack;
import java.util.PriorityQueue;
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

public class RemoveRepeated {

	public static void main(String[] args) throws InterruptedException{
		// TODO Auto-generated method stub
		
	System.out.println("Given a string, can you remove all duplicate characters in the string.");
		
	String text="WweE havee tOo remoove repeaated chaaraccterRSs";
	//String text="";
	
	if (text!=""){
		StringBuilder fintext = new StringBuilder();
	
		String clean = text.toLowerCase();
		char[] Atext = clean.toCharArray();
	
		char antchar = '\0';
		
		for (char c: Atext){
			if (c != antchar) fintext.append(c);
			antchar = c;
		}
		System.out.println (fintext);
	}
	else System.out.println ("Text empty"); 
	}
/*
	//Actually, the solution must remove repeated character even separated:
			String text="WweE havee tOo remoove repeaated chaaraccterRSs"; //output: we havtormpdcs
		//String text = "repeated separated";			//output: repatd s
		//String text ="";				//empty
		//String text ="   ";				//blank
		//String text ="weryt";				//any repeated
		//String text = "6543654";			//numbers output: 6543
		//String text = "$%^*%&*";			//strange chars


		if(text.isBlank() || text.isEmpty()) System.out.println ("Text empty or blank");
		else{
			StringBuilder cleantext = remdup(text);
			System.out.println (cleantext);
		}
	}
	public static StringBuilder remdup(String text){
		
		StringBuilder cleantext = new StringBuilder();
		text = text.toLowerCase();
		for (int i=0; i<text.length();i++){
			boolean rep = false;
			for (int j=0; j<cleantext.length();j++){
			if (text.charAt(i)==cleantext.charAt(j)) {
					rep = true;
					break;
				}
			}
			if (!rep) cleantext.append(text.charAt(i));
		}
		return cleantext;
	}
*/
	
	
	

	
}

