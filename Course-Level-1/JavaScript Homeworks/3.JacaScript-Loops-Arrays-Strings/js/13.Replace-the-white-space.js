function replaceSpaces (value) {
	var pattern = RegExp(" ", 'g');
	var match = value.replace(pattern, '');
	return match;
}


console.log(replaceSpaces("But you were living in another world tryin' to get your message through"))