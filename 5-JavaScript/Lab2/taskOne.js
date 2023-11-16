//1.1-)

let str = prompt(`Enter your string!`);
let ch = prompt(`Enter the character`);
let upperOrLower = prompt(`Case sensitive yes || no ?`);
let counter = 0;
let upper = ch.toUpperCase();

switch (upperOrLower)
{
    case 'yes':
        for(let i = 0 ; i < str.length ; i++)
            if(str[i] === ch || str[i] === upper ) counter++;
        break;
    case 'no':
        for(let i = 0 ; i < str.length ; i++)
            if(str[i] === ch) counter++;
        break;
}
console.log(counter);