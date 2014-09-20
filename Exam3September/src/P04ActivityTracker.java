import java.util.Scanner;
import java.util.TreeMap;

public class P04ActivityTracker {

	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		Integer n = Integer.parseInt(scan.nextLine());
		
		TreeMap<Integer, TreeMap<String, Float>> monthsActivity = new TreeMap<>();
		for (int i = 0; i < n; i++) {
			String[] activity = scan.nextLine().split(" ");
			String[] date = activity[0].split("/");
			
			Integer month = Integer.parseInt(date[1]);
			String name = activity[1];
			Float distance = Float.parseFloat(activity[2]);
					
			if (monthsActivity.containsKey(month)) {
				if (monthsActivity.get(month).containsKey(name)) {
					distance += monthsActivity.get(month).get(name);
					monthsActivity.get(month).put(name, distance);
				}					
				monthsActivity.get(month).put(name, distance);				
			}else {
				TreeMap<String, Float> users = new TreeMap<>();
				users.put(name, distance);
				monthsActivity.put(month, users);
			}
														
		}
		for (int month : monthsActivity.keySet()) {
			System.out.print(month + ": ");
			
			TreeMap<String, Float> users = monthsActivity.get(month);
			
			int count = 0;
			
			for (String name : users.keySet()) {
				if (count > 0) {
					System.out.printf(", %s(%.0f)", name, users.get(name));
				}else {
					System.out.printf("%s(%.0f)", name, users.get(name));
				}
				count++;
			}
			System.out.println();
		}

	}

}
