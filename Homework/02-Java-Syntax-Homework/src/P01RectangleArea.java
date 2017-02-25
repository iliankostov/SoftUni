import java.util.Scanner;

public class P01RectangleArea {
	public static void main(String[] args) {
		
		int a = 0, b = 0, area = 0;
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		try {
			a = scan.nextInt();
			b = scan.nextInt();
			area = a * b;
			System.out.println(area);
		} catch (NumberFormatException nfex) {
			System.err.println("Fail to scan number " + nfex);
		}							
	}
}
