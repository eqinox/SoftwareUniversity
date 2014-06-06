import java.util.*;

public class SortArray {

	public static void main(String[] args) {
		Scanner reader = new Scanner(System.in);
		int townsCount = reader.nextInt();
		String[] towns = new String[townsCount];

		for (int i = 0; i < towns.length; i++) {
			towns[i] = reader.next();
		}
		Arrays.sort(towns);
		for (int i = 0; i < towns.length; i++) {
			System.out.println(towns[i]);
		}
		reader.close();
	}

}
