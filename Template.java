package Exercices;

import java.util.Arrays;

public class Template {
	
	public static void main(String[] args) throws InterruptedException{
	
		String text="WweE havee tOo remoove repeaated chaaraccterRSs"; //output: we havtormpdcs
		//String text = "repeated separated";			//output: repatd s
		//String text ="";				//empty
		//String text ="   ";				//blank
		//String text ="weryt";				//any repeated
		//String text = "6543654";			//numbers output: 6543
		//String text = "$%^*%&*";			//strange chars


		if(text.isBlank() || text.isEmpty()) System.out.println ("Text empty or blank");
		else{
			StringBuilder cleantext = remdup(text);
			System.out.println (cleantext);
		}
	}
	public static StringBuilder remdup(String text){
		
		StringBuilder cleantext = new StringBuilder();
		text = text.toLowerCase();
		for (int i=0; i<text.length();i++){
			boolean rep = false;
			for (int j=0; j<cleantext.length();j++){
			if (text.charAt(i)==cleantext.charAt(j)) {
					rep = true;
					break;
				}
			}
			if (!rep) cleantext.append(text.charAt(i));
		}
		return cleantext;
	}
	
}