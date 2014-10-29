import java.util.Scanner;
import java.util.TreeSet;

public class P03Biggest3PrimeNumbers {

	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		String line = scan.nextLine();
		String[] inputs = line.split("[ ()]+");
		
		TreeSet<Integer> primeNumbers = new TreeSet<>();
		for (String string : inputs) {
			if (string.equals("")) {
				continue;
			}
			Integer number = Integer.parseInt(string);
			if (isPrime(number)) {
				primeNumbers.add(number);
			}
		}
		if (primeNumbers.size() > 2) {
			Integer sum = primeNumbers.last();
			for (int i = 0; i < 2; i++) {
				primeNumbers.remove(primeNumbers.last());
				sum += primeNumbers.last();
			}
			System.out.println(sum);
		}else {
			System.out.println("No");
		}
		
	}
	
	static boolean isPrime(Integer n){
		if (n < 2) {
			return false;
		}
		for (int i = 2; i <= Math.sqrt(n); i++) {
			if (n % i == 0) {
				return false;
			}
		}		
		return true;
	}

}
