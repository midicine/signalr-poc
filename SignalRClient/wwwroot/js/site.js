"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("http://localhost:7409/MessageHub").build();

connection.on("ReceiveMessage", function (message) {
    $("#messagesList").append($("<li class='list-group-item'>" + message + "</li>"));
});

connection
    .start()
    .then(function(){
        
    }).catch(function (err) {
        return console.error(err.toString());
    });

$("#btn").click(function() {
    connection
        .invoke("GetMessage")
        .catch(function (err) {
            return console.error(err.toString());
        });
});