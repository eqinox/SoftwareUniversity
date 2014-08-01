var persons = [];
    persons.push(new Person("Scott", "Guthrie", 38));
    persons.push(new Person("Scott", "Johns", 36));
    persons.push(new Person("Scott", "Hanselman", 39));
    persons.push(new Person("Jesse", "Liberty", 57));
    persons.push(new Person("Jon", "Skeet", 38));

console.log('Sorted by firstName:')
group(persons, 'firstname');
console.log('Sorted by lastName:');
group(persons, 'lastname');
console.log('Sorted by age:');
group(persons, 'age');

function Person(firstName, lastName, age) {
	return {
		firstName: firstName,
		lastName: lastName,
		age: age
	}
}

Person.prototype = { constructor: Person };

function group(persons, key) {
	switch(key) {
		case 'firstname':
			var array = [];
			var obj = {};
			var name = persons[0].firstName;
			var innerArray = [];

			for (var i = 0; i < persons.length; i++) {				
				if (name == persons[i].firstName) {					
					innerArray.push(persons[i].firstName + ' '
									+ persons[i].lastName + '(age '
									+ persons[i].age + ')');
				} else {
					array.push(innerArray);
					obj[name] = innerArray;
					innerArray = [];
					innerArray.push(persons[i].firstName + ' '
									+ persons[i].lastName + '(age '
									+ persons[i].age + ')');
					name = persons[i].firstName;
				}
			}

			array.push(innerArray);

			if (name in obj) {
				obj[name].push(innerArray);
			} else {
				obj[name] = innerArray;
			}

			for (var item in obj) {
				console.log('Group ' + item + ' : [ ' + obj[item].join(', ') + ' ]');
			}
			console.log();
			break;

		case 'lastname' :
			var array = [];
			var obj = {};
			var name = persons[0].lastName;
			var innerArray = [];

			for (var i = 0; i < persons.length; i++) {				
				if (name == persons[i].lastName) {					
					innerArray.push(persons[i].firstName + ' '
									+ persons[i].lastName + '(age '
									+ persons[i].age + ')');
				} else {
					array.push(innerArray);
					obj[name] = innerArray;
					innerArray = [];
					innerArray.push(persons[i].firstName + ' '
									+ persons[i].lastName + '(age '
									+ persons[i].age + ')');
					name = persons[i].lastName;
				}
			}

			array.push(innerArray);

			if (name in obj) {
				obj[name].push(innerArray);
			} else {
				obj[name] = innerArray;
			}

			for (var item in obj) {
				console.log('Group ' + item + ' : [ ' + obj[item].join(', ') + ' ]');
			}
			console.log();
			break;

		case 'age' :
			var array = [];
			var obj = {};
			var name = persons[0].age;
			var innerArray = [];

			for (var i = 0; i < persons.length; i++) {				
				if (name == persons[i].age) {					
					innerArray.push(persons[i].firstName + ' '
									+ persons[i].lastName + '(age '
									+ persons[i].age + ')');
				} else {
					array.push(innerArray);
					obj[name] = innerArray;
					innerArray = [];
					innerArray.push(persons[i].firstName + ' '
									+ persons[i].lastName + '(age '
									+ persons[i].age + ')');
					name = persons[i].age;
				}
			}

			array.push(innerArray);

			if (name in obj) {
				obj[name].push(innerArray);
			} else {
				obj[name] = innerArray;
			}

			for (var item in obj) {
				console.log('Group ' + item + ' : [ ' + obj[item].join(', ') + ' ]');
			}
			console.log();
			break;					
	}
}