function findCardFrequency (value) {

	var newValue = value.split(/[♥♣♦♠ ]+/);
	newValue.pop();
	var arr = {"1" : 0, "2" : 0, "3" : 0, "4" : 0, "5" : 0, "6" : 0, "7" : 0, "8" : 0, "9" : 0, "10" : 0, "J" : 0, "Q" : 0, "K" : 0, "A" : 0};



	var result = "";

	for (var i = 0; i < newValue.length; i++) {
		for (var key in arr) {
			if (newValue[i] == key) {
				arr[key]++;
			}
		}
	}

	//var cardslength = getCardsLength(arr);

	for (var key in arr) {
		var value = arr[key];
		if (value != 0) {
			result += key + " -> " + ( (value / newValue.length) * 100 ).toFixed(2) + "%\r\n";
		}
	}
	return result;
}

console.log(findCardFrequency("8♥ 2♣ 4♦ 10♦ J♥ A♠ K♦ 10♥ K♠ K♦"));
console.log(findCardFrequency('J♥ 2♣ 2♦ 2♥ 2♦ 2♠ 2♦ J♥ 2♠'));
console.log(findCardFrequency('10♣ 10♥'));

