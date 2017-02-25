import java.util.Arrays;
import java.util.Scanner;

public class P01SortArrayOfNumbers {

	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		
		int n =Integer.parseInt(scan.nextLine());
		String sLine = scan.nextLine();
		
		String[] strings = sLine.split(" ");
		int[] numbers = new int[n];
		
		for (int i = 0; i < n; i++) {
			
			numbers[i] = Integer.parseInt(strings[i]);  
			
		}
		
		Arrays.sort(numbers);
		
		for (int number: numbers) {
			System.out.print(number + " ");
		}
		
	}

}