import java.util.Scanner;

public class P07CountOfBitsOne {
	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner scanner = new Scanner(System.in);
		
		try {
			int number = scanner.nextInt();
			int output = numOnesInBinary(number);
			System.out.println(output);
		} catch (NumberFormatException nfex) {
			System.err.println("Invalid input " + nfex);
		}
							
	}
	
	public static int numOnesInBinary(int n) {

		  if (n < 0) return -1;

		  int j = 0;
		  while ( n > Math.pow(2, j)) j++;

		  int result = 0;
		  for (int i=j; i >=0; i--){
		    if (n >= Math.pow(2, i)) {
		        n = (int) (n - Math.pow(2,i));
		        result++;    
		    }
		  }

		  return result;
		}
}
