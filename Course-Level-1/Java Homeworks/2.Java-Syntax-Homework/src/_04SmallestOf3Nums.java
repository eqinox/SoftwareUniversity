import java.util.Scanner;


public class _04SmallestOf3Nums {

	public static void main(String[] args) {
		Scanner reader = new Scanner(System.in);
		Double firstInt = reader.nextDouble();
		Double secondInt = reader.nextDouble();
		Double thirdInt = reader.nextDouble();
		if (firstInt < secondInt) {
			if (firstInt < thirdInt) {
				System.out.println(firstInt);
			}
		} else if (secondInt < thirdInt) {
			System.out.println(secondInt);
		}
		else {
			System.out.println(thirdInt);
		}
		reader.close();
	}

}
