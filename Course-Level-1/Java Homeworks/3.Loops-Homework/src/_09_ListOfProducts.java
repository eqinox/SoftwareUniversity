import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Collections;




public class _09_ListOfProducts {

	public static void main(String[] args) {
		try (BufferedReader fileReader = new BufferedReader(new FileReader(
			"input.txt"));) {
		    ArrayList<Product> productList = new ArrayList<>();

		    while (true) {
			Product product = new Product();
			String line = fileReader.readLine();
			if (line == null) {
			    break;
			}
			String[] tokens = line.split(" ");
			product.setName(tokens[0]);
			product.setPrice(Double.parseDouble(tokens[1]));
			productList.add(product);
		    }
		    Collections.sort(productList);
		    for (Product pro : productList) {
			System.out.printf("%.2f %s\n", pro.getPrice(), pro.getName());
		    }
		} catch (IOException e) {
		    System.out.println("Error");
		}
	    }

}
