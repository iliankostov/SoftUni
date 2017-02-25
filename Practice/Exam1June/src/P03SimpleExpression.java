import java.math.BigDecimal;
import java.util.Scanner;

public class P03SimpleExpression {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String input = scanner.nextLine();
        input = input.replace(" ", "");
        String[] numbers = input.split("[^0-9.]+");
        String[] signs = input.split("[0-9.]+");

        BigDecimal sum = new BigDecimal(numbers[0]);
        for (Integer i = 1; i < signs.length; i++) {
            BigDecimal number = new BigDecimal(numbers[i]);
            if (signs[i].equals("+")) {
                sum = sum.add(number);
            } else if (signs[i].equals("-")) {
                sum = sum.subtract(number);
            }
        }
        System.out.println(sum.toPlainString());
    }
}