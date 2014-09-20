import java.util.Scanner;

public class P07CountSubstringOccurrences {

	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);		
		String text = scan.nextLine().toLowerCase();
		String word = scan.nextLine().toLowerCase();
		int counter = 0;
		
		for (int i = 0; i <= text.length() - word.length(); i++) {
			
			if (text.substring(i, word.length() + i).contains(word)) {
				counter++;
			}
		}
		
		System.out.println(counter);

	}

}
