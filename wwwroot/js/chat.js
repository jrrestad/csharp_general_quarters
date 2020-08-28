const connection = new signalR.HubConnectionBuilder()
    .withUrl("/chatHub")
    .build();

connection.on("Send", function (message) {
    var encodedMsg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var li = document.createElement("h6");
    var messageBox = document.querySelector('#messageBox')
    li.textContent = encodedMsg;
    document.getElementById("messagesList").appendChild(li);
    messageBox.scrollTop = messageBox.scrollHeight - messageBox.clientHeight;
});

connection.on("SendOutput", function (message) {
    var encodedMsg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var li = document.createElement("h6");
    var messageBox = document.querySelector('#outputBox')
    li.textContent = encodedMsg;
    document.getElementById("outputList").appendChild(li);
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
