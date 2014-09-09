import java.util.Scanner;

public class P01RectangleArea {
	public static void main(String[] args) {
		
		int a = 0, b = 0, area = 0;
		Scanner scan = new Scanner(System.in);
		try {
			
		} catch (NumberFormatException nfex) {
			System.err.println("Fail to scan number " + nfex);
		}
		a = scan.nextInt();
		b = scan.nextInt();	
		scan.close();
		area = a * b;
		System.out.println(area);
	}
}
