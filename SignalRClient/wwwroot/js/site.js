"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("http://localhost:7409/MessageHub").build();

connection.on("ReceiveMessage", function (message) {
    $('.list-group-item.active').removeClass("active");
    $("#messagesList").append($("<li class='list-group-item active'>" + message + "</li>"));
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