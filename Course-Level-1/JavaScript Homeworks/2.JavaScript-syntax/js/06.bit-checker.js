
function getValue () {
	var input = document.getElementById('input').value;

	var mask = 1 << 3;
	var bit = (mask & input) >> 3;
	alert(bit);

	document.getElementById('output').innerHTML = "";
}