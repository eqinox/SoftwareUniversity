function getValue () {
	var input = document.getElementById('input').value;
	var output = input / 0.745699872;
	document.getElementById('output').innerHTML = output.toFixed(2);
}