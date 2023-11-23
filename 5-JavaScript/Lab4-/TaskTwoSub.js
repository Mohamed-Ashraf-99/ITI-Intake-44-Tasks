
let textMessage = document.querySelector('.text');
let message = "Welcome--to--Ashraf's--Page";
let mess =  message.split("");
let counter = 0;

write = setInterval(function (){
    if(counter !== mess.length){
        textMessage.innerText += mess[counter];
        counter++;
    }
    else
        window.close();
},500);