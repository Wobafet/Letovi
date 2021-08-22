"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/lethub").build();


connection.on("addNewReservation", function (rez) {


    $("tbody").append("<tr>" +
        "<td>" + rez.email + "</td>" +
        "<td>" + rez.mestoPolaska + "</td>" +
        "<td>" + rez.mestoDolaska + "</td>" +
        "<td>" + rez.brojMesta + "</td>" +
        "<td>" + rez.datum + "</td>" +
        "<td><span class='btn btn - link' onclick='allowReservation(" + rez.letId + "," + rez.korisnikId + ")'>Odobri</span></td>" +
        + "</tr>");
});

connection.start().then(function () {

    console.log("Start..rezervacije");
}).catch(function (err) {
    return console.error(err.tostring());
});