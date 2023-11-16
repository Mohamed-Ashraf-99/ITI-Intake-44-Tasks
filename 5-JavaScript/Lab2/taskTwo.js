let str = prompt(`Enter your string`);
let upperOrLower = prompt(`Case sensitive yes || no ?`);
let rev = "";
let flag = 0;

for (let i = str.length - 1; i >= 0; i--) rev += str[i];

switch (upperOrLower)
{
    case 'yes':
        let upper = rev.toUpperCase();
        for(let i = 0 ; i < str.length ; i++)
            if(str[i] === rev[i] || str[i] === upper[i]) flag = 1;
        break;
    case 'no':
        for(let i = 0 ; i < str.length ; i++)
            str[i] === rev[i] ? flag = 1 : flag = 0;
        break;
}

if(flag) console.log(`palindrome`);
else console.log(`Not palindrome`);

