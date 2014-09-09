import java.util.Scanner;

public class P04TheSmallestOfThreeNumbers {
	public static void main(String[] args) {
		
		Scanner scan = new Scanner(System.in);
		float aNumber = 0 ,bNumber = 0 ,cNumber = 0;
		try {
			aNumber = scan.nextFloat();
			bNumber = scan.nextFloat();
			cNumber = scan.nextFloat();
		} catch (NumberFormatException nfex) {
			System.err.println("Fail to scan number" + nfex);
		}
		scan.close();		
		float[] numbers = {aNumber, bNumber, cNumber};
		try {			
			float output = min(numbers);
			System.out.println(output);
		} catch (IllegalArgumentException iae) {
			System.err.println("Fail to read array" + iae);
		}		
					
	}
	public static float min(float[] array) {
	      // Validates input
	      if (array == null) {
	          throw new IllegalArgumentException("The Array must not be null");
	      } else if (array.length == 0) {
	          throw new IllegalArgumentException("Array cannot be empty.");
	      }
	  
	      // Finds and returns min
	      float min = array[0];
	      for (int i = 1; i < array.length; i++) {
	          if (Float.isNaN(array[i])) {
	              return Float.NaN;
	          }
	          if (array[i] < min) {
	              min = array[i];
	          }
	      }
	  
	      return min;
	  }
}
