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

public class ReverseArray {

	public static void main(String[] args) throws InterruptedException{
		// TODO Auto-generated method stub
		
		System.out.println("Reverse Array challenge");

		System.out.println("How to reverse an array in the subset of N?");
		System.out.println("e.g. Input: [1,3,5,7,9,11,15,17,19], Output: [5,3,1,11,9,7,19,17,15]");
/*		
		int [] AInic = {1,2,3,4,5,6,7,8,9};
		//int [] AInic = {};
		int subN = 3;
		//int subN = 0;
		//int subN = 1;
		//int subN = 5;
		if (AInic.length==0) System.out.println("Array to order empty");
		else if (subN<=0) System.out.println("Error in the size of subarrays. Ist has to be >=0 ");
		else if (subN==1) System.out.println("Array won't change, subarrays' size = 1");
		else {
			if (AInic.length%subN !=0) System.out.println("Main array size no multiple of subarray. Last subarray won't be the same size");
			List<Integer> LFin = ReverseArray(subN,AInic);
			System.out.println (LFin);
		}
*/
		//We will use lists as they are easy to order, join and present

		//We will use lists as they are easy to order, join and present

		int[] ainic= {1,2,3,4,5,6,7,8,9};
		int subar = 3;
		//VALIDATIONS
		if (ainic.length == 0) System.out.println("Inicial Array empty");
		else if (subar == 0) System.out.println("Subarray empty or size 0 not allowed");
		else if (subar == 1) System.out.println("Subarray size 1 won't change the array");
		else if (subar >= ainic.length) System.out.println("Subarray size >= initial array not allowed");
		else{
			if (ainic.length % subar !=0 ) System.out.println("Last array will have different size");
			List<Integer> lfin = new ArrayList<Integer>();
			lfin = order (ainic, subar);
			System.out.println (lfin);
		}
		
	}

	public static List<Integer> order (int[] ainic, int subar){

		List<Integer> lfin = new ArrayList<Integer>();
		List<Integer> lsubar = new ArrayList<Integer>();
		int i=0;	

		while (i<ainic.length) {
			//controlling case array size is not multiple of subarray size
			if ((i+subar)>= ainic.length) subar = ainic.length - i;
			for (int j=1; j<=subar;j++){
				lsubar.add(ainic[i]);
				i++;
			}
			Collections.reverse(lsubar);
			lfin.addAll(lsubar);
			lsubar.clear();
		}
		return lfin;
	}


	
	/*
	public static List<Integer> ReverseArray (int subN, int [] AInic){
			List<Integer> order = new ArrayList <Integer>();
			List<Integer> LFin = new ArrayList <Integer>();
			System.out.println(AInic.length);
			int i = 0;
			while  (i < AInic.length) {
				if ((i+subN)> AInic.length) subN = AInic.length-i;
				for (int j=1; j<=subN; j++){	
					order.add(AInic[i]);
					i++;			
				}
				Collections.reverse(order); 
				LFin.addAll(order); 
				order.clear();
			}
			return LFin;
		} 
*/		

}

