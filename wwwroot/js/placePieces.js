// This Scripts is to place the pieces on the board
// using AJAX so that they are updated in real time.
// then when the submit button is pushed it will 
// signal the beginning of the game and submit the 
// layout of the pieces and remove the ability to
// Place the pieces.

// Placement of the Carrier
function getCarrierPlacement(){
    var Row = $("#CARow").val();
    var Col = $("#CACol").val();
    var Align = $("#CAAlign").val();
    // console.log(Row, Col, Align);
    Row = parseInt(Row);
    Col = parseInt(Col);
    if (Align == "H"){
        if (Col > 6){
            Col = 6;
        }
        for(let i =0;i<5;i++){
            Col = Col+1
            let col = Col-1
            // console.log(Col,i);
            // console.log("friendly"+Row+Col);
            $("#friendly"+Row+col).addClass("Ship");
        }
    }
    if (Align == "V"){
        if(Row > 6){
            Row = 6;
        }
        for(let i =0;i<5;i++){
            Row = Row+1
            let row = Row-1
            // console.log(Row,i);
            // console.log("friendly"+Row+Col);
            $("#friendly"+row+Col).addClass("Ship");
        }
    }
}
// Placement of the Battleship
function getBSPlacement(){
    var Row = $("#BARow").val();
    var Col = $("#BACol").val();
    var Align = $("#BAAlign").val();
    // console.log(Row, Col, Align);
    Row = parseInt(Row);
    Col = parseInt(Col);
    if (Align == "H"){
        if (Col > 7){
            Col = 7;
        }
        for(let i =0;i<4;i++){
            Col = Col+1
            let col = Col-1
            // console.log(Col,i);
            // console.log("friendly"+Row+Col);
            $("#friendly"+Row+col).addClass("Ship");
        }
    }
    if (Align == "V"){
        if(Row > 7){
            Row = 7;
        }
        for(let i =0;i<4;i++){
            Row = Row+1
            let row = Row-1
            // console.log(Row,i);
            // console.log("friendly"+Row+Col);
            $("#friendly"+row+Col).addClass("Ship");
        }
    }
}
// Placement of the Sub
function getSubPlacement(){
    var Row = $("#SURow").val();
    var Col = $("#SUCol").val();
    var Align = $("#SUAlign").val();
    // console.log(Row, Col, Align);
    Row = parseInt(Row);
    Col = parseInt(Col);
    if (Align == "H"){
        if (Col > 8){
            Col = 8;
        }
        for(let i =0;i<3;i++){
            Col = Col+1
            let col = Col-1
            // console.log(Col,i);
            // console.log("friendly"+Row+Col);
            $("#friendly"+Row+col).addClass("Ship");
        }
    }
    if (Align == "V"){
        if(Row > 8){
            Row = 8;
        }
        for(let i =0;i<3;i++){
            Row = Row+1
            let row = Row-1
            // console.log(Row,i);
            // console.log("friendly"+Row+Col);
            $("#friendly"+row+Col).addClass("Ship");
        }
    }
}
// Placement of the Cruiser
function getCruiserPlacement(){
    var Row = $("#CRRow").val();
    var Col = $("#CRCol").val();
    var Align = $("#CRAlign").val();
    // console.log(Row, Col, Align);
    Row = parseInt(Row);
    Col = parseInt(Col);
    if (Align == "H"){
        if (Col > 8){
            Col = 8;
        }
        for(let i =0;i<3;i++){
            Col = Col+1
            let col = Col-1
            // console.log(Col,i);
            // console.log("friendly"+Row+Col);
            $("#friendly"+Row+col).addClass("Ship");
        }
    }
    if (Align == "V"){
        if(Row > 8){
            Row = 8;
        }
        for(let i =0;i<3;i++){
            Row = Row+1
            let row = Row-1
            // console.log(Row,i);
            // console.log("friendly"+Row+Col);
            $("#friendly"+row+Col).addClass("Ship");
        }
    }
}
// Placement of the Destroyer
function getDestroyerrPlacement(){
    var Row = $("#DERow").val();
    var Col = $("#DECol").val();
    var Align = $("#DEAlign").val();
    // console.log(Row, Col, Align);
    Row = parseInt(Row);
    Col = parseInt(Col);
    if (Align == "H"){
        if (Col > 9){
            Col = 9;
        }
        for(let i =0;i<2;i++){
            Col = Col+1
            let col = Col-1
            // console.log(Col,i);
            // console.log("friendly"+Row+Col);
            $("#friendly"+Row+col).addClass("Ship");
        }
    }
    if (Align == "V"){
        if(Row > 9){
            Row = 9;
        }
        for(let i =0;i<2;i++){
            Row = Row+1
            let row = Row-1
            // console.log(Row,i);
            // console.log("friendly"+Row+Col);
            $("#friendly"+row+Col).addClass("Ship");
        }
    }
}
function clearBoard(){
    for (let i = 0;i<11;i++){
        for (let j=0;j<11;j++){
            // console.log("friendly"+i+j);
            $("#friendly"+i+j).removeClass("Ship");
        }
    }
}
$(document).ready(function(){
    getCarrierPlacement();
    getBSPlacement();
    getSubPlacement();
    getCruiserPlacement();
    getDestroyerrPlacement();
})
$("#Places").click(function(event){
    clearBoard();
    getCarrierPlacement();
    getBSPlacement();
    getSubPlacement();
    getCruiserPlacement();
    getDestroyerrPlacement();
    $("#Start").removeClass("d-none");
    // var userId = document.getElementById("@(ViewBag.UserId)").value;



})

