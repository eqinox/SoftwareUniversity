import java.util.Scanner;


public class _06FormattingNumbers {

	public static void main(String[] args) {
		Scanner reader = new Scanner(System.in);
		int a = reader.nextInt();
		float b = reader.nextFloat();
		float c = reader.nextFloat();
		System.out.printf("|%-10s|%10s|%10.2f|%-10.3f|", Integer.toHexString(a).toUpperCase(), 
			   String.format("%10s", Integer.toBinaryString(a)).replace(' ', '0'), b, c);
		reader.close();
	}

}
