import java.util.Scanner;

public class P02AddingAngles {

	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		Integer num = Integer.parseInt(scan.nextLine());		 
		Integer[] degrees = new Integer[num];
		for (int i = 0; i < degrees.length; i++) {
			degrees[i] = scan.nextInt();			
		}
		
		boolean isFound = false;
		for (int a = 0; a < degrees.length; a++) {
			for (int b = a + 1; b < degrees.length; b++) {
				for (int c = b + 1; c < degrees.length; c++) {
					Integer angleA = degrees[a];
					Integer angleB = degrees[b];
					Integer angleC = degrees[c];
					Integer sum = angleA + angleB + angleC;
					if (sum % 360 == 0) {	
						System.out.printf("%d + %d + %d = %d degrees\n",
								angleA, angleB, angleC, sum);
						isFound = true;
					}
				}
			}
		}
		
		if (!isFound) {
			System.out.println("No");
		}
		
	}

}
