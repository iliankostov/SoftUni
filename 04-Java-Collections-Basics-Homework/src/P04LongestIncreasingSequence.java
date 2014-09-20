import java.util.Scanner;

public class P04LongestIncreasingSequence {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		String input = scan.nextLine();
		String[] arrayStr = input.split(" ");
		
		int[] numbers = new int[arrayStr.length];
		int counter = 1;
		int maxCounter = 1;
		int positionOfInt = 0;

		for (int i = 0; i < arrayStr.length; i++) {
			numbers[i] = Integer.parseInt(arrayStr[i]);
		}

		System.out.print(numbers[0]);
		for (int i = 1; i < numbers.length; i++) {
			
			if (numbers[i] > numbers[i - 1]) {
				System.out.print(" " + numbers[i]);
				counter++;
			} else {
				counter = 1;
				System.out.println();
				System.out.print(numbers[i]);
			}
			
			if (maxCounter < counter) {
				maxCounter = counter;
				positionOfInt = i;
			}
		}

		System.out.println();
		System.out.print("Longest: ");
		
		for (int i = 0; i < maxCounter - 1; i++) {
			System.out.print(numbers[positionOfInt - maxCounter + 1 + i] + " ");
		}
		System.out.print(numbers[positionOfInt]);

	}

}
