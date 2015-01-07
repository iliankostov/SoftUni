import java.util.ArrayList;
import java.util.Scanner;

public class P01MirrorNumbers {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        Integer number = Integer.parseInt(scan.nextLine());
        String[] digits = scan.nextLine().split(" ");
        boolean isFound = false;
        ArrayList<String> outputs = new ArrayList<String>();

        for ( Integer i = 0; i < number - 1; i++ ) {
            for (Integer j = i + 1; j < number; j++) {
                String first = digits[i];
                String second = digits[j];
                boolean isEqual = revers(first).equals(second);
                if (isEqual) {
                    isFound = true;
                    outputs.add("" + first + "<!>" + second);
                }
            }
        }
        if (isFound) {
            for (String output : outputs) {
                System.out.println(output);
            }
        } else {
            System.out.printf("No");
        }

    }
    public static String revers(String str) {
        return new StringBuilder(str).reverse().toString();
    }
}
