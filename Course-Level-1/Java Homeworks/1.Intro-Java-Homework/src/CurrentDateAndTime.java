import java.text.SimpleDateFormat;
import java.util.Date;


public class CurrentDateAndTime {

	public static void main(String[] args) {
		Date timeNow = new Date();
		SimpleDateFormat format = new SimpleDateFormat("dd hh:mm");
		System.out.println(format.format(timeNow));
	}

}
