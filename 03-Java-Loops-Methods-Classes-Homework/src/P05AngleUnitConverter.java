import java.util.Scanner;

public class P05AngleUnitConverter {

	public static void main(String[] args) {

		@SuppressWarnings("resource")
		Scanner scanner = new Scanner(System.in);		 		
		int number = scanner.nextInt();
				
		double[] values = new double[number];
		String[] units = new String[number];		
		for (int i = 0; i < number; i++) {			
			values[i] = scanner.nextDouble();
			units[i] = scanner.next();						
		}		
		for (int j = 0; j < number; j++) {
					
			double result = 0;			
			if (units[j].equals("deg")) {
				result = degToRad(values[j]);
				System.out.printf("%.6f rad\n", result);
			}

			if (units[j].equals("rad")) {
				result = radToDeg(values[j]);
				System.out.printf("%.6f deg\n", result);
			}
		}
		
	}

	public static double degToRad(double deg) {
		double rad = deg * (Math.PI / 180);
		return rad;
	}

	public static double radToDeg(double rad) {
		double deg = rad * (180 / Math.PI);
		return deg;
	}

}