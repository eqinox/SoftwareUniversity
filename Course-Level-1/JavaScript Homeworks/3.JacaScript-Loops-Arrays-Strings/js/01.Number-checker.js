function printNumbers (value) {
	var result = "";
	for (var i = 1; i < value; i++) {
		if (!(i % 4 == 0 || i % 5 == 0)) {
			result += i + "\r\n";
		}
	}
	return result;
}


console.log(printNumbers(20));