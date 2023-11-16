//1.2
numRetrive = function()
{
    while (true)
    {
        var userNum = prompt(`Enter the value:`);

        if (userNum === null)
        {
            return null;
        }

        return parseInt(userNum);
    }
}

sum = function()
{
    var totalSum = 0;

    while (totalSum <= 100)
    {
        var value = numRetrive();

        if (value === null)
        {
            return null;
        }

        totalSum += value

        if (totalSum > 100)
        {
            console.log(`Sum exceeds 100`);
        }
    }
    console.log(`Sum of values:  ${totalSum}`);
}

sum();