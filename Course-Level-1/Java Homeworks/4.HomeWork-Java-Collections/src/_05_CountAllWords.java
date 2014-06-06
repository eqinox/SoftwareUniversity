import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;


public class _05_CountAllWords {

	public static void main(String[] args) {
		Scanner reader = new Scanner(System.in);
		String text = reader.nextLine();
		Pattern match = Pattern.compile("\\w+");
		Matcher matches = match.matcher(text);
		int counter = 0;
		while (matches.find()) {
			counter++;
		}
		System.out.println(counter);
		reader.close();

	}

}
