var a = {name: 'Pesho', age: 21} 
var b = clone(a); // a deep copy 
compareObjects(a, b);  

var a = {name: 'Pesho', age: 21} ;
var b = a; // not a deep copy
compareObjects(a, b);

function clone(input) {
	return input = JSON.parse(JSON.stringify(input));
}

function compareObjects(a, b) {
	console.log('a == b --> ' + (a == b));
}