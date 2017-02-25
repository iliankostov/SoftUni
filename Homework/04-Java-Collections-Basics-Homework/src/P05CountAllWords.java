import java.util.Scanner;

public class P05CountAllWords {

	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		String input = scan.nextLine();
		String[] words = input.split("\\W+");
		System.out.println(words.length);

	}

}
