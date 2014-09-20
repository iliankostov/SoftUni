import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;

public class P11MostFrequentWord {

	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		
		String[] text = scan.nextLine().toLowerCase().split("\\W+");

		TreeMap<String, Integer> wordOccurrences = new TreeMap<>();

		int maxCountWord = 0;

		for (String word : text) {
			
			Integer wordCount = wordOccurrences.get(word);

			if (wordCount == null) {
				wordCount = 0;
			}

			if (wordCount + 1 > maxCountWord){
				maxCountWord = wordCount + 1;
			}
			wordOccurrences.put(word, wordCount + 1);

		}

		for (Map.Entry<String, Integer> entry : wordOccurrences.entrySet()) {
			if (entry.getValue() == maxCountWord) {
				System.out.println(entry.getKey() + " -> " + maxCountWord
						+ " times");
			}

		}
		
	}

}
