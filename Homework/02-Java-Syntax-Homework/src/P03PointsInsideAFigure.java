import java.util.Scanner;

public class P03PointsInsideAFigure {
	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);		
		float xPoint = 0 ,yPoint = 0;
		try {
			xPoint = scan.nextFloat();
			yPoint = scan.nextFloat();			
		} catch (NumberFormatException nfex) {
			System.err.println("Fail to scan number" + nfex);
		}	
		
		if (isInside(xPoint, yPoint)) {
			System.out.println("Inside");
		}
		else {
			System.out.println("Outside");
		}
				
	}
	private static boolean isInside(float xPoint, float yPoint) {
		boolean answer = false;
		
		boolean insideRoof = xPoint >= 12.5 && xPoint <= 22.5 && yPoint >= 6 && yPoint <= 8.5;
		boolean insideLeftWall = xPoint >= 12.5 && xPoint <= 17.5 && yPoint >= 8.5 && yPoint <= 13.5;
		boolean insideRightWall = xPoint >= 20 && xPoint <= 22.5 && yPoint >= 8.5 && yPoint <= 13.5;
		if (insideRoof || insideLeftWall || insideRightWall) {
			answer = true;
		}		
		
		return answer;
	}
}
