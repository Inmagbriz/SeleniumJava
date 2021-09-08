package Exercices;

import java.util.Arrays;
import java.util.Collections;
import java.util.ArrayList;
import java.util.List;
import java.util.Stack;
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

public class Stacks {

	public static void main(String[] args) throws InterruptedException{
		// TODO Auto-generated method stub
		
	System.out.println("Using Stacks");
		
	Stack<Character> stk = new Stack<Character>();
/*
	System.out.println (stk.empty());		//method to know if it is empty
	
	stk.push('z');							//pushes an element to the top of the stack
	stk.push('v');
	stk.push('a');
	System.out.println (stk.pop());		//removes an element from the top of the stack and shows it

	System.out.println (stk);				
	
	System.out.println (stk.peek());		// looks at the top element
	
	System.out.println (stk.search('v'));		// searches the specified object and returns the position of the object.
*/
	
	stk.push('z');							//pushes an element to the top of the stack
	stk.push('v');
	stk.push('a');
	System.out.println (stk.peek());
	System.out.println (stk);
	System.out.println (stk.pop());
	System.out.println (stk);
	
	}

	
}

