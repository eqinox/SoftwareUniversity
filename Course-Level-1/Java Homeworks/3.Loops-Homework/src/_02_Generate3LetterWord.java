import java.util.Scanner;


public class _02_Generate3LetterWord {

	static void generate(StringBuilder sb, int n, String characters) {
		char[] alphabet = characters.toCharArray();
		if (n == sb.length()) {
			System.out.println(sb.toString());
			return;
		}
		for (char letter : alphabet) {
			sb.setCharAt(n, letter);
			generate(sb, n + 1, characters);
		}
	}

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String characters = input.next();
		StringBuilder sb = new StringBuilder();
		sb.setLength(3);
		generate(sb, 0, characters);
	}

}
