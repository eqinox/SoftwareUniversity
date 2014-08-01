function findMaxSequence(value) {
    var maxLength = 1;
    var length = 1;
    var result = value[0];
 
    for (var i = 0; i < value.length; i+=1) {
        if(value[i] === value[i+1]) {
            length++;
        }
 
        else {
            if (maxLength <= length) {
                maxLength = length;
                result = value[i];
            }
 
            length = 1;
        }
    }
 
    var arr = [];
 
    for( i= 0; i < maxLength; i+=1) {
        arr[i] = result;
    }
 
    return arr;
}
 
 
console.log(findMaxSequence([2, 1, 1, 2, 3, 2, 2, 2, 1]));
console.log(findMaxSequence(['happy']));
console.log(findMaxSequence([2, 'qwe', 'qwe', 3, 3, '3']));