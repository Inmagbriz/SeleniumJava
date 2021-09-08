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

public class Queues {

	public static void main(String[] args) throws InterruptedException{
		// TODO Auto-generated method stub
		
	System.out.println("Using Queues");
		
	PriorityQueue <Character> queue = new PriorityQueue <Character>();
/*	
	queue.add('z');							//adds an element
	queue.offer('v');							//same for offer
	queue.add('a');
	System.out.println (queue);
	System.out.println (queue.add('f'));	//add/ offer return true when succeed
	System.out.println (queue.offer('g'));
	
	queue.remove('v');
	System.out.println (queue);
	
	queue.poll();							//retrieves and removes the element
	System.out.println (queue);
	
	System.out.println (queue.element());	//retrieves, but does not remove, the head of this queue.
	System.out.println (queue.peek());  	//retrieves, but does not remove, the head of this queue. Returns null if this queue is empty
*/	
	
	queue.add('z');							//pushes an element 
	queue.add('v');
	queue.add('a');
	System.out.println (queue.peek()); 
	System.out.println (queue);
	System.out.println (queue.poll());
	System.out.println (queue);

	
	
	

	
	
	}

	
}

