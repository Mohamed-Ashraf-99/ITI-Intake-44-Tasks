let page = open("./page.html", "_target", "width = 100px, height = 100px");
page.focus();

let xDir = 250, yDir = 250;
let x = 0, y = 0;
const windowWidth = 1200;
const windowHeight = 400;


movement = setInterval(function () {
    x += xDir;
    y += yDir;
    if (x <= 0 || x >= windowWidth)
        xDir = (-1) * xDir;

    if (y <= 0 || y >= windowHeight)
        yDir = (-1) * yDir;
    page.moveTo(x, y);
}, 1000);

function pageStop(){
    clearInterval(movement);
    page.focus();
}