//This function send the attack command to the server and disables the current
//players board.
document.getElementById("enemyMap").addEventListener("click", async (event)=>{
    console.log("gamestarted");
    let X = ClickLocationX();
    let Y = ClickLocationY();
    var userId = document.getElementById("userIdentification").value;
    var user = document.getElementById("userInput").value;
    var groupName = document.getElementById("group-name").value;
    try{
        console.log("fails here? attack line 10");
        await connection.invoke("Round",userId, user, groupName, X, Y);
        $("#enemyMap").addClass("dis");
    }
    catch (e) {
        console.error(e.toString());
    }
    event.preventDefault();

});

// Sound functions to play if missed or hit
function playExplosion() {
    var explosionArray = [
        "explosion", 
        "explosion1",
        "explosion2",
        "explosion3",
        "explosion4",
        "explosion5",
        "explosion6",
    ]
    var randomExplosion = explosionArray[Math.floor(Math.random()*explosionArray.length)];
    var sound = document.getElementById(randomExplosion);
    sound.play();
};
function playSplash() {
    var sound = document.getElementById("splash");
    sound.play();
};
function playFinal() {
    var sound = document.getElementById("Final");
    sound.play();
};

connection.on("UpdateBoards", function (userId, x, y, TileState){
    var thisuser = document.getElementById("userIdentification").value;
    if(thisuser == userId){
        //work on enemyMap
        if(TileState == 1){
            // $("#enemy"+y+x).addClass("Miss");
            let imageString = "url(../../Content/Images/Splash-Sm.gif?" + new Date().getTime()+")";
            $('#enemy'+y+x).css("backgroundImage",imageString);
            playSplash();
        }
        if(TileState == 2){
            // $("#enemy"+y+x).addClass("Hit");
            let imageString = "url(../../Content/Images/ExplosionSM.gif?" + new Date().getTime()+")";
            $('#enemy'+y+x).css("backgroundImage",imageString);
            playExplosion();
        }
    } 
    if(thisuser != userId){
        //work on friendlyMap
        if(TileState == 1){
            // $("#friendly"+y+x).addClass("Miss");
            let imageString = "url(../../Content/Images/Splash-Sm.gif?" + new Date().getTime()+")";
            $('#friendly'+y+x).css("backgroundImage",imageString);
            playSplash();
        }
        if(TileState == 2){
            // $("#friendly"+y+x).addClass("Hit");
            let imageString = "url(../../Content/Images/ExplosionSM.gif?" + new Date().getTime()+")";
            $('#friendly'+y+x).css("backgroundImage",imageString);
            playExplosion();
        }
        $("#enemyMap").removeClass("dis");
    }

});

connection.on("EndState", function(userId){
    var thisuser = document.getElementById("userIdentification").value;
    ClearEnemyBoard();
    playFinal();
    if(thisuser == userId){
        Win();
    }
    if(thisuser != userId){
        Lose();
    }
    window.setTimeout(
        function(){
            window.location.replace("/main")
        },
        5000
    );

})