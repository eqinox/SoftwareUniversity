
1
2
3
4
5
6
7
8
9
10
11
12
13
14
15
16
17
18
19
20
21
22
23
24
function compareChars(arr1, arr2) {
    if (arr1.length != arr2.length) {
        return "Not Equal";
    }

    var areEqual = true;

    for (var i = 0; i < arr1.length; i++) {
        if (arr1[i] != arr2[i]) {
            areEqual = false;
            break;
        }
    }

    if (areEqual) {
        return "Equal";
    }
    else {
        return "Not Equal";
    }
}

console.log(compareChars(['1', 'f', '1', 's', 'g', 'j', 'f', 'u', 's', 'q'], ['1', 'f', '1', 's', 'g', 'j', 'f', 'u', 's', 'q']));
console.log(compareChars(['3', '5', 'g', 'd'], ['5', '3', 'g', 'd']));
console.log(compareChars(['q', 'g', 'q', 'h', 'a', 'k', 'u', '8', '}', 'q', '.', 'h', '|', ';'], ['6', 'f', 'w', 'q', ':', '”', 'd', '}', ']', 's', 'r']));