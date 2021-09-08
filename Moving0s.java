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

public class Moving0s {

	public static void main(String[] args) throws InterruptedException{
		// TODO Auto-generated method stub
		
		System.out.println("Moving 0s challenge");
		
		try {
			int[] AInumber = {1,2,5,0,4,0,2,6,0};
			int dimarray = AInumber.length;
			int[] AFnumber = new int[dimarray];
	
			AFnumber = mov0 (AInumber);
			for (int i=0; i<dimarray; i++) System.out.println (AFnumber[i]);
		
		}
					
		catch (Exception e){
			System.out.println("Error");
		}

		System.out.println("Execution complete");
	
	
	}
		
		public static int[] mov0 (int[] AInumber){

			int cont0 = 0;
			int j = 0;
			int i; 
			int dimarray = AInumber.length;
			int[] AFnumber = new int[dimarray];
			dimarray = AInumber.length;
			for (i=0; i< dimarray ;i++) {
				if (AInumber[i] == 0) cont0++;
				else {
				
					AFnumber[j] = AInumber[i];
					j++;
				}
			}

			if (cont0 != 0) {
				for (i=0;i<cont0; i++){
					AFnumber[j] = 0;
					j++;
				}	
			
			}
			return AFnumber;
		}

}

