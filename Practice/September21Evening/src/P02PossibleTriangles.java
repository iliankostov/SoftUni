import java.util.ArrayList;
import java.util.Arrays;
import java.util.Scanner;

public class P02PossibleTriangles {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        ArrayList<String> inputLines = new ArrayList<String>();
        while (true) {
            String line = scan.nextLine();
            if (line.equals("End")) {
                break;
            }
            inputLines.add(line);
        }
        if (!inputLines.isEmpty()) {
            boolean isFound = false;
            for (String line : inputLines) {
                String[] sides = line.split(" ");
                Double[] numbers = { Double.parseDouble(sides[0]), Double.parseDouble(sides[1]), Double.parseDouble(sides[2]) };
                Arrays.sort(numbers);
                Double sideA = numbers[0];
                Double sideB = numbers[1];
                Double sideC = numbers[2];

                if (sideA + sideB > sideC) {
                    isFound = true;
                    System.out.printf("%.2f+%.2f>%.2f\n", sideA, sideB, sideC);
                }
            }
            if (!isFound) {
                System.out.printf("No");
            }
        }
    }
}