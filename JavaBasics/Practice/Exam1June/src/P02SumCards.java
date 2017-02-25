import java.util.ArrayList;
import java.util.Scanner;

public class P02SumCards {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String[] inputs = scan.nextLine().split(" ");
        ArrayList<Integer> faces = new ArrayList<Integer>();
        Integer face;
        for (String input : inputs) {
            input = input.substring(0, input.length()-1);
            if( input.equals("J") ) {
                input = "12";
            } else if ( input.equals("Q") ) {
                input = "13";
            } else if ( input.equals("K") ) {
                input = "14";
            } else if ( input.equals("A") ) {
                input = "15";
            }
            face = Integer.parseInt(input);
            faces.add(face);
        }
        Integer value;
        Integer prevValue = -1;
        Integer counter = 1;
        Integer sum = 0;
        for (Integer face1 : faces) {
            value = face1;
            if (value.equals(prevValue)) {
                counter++;
            } else {
                counter = 1;
            }
            sum = sum + value;
            if (counter == 2) {
                sum = sum + 2 * value;
            }
            if (counter > 2) {
                sum = sum + value;
            }
            prevValue = value;
        }
        System.out.println(sum);
    }
}
