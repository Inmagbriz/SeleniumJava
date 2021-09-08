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

public class FizzBuzz {

	public static void main(String[] args) throws InterruptedException{
		// TODO Auto-generated method stub
		
		System.out.println("FizzBuzz challenge");

		try {

			System.out.println("You are asked to write a program that prints out numbers from 1 to 100 under the following conditions: ");
			System.out.println("Multiples of three, (3, 6, 9, 12, etc.) must be replaced by the word Fizz in the printout.");
			System.out.println("Multiples of five, (5, 10, 15, 25, etc.) must be replaced by Buzz");
			System.out.println("Multiples of both three and five (15, 30, 45, etc.) must be replaced by FizzBuzz");	
/*			
			int num = 100;
			
			for (int i = 1; i <= num; i++){

			    if (((i % 3) == 0) && ((i % 5) == 0)) // Is it a multiple of 3 & 5?
			        System.out.println("fizzbuzz");
			    else if ((i % 3) == 0) // Is it a multiple of 3?
			        System.out.println("fizz");
			    else if ((i % 5) == 0) // Is it a multiple of 5?
			        System.out.println("buzz");
			    else
			        System.out.println(i); // Not a multiple of 3 or 5
			}			
*/		
			int num = 100;
			for (int i=1; i<=num; i++){
				if ((i%3)==0 && (i%5)==0) System.out.println("FizzBuzz");
				else if ((i%3)==0) System.out.println("Fizz");
				else if ((i%5)==0) System.out.println("Buzz");
				else System.out.println(i);
			}
		
		}

		catch (Exception e){
			System.out.println("Error");
		}

		System.out.println("Execution complete");
	
	
	}
	
}
