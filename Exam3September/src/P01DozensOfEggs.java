import java.util.Scanner;


public class P01DozensOfEggs {

	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		Integer totalEggs = 0;
		for (int i = 0; i < 7; i++) {
			String[] input = scan.nextLine().split(" ");
			if (input[1].equals("dozens")) {
				totalEggs += Integer.parseInt(input[0]) * 12;
			}else {
				totalEggs += Integer.parseInt(input[0]);
			}
		}
		System.out.printf("%d dozens + %d eggs%n", totalEggs / 12, totalEggs % 12);

	}

}
