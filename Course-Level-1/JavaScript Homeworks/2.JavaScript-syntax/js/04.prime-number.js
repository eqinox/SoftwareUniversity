function getValue () {
	var input = document.getElementById('input').value;
	var maxCycle = Math.floor(Math.sqrt(input));
	var prime = false;
	for (var i = 2; i <= maxCycle; i++) {
		if (input % i == 0) {
			prime = false;
			break;
		} else{
			prime = true;
		};
	};
	document.getElementById('output').innerHTML = "is prime? - " + prime;
}