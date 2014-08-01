function reverseWordsInString(str) {
	var words = str.split(' ');
	var length = words.length;

	for (var i = 0; i < length; i++) {
		var text = '';

		for (var j = words[i].length - 1; j >= 0 ; j--) {
			text += words[i][j];
		}

		words[i] = text;
	}

	return words.join(' ');
}

console.log(reverseWordsInString('Hello, how are you.'));
console.log(reverseWordsInString('Life is pretty good, isn’t it?'));