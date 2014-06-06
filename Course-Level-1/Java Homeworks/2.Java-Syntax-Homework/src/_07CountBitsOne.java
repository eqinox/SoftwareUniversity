import java.util.Scanner;


public class _07CountBitsOne {

	public static void main(String[] args) {
		Scanner reader = new Scanner(System.in);
		int num = reader.nextInt();
		System.out.println(Integer.bitCount(num));
		reader.close();
	}

}
