import java.util.Arrays;
import java.util.Scanner;


public class _01_SortArrayOfNums {

	public static void main(String[] args) {
		Scanner reader = new Scanner(System.in);
		int length = reader.nextInt();
		int[] nums = new int[length];
		for (int i = 0; i < nums.length; i++) {
			nums[i] = reader.nextInt();
		}
		Arrays.sort(nums);
		for (int i = 0; i < nums.length; i++) {
			System.out.print(nums[i] + " ");
		}
		reader.close();
	}

}
