function sortArray(value) {
    for(var i = 0; i < value.length; i+=1) {
        var indexOfMinElement = i;
        for(var j = i + 1; j < value.length; j+=1) {
            if(value[indexOfMinElement] > value[j]) {
                indexOfMinElement = j;
            }
        }
        if (indexOfMinElement !== i) {
            var temp = value[i];
            value[i] = value[indexOfMinElement];
            value[indexOfMinElement] = temp;
        }
    }
 
    return value;
}
 
console.log(sortArray([5, 4, 3, 2, 1]));
console.log(sortArray([12, 12, 50, 2, 6, 22, 51, 712, 6, 3, 3]));