import java.util.ArrayList;
import java.util.Arrays;
import java.util.Scanner;

public class P01Pyramid {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        Integer rowNumber = Integer.parseInt(scan.nextLine());
        Integer startNumber = scan.nextInt();
        scan.nextLine();
        boolean hasElement = false;

        ArrayList<Integer> outputs = new ArrayList<Integer>();
        outputs.add(startNumber);
        for (Integer i = 1; i < rowNumber; i++) {
            String[] elements = scan.nextLine().split("\\s+");
            Integer[] numbers = new Integer[elements.length];

            // parse array
            for (Integer p = 0; p < elements.length; p++) {
                if (!elements[p].equals("")) {
                    numbers[p] = Integer.parseInt(elements[p]);
                } else {
                    numbers[p] = Integer.MIN_VALUE;
                }
            }

            //sort array
            Arrays.sort(numbers);

            for (Integer number : numbers) {
                if (number > startNumber) {
                    startNumber = number;
                    outputs.add(startNumber);
                    hasElement = true;
                    break;
                }
            }
            if (!hasElement) {
                startNumber++;
            }
            hasElement = false;
        }
        for (Integer i = 0; i < outputs.size(); i++) {
            if (i < outputs.size() - 1) {
                System.out.printf("%s, ", outputs.get(i));
            } else {
                System.out.printf("%s", outputs.get(i));
            }
        }
    }
}