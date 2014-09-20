import java.util.ArrayList;
import java.util.Scanner;


public class P09CombineListsOfLetters {

	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		ArrayList<Character> firstList = new ArrayList<>();
		ArrayList<Character> secondList = new ArrayList<>();
		ArrayList<Character> resultList = new ArrayList<>();

		for (char chars : input.nextLine().toCharArray()) {
			firstList.add(chars);
		}
		for (char chars : input.nextLine().toCharArray()) {
			secondList.add(chars);
		}
		resultList.addAll(firstList);

		for (int i = 0; i < secondList.size(); i++) {

			if (firstList.contains(secondList.get(i))) {
				continue;
			} else {
				resultList.add(' ');
				resultList.add(secondList.get(i));
			}
		}

		for (int i = 0; i < resultList.size(); i++) {
			System.out.print(resultList.get(i));
		}
		
	}

}
