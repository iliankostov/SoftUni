import java.util.Scanner;

public class P01StuckNumbers {

	public static void main(String[] args) {

		Scanner scanner = new Scanner(System.in);
		int n = scanner.nextInt();
		int[] nums = new int[n];
		for (int i = 0; i < nums.length; i++) {
			nums[i] = scanner.nextInt();
		}
		
		int count = 0;
		for (int num : nums) {
			for (int num1 : nums) {
				for (int num2 : nums) {
					for (int num3 : nums) {
						if (num != num1 && num1 != num2 && num2 != num3 && num != num2 && num != num3 && num1 != num3) {
							if (("" + num + num1).equals("" + num2 + num3)) {
								System.out.printf("%d|%d==%d|%d\n", num, num1, num2, num3);
								count++;
							}
						}
					}
				}
			}
		}
		if (count == 0) {
			System.out.println("No");
		}
	}
}