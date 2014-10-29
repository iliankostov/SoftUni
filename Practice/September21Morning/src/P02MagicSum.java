import java.util.ArrayList;
import java.util.HashMap;
import java.util.Scanner;

public class P02MagicSum {

	public static void main(String[] args) {

		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		Integer d = Integer.parseInt(scan.nextLine());
		ArrayList<Integer> numbers = new ArrayList<>();
		
		while (true) {
			String input = scan.nextLine();
			if (input.equals("End")) {
				break;
			}			
			numbers.add(Integer.parseInt(input));						
		}
		
		boolean isFound = false;
		Integer maxSum = -10000;
		String out = "";
		HashMap<Integer, String> output = new HashMap<>();
		for (int a = 0; a < numbers.size(); a++) {
			for (int b = a + 1; b < numbers.size(); b++) {
				for (int c = b + 1; c < numbers.size(); c++) {
					Integer sum = (numbers.get(a) + numbers.get(b) + numbers.get(c));
					if (a == b || b == c || c == a || sum == maxSum) {
						continue;
					}																
					else if (sum % d == 0 && sum > maxSum) {
						
						maxSum = sum;
						out = "(" + numbers.get(a) + " + " + numbers.get(b) + " + " +
								numbers.get(c) + ")" + " % " + d + " = 0\n";
						output.put(maxSum, out);													
						isFound = true;	
							
					}																				
				}				
			}
		}
		
		if (!isFound) {
			System.out.println("No");
		}else {
			System.out.println(output.get(maxSum));
		}	
	}

}
