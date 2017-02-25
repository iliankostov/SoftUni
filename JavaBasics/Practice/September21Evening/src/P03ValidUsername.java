import java.util.ArrayList;
import java.util.Scanner;

public class P03ValidUsername {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String input = scan.nextLine().replaceAll("[\\s+/\\\\()]", "|");
        String[] words = input.split("\\|+");
        ArrayList<String> correctWords = new ArrayList<String>();

        for (String word : words) {
            if (!word.isEmpty()){
                if (word.substring(0, 1).matches("[a-zA-Z]") &&
                        word.matches("[a-zA-Z0-9_]+") &&
                        word.length() >= 3 && word.length() <= 25) {
                    correctWords.add(word);
                }
            }
        }

        Integer maxSum = 0;
        String printOne = "";
        String printTwo = "";
        for (Integer i = 0; i < correctWords.size() - 1; i++) {
            String first = correctWords.get(i);
            String second = correctWords.get(i+1);
            Integer sum = first.length() + second.length();
            if (sum > maxSum) {
                maxSum = sum;
                printOne = first;
                printTwo = second;
            }
        }
        System.out.printf("%s\n%s", printOne, printTwo);
    }
}
