function getValue() {
	var a = document.getElementById('first').value;
	var b = document.getElementById('second').value;
    areaHouse = a * a +((a*(a*2/3)))/2;
    areaTree = b * (b / 3) + ((b / 3* 2) * (b / 3* 2) * Math.PI);
    document.getElementById('output').innerHTML = areaHouse > areaTree? "house/" + areaHouse.toFixed(2): "tree/" + areaTree.toFixed(2);
}