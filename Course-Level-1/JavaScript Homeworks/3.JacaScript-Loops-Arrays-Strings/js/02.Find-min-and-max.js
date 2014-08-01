function findMinAndMax (value) {
	var min = Number.MAX_VALUE;
	var max = Number.MIN_VALUE;

	for (var id in value) {
		if (value[id] < min) {
			min = value[id];
		}
		if (value[id] > max) {
			max = value[id];
		}
	}


	return min + "  " + max;
}


console.log(findMinAndMax([1, 2, 1, 15, 20, 5, 7, 31]));
console.log(findMinAndMax([2, 2, 2, 2, 2]));
console.log(findMinAndMax([500, 1, -23, 0, -300, 28, 35, 12]));