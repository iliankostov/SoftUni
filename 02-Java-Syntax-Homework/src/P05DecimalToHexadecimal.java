import java.util.Scanner;

public class P05DecimalToHexadecimal {
	public static void main(String[] args) {
	
		Scanner scan = new Scanner(System.in);
		int input = 0;
		try {
			input = scan.nextInt();
		} catch (NumberFormatException nfex) {
			System.err.println("Fail to scan number" + nfex);
		}
		scan.close();
		String output = Integer.toHexString(input);
		System.out.println(output);
		
	}
}
