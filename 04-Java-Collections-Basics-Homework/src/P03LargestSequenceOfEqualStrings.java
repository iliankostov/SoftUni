import java.util.Scanner;

public class P03LargestSequenceOfEqualStrings {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		String input = scan.nextLine();
		String[] elements = input.split(" ");

		int repeat = 1;
		int counter = 1;
		int positionOfWord = 0;

		for (int i = 1; i < elements.length; i++) {

			if (elements[i].equals(elements[i - 1])) {
				counter++;
			} else {

				counter = 1;
			}

			if (counter > repeat) {
				repeat = counter;
				positionOfWord = i;
			}

		}

		for (int i = 0; i < repeat - 1; i++) {
			System.out.print(elements[positionOfWord] + " ");
		}
		System.out.println(elements[positionOfWord]);

	}

}
