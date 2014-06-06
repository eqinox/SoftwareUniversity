import java.util.Scanner;


public class _08CountOfEqualBits {

	public static void main(String[] args) {
		Scanner reader = new Scanner(System.in);
		int num = reader.nextInt();
		String hexaNum = Integer.toBinaryString(num);
		int count = 0;
		for (int i = 0; i < hexaNum.length() - 1; i++) {
			if (hexaNum.charAt(i) == hexaNum.charAt(i + 1)) {
				count++;
			}
		}
		System.out.println(count);
		reader.close();
	}

}
