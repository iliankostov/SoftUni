import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Scanner;
import java.util.concurrent.TimeUnit;

public class P07DaysBetweenTwoDates {
		
	public static void main(String[] args) throws ParseException {

		@SuppressWarnings("resource")
		Scanner scanner = new Scanner(System.in);

		Date firstDate = parseDate(scanner.next());
		Date secondDate = parseDate(scanner.next());

		long days = getDateDiff(firstDate, secondDate, TimeUnit.DAYS);

		System.out.println(days);
	}

	public static Date parseDate(String dateAsString) throws ParseException {

		DateFormat dateFormat = new SimpleDateFormat("dd-MM-yyyy");
		Date date = new Date();
		date = dateFormat.parse(dateAsString);
		return date;
	}

	public static long getDateDiff(Date date1, Date date2, TimeUnit timeUnit) {
		long diffInMillies = date2.getTime() - date1.getTime();
		return timeUnit.convert(diffInMillies, TimeUnit.MILLISECONDS);
	}

}
