import java.util.Scanner;

public class P06CountSpecifiedWord {

	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		String[] input = scan.nextLine().toLowerCase().split("\\W+");
		String isEqual = scan.nextLine().toLowerCase();
		int counter = 0;
		
		for (int i = 0; i < input.length - 1; i++) {
			if (input[i].equals(isEqual)) {
				counter++;
			}
		}
		System.out.println(counter);	
		
	}

}
