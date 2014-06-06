import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;


public class _08_ExtractEmails {

	public static void main(String[] args) {
		Scanner reader = new Scanner(System.in);
		String text = reader.nextLine();
		Pattern pattern = Pattern.compile("([a-zA-Z0-9]+(?:[._+-][a-zA-Z0-9]+)*)@([a-zA-Z0-9]+(?:[.-][a-zA-Z0-9]+)*[.][a-zA-Z]{2,})");
		Matcher matches = pattern.matcher(text);
		while (matches.find()) {
			System.out.println(matches.group());
		}
		reader.close();
	}

}
