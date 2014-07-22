function getValue () {
	var input = document.getElementById('input').value;
	var rounded = Math.round(input);
	var floored = Math.floor(input);
	document.getElementById('output').innerHTML = floored + "<br />" + rounded;
}