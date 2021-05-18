//1.
let salaries = {
    John: 100,
    Ann: 160,
    Pete: 130
}
let sumSalary = 0;
let values = Object.values(salaries);
for (var i = 0; i < values.length; i++) {
    sumSalary += parseFloat(values[i]);
}

console.log("sum =" + sumSalary);
//2.
let menu = {
    width: 200,
    height: 300,
    title: "My menu"
};

function multiplyNumeric(object) {
   
    for (var property in object) {

        if (typeof (object[property]) == "number" )
        object[property] *= 2;
        console.log(`${property}: ${object[property]}`);
    }
}
multiplyNumeric(menu)
console.log(menu)
//3.

function checkEmailId(str) {
    const re = /^[a-zA-Z0-9]+@[a-zA-Z0-9]+\.[a-zA-Z0-9]+$/is
    return (re.test(str));

    

}
console.log(checkEmailId("fmai@gmail.com"));
console.log(checkEmailId("adad2123.213.132ads@gmailco.m"));
console.log(checkEmailId("wadawd@awd"));


//4. 
function truncate(str, maxlength) {
    if (str.length > maxlength) {
        str = str.slice(0, 19)
        str += "…";
    }
    return str;
}
console.log(truncate("What I'd like to tell on this topic is:", 20))
console.log(truncate("Hi everyone!", 20))
//5. 
//a
let names = ['James', 'Brennie']
console.log(names)
//b
names.push("Robert")
console.log(names)
//c
names[(names.length - 1) / 2] = "Calvin";
console.log(names)
//d.
console.log(names.shift())
console.log(names)
//e.
names.unshift("Regal");
names.unshift("Rose");
console.log(names)
//6.
function validCards(card, bannedPrefixes) {
    console.log(card);
    ArrayCard = card.split('')
    let last = ArrayCard.pop();
    let sum = 0;

    for (var i = 0; i < ArrayCard.length; i++) {
        sum += ArrayCard[i] * 2;
    }
    let isValid = (sum % 10 == last)

    let isAllowed = true;
    for (var j in bannedPrefixes) {
        if (card.slice(0, j.length + 1) == j) {
            isAllowed = false;
        }
    }
    let ArrayPrefixes = bannedPrefixes.split(',')
    console.log(isAllowed);
    return {
        "card": card,
        "isValid": isValid,
        "isAllowed": isAllowed
    }
}
console.log(validCards('6724843711060148', '11, 3434, 67453, 9'))
//7.
function checkEmailId2(str) {
    const re = /^[a-z]{1,6}\_*[0-9]{0,4}@hackerrank.com$/is
    return (re.test(str));



}
console.log(checkEmailId2("julia@hackerrank.com"));
console.log(checkEmailId2("julia_@hackerrank.com"));
console.log(checkEmailId2("julia_0@hackerrank.com"));
console.log(checkEmailId2("julia0_@hackerrank.com"))
console.log(checkEmailId2("julia@gmail.com"))