import java.util.Scanner;

public class P04TheSmallestOfThreeNumbers {
	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		float aNumber = 0 ,bNumber = 0 ,cNumber = 0;
		try {
			aNumber = scan.nextFloat();
			bNumber = scan.nextFloat();
			cNumber = scan.nextFloat();
		} catch (NumberFormatException nfex) {
			System.err.println("Fail to scan number" + nfex);
		}		
		if (aNumber <= bNumber && aNumber <= cNumber) {
			System.out.println(aNumber);
		}
		else if (bNumber <= aNumber && bNumber <= cNumber) {
			System.out.println(bNumber);
		}
		else {
			System.out.println(cNumber);
		}
	}
}
