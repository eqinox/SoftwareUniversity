function replaceATag (value) {
	var pattern = RegExp(/<a(.+)>(.+)<\/a>/gi);
	var test = value.replace(pattern, "[URL= $1]$2[/URL]")
	return test;
}


console.log(replaceATag('<ul> <li>  <a href=http://softuni.bg>SoftUni</a> </li></ul>'))