import java.util.Scanner;

public class P03PointsInsideAFigure {
	public static void main(String[] args) {
		
		Scanner scan = new Scanner(System.in);
		float xPoint = scan.nextFloat();
		float yPoint = scan.nextFloat();
		scan.close();
		boolean insideRoof = xPoint >= 12.5 && xPoint <= 22.5 && yPoint >= 6 && yPoint <= 8.5;
		boolean insideLeftWall = xPoint >= 12.5 && xPoint <= 17.5 && yPoint >= 8.5 && yPoint <= 13.5;
		boolean insideRightWall = xPoint >= 20 && xPoint <= 22.5 && yPoint >= 8.5 && yPoint <= 13.5;
		if (insideRoof || insideLeftWall || insideRightWall) {
			System.out.println("Inside");
		}
		else {
			System.out.println("Outside");
		}
		
	}	
}
