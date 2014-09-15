import java.util.Scanner;


public class P06FormattingNumbers {
	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		int aNumber = 0;
		float bNumber = 0.0f, cNumber = 0.0f;
		try {
			aNumber = scan.nextInt();
			bNumber = scan.nextFloat();
			cNumber = scan.nextFloat();
		} catch (NumberFormatException nfex) {
			System.err.println("Fail to scan numbers" + nfex);
		}
		String hex = Integer.toHexString(aNumber);
		String bin = Integer.toBinaryString(aNumber);
		
		System.out.printf("|%-10S|%s|%10.2f|%-10.3f|", hex,
				String.format("%10s", bin).replace(" ", "0"), bNumber, cNumber);			
		
	}
}
