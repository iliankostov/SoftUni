import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;

public class P04OfficeStuff {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        Integer number = Integer.parseInt(scan.nextLine());

        TreeMap<String, LinkedHashMap<String, Integer>> companies = new TreeMap<String, LinkedHashMap<String, Integer>>();
        for (Integer i = 0; i < number; i++) {
            String line = scan.nextLine().replace("|", "");
            String[] elements = line.split("\\s+\\-\\s+");
            String company = elements[0];
            Integer amount = Integer.parseInt(elements[1]);
            String stuff = elements[2];

            if (!companies.containsKey(company)) {
                companies.put(company, new LinkedHashMap<String, Integer>());
            }
            LinkedHashMap<String, Integer> amounts = companies.get(company);
            int oldAmount = 0;
            if (amounts.containsKey(stuff)) {
                oldAmount = amounts.get(stuff);
            }
            amounts.put(stuff, oldAmount + amount);
        }
        for (String company : companies.keySet()) {
            System.out.print(company + ": ");
            LinkedHashMap<String, Integer> amounts = companies.get(company);
            boolean first = true;
            for (Map.Entry<String, Integer> pair : amounts.entrySet()) {
                if (!first) {
                    System.out.print(", ");
                }
                first = false;
                String stuff = pair.getKey();
                Integer amount = pair.getValue();
                System.out.print(stuff + "-" + amount);
            }
            System.out.println();
        }
    }
}
