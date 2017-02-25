import java.util.Scanner;

public class P02SequencesOfEqualStrings {
			
	public static void main(String[] args) {

		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);

		String[] strings = scan.nextLine().split(" ");
		
		for (int i = 0; i < strings.length - 1; i++) {
			
			System.out.print(strings[i]);
			
			if (strings[i].equals(strings[i+1])) {
				System.out.print(" ");
			} else {
				System.out.println();
			}
		}
		
		System.out.print(strings[strings.length -1]);

	}
}