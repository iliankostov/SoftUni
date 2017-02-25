import java.util.*;

public class P04Nuts {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        Integer num = scan.nextInt();

        TreeMap<String, LinkedHashMap<String, Integer>> nuts = new TreeMap<String, LinkedHashMap<String, Integer>>();
        for (int i = 0; i < num; i++) {
            String company = scan.next();
            String nut = scan.next();
            String amountStr = scan.next();
            Integer amount = Integer.parseInt(amountStr.substring(0, amountStr.length() - 2));

            if (!nuts.containsKey(company)) {
                nuts.put(company, new LinkedHashMap<String, Integer>());
            }
            LinkedHashMap<String, Integer> amounts = nuts.get(company);
            int oldAmount = 0;
            if (amounts.containsKey(nut)) {
                oldAmount = amounts.get(nut);
            }
            amounts.put(nut, oldAmount + amount);
        }

        for (String company : nuts.keySet()) {
            System.out.print(company + ": ");
            LinkedHashMap<String, Integer> amounts = nuts.get(company);
            boolean first = true;
            for (Map.Entry<String, Integer> pair : amounts.entrySet()) {
                if (!first) {
                    System.out.print(", ");
                }
                first = false;
                String nut = pair.getKey();
                Integer amount = pair.getValue();
                System.out.print(nut + "-" + amount + "kg");
            }
            System.out.println();
        }
    }
}