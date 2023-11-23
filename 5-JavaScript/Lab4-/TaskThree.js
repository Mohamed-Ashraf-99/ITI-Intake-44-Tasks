let textMessage = document.querySelector('.text');
let y = 100;
let openPage = function (){
    page = open("TaskThreeSub.html", "_target", "width = 250px, height = 250px");
    page.focus();
}

setInterval(function () {
    page.scrollBy(0, y);
    y += 100;
}, 3000);

