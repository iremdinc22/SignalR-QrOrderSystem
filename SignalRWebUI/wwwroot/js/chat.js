var connection = new signalR.HubConnectionBuilder()
    .withUrl("http://localhost:5247/signalrhub")
    .build();

document.getElementById("sendbutton").disabled = true;

connection.on("ReceiveMessage", function(user, message) {
    var currentTime = new Date();
    var currentHour = currentTime.getHours();
    var currentMinute = currentTime.getMinutes();

    var li = document.createElement("li");
    var span = document.createElement("span");
    span.style.fontWeight = "bold";
    span.textContent = user + ": ";
    li.appendChild(span);
    li.innerHTML += `${message} - ${currentHour}:${currentMinute}`;
    document.getElementById("messagelist").appendChild(li);
});

connection.start().then(function () {
    document.getElementById("sendbutton").disabled = false;

    // (Daha önce ikinci start() içindeydi) — sadece buraya taşıdım
    document.getElementById("sendbutton").addEventListener("click", function (event) {
        var user = document.getElementById("userinput").value;
        var message = document.getElementById("messageinput").value;
        connection.invoke("SendMessage", user, message).catch(function (err) {
            return console.error(err.toString());
        });
        event.preventDefault();
    });

}).catch(function (err) {
    return console.error(err.toString());
});

    


