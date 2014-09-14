import java.util.Scanner;

public class P01SymmetricNumbersInRange {

	public static void main(String[] args) {
		
		Scanner scanner = new Scanner(System.in);
		int startRange = 0;
		int endRange = 0;
		try {
			startRange = scanner.nextInt();
			endRange = scanner.nextInt();
		} catch (NumberFormatException nfex) {
			System.err.println("Invalid input " + nfex);
		}				
		scanner.close();
					
		String output = "";
		for (int i = startRange; i <= endRange; i++) {
			if (i < 10) {				
				output += Integer.toString(i);
				output += " ";
			}
			else if (i > 10 && i < 100 && i % 11 == 0) {				
				output += Integer.toString(i);
				output += " ";
			}
			else if (i > 100 && i <= 999) {
				int firstDigit = i / 100 % 100;
				int lastDigit = i % 10;
				if (firstDigit == lastDigit) {
					output += Integer.toString(i);
					output += " ";
				}
			}
		}
		System.out.println(output);
	}

}
