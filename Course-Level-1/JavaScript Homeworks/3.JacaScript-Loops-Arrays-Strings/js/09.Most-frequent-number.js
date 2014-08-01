function findMostFreqNum(value) {
 
    var mostFreq = 1;
    var number = value[0];
 
    var currentLength = 0,
        maxLength = 0;
 
    for (var i = 0; i < value.length; i+=1) {
 
        for (var j = i; j < value.length; j+=1) {
            if(value[i] === value[j]) {
                currentLength += 1;
            }
        }
        if(mostFreq < currentLength) {
            mostFreq = currentLength;
            number = value[i];
        }
 
        currentLength = 0;
    }
 
    console.log(number + ' (' + mostFreq + ' times)');
 
}
 
findMostFreqNum([4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3]);
findMostFreqNum([2, 1, 1, 5, 7, 1, 2, 5, 7, 3, 87, 2, 12, 634, 123, 51, 1]);
findMostFreqNum([1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13]);