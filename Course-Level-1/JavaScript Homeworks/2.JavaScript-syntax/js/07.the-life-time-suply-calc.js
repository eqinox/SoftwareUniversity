function getValue(){
	var first = document.getElementById('first').value;
	var second = document.getElementById('second').value;
	var third = document.getElementById('third').value;

    var foods = ["chocolate", "nuts", "fruits", "vegetables", "candies", "pizza", "burgers"];
    var dayLeft = (second - first) * 365;
    var allfood = dayLeft * third;
    document.getElementById('output').innerHTML = allfood + "kg of " + foods[Math.floor((Math.random() * 7))] + " would be enough until I am " + second + " years old.";

}