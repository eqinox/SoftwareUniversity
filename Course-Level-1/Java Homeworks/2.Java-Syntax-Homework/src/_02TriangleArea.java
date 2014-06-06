import java.util.*;


public class _02TriangleArea {

	public static void main(String[] args) {
		Scanner reader = new Scanner(System.in);
		Integer[][] sides = new Integer[3][2];
		for (int i = 0; i < 3; i++) {
			String[] inputAsString = reader.nextLine().split(" ");
			Integer firstInt = Integer.parseInt(inputAsString[0]);
			Integer secondInt = Integer.parseInt(inputAsString[1]);
			sides[i][0] = firstInt;
			sides[i][1] = secondInt;
		}
		Integer firstSide = sides[0][0] * (sides[1][1] - sides[2][1]);
		Integer secondSide = sides[1][0] * (sides[2][1] - sides[0][1]);
		Integer thirdSide = sides[2][0] * (sides[0][1] - sides[1][1]);
		System.out.println((firstSide + secondSide + thirdSide) / 2);

		reader.close();
		
	}

}
