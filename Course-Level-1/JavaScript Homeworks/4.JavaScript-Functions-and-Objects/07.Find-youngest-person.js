function findYoungestPerson(persons) {
	var index = 0;
	var minAges = Number.MAX_VALUE;
	var opit = Number.MIN_VALUE;

	for (var i = 0; i < persons.length; i++) {
		if (persons[i].age < minAges ) {
			minAges = persons[i].age;
			index = i;
		}
	}

	console.log('The youngest person is ' + persons[index].firstname +
				 ' ' + persons[index].lastname);
}

var persons = [
	{ firstname : 'George', lastname: 'Ivanov', age: 56},
	{ firstname : 'George', lastname: 'Kolev', age: 32}, 
	{ firstname : 'Bay', lastname: 'Ivan', age: 81},
	{ firstname : 'Baba', lastname: 'Ginka', age: 40}]

findYoungestPerson(persons);