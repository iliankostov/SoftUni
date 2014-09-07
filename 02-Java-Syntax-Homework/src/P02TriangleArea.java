import java.util.Scanner;

public class P02TriangleArea {
	public static void main(String[] args) {
		
		Scanner scan = new Scanner(System.in);
		int ax, ay, bx, by, cx, cy;
		double a, b, c, perimeter, area;		
		ax = scan.nextInt();
		ay = scan.nextInt();
		bx = scan.nextInt();
		by = scan.nextInt();
		cx = scan.nextInt();
		cy = scan.nextInt();
		scan.close();
		a = Math.sqrt(Math.pow((bx - ax), 2) + Math.pow((by - ay), 2));
		b = Math.sqrt(Math.pow((cx - bx), 2) + Math.pow((cy - by), 2));
		c = Math.sqrt(Math.pow((ax - cx), 2) + Math.pow((ay - cy), 2));
		
		if ((a + b > c) && (b + c > a) && (c + a > b)) {
			perimeter = (a + b + c)/2;
			area = Math.sqrt(perimeter * (perimeter - a) * (perimeter - b) * (perimeter - c));
			System.out.println(Math.round(area));
		}
		else {
			System.out.println(0);
		}
		
	}
}
