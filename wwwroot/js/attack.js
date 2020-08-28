//This function send the attack command to the server and disables the current
//players board.
document.getElementById("enemyMap").addEventListener("click", async (event)=>{
    console.log("gamestarted");
    let X = ClickLocationX();
    let Y = ClickLocationY();
    var user = document.getElementById("userInput").value;
    var groupName = document.getElementById("group-name").value;
    try{
        console.log("fails here? attack line 10");
        await connection.invoke("Round", user, groupName, X, Y);
        $("#enemyMap").addClass("dis");
    }
    catch (e) {
        console.error(e.toString());
    }
    event.preventDefault();

});

connection.on("UpdateBoards", function (user, x, y, TileState){
    var thisuser = document.getElementById("userInput").value;
    if(thisuser == user){
        //work on enemyMap
        if(TileState == 1){
            $("#enemy"+y+x).addClass("Miss");
        }
        if(TileState == 2){
            $("#enemy"+y+x).addClass("Hit");
        }
    } 
    if(thisuser != user){
        //work on friendlyMap
        if(TileState == 1){
            $("#friendly"+y+x).addClass("Miss");
        }
        if(TileState == 2){
            $("#friendly"+y+x).addClass("Hit");
        }
        $("#enemyMap").removeClass("dis");
    }

});

connection.on("EndState", function(user){
    var thisuser = document.getElementById("userInput").value;
    ClearEnemyBoard();
    if(thisuser == user){
        Win();
    }
    if(thisuser != user){
        Lose();
    }
    window.setTimeout(
        function(){
            window.location.replace("/main")
        },
        5000
    );

})