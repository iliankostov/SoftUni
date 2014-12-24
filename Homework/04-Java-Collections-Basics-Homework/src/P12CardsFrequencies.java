import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;

public class P12CardsFrequencies {

	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		String[] cards = scan.nextLine().split("[ ♥♣♦♠]+");

		Map<String, Integer> cardsMap = new LinkedHashMap<String, Integer>();

		for (String card : cards) {
			Integer count = cardsMap.get(card);
			if (count == null) {
				count = 0;
			}
			cardsMap.put(card, count + 1);
		}

		for (Map.Entry<String, Integer> entry : cardsMap.entrySet()) {
			double percentage = (double) entry.getValue() * 100 / cards.length;
			System.out.printf("%s -> %.2f%%\n", entry.getKey(), percentage);
		}
		
	}

}
