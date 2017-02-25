import java.util.Scanner;

public class P01VideoDurations {

	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		
		Integer totalMinutes = 0;
		while (true) {	
			String input = scan.nextLine();
			if (input.equals("End")) {
				break;
			}		
			String[] times = input.split(":");					
			Integer hour = Integer.parseInt(times[0]);
			Integer minute = Integer.parseInt(times[1]);
			totalMinutes += hour*60 + minute;				
		}
		
		System.out.printf("%d:%02d", totalMinutes / 60, totalMinutes % 60);
					
	}

}
