import java.util.Map.Entry;
import java.util.Scanner;
import java.util.TreeMap;
import java.util.regex.Matcher;
import java.util.regex.Pattern;




public class _11_MostFrequentWord {

	public static void main(String[] args) {
		TreeMap<String, Integer> frequentWord = new TreeMap<>();
		Scanner reader = new Scanner(System.in);
		String text = reader.nextLine();
		reader.close();
		Pattern pattern = Pattern.compile("\\w+");
		Matcher match = pattern.matcher(text);
		int maxWordCount = 0;
		while (match.find()) {
			int wordCount = 0;
			String key = match.group().toLowerCase();
			if (frequentWord.containsKey(key)) {
				wordCount = frequentWord.get(key);	
			}
			if (!frequentWord.containsKey(key)) {
				frequentWord.put(key, 1);
			}
			else {
				frequentWord.put(key, wordCount + 1);
			}
			if (frequentWord.get(key) > maxWordCount) {
				maxWordCount = frequentWord.get(key);
			}
		}
		for (Entry<String, Integer> entry : frequentWord.entrySet()) {
			if (entry.getValue() == maxWordCount) {
				System.out.println(entry.getKey() + " " + entry.getValue());
			}
			
		}
	}

}
