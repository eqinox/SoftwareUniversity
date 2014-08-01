function findMaxSequence(value) {
    var exist = false;
 
    var indexMaxSequence;
 
    var currentLength = 0,
        maxLength = 0;
 
    for (var i = 0; i < value.length; i+=1) {
        if(value[i] < value[i+1]) {
            currentLength += 1;
            exist = true;
        }
 
        else {
            if(maxLength < currentLength) {
                maxLength = currentLength;
                indexMaxSequence = i - maxLength;
            }
 
            currentLength = 0;
        }
    }
 
    var result = [];
 
    for(i = 0; i <= maxLength; i+=1) {
        result[i] = value[i + indexMaxSequence];
    }
 
    return exist ? result : 'no';
}
 
console.log(findMaxSequence([3, 2, 3, 4, 2, 2, 4]));
console.log(findMaxSequence([3, 5, 4, 6, 1, 2, 3, 6, 10, 32]));
console.log(findMaxSequence([3, 2, 1]));