function changeColor () {
	var anchor = document.getElementById('anchor');

	if (anchor.innerText == 'Like') {
		anchor.innerText = 'Unlike';
	}else{
		anchor.innerText = 'Like';
	}


}