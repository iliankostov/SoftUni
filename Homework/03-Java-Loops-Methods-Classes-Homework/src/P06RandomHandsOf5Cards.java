import java.util.ArrayList;
import java.util.Random;
import java.util.Scanner;

public class P06RandomHandsOf5Cards {

	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner scanner = new Scanner(System.in);
		System.out.println("Enter a number 'n': ");
		int numberOfHands = scanner.nextInt();
		Random rnd = new Random();
		
		char[] suits = {'\u2666','\u2663', '\u2665','\u2660' };
		String[] cards = {"2", "3","4", "5", "6", "7", "8" ,"9", "10","J", "Q", "K","A"};
		ArrayList<String> fullDeck = new ArrayList<String>();
		for (String card : cards) {
			for (Character suit : suits) {
				fullDeck.add("" + card + (char)suit);
			}
		}
		
		ArrayList<String> pulledCards = new ArrayList<>();
		for (int i = 0; i < numberOfHands; i++) {
			for (int j = 0; j < 5; j++) {
				int index = rnd.nextInt(fullDeck.size());
		        String card = fullDeck.get(index);		        
		        fullDeck.remove(index);
		        pulledCards.add(card);
			    System.out.printf("%s ",card);   			
			}	
			System.out.println();
			fullDeck.addAll(pulledCards);
		}
	}

	
	
}
