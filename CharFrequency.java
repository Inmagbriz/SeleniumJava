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

public class CharFrequency {

	public static void main(String[] args) throws InterruptedException{
		// TODO Auto-generated method stub
		
		System.out.println("Frequency of characters challenge");

		System.out.println("Calculate the frequency of characters in a string. Print each char with its frequency.");
		System.out.println(" For input <abcabc>, output should be <(a,2),(b,2),(c,2)>");
		
		//String text = "aAb aB cd";    //result <(a,3),(b,2),(c,1),(d,1),>
		//String text = "    ";
		//String text = "abcabc";
		String text = "aA b Ccabc 5";
		if (text.isBlank()) { 
			System.out.println ("Text empty or only has blanks");
		}else{
			List<String> result = new ArrayList<String>();
			result = calfre (text);
			System.out.println (result);
		}
	
	}
	
	
	public static List<String>  calfre (String text) {
		
		String clear = text.replaceAll("\\s+","").toLowerCase();
		char[] atext = clear.toCharArray();
		Arrays.sort(atext);
//		String textorde = new String(atext);
//		System.out.println (textorde); 
		String[][] tempresult = new String[1][2];

		List<String> result= new ArrayList<String>();
		char latchar = atext[0];
		int frch = 1;

		for (int i=1;i<atext.length;i++){ 
			if(atext[i]==latchar){
				frch++;			
			}else{
				tempresult [0][0] = Character.toString(latchar);
				tempresult [0][1] = Integer.toString(frch);
				result.add(Arrays.deepToString(tempresult));
				frch = 1;
			}
			latchar = atext[i];
			//The last one has to be dealt with at the end
			if (i==atext.length-1) {
				tempresult [0][0] = Character.toString(latchar);
				tempresult [0][1] = Integer.toString(frch);
				result.add(Arrays.deepToString(tempresult));				
			}
		}
		return result;
	}	
}

/*

ArrayList<char[][]> result = new ArrayList<char[][]>();
char[][] tempresult = new char[1][1];
String text = "aAb aB cd";    //result <(a,3),(b,2),(c,2)>

String clear = text.replaceAll("\\s","").toLowerCase();

result = countfrch (clear);
System.out.println (result);	


}

public static ArrayList<char[][]> countfrch (String text){

char[] atext = text.toCharArray();
Arrays.sort(atext);

ArrayList<char[][]> result = new ArrayList<char[][]>();

int contlet = 0;
int contfre = 0;

char antch = '\0';
char[][] tempresult = new char[1][2];
tempresult[0][0] = '\0';
tempresult[0][1] = '0';

for (int i = 0 ; i<atext.length;i++){

	if (atext[0] == antch) {
		contfre ++;
	}
	else if (contfre !=0){
		tempresult[0][0] = atext[i];
		tempresult[0][1] = (char)contfre;
		System.out.println(tempresult[0][1]);
		contfre = 0;
		result.add(tempresult);
	}
	antch = atext[i];
	//Last character
	if (i == atext.length-1 && contfre!=0) {
		tempresult[0][0] = atext[i];
		tempresult[0][1] = (char)contfre;
		contfre = 0;
		result.add(tempresult);
	}

}

return result;

}



}

*/