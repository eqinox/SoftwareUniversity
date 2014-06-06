import java.util.*;


public class _09PointsInHouse {

	public static void main(String[] args) {
		Locale.setDefault(Locale.ROOT); 
		Scanner reader = new Scanner(System.in);
		double first = reader.nextDouble();
		double second = reader.nextDouble();
		Point a = new Point(8.5, 12.5);
		Point b = new Point(3.5, 17.5);
		Point c = new Point(8.5, 22.5);
		
		Boolean right = CheckRight(first, second);
		Boolean left = CheckLeft(first, second);
		Boolean top = CheckTop(a, b, c);
		if (right || left || top) {
			System.out.println("Inside");
		}else {
			System.out.println("Outside");
		}
		reader.close();
	}
	private static Boolean CheckRight(Double firstNum, Double secondNum) {
		if ((firstNum >= 20 && firstNum <= 22.5) && (secondNum >= 6 && secondNum <= 13.5)) {
			return true;
		} else {
			return false;
		}
	}

	private static Boolean CheckTop(Point a, Point b, Point c){
	     return ((b.x() - a.x())*(c.y() - a.y()) - (b.y() - a.y())*(c.x() - a.x())) > 0;
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


