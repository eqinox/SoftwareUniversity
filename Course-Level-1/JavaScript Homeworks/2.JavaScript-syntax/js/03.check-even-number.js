function getValue () {
	var input = document.getElementById('input').value;
	if (input % 2 == 1) {
		document.getElementById('output').innerHTML = true;	
	} else{
		document.getElementById('output').innerHTML = false;	
	};
	
}