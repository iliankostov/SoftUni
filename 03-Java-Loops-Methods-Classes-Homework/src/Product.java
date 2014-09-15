import java.io.File;
import java.io.FileNotFoundException;
import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.Comparator;
import java.util.Scanner;

public class Product implements Comparable<Product> {

	private String name;
	private BigDecimal price;

	public Product(String fileRow) {
		String[] splitFileRow = fileRow.split(" ");
		this.name = splitFileRow[0];
		this.price = new BigDecimal(splitFileRow[1]);
	}

	public String getName() {
		return name;
	}

	public BigDecimal getPrice() {
		return price;
	}

	public String toString() {
		return "" + this.price + " " + this.name;
	}
	
	public static ArrayList<String> readFile(String fileName) {

		File file = new File(fileName);
		ArrayList<String> fileContent = new ArrayList<>();

		Scanner fileReader = null;

		try {

			fileReader = new Scanner(file, "UTF-8");

			while (fileReader.hasNextLine()) {

				fileContent.add(fileReader.nextLine());
			}

			return fileContent;

		} catch (FileNotFoundException e) {

			System.out.println("Error");
			return null;

		} finally {

			if (fileReader != null) {
				fileReader.close();
			}

		}
	}

	public int compareTo(Product compareProduct) {
		 
		@SuppressWarnings("unused")
		BigDecimal comparePrice = ((Product) compareProduct).getPrice(); 
 
		//ascending order
		return 1;
 
		//descending order
		//return compareQuantity - this.quantity;
	}
	
	
	public static Comparator<Product> ProductPriceComparator = new Comparator<Product>() {

		public int compare(Product product1, Product product2) {

			BigDecimal price1 = product1.price;
			BigDecimal price2 = product2.price;

			// ascending order
			return price1.compareTo(price2);

			// descending order
			// return fruitName2.compareTo(fruitName1);
		}

	};

}