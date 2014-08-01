function findMostFreqWord (value) {
	value = value.toLowerCase();
	var pattern = RegExp("[a-z]+", "g");
	var words = value.match(pattern);
	var repeatedWords = [];
	for (var id in words) {
		if (words[id] in repeatedWords) {
			repeatedWords[words[id]]++;
		}else{
			repeatedWords[words[id]] = 1;
		}
	}
	
	var mostFreqWords = [];
	for (var id in repeatedWords) {
		if (repeatedWords[id] > 1) {
			mostFreqWords.push(id + " -> " + repeatedWords[id]);
		}
	}
	mostFreqWords.sort();
	return mostFreqWords;
}


console.log(findMostFreqWord('Hello my friend, hello my darling. Come on, come here. Welcome, welcome darling.'));