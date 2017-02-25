import java.util.Scanner;

public class P01CountBeers {

	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		
		Integer totalBeers = 0;
		while (true) {
			String input = scan.nextLine();
			if (input.equals("End")) {
				break;
			}
			String[] inputArray = input.split(" ");
			Integer number = Integer.parseInt(inputArray[0]);
			if (inputArray[1].equals("stacks")) {
				totalBeers +=  number * 20;
			}			
			else {
				totalBeers += number;
			}
		}
		System.out.printf("%d stacks + %d beers", totalBeers / 20, totalBeers % 20);

	}

}
