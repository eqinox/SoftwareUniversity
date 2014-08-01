function reverseString(value) {
    var reversedStr = '';
 
    for (var i = value.length  - 1; i >= 0; i -= 1) {
        reversedStr += value[i];
    }
 
    return reversedStr;
}
 
console.log(reverseString('sample'));
console.log(reverseString('softUni'));
console.log(reverseString('java script'));