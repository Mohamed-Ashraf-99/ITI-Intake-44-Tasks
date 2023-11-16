
//1.3
numChecks = function(x,y,z)
{
    x = parseInt(prompt(`Enter the first num`,x));
    y = parseInt(prompt(`Enter the first num`,y));
    z =parseInt(prompt(`Enter the first num`,z));
    if(x % y === 0 && x % z !== 0)
    {
        console.log(`${x} is divisible by ${y} only`);
    }
    else if(x % z === 0 && x % y !== 0)
    {
        console.log(`${x} is divisible by ${z} only`);
    }
    else if(x % z === 0 && x % y === 0)
    {
        console.log(`${x} is divisible by both ${y} and ${z}`);
    }
};

numChecks();