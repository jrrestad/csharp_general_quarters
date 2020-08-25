This is the readMe file

************** For implementing Signal R with Aspnet CORE **************

1) in .Net CORE dotnet tool install -g Microsoft.Web.LibraryManager.Cli
2) libman install @microsoft/signalr@latest -p unpkg -d wwwroot/js/signalr --files dist/browser/signalr.js --files dist/browser/signalr.min.js
3) Add a hub class in Models

    using Microsoft.AspNetCore.SignalR;
    using System.Threading.Tasks;

    namespace SignalRChat.Hubs
    {
        public class ChatHub : Hub
        {
            public async Task SendMessage(string user, string message)
            {
                await Clients.All.SendAsync("ReceiveMessage", user, message);
            }
        }
    }

4) Add to Startup.cs

    using <projname>.Hubs;

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSignalR();
    }

*********************** Place before UseMvc(routes) ***********************

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapHub<Chathub>("/chathub");
    });

5) cshtml code

    <div class="container">
        <div class="row">&nbsp;</div>
        <div class="row">
            <div class="col-2">User</div>
            <div class="col-4"><input type="text" id="userInput" /></div>
        </div>
        <div class="row">
            <div class="col-2">Message</div>
            <div class="col-4"><input type="text" id="messageInput" /></div>
        </div>
        <div class="row">&nbsp;</div>
        <div class="row">
            <div class="col-6">
                <input type="button" id="sendButton" value="Send Message" />
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-12">
            <hr />
        </div>
    </div>
    <div class="row">
        <div class="col-6">
            <ul id="messagesList"></ul>
        </div>
    </div>
    <script src="~/js/signalr/dist/browser/signalr.js"></script>
    <script src="~/js/chat.js"></script>

6) In the wwwroot/js folder create a .js file

    "use strict";

    var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

    //Disable send button until connection is established
    document.getElementById("sendButton").disabled = true;

    connection.on("ReceiveMessage", function (user, message) {
        var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
        var encodedMsg = user + " says " + msg;
        var li = document.createElement("li");
        li.textContent = encodedMsg;
        document.getElementById("messagesList").appendChild(li);
    });

    connection.start().then(function () {
        document.getElementById("sendButton").disabled = false;
    }).catch(function (err) {
        return console.error(err.toString());
    });

    document.getElementById("sendButton").addEventListener("click", function (event) {
        var user = document.getElementById("userInput").value;
        var message = document.getElementById("messageInput").value;
        connection.invoke("SendMessage", user, message).catch(function (err) {
            return console.error(err.toString());
        });
        event.preventDefault();
    });

 ************************************************************************************