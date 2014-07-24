function extractContent(value){
    var text = "";
    for(var i = 0; i < value.length; i += 1){
        var symbol = value[i];
        if(symbol == ">"){
            i++;
            do{
                symbol = value[i];
                text += symbol;
                i++;
                symbol = value[i];
            }while(symbol != "<")
        }
        else{
            continue;
        }
    }
    console.log(text);
    return text;
}
extractContent("'<p>Hello</p><a href='http://w3c.org'>W3C</a>'");