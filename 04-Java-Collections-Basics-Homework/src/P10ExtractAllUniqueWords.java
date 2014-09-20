import java.util.Scanner;
import java.util.TreeSet;

public class P10ExtractAllUniqueWords {

	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);				
		String[] words = scan.nextLine().toLowerCase().split("\\W+");
		TreeSet<String> orederedWords = new TreeSet<>();

		for (int i = 0; i < words.length; i++) {
			orederedWords.add(words[i]);
		}
		
		for (String word : orederedWords) {
			System.out.print(word + " ");
		}	

	}

}
