"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/lethub").build();


connection.on("addNewReservation", function (rez) {


    //$("tbody").append("<tr>" +
    //    "<td>" + rez.korisnik.email+ "</td>" +
    //    "<td>" + rez.let.mestoPolaska + "</td>" +
    //    "<td>" + rez.let.mestoDolaska + "</td>" +
    //    "<td>" + rez.brojMesta + "</td>" +
    //    "<td>" + rez.let.datum + "</td>" +
    //    "<td><span class='btn btn - link' onclick='allowReservation("+rez.letId+","+rez.korisnikId+")'>Odobri</span></td>" +
    //    + "</tr>");

         $("tbody").append("<tr>" +
        "<td>" + rez.email+ "</td>" +
        "<td>" + rez.mestoPolaska + "</td>" +
        "<td>" + rez.mestoDolaska + "</td>" +
        "<td>" + rez.brojMesta + "</td>" +
        "<td>" + rez.datum + "</td>" +
        "<td><span class='btn btn - link' onclick='allowReservation("+rez.letId+","+rez.korisnikId+")'>Odobri</span></td>" +
        + "</tr>");
});


connection.on("updateStatus", function (letId, korisnikId) {

    var tekst = letId + '' + korisnikId;
    var row = $(`#${tekst}`);

    console.log(tekst);
    row.find('td:eq(5)').html("Odobren");

});


connection.on("Poruka", function (rezervacija) {

    console.log(rezervacija);
});

connection.start().then(function () {

    console.log("Start...");
}).catch(function (err) {
    return console.error(err.tostring());
});

/*document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});*/