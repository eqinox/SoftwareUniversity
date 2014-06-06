import java.util.ArrayList;
import java.util.Scanner;


public class _02_SequenceOfEqualStrings {

	public static void main(String[] args) {
		Scanner reader = new Scanner(System.in);
		String[] input = reader.nextLine().split(" ");
		ArrayList<String> sequence = new ArrayList();
		sequence.add(input[0]);
		for (int i = 1; i < input.length; i++) {
			if (sequence.isEmpty()) {
				sequence.add(input[i]);
			}
			else if (sequence.get(sequence.size() - 1).equals(input[i])) {
				sequence.add(input[i]);
			}
			else {
				System.out.println(String.join(" ", sequence));
				i--;
				sequence.clear();
			}
		}
		if (!sequence.isEmpty()) {
			System.out.println(String.join(" ", sequence));
		}
		reader.close();
	}

}
