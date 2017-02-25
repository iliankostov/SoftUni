import java.util.ArrayList;
import java.util.Scanner;

public class P09CombineListsOfLetters {

	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		ArrayList<Character> firstList = new ArrayList<Character>();
		ArrayList<Character> secondList = new ArrayList<Character>();
		ArrayList<Character> resultList = new ArrayList<Character>();

		for (char chars : scan.nextLine().toCharArray()) {
			firstList.add(chars);
		}
		for (char chars : scan.nextLine().toCharArray()) {
			secondList.add(chars);
		}
		resultList.addAll(firstList);

		for (Character aSecondList : secondList) {

			if (!firstList.contains(aSecondList)) {
				resultList.add(' ');
				resultList.add(aSecondList);
			}
		}

		for (Character aResultList : resultList) {
			System.out.print(aResultList);
		}
		
	}

}
