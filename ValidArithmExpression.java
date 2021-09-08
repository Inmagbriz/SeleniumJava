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

public class ValidArithmExpression {

	public static void main(String[] args) throws InterruptedException{
		// TODO Auto-generated method stub
		
		System.out.println("Validation of Arithmetic Expression challenge");

		System.out.println("How to find if a given arithmetic expression is a valid one?");
		System.out.println("");
		System.out.println("");

/*		
	Arithmetic expression, NOT algebraic, letters are not expected
	Initial validation: text is not empty
	Only with a text we only can validate some things:
	1. Chars in the expression are in the set [0,9] . ( ) / * - +	
	2. Number of ( = Number of ) First can't be ). Last can't be ( 
	3. Regarding parenthesis we allow:
	Left side (		any but .
	 ( Right side	any but . * /
	Left side )		only [0,9]
	) Right side	any but .	
	4. + - * /  never together 
	5. + - * / not at the beginning, not at the end
*/	

		String text = "(4+2)*7";					//Nice case. True
		
//		text = "()(()#)";
		
//		text = "5+5";								//Without parentheses
//		text = "4525";								//only numbers
//		text = "((7+29)*(-7))/(.4+38)-(56*(1+0))";					//Complicated. True
//Mischievous cases:
//		text = "   ";
//		text = "";
//		text = "1(2)3.4/5*6-7+890";					//True. it's ok as we won't validate syntax
//		text = "1(2)3.J/5*6-7+890";					//False. J not allowed
//		text = "((5+3)";							//False. number of ( and ) not the same
//		text = ")5+3)";								//False. First parenthesis can't be )
//		text = "(5+3(";								//False. Last parenthesis can't be (
		//Not allowed pairs
//		text = ".(7+3)";
//		text = "(*7+3)";
//		text = "(/7+3)";
//		text = "(7+3*)";
//		text = "(7+3.)";
//		text = "(7+3/)";
//		text = "(7+3+)";
//		text = "(7+3-)";
		//Two symbols together, some examples
//		text = "..2";
//		text = "5++3";
//		text = "4*-6";
//		text = "1./3";
		
		
		
		if (text.isBlank()){
			System.out.println("Text empty or only blanks");
		}else{
			boolean valid = valexp (text);
			if (valid) {
				System.out.println("Validations ok");
			}else {
				System.out.println("Validations no ok");
			}
			//System.out.println(valid);
		}	
		
	}
	
	public static boolean valexp (String texti){

		String text = texti.replaceAll("\\s+","");		//taking away spaces
		char[] exp = text.toCharArray();
		//valid characters
		String allochar = "0123456789.()/*-+";
		//prohibited pairs 
		String [] notallowcomb = {".(", "(*", "(/","*)", ".)", "/)", "+)", "-)", "..", "./", ".*", ".-", ".+"};
		//Symbols
		String symbols = "+-*/";
	 
		//1. Chars in the expression are in the set [0,9] . ( ) / * - +	-->allowchar
		for (char c: exp){
			if (allochar.contains(Character.toString(c)) == false){
				 System.out.println ("Invalid character: " + c);
				 return false;
			}
		}	
		//2. Number of ( = Number of ) First can't be ). Last can't be ( 
		//Extractions of all parentheses
		String parenth = text.replaceAll("[^(,)]", "");
		//If there are parentheses in the expression
		if (parenth.length() !=0){
			if ((parenth.startsWith(")")) || (parenth.lastIndexOf("(") == (parenth.length() - 1))){
				System.out.println (")at the beginning or (at the end");
				return false;
			}
			if (text.replaceAll("[^(]", "").length() != text.replaceAll("[^)]", "").length()){
				System.out.println ("Number of ( different from number of )");
				return false;
			}
		}
		//3. Regarding parentheses we'll pick every 2 char in the expresion to make validations.
		//4. + - * /  never together 
		for (int i=0;i<exp.length-1;i++){
			//one of the prohibited combination with parentheses
			if (Arrays.asList(notallowcomb).contains(Character.toString(exp[i])+Character.toString(exp[i+1]))) {
				System.out.println ("Incorrect use of parenthesis/symbol " + Character.toString(exp[i])+Character.toString(exp[i+1]));
				return false;
			}
			//two sign together
			if (symbols.contains(Character.toString(exp[i])) && symbols.contains(Character.toString(exp[i+1]))){
				System.out.println ("Symbols together " + Character.toString(exp[i])+Character.toString(exp[i+1]));
				return false;
			}
		}
		//5. + - * / not at the beginning, not at the end
		String first = Character.toString(exp[0]);
		String last = Character.toString(exp[exp.length-1]);
		if (symbols.contains(first) || symbols.contains(last)) {
			System.out.println ("Symbols cannot be at the beginning or at the end");
			return false;
		}
		return true;
	}

	
}

