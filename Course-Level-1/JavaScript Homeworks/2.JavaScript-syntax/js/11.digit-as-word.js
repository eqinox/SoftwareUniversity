function getValue() {
	var num = Number(document.getElementById('input').value);
    switch (num) {
        case 0: document.getElementById('output').innerHTML =  "zero"; break;
        case 1: document.getElementById('output').innerHTML =  "one"; break;
        case 2: document.getElementById('output').innerHTML =  "two"; break;
        case 3: document.getElementById('output').innerHTML =  "three"; break;
        case 4: document.getElementById('output').innerHTML =  "four"; break;
        case 5: document.getElementById('output').innerHTML =  "five"; break;
        case 6: document.getElementById('output').innerHTML =  "six"; break;
        case 7: document.getElementById('output').innerHTML =  "seven"; break;
        case 8: document.getElementById('output').innerHTML =  "eight"; break;
        case 9: document.getElementById('output').innerHTML =  "nine"; break;
        default: document.getElementById('output').innerHTML =  "This number is too big"; break;
    }
}
