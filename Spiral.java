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

public class Spiral {
	
	public static void main(String[] args) throws InterruptedException{
		// TODO Auto-generated method stub
		
		System.out.println("Matrix in Spiral challenge");

		System.out.println("Write code to print a 2×2 matrix in the spiral format");
/*
   Input:  1    2   3   4
           5    6   7   8
           9   10  11  12
          13   14  15  16
          
   Output: 1 2 3 4 8 12 16 15 14 13 9 5 6 7 11 10 

   Explanation: The output is matrix in spiral format. 
 */
		
		int r = 25;		//columns
		int c = 15;		//rows
		
		if (r!=0 && c!=0) {

			List<Integer> listoutput = spiral(r,c);
			System.out.println(listoutput); 
	
		}else {
			System.out.println("Empty matrix"); 
		}
	}
	
	public static List<Integer> spiral (int r, int c) {
		
		//creating the matrix
		int [][] input = new int [r][c];
		int num = 1;
		List<Integer> listinput = new ArrayList<Integer>(); 
		//filling the matrix
		for (int j = 0; j<r ;j++){
			for (int i = 0; i<c ;i++){
				input [j][i] = num;
				listinput.add(num);
				num++;
			}
		}
		System.out.println(listinput);  //to see the input matrix
		
		List<Integer> listoutput = new ArrayList<Integer>(); 
		//We will need to control the direction of the traversing of the matrix
		// 1: traversing right (second dimension increasing)
		// 2: traversing down (first dimension increasing)
		// 3: traversing left (second dimension decreasing)
		// 4: traversing up (first dimension decreasing)
		int direc = 1; //starts going right

		//In each traversing, number of cells decreased:
		//first traversing = c  we will traverse right all the columns
		//second traversing = r-1 we will traverse down all the rows less the one we traversed in the previous step
		//third traversing = c-1 we will traverse left all the columns less the one we traversed in the previous step
		//fourth traversing = r-2 we will traverse up all the columns less the one we traversed in the previous steps
		//successively until c-n and c-n value  = 0 
		//To keep this in control we need:
		int remco = c;		//remaining columns
		int remro = r;		//remaining rows

		//Starting in [0][0]
		int rco = 0;	//row coordinate. Element we are traversing and printing  
		int cco = 0;	//column coordinate
		
		while (remco>0 && remro>0){

			if ((direc == 1) && (remro>0)){	
				for (int i=0; i < remco; i++){			//traversing right
					//System.out.println(input[rco][cco]);
					listoutput.add(input[rco][cco]);
					cco++;
				}
				cco--;					//last cco++ would overflow matrix
				rco++;					//next row
				remro--;				//we have traversed a row, we decreased in one

			}
			if ((direc == 2) && (remco>0)){
				for (int i=0; i < remro;i++){			//traversing down
					//System.out.println(input[rco][cco]);
					listoutput.add(input[rco][cco]);
					rco++;
				}
				rco--;
				cco--;					//next column (will be left direction)
				remco--;				//we have traversed a column, we decreased in one

			}
			if ((direc == 3) && (remro>0)){
				for (int i=0; i < remco; i++){		//traversing left
					//System.out.println(input[rco][cco]);
					listoutput.add(input[rco][cco]);
					cco--;
				}
				cco++;
				rco--;
				remro--;				//we have traversed a row, we decreased in one
			}
			if ((direc == 4) && (remco>0)){
				for (int i=0; i < remro; i++){		//traversing up
					//System.out.println(input[rco][cco]);
					listoutput.add(input[rco][cco]);
					rco--;
				}
				rco++;
				cco++;
				remco--;				//we have traversed a column, we decreased in one
			}

			direc++;				//next traverse is in the next direction
			if (direc==5) direc=1; 			// we only have 4 directions
		}
	
		return listoutput;
		
	}

}

