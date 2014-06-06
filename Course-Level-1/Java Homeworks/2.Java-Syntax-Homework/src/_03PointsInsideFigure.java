import java.util.Scanner;


public class _03PointsInsideFigure {

	public static void main(String[] args) {
		Scanner reader = new Scanner(System.in);
		String[] inputString = reader.nextLine().split(" ");
		Double firstNum = Double.parseDouble(inputString[0]);
		Double secondNum = Double.parseDouble(inputString[1]);
		reader.close();
		Boolean left = CheckLeft(firstNum, secondNum);
		Boolean right = CheckRight(firstNum, secondNum);
		Boolean top = CheckTop(firstNum, secondNum);
		if (left) {
			System.out.println("Inside");
		} else if (right) {
			System.out.println("Inside");
		}
		else if (top) {
			System.out.println("Inside");
		}
		else {
			System.out.println("Outside");
		}
	}

	private static Boolean CheckTop(Double firstNum, Double secondNum) {
		if ((firstNum >= 12.5 && firstNum <= 22.5) && (secondNum >= 6 && secondNum <= 8.5)) {
			return true;
		} else {
			return false;
		}
	}

	private static Boolean CheckRight(Double firstNum, Double secondNum) {
		if ((firstNum >= 20 && firstNum <= 22.5) && (secondNum >= 6 && secondNum <= 13.5)) {
			return true;
		} else {
			return false;
		}
	}

	private static Boolean CheckLeft(Double firstInt, Double secondInt) {
		if ((firstInt >= 12.5 && firstInt <= 17.5) && (secondInt >= 6 && secondInt <= 13.5)) {
			return true;
		}
		else {
			return false;
		}
	}

}
