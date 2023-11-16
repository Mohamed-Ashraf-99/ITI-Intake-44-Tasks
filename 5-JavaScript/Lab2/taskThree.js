str = function (lrg = ""){
    let afterSplit = lrg.split(" ");
    let bigWord = "";
    let len = 0;
    for(let i = 0 ; i < afterSplit.length ; i++)
    {
        if(afterSplit[i].length >= len)
        {
            len = afterSplit[i].length;
            bigWord = afterSplit[i];
        }
    }
    return bigWord;
}


