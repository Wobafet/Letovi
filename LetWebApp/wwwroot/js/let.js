"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/lethub").build();


//connection.on("addNewReservation", function (rez) {


//         $("tbody").append("<tr>" +
//        "<td>" + rez.email+ "</td>" +
//        "<td>" + rez.mestoPolaska + "</td>" +
//        "<td>" + rez.mestoDolaska + "</td>" +
//        "<td>" + rez.brojMesta + "</td>" +
//        "<td>" + rez.datum + "</td>" +
//        "<td><span class='btn btn - link' onclick='allowReservation("+rez.letId+","+rez.korisnikId+")'>Odobri</span></td>" +
//        + "</tr>");
//});


connection.on("updateStatus", function (letId, korisnikId) {

    var tekst = letId*10 + '' + korisnikId;
    var row = $(`#${tekst}`);

    console.log(tekst);
    // row.find('td:eq(5)').html("Odobren");
    row.html("Odobren")
});

connection.on("deleteFlight", function (letId) {

    removeFlightFromTable(letId);
});
function removeFlightFromTable(letId) {
    $("tbody tr").each(function () {
        var row = $(this);
        var rowId = this.id;
        console.log(rowId);
        if (rowId==letId)
            row.attr("hidden", true);

    })

}


connection.start().then(function () {

    console.log("Start...");
}).catch(function (err) {
    return console.error(err.tostring());
});
