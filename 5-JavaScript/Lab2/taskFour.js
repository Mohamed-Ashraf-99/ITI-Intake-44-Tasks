//Name Validation
let nameInput = prompt(`Enter your name`);
let nameExp = /^[a-zA-Z]+$/;
let nameValidOrNot = nameExp.test(nameInput);
console.log(nameValidOrNot);

if(nameValidOrNot) console.log(`Valid`);
 else console.log(`Not Valid!`);

/////////////////////////////////////////////

//Phone Validation
let  phoneInput = prompt(`Enter your phone`);
let phoneExp = /^[0-9]{8}$/;
let phoneValidOrNot = phoneExp.test(phoneInput);
console.log(phoneValidOrNot);

if(phoneValidOrNot) console.log(`Valid`);
else console.log(`Not Valid!`);

///////////////////////////////////////////////

//Phone Validation 01
let  phoneInput2 = prompt(`Enter your phone 01`);
let phoneExp2 = /^01[0-2]{1}[0-9]{8}$/;
let phoneValidOrNot2 = phoneExp2.test(phoneInput2);
console.log(phoneValidOrNot2);

if(phoneValidOrNot2) console.log(`Valid`);
else console.log(`Not Valid!`);

///////////////////////////////////////////////

//Email Validation
let emailInput = prompt(`Enter your mail!`);
let emailExp = /[a-zA-Z0-9]+@[a-zA-Z]+\.com/;
let emailValidOrNot = emailExp.test(emailInput);
console.log(emailValidOrNot);

if(emailValidOrNot) console.log(`Valid`);
else console.log(`Not Valid!`);

///////////////////////////////////////

let colorInput = prompt(`Enter your Color !`);
let colorExp;
let colorValidOrNot;
switch (colorInput)
{
    case `red`:
        colorExp = /red/;
        colorValidOrNot = colorExp.test(colorInput);
        console.log(colorValidOrNot);
        break;
    case `green`:
        colorExp = /green/;
        colorValidOrNot = colorExp.test(colorInput);
        console.log(colorValidOrNot);
        break;
    case `blue`:
        colorExp = /blue/;
        colorValidOrNot = colorExp.test(colorInput);
        console.log(colorValidOrNot);
        break;
    default:
        console.log(`Not Valid!`);
        break;
}