// Create functions to gather the positions and alignment
// of the ships.
function getCaPos(){
    var Row = $("#CARow").val();
    var Col = $("#CACol").val();
    var Align = $("#CAAlign").val();
    // if (Align == "H")
    // {
    //     Align = 0;
    // }
    // if (Align == "V")
    // {
    //     Align ==1;
    // }
    var CarrierPos = {
        Row: Row,
        Col: Col,
        Align:Align
    };
    return CarrierPos;
};
function getBaPos(){
    var Row = $("#BARow").val();
    var Col = $("#BACol").val();
    var Align = $("#BAAlign").val();
    // if (Align == "H")
    // {
    //     Align = 0;
    // }
    // if (Align == "V")
    // {
    //     Align ==1;
    // }
    var BattlePos = {
        Row: Row,
        Col: Col,
        Align:Align
    };
    return BattlePos;
};
function getSuPos(){
    var Row = $("#SURow").val();
    var Col = $("#SUCol").val();
    var Align = $("#SUAlign").val();
    // if (Align == "H")
    // {
    //     Align = 0;
    // }
    // if (Align == "V")
    // {
    //     Align ==1;
    // }
    var SubPos = {
        Row: Row,
        Col: Col,
        Align:Align
    };
    return SubPos;
};
function getCrPos(){
    var Row = $("#CRRow").val();
    var Col = $("#CRCol").val();
    var Align = $("#CRAlign").val();
    // if (Align == "H")
    // {
    //     Align = 0;
    // }
    // if (Align == "V")
    // {
    //     Align ==1;
    // }
    var CruPos = {
        Row: Row,
        Col: Col,
        Align:Align
    };
    return CruPos;
};
function getDePos(){
    var Row = $("#DERow").val();
    var Col = $("#DECol").val();
    var Align = $("#DEAlign").val();
    // if (Align == "H")
    // {
    //     Align = 0;
    // }
    // if (Align == "V")
    // {
    //     Align ==1;
    // }
    var DesPos = {
        Row: Row,
        Col: Col,
        Align:Align
    };
    return DesPos;
};

// $("#Start").click(function(event){
//     $(".PlacePieces").remove(".PlacePieces");
// })
var chkEl = document.getElementById("Start");
if(chkEl){
    document.getElementById("Start").addEventListener("click", async (event)=> {
        let Carrier = getCaPos();
        let Battleship = getBaPos();
        let Submarine = getSuPos();
        let Cruiser = getCrPos();
        let Destroyer = getDePos();
        var groupName = document.getElementById("group-name").value;
        var user = document.getElementById("userInput").value;
        var userId = userid.toString();
    
        try{
            // console.log("here")
            await connection.invoke("addPlayer",userId, user, groupName, Carrier, Battleship,Submarine,Cruiser,Destroyer);
            // await connection.invoke("addPlayer");
            $(".PlacePieces").remove(".PlacePieces");
        }
        catch(e){
            console.error(e.toString());
        }
        event.preventDefault();
    });
}