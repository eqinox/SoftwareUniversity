import java.util.Scanner;
import java.util.TreeMap;
import java.util.Map.Entry;

import javax.security.auth.Subject;


public class _12_CardFrequencies {

	public static void main(String[] args) {
		Scanner reader = new Scanner(System.in);
		String[] input = reader.nextLine().split(" ");
		reader.close();
		TreeMap<String, Integer> map = new TreeMap<>();
		for (String string : input) {
			String card = string.substring(0, string.length() - 1);
			int cardCount = 0;
			if (map.containsKey(card)) {
				cardCount = map.get(card);
				map.put(card, cardCount + 1);
			}else {
				map.put(card, 1);
			}
		}
		for (Entry<String, Integer> entry : map.entrySet()) {
				System.out.printf("%s -> %.2f%%\n", entry.getKey(), (double)entry.getValue() * 100 / input.length);
			
		}
	}

}
