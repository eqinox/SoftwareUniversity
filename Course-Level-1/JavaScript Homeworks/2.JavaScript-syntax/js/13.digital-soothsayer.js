function soothsayer (years, professions, towns, cars) {
	var year = years[Math.floor(Math.random() * years.length)];
	var profession = professions[Math.floor(Math.random() * professions.length)];
	var town = towns[Math.floor(Math.random() * 4)];
	var car = cars[Math.floor(Math.random() * 4)];
	var asd = "you will work " + year + " years on " + profession + "\r\nyou will live in " + town + "and drive " + car;
	return asd;
}

console.log(soothsayer([3, 5, 2,  7, 9], ['Java', 'Pyton', 'C#', 'JavaScript', 'Ruby'],
 ['Silicon Valley', 'London', 'Las Vegas', 'Paris', 'Sofia'], 
 ['BMW', 'Audi', 'Lada', 'Skoda', 'Opel']));


