const getData = window.location.search;
const Data = getData.split("&");

for(let i=0; i < Data.length ; i++){
    display = Data[i].split("=")[1];
    document.querySelector('#userData').innerHTML += display + '<br>';
}