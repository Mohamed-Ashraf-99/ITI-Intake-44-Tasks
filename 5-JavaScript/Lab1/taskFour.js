rangeDisplay = function (x,y,z)
{
    x = parseInt(prompt(`Enter the first num`,x));
    y = parseInt(prompt(`Enter the second num`,y));
    z =(prompt(`odd or even or no`,z));
    var sum = 0;
    if(z === "odd")
    {
        if(x < y)
        {
            for (let i = x; i <= y; i++) {
                if (i % 2 !== 0) {
                    console.log(i);
                    sum += i;
                }
            }
        }
        if(x > y)
        {
            for (let i = x; i >= y; i--)
            {
                if (i % 2 !== 0)
                {
                    console.log(i);
                    sum += i;
                }
            }
        }
        console.log(`Sum of nums = ${sum}`);
    }
    else if(z  === "even")
    {
        if(x > y)
        {
            for(let i = x ; i >= y ; i--)
            {
                if(i % 2 === 0)
                {
                    console.log(i);
                    sum += i;
                }
            }
        }
        if(x < y)
        {
            for(let i = x ; i <= y ; i++)
            {
                if(i % 2 === 0)
                {
                    console.log(i);
                    sum += i;
                }
            }
        }

        console.log(`Sum of nums = ${sum}`);
    }
    else if(z === "no")
    {
        if(x < y)
        {
            for(let i = x ; i <= y ; i++)
            {
                console.log(i);
                sum += i;
            }
        }
        if(x > y)
        {
            for(let i = x ; i >= y ; i--)
            {
                console.log(i);
                sum += i;
            }
        }

        console.log(`Sum of nums = ${sum}`);
    }
}

rangeDisplay();