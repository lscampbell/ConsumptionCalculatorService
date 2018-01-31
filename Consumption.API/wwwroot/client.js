(function(){
    var connection = new WebSocketManager.Connection("ws://" + location.host + "/consumption");
    connection.enableLogging = true;
    
    connection.connectionMethods.onConnected = () => {
        //optional
        console.log("You are now connected! Connection ID: " + connection.connectionId);
    }
    
    connection.connectionMethods.onDisconnected = () => {
        //optional
        console.log("Disconnected!");
    }
    
    connection.clientMethods["receiveMessage"] = (socketId, message) => {
        var messageText = socketId + " said: " + message;
    
        console.log(messageText);
        appendItem(list, message);
    };
    
    connection.start();
    
    var list = document.getElementById("consumption");
    var button = document.getElementById("sendButton");
    
    button.addEventListener("click", function() {
        connection.invoke("SendMessage", connection.connectionId, "");
    });

    function appendItem(list, message) {
        var item = document.createElement("li");
        item.appendChild(document.createTextNode(message));
        list.insertBefore(item, list.firstChild);
     }
})();

