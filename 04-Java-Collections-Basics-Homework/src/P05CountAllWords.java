import java.util.Scanner;


public class P05CountAllWords {

	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner in = new Scanner(System.in);
		String input = in.nextLine();
		String[] words = input.split("\\W+");
		System.out.println(words.length);

	}

}
