import java.util.ArrayList;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class P02TerroristsWin {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String input = scan.nextLine();
        String pattern = "[\\|]+[a-zA-Z]+[\\|]";
        String[] words = input.split(pattern);
        ArrayList<String> bombs = new ArrayList<String>();
        Matcher m = Pattern.compile(pattern).matcher(input);
        while (m.find()) {
            bombs.add(m.group());
        }

        Integer beginIndex = 0;
        String bombStr;
        Integer sum = 0;
        Integer power = 0;
        Integer length = 0;
        String output = "";

        for (Integer i = 0; i < words.length -1; i++) {
            String tempWord = words[i];
            bombStr = bombs.get(i);
            for (Integer j = 1; j < bombStr.length() - 1; j++) {
                sum += bombStr.charAt(j);
                length = bombStr.length();
                power = sum % 10;
            }
            Integer endIndex = tempWord.length() - power;
            output += tempWord.substring(beginIndex, endIndex);


        }
        System.out.printf("%s", output);


    }
}
