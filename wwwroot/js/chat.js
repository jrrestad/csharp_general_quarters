
// **** Old code for data to Clients.All *****

// "use strict";

// var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable send button until connection is established
// document.getElementById("sendButton").disabled = true;

// connection.on("ReceiveMessage", function (user, message) {
//     var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
//     var encodedMsg = user + " says: " + msg;
//     var li = document.createElement("h6");
//     var UserName = document.getElementById("userInput").value;
//     if (user == UserName){
//         li.className = "text-right text-primary"

//     }
//     li.textContent = encodedMsg;
//     document.getElementById("messagesList").appendChild(li);
// });

// connection.start().then(function () {
//     document.getElementById("sendButton").disabled = false;
// }).catch(function (err) {
//     return console.error(err.toString());
// });

// document.getElementById("sendButton").addEventListener("click", function (event) {
//     var user = document.getElementById("userInput").value;
//     var message = document.getElementById("messageInput").value;
//     document.getElementById("messageInput").value="";
//     connection.invoke("SendMessage", user, message).catch(function (err) {
//         return console.error(err.toString());
//     });
//     event.preventDefault();
// });


// ***** New code for group joining, leaving, and messaging in groups *****

const connection = new signalR.HubConnectionBuilder()
    .withUrl("/chatHub")
    .build();


connection.on("Send", function (message) {
    var li = document.createElement("li");
    li.textContent = message;
    document.getElementById("messagesList").appendChild(li);
});

document.getElementById("groupmsg").addEventListener("click", async (event) => {
    var groupName = document.getElementById("group-name").value;
    var groupMsg = document.getElementById("group-message-text").value;
    var user = document.getElementById("userInput").value;
    try {
        await connection.invoke("SendMessageToGroup", groupName, groupMsg, user);
    }
    catch (e) {
        console.error(e.toString());
    }
    event.preventDefault();
});

document.getElementById("join-group").addEventListener("click", async (event) => {
    var groupName = document.getElementById("group-name").value;
    var user = document.getElementById("userInput").value;
    try {
        await connection.invoke("AddToGroup", groupName, user);
        console.log("Logging: Connected to " + groupName)
    }
    catch (e) {
        console.error(e.toString());
    }
    event.preventDefault();
});

document.getElementById("leave-group").addEventListener("click", async (event) => {
    var groupName = document.getElementById("group-name").value;
    var user = document.getElementById("userInput").value;
    try {
        await connection.invoke("RemoveFromGroup", groupName, user);
        console.log("Logging: Disconnected from  " + groupName)
    }
    catch (e) {
        console.error(e.toString());
    }
    event.preventDefault();
});

// var chat = $.connection.Chat;
// $.connection.hub.start();
// chat.server.AddToGroup("Global")

// Auto join the channel when you click on link in Main page
(async () => {
    try {
        await connection.start();
        var groupName = document.getElementById("auto-join").value;
        var user = document.getElementById("userInput").value;
        try {
            await connection.invoke("AddToGroup", groupName, user);
            console.log("Logging: Connected to " + groupName)
        }
        catch (e) {
            console.error(e.toString());
        }
        event.preventDefault();
        console.log("Connection working:")
    }
    catch (e) {
        console.error(e.toString());
    }
})();
// connection.onclose(async () => {
//     await start();
//     console.log("disconnected")
// });