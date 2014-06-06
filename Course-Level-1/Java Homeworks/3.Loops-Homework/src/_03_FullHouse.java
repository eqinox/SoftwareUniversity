import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashSet;



public class _03_FullHouse {
	
	public static void main(String[] args) {
		String[] cards = {"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"};
		String[] colors = {"♣", "♦", "♥", "♠"};
		ArrayList<String> allCards = new ArrayList<String>();
		for (int i = 0; i < cards.length; i++) {
			for (int j = 0; j < colors.length; j++) {
				allCards.add(String.format("%s%s", cards[i], colors[j]));
			}
		}
		
		HashSet<String> allCombinations = new HashSet<String>();
		for (int firstCard = 0; firstCard < allCards.size(); firstCard++) {
			int firstNum = allCards.get(firstCard).charAt(0);
			char firstColor = allCards.get(firstCard).charAt(1);
			for (int secondCard = firstCard; secondCard < allCards.size(); secondCard++) {
				int secondNum = allCards.get(secondCard).charAt(0);
				char secondColor = allCards.get(secondCard).charAt(1);
				for (int thirdCard = secondCard; thirdCard < allCards.size(); thirdCard++) {
					int thirdNum = allCards.get(thirdCard).charAt(0);
					char thirdColor = allCards.get(thirdCard).charAt(1);
					if (firstNum == secondNum && firstNum == thirdNum) {
						if (firstColor != secondColor && firstColor != thirdColor
								&& secondColor != thirdColor) {
							for (int fourthCard = 0; fourthCard < allCards.size(); fourthCard++) {
								int fourthNum = allCards.get(fourthCard).charAt(0);
								char fourthColor = allCards.get(fourthCard).charAt(1);
								for (int fifthCard = 0; fifthCard < allCards.size(); fifthCard++) {
									int fifthNum = allCards.get(fifthCard).charAt(0);
									char fifthColor = allCards.get(fifthCard).charAt(1);
									if (fourthNum == fifthNum) {
										if (fourthColor != fifthColor) {
											allCombinations.add(String.format("%1$s %2$s %1$s %3$s %1$s %4$s %5$s %6$s %5$s %7$s", allCards.get(firstCard).charAt(0),
													allCards.get(firstCard).charAt(1), allCards.get(secondCard).charAt(1), 
													allCards.get(thirdCard).charAt(1), allCards.get(fourthCard).charAt(0),
													allCards.get(fourthCard).charAt(1), allCards.get(fifthCard).charAt(1)));
										}
									}
								}
							}
						}
					}
					else {
						continue;
					}
					
						
					
				}
			}
		}
		System.out.println(allCombinations.size());
		
		
	}

}
