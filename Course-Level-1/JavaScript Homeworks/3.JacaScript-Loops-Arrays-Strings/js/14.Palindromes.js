function findPalindromes(value) {
    value = value.toLowerCase();
    var pattern = RegExp("[a-z]+", "g");
    var words = value.match(pattern);
    var result = "";
    var palindromes = [];
    for (var key in words) {
        var word = words[key];
        if (checkWord(word)) {
            palindromes.push(word);
        }
    }

    return palindromes.join(', ');

}

console.log(findPalindromes('There is a man, his name was Bob.'));



function checkWord (word) {
    var newWord = "";
    for (var i = word.length - 1; i >= 0; i--) {
        newWord += word[i];
    }
    if (newWord == word) {
        return true
    } else{
        return false;
    }
}
