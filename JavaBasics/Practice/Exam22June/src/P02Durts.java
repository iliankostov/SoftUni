import java.util.Scanner;

public class P02Durts {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        Integer centerX = scanner.nextInt();
        Integer centerY = scanner.nextInt();
        Integer r = scanner.nextInt();
        Integer n = scanner.nextInt();

        double verticalRectMinX = centerX - (0.5 * r);
        double verticalRectMaxX = centerX + (0.5 * r);
        double verticalRectMinY = centerY - r;
        double verticalRectMaxY = centerY + r;

        double horizontalRectMinX = centerX - r;
        double horizontalRectMaxX = centerX + r;
        double horizontalRectMinY = centerY - (0.5*r);
        double horizontalRectMaxY = centerY + (0.5*r);

        for (int i = 0; i < n; i++) {
            int x = scanner.nextInt();
            int y = scanner.nextInt();
            boolean inside =
                    isPointInRectangle(
                            x, y,
                            verticalRectMinX, verticalRectMaxX,
                            verticalRectMinY, verticalRectMaxY) ||
                    isPointInRectangle(
                            x, y,
                            horizontalRectMinX, horizontalRectMaxX,
                            horizontalRectMinY, horizontalRectMaxY);
            System.out.println(inside ? "yes" : "no");
        }
    }
    private static boolean isPointInRectangle(int x, int y, double minX, double maxX, double minY, double maxY) {
        return (x >= minX) && (x <= maxX) && (y >= minY) && (y <= maxY);
    }
}