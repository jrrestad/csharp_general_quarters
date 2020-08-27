
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

    // **** Test function *****
// connection.on("Test", function () {
//     var x = document.getElementById("myDIV");
//     if (x.style.display === "none") {
//       x.style.display = "block";
//     } else {
//       x.style.display = "none";
//     }
// });

// document.getElementById("MyInput").addEventListener("click", async (event) => {
//     // document.getElementById("MyInput").value="";
//     var groupName = document.getElementById("group-name").value;
//     try {
//         await connection.invoke("Test2", groupName);
//         }
//     catch (e) {
//         console.error(e.toString());
//     }
//     event.preventDefault();
// });

// **************************

connection.on("Send", function (message, user) {
    var encodedMsg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var li = document.createElement("h6");
    var messageBox = document.querySelector('#messageBox')
    li.textContent = encodedMsg;
    // var UserName = document.getElementById("userInput").value;
    // if (user == UserName){
    //     li.className = "text-primary"
    // }
    // else {
    //     li.className = "text-danger"
    // }
    document.getElementById("messagesList").appendChild(li);
    messageBox.scrollTop = messageBox.scrollHeight - messageBox.clientHeight;
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
    
    // clear the group-message-text
    document.getElementById("group-message-text").value = '';
    document.getElementById("group-message-text").focus();
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

(async () => {
    try {
        await connection.onclose();
        var groupName = document.getElementById("auto-join").value;
        var user = document.getElementById("userInput").value;
        try {
            await connection.invoke("RemoveFromGroup", groupName, user);
            console.log("Logging: Disconnected from " + groupName)
        }
        catch (e) {
            console.error(e.toString());
        }
        event.preventDefault();
    }
    catch (e) {
        console.error(e.toString());
    }
})();
