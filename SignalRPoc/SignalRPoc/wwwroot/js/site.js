"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/MessageHub").build();

connection.on("ReceiveMessage", function (message) {
    $("#messagesList").append($("<li class='list-group-item'>" + message + "</li>"));
});

connection
    .start()
    .then(function(){
        connection
            .invoke("GetMessage")
            .catch(function (err) {
                return console.error(err.toString());
            });
    }).catch(function (err) {
        return console.error(err.toString());
    });