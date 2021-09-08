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

public class sumdigits {

	public static void main(String[] args) throws InterruptedException{
		// TODO Auto-generated method stub
		
	System.out.println("find the sum of digits in a number");
		
	int number = 2222;
	int sum = SumDigits(number);
	System.out.println(sum);

	
	}

	public static int SumDigits(int number){

		String Snumber = String.valueOf(number);
		char[] Anumber = Snumber.toCharArray();

		int sum = 0;
		for (char c : Anumber){
			sum = sum + Character.getNumericValue(c);
		}
		return sum;

	}
	
}

