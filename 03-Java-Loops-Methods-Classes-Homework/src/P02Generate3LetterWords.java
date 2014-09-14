import java.util.Scanner;

public class P02Generate3LetterWords {
	public static void main(String[] args) {
		
		Scanner scanner = new Scanner(System.in);
		char[] letters = scanner.next().toCharArray();
		scanner.close();
		
		for (int i = 0; i < letters.length; i++) {
			for (int j = 0; j < letters.length; j++) {
				for (int j2 = 0; j2 < letters.length; j2++) {
					System.out.printf("%s%s%s ", letters[i], letters[j], letters[j2]);
				}
			}
		}
		
	}
}
