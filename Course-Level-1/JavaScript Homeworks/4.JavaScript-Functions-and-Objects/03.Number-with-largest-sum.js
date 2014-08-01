function findLargestBySumOfDigits(nums) {
	var length = nums.length;
	var biggestSum = 0;
	var sum = 0;
	var index = 0;

	for (var i = 0; i < length; i++) {

		if (nums[i].toString().indexOf('.') == -1 || typeof(nums[i]) == Number) {
			var number = nums[i];

			if (number < 0) {
				number = number * -1;
			}

			while(number > 0) {
				var lastNumber = number % 10;
				sum += lastNumber;
				number = Math.floor(number / 10);
			}

			if (sum > biggestSum) {
				biggestSum = sum;
				index = i;
			}

			sum = 0;
		} else {
			return 'undefined';
		}
	}

	return nums[index];
}

console.log(findLargestBySumOfDigits([0.0, 10, 15, 111]));
console.log(findLargestBySumOfDigits([5, 10, 15, 111]));
console.log(findLargestBySumOfDigits([33, 44, -99, 0, 20]));
console.log(findLargestBySumOfDigits(['hello']));
console.log(findLargestBySumOfDigits([5, 3.3]));