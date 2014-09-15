import java.io.FileNotFoundException;
import java.io.PrintStream;
import java.util.ArrayList;

public class P09ListOfProducts {

	public static void main(String[] args) throws FileNotFoundException {

		ArrayList<Product> products = new ArrayList<>();
		ArrayList<String> fileRows = new ArrayList<>();

		fileRows = Product.readFile("Input.txt");

		for (String row : fileRows) {

			products.add(new Product(row));
		}

		products.sort(Product.ProductPriceComparator);

		printToFile("Output.txt", products);

	}

	public static void printToFile(String fileName, ArrayList<Product> products)
			throws FileNotFoundException {

		PrintStream fileWriter = new PrintStream(fileName);

		for (Product product : products) {

			fileWriter.println(product);

		}

		fileWriter.close();
	}

}
