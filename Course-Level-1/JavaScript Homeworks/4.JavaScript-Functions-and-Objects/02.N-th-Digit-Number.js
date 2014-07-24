function findNthDigit (value) {

	var inputAsString = value[1].toString();
	var improvedInput = removeDots(inputAsString);

	for (var i = improvedInput.length - 1, j = 1; i >= 0; i--, j++) {
		if (j == value[0]) {
			return improvedInput[i];
		}
	}

	return improvedInput;


}


function removeDots (value) {
	var result = "";
	for (var i = 0; i < value.length; i++) {
		if (value[i] != "." && value[i] != "-") {
			result += value[i];
		}
	}
	return result;
}

console.log(findNthDigit([1, 6]));
console.log(findNthDigit([2, -55]));
console.log(findNthDigit([6, 923456]));
console.log(findNthDigit([3, 1451.78]));