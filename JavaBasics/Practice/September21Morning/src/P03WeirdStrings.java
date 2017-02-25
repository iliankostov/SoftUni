import java.util.Scanner;

public class P03WeirdStrings {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String inputLine = scan.nextLine();
        inputLine = inputLine.replaceAll("[()\\[\\]\\|\\^\\\\/\\s]+", "");
        String[] words = inputLine.split("[^a-zA-Z]+");

        String[] longestTwoWord = new String[2];
        Integer maxWeight = 0;
        for (Integer i = 0; i < words.length - 1; i++) {
            Integer weight = calcWeight(words[i]) + calcWeight(words[i+1]);
            if (weight >= maxWeight) {
                maxWeight = weight;
                longestTwoWord[0] = words[i];
                longestTwoWord[1] = words[i+1];
            }
        }
        for (String word : longestTwoWord) {
            System.out.println(word);
        }

    }

    public static int calcWeight(String str) {
        String strLow = str.toLowerCase();
        Integer sum = 0;
        for (Integer i = 0; i < strLow.length(); i++) {
            Character ch = strLow.charAt(i);
            Integer num = (int)ch - 95;
            sum += num;
        }
        return sum;
    }
}
