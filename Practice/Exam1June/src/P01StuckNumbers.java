import java.util.Scanner;
import java.util.HashSet;

public class P01StuckNumbers {

	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		Integer num = Integer.parseInt(scan.nextLine());
		String input = scan.nextLine();
		String[] numbers = input.split(" ");
		
		HashSet<String> eql = new HashSet<String>();
		for (int a = 0; a < num; a++) {
			for (int b = 0; b < num; b++) {
				for (int c = 0; c < num; c++) {
					for (int d = 0; d < num; d++) {
						if (a!=b && b!=c && c!=d && a!=c && a!=d && b!=d) {							
							if ((numbers[a] + numbers[b]).equals(numbers[c] + numbers[d])) {
								eql.add("" + numbers[a] + "|" + numbers[b] + "==" + numbers[c] + "|" + numbers[d]);
							}
						}
					}
				}
			}
		}
		if (eql.isEmpty()) {
			System.out.println("No");
		}else {
			for (String string : eql) {
				System.out.println(string);
			}
		}			

	}

}
