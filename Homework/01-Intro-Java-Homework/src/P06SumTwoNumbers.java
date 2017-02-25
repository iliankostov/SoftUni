
import java.util.Scanner;

public class P06SumTwoNumbers {

	public static void main(String[] args) {
		
		Scanner scanner = new Scanner(System.in);
		int one, two, sum;
		System.out.print("Enter number one: ");
		one = scanner.nextInt();
		scanner.nextLine();
		System.out.print("Enter number two: ");
		two = scanner.nextInt();
		scanner.close();
		sum = one + two;
		System.out.println("Sum = " + sum);
		
	}
	
}
