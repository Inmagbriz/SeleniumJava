package Exercices;

import java.util.Arrays;
import java.util.Collections;
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

public class MergeLists {

	public static void main(String[] args) throws InterruptedException{
		// TODO Auto-generated method stub
		
		System.out.println("Merging lists challenge");
		System.out.println("Given are two ordered lists of size 7 and 3. The first list has three vacant spots in the end. ");
		System.out.println("Merge them in a sorted manner with minimum no. of steps");
		
		int i;
		List<Character> list7 = new ArrayList<Character>(7);  //sets the size but you can't set an element until it is added
		List<Character> list3 = new ArrayList<Character>(3);
		
		for (i=0; i<=3; i++)	list7.add('b');
		for (i=0; i<=2; i++)	list3.add('a');
		
		for (i=0;i<list3.size();i++) list7.add(list3.set(i, 'y'));
		Collections.sort(list7);
			
		System.out.println (list7);
		System.out.println (list3);
	}

	
}

