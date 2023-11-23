const arr = [5];
for(let i = 1 ; i <= 5 ; i++){
    arr[i] = parseInt(prompt(`Enter the number ${i}`));
}
// Ascending
arr.sort((a,b) => a - b);
console.log(arr);

// Descending
arr.sort((a,b) => b - a);
console.log(arr);
