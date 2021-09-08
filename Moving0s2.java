package Exercices;

import java.util.Arrays;
import java.util.ArrayList;
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

public class Moving0s2 {

	public static void main(String[] args) throws InterruptedException{
		// TODO Auto-generated method stub
		
		System.out.println("Moving 0s challenge. Using Array list");
		
			int[] AInumber = {1,2,5,0,4,0,2,6,0};
			//int[] AInumber = {1,2,5,4,2,6};   //No zeros
			//int[] AInumber = {};				//No numbers
			if (AInumber.length != 0) {
				List <Integer> AFnumber = new ArrayList<Integer>();
		
				AFnumber = mov0 (AInumber);
				System.out.println (AFnumber);
			}
			else System.out.println ("There is no numbers in the list");
	}
		
	public static List <Integer> mov0 (int[] AInumber){

		int cont0 = 0;
		int i; 
		int dimarray = AInumber.length;
		List <Integer> AFnumber = new ArrayList<Integer>();
		//dimarray = AInumber.length;

		for (i=0; i< dimarray ;i++) {
			if (AInumber[i] == 0) cont0++;
			else {
				AFnumber.add(AInumber[i]);
			}
		}
		if (cont0 != 0) {
			for (i=0;i<cont0; i++){
				AFnumber.add(0);
			}	
		}
		else System.out.println ("There is no 0's in the list");    //Just saying
		return AFnumber;
	}
}

