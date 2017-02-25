import java.util.HashSet;
import java.util.Scanner;

public class P01CognateWords {

	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		String input = scan.nextLine();
		String[] words = input.split("[^a-zA-Z]+");
		
		HashSet<String> cognateWords = new HashSet<String>();
		for (int a = 0; a < words.length; a++) {
			for (int b = 0; b < words.length; b++) {
				for (String word : words) {
					if (a != b) {
						boolean check = (words[a] + words[b]).equals(word);
						if (check) {
							cognateWords.add(words[a] + "|" + words[b] + "=" + word);
						}
					}
				}				
			}		
		}
		if (!cognateWords.isEmpty()) {
			for (String cognate : cognateWords) {
				System.out.println(cognate);
			}
					
		}
		else {
			System.out.println("No");
		}
		
	}

}