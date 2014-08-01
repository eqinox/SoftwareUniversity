function sumTwoHugeNumbers(value) {
	var firstNumber = value[0].split('');
	var secondNumber = value[1].split('');
	var length;
	var result = [];
	var reminder = 0;
	var firstNumDigit;
	var secondNumDigit;

	if (firstNumber.length > secondNumber.length) {
		length = firstNumber.length;
	} else {
		length = secondNumber.length;
	}

	for (var i = length - 1; i >= 0; i--) {

		if (firstNumber.length > 0) {
			var firstNumDigit = firstNumber.pop() * 1;
		} else {
			firstNumDigit = 0;
		}

		if (secondNumber.length > 0) {
			secondNumDigit = secondNumber.pop() * 1;
		} else {
			secondNumDigit = 0;
		}		

		var sum = firstNumDigit + secondNumDigit + reminder;

		if (sum >= 10) {
			result.unshift(sum % 10);
			reminder = Math.floor(sum / 10);
		} else {
			result.unshift(sum);
			reminder = 0;
		}

		sum = 0;
	}

	return result.join('');
}

console.log(sumTwoHugeNumbers(['155', '65']));
console.log(sumTwoHugeNumbers(['123456789', '123456789']));
console.log(sumTwoHugeNumbers(['887987345974539','4582796427862587']));
console.log(sumTwoHugeNumbers(['347135713985789531798031509832579382573195807',
								'817651358763158761358796358971685973163314321']
));