import java.util.Scanner;


public class _03_LargestSequenceOfEqual {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);
		String str = in.nextLine();
		String[] arr = str.split(" ");
		int counterTemp = 1;
		int counter = 1;
		int positionOfWord = 0; // positionOfWord shows the position of the
								// last word in the largest sequence of equal elements

		for (int i = 1; i < arr.length; i++) {
			if (arr[i].equals(arr[i - 1])) {
				counterTemp++;
			} else {
				counterTemp = 1;
			}
			if (counterTemp > counter) {
				counter = counterTemp;
				positionOfWord = i;
			}
		}
		for (int j = 0; j < counter - 1; j++) {
			System.out.print(arr[positionOfWord] + " ");
		}
		System.out.println(arr[positionOfWord]);

	}

}
