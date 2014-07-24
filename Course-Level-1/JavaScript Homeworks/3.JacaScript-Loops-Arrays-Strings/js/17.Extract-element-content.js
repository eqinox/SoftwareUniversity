function extractContent (value) {
	var text = "";
	var inTag = false;
	for (var i = 0; i < value.length; i++) {
		var symbol = value[i];

		if (symbol == "<") {
			while(symbol != ">"){
				i++;
				symbol = value[i];
			}
		}
		else{
			text += symbol;	
		}
		
	}
	return text;

}
console.log(extractContent("<p>Hello</p><a href='http://w3c.org'>W3C</a>"));