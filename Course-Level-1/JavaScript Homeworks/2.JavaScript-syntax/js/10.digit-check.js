function getValue(){
	var num = document.getElementById('input').value;

	var mask = 1 << 3;
	var numAndMast = num & mask;
	var bit = numAndMast >> 3;

	alert("third bit is: " + bit);
}