import java.util.Scanner;


public class _07_CountSubString {

	public static void main(String[] args) {
		Scanner reader = new Scanner(System.in);
		String text = reader.nextLine().toLowerCase();
		String pattern = reader.nextLine().toLowerCase();
		int counter = 0;
		for (int i = 0; i < text.length() - pattern.length() + 1; i++) {
			String sub = text.substring(i, pattern.length() + i);
			if (sub.equals(pattern))  {
				counter++;
			}
		}
		System.out.println(counter);
		reader.close();
	}

}
