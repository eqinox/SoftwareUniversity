function getValue () {
	var input = document.getElementById('input').value;
	var maxCycle = Math.floor(Math.sqrt(input));
	var prime = false;
	if (input % 3 == 0) {
		document.getElementById('output').innerHTML = "the number is divided by 3 without remainder";
	} else{
		document.getElementById('output').innerHTML = "the number is not divided by 3 without remainder";
	};
	
}