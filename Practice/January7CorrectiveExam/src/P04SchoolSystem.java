import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;

public class P04SchoolSystem {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        Integer number = Integer.parseInt(scan.nextLine());

        TreeMap<String, TreeMap<String, Double>> students = new TreeMap<String, TreeMap<String, Double>>();
        for (Integer i = 0; i < number; i++) {
            String line = scan.nextLine();
            String[] elements = line.split("\\s+");
            String student = elements[0]+ " " + elements[1];
            String subject = elements[2];
            Double score = Double.parseDouble(elements[3]);

            if (!students.containsKey(student)) {
                students.put(student, new TreeMap<String, Double>());
            }
            TreeMap<String, Double> scores = students.get(student);
            Double avgScore;
            if(scores.containsKey(subject)) {
                avgScore = (scores.get(subject) + score) / 2;
            } else {
                avgScore = score;
            }
            scores.put(subject, avgScore);
        }

        for (String student : students.keySet()) {
            System.out.print(student + ": [");
            TreeMap<String, Double> scores = students.get(student);
            boolean first = true;
            for (Map.Entry<String, Double> pair : scores.entrySet()) {
                if (!first) {
                    System.out.print(", ");
                }
                first = false;
                String subject = pair.getKey();
                Double score = pair.getValue();
                System.out.printf("%s - %.2f", subject, score);
            }
            System.out.print("]");
            System.out.println();
        }
    }
}