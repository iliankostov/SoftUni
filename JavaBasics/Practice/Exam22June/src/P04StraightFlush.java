import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashSet;
import java.util.Scanner;

public class P04StraightFlush {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String[] inputCards = sc.nextLine().split("\\W+");

        HashSet<String> existingCards = new HashSet<String>();
        existingCards.addAll(Arrays.asList(inputCards));
        int count = 0;
        for (String startCard : inputCards) {
            String cardFace = startCard.substring(0, startCard.length() - 1);
            String cardSuit = startCard.substring(startCard.length() - 1);
            ArrayList<String> straightFlush = new ArrayList<String>();
            for (int i = 0; i < 5; i++) {
                straightFlush.add(cardFace + cardSuit);
                cardFace = GetNextCard(cardFace);
            }

            if (existingCards.containsAll(straightFlush)) {
                System.out.println(straightFlush);
                count++;
            }
        }

        if (count == 0) {
            System.out.println("No Straight Flushes");
        }
    }

    public static String GetNextCard(String cardFace) {
        String[] cardFaces = {"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"};
        for (int i = 1; i < cardFaces.length; i++) {
            if (cardFaces[i-1].equals(cardFace)) {
                return cardFaces[i];
            }
        }
        return null;
    }
}
