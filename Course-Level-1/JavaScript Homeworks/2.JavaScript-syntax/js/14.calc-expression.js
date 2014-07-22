function getValue () {
	var number = document.getElementById('input').value;
	var result = eval(number);
	document.getElementById('output').innerHTML = result;
}