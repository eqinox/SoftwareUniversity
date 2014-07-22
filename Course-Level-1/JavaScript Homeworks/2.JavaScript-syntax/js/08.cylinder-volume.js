function getValue(){
	var radius = document.getElementById('first').value;
	var height = document.getElementById('second').value;

	document.getElementById('output').innerHTML = (Math.PI * radius * radius * height).toFixed(3);

    

}