import java.util.Scanner;

public class P01Timespan {

	public static void main(String[] args) {

		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		String[] timeStart = scan.nextLine().split(":");
		String[] timeEnd = scan.nextLine().split(":");
		
		long totalSecondsStart = 0L;
		long totalSecondsEnd = 0L;
		long diff = 0L;
		    
		totalSecondsStart = Long.parseLong(timeStart[0])*3600 + Long.parseLong(timeStart[1])*60 + Long.parseLong(timeStart[2]);
		totalSecondsEnd = Long.parseLong(timeEnd[0])*3600 + Long.parseLong(timeEnd[1])*60 + Long.parseLong(timeEnd[2]);
	
		diff = totalSecondsStart - totalSecondsEnd;
		
		long hours = diff / 3600;
		long minutes = (diff%3600)/60;				
		long seconds = diff - hours*3600 - minutes*60 ;		
		
		System.out.printf("%d:%02d:%02d", hours, minutes, seconds);	

	}

}
