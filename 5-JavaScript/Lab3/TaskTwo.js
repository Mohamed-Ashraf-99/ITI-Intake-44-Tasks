const radius = parseInt(prompt(`Enter the radius of the circle`));
const area = Math.PI.toFixed(2) * Math.pow(radius, 2);
console.log(area);

const squareRootNum = parseInt(prompt(`Enter the number:`));
const squreRoot = Math.sqrt(squareRootNum).toFixed(2);
alert(`The square root of ${squareRootNum} = ${squreRoot}`);

// Convert from degrees to radians.
Math.radians = function(degrees) {
    return degrees * Math.PI / 180;
}

let angle = parseInt(prompt("Enter the angle :"));
const ang = Math.radians(angle);
let cosValue = Math.cos(ang).toFixed(2);
console.log(`The cosine value = ${cosValue}`);