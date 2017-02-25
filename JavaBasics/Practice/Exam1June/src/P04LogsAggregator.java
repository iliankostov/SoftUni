import java.util.*;

public class P04LogsAggregator {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        Integer number = scanner.nextInt();
        scanner.nextLine();

        TreeMap<String, Integer> durations = new TreeMap<String, Integer>();
        HashMap<String, TreeSet<String>> ipAddresses = new HashMap<String, TreeSet<String>>();
        for (int i = 0; i < number; i++) {
            String[] logTokens = scanner.nextLine().split(" ");
            String ip = logTokens[0];
            String user = logTokens[1];
            Integer duration = Integer.parseInt(logTokens[2]);

            Integer oldDuration = durations.get(user);
            if (oldDuration == null) {
                oldDuration = 0;
            }
            durations.put(user, oldDuration + duration);

            TreeSet<String> ipSet = ipAddresses.get(user);
            if (ipSet == null) {
                ipSet = new TreeSet<String>();
            }
            ipSet.add(ip);
            ipAddresses.put(user, ipSet);
        }

        for (Map.Entry<String, Integer> userAndDuration : durations.entrySet()) {
            String user = userAndDuration.getKey();
            Integer duration = userAndDuration.getValue();
            TreeSet<String> ipSet = ipAddresses.get(user);
            System.out.println(user + ": " + duration + " " + ipSet);
        }
    }
}