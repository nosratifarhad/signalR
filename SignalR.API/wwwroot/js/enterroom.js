"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/onlineclienthub").build();

connection.start().then(function () {
    console.log("Connection started successfully");
}).catch(function (err) {
    return console.error(err.toString());
});

connection.on("RecieveDBUpdates", function (date) {
    let myString = JSON.stringify(date.result);
    document.getElementById("demo").innerHTML = myString;
});
function myFunction(value, index, array) {
    txt += value + "<br>";
}