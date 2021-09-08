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

public class ElementPositions {

	public static void main(String[] args) throws InterruptedException{
		// TODO Auto-generated method stub
		
		System.out.println("Element Positions challenge");

		System.out.println("Given a sorted array with possibly duplicate elements, "
				+ "the task is to find indexes of first and last occurrences of an element x in the given array.");
/*
	Input : arr[] = {1, 3, 5, 5, 5, 5, 67, 123, 125}    
        x = 5
	Output : First Occurrence = 2
    Last Occurrence = 5	
		
		//The EASIER way is to covert array to list and use indexOf and lastIndexOf
		int [] arr = {1, 3, 5, 5, 5, 5, 67, 123, 125}  ;
		int x = 5;

		List<Integer> list = new ArrayList<Integer>();
		for (int n:arr) {
			list.add(n);
		}
		int first = list.indexOf(x);
		int last = list.lastIndexOf(x);

		System.out.println ("First position: " + first);
		System.out.println ("Last position: " + last);
*/
		int [] inputarray = {1, 3, 5, 5, 5, 5, 67, 123, 125};
		int x = 5;							//x in the middle
		//int [] inputarray = {};			//arr{} is empty
		//int x = 8;						//x is not in the array
		//int x = 1;						//x at the beginning and only 1 occurrence
		//int x = 125;						//x at the end and only 1 occurrence
		//int [] arr = {1, 1, 1, 3, 5, 5, 5, 5, 67, 123, 125, 125}  ;
		//int x = 1;						//x at the beginning and more than 1 occurrence
		//int x = 125;						//x at the end and more than 1 occurrence
	
		//Array is empty
		if (inputarray.length != 0) {
			detpos(inputarray, x);
		}else {
			System.out.println ("Array empty");
		}
		
	}
	
	public static void detpos (int[] arr, int x){

		int first = -1;
		int last = -1;
		for (int i = 0; i<arr.length; i++){
			if (arr[i]==x){
				if (first == -1) {
					first = i;
				}
			last = i;
			}			
		}
		if (first != -1){
			System.out.println ("First position (starting with 0): " + (first));
			System.out.println ("Last position: " + (last));
		} else {
			System.out.println ("Element not found");
		}
	}
	
}

