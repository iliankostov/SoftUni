import java.util.Scanner;
import java.util.TreeMap;

public class P03ExamScore {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        scanner.nextLine();
        scanner.nextLine();
        scanner.nextLine();

        TreeMap<Integer, TreeMap<String, Double>> scores = new TreeMap<Integer, TreeMap<String, Double>>();
        while (true) {
            String line = scanner.nextLine();
            String[] tokens = line.split("\\s*\\|\\s*");
            if (tokens.length < 4) {
                break;
            }
            String name = tokens[1];
            Integer examScore = Integer.parseInt(tokens[2]);
            Double grade = Double.parseDouble(tokens[3]);

            if (!scores.containsKey(examScore)) {
                scores.put(examScore, new TreeMap<String, Double>());
            }

            scores.get(examScore).put(name, grade);
        }

        for (Integer score : scores.keySet()) {
            System.out.print(score + " -> ");
            System.out.print(scores.get(score).keySet());
            Double sum = 0.0;
            for (Double grade : scores.get(score).values()) {
                sum += grade;
            }
            Double avg = sum / scores.get(score).values().size();
            System.out.printf("; avg=%.2f\n", avg);
        }
    }
}
