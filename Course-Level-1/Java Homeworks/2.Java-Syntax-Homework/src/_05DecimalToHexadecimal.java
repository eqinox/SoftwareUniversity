import java.util.Scanner;


public class _05DecimalToHexadecimal {
	public static void main(String[] asd){
		Scanner reader = new Scanner(System.in);
		int num = reader.nextInt();
		System.out.println(Integer.toHexString(num));
		reader.close();
	}
}
