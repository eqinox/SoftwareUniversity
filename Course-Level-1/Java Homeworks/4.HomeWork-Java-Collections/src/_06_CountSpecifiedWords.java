import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;


public class _06_CountSpecifiedWords {

	public static void main(String[] args) {
		Scanner reader = new Scanner(System.in);
		String text = reader.nextLine();
		String word = reader.nextLine();
		Pattern pattern = Pattern.compile("(?i)" + word + "\\b");
		Matcher matches = pattern.matcher(text);
		reader.close();
		int counter = 0;
		while (matches.find()) {
			counter++;
		}
		System.out.println(counter);
	}

}
