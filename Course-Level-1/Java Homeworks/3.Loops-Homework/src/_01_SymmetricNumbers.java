import java.util.ArrayList;
import java.util.Scanner;


public class _01_SymmetricNumbers {

	public static void main(String[] args) {
		Scanner reader = new Scanner(System.in);
		int start = reader.nextInt();
		int end = reader.nextInt();
		
		
		for (int i = start; i <= end; i++) {
			String numAsStr = String.valueOf(i);
			if (numAsStr.length() == 1) {
				System.out.println(i);
			}else if (numAsStr.length() == 2) {
				if (numAsStr.charAt(0) == numAsStr.charAt(1)) {
					
				}
			}
		}
		reader.close();
	}

}
