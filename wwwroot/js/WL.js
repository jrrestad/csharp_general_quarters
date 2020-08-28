//  w  0  0  0  0  0  0  0  0  w
//  w  0  0  0  0  0  0  0  0  w
//  w  0  0  0  0  0  0  0  0  w
//  w  0  0  0  0  0  0  0  0  w
//  0  w  0  0  0  0  0  0  w  0
//  0  w  0  0  w  w  0  0  w  0
//  0  w  0  0  w  w  0  0  w  0
//  0  w  0  w  0  0  w  0  w  0
//  0  0  w  w  0  0  w  w  0  0
//  0  0  w  0  0  0  0  w  0  0
function Win(){
    //col1
    $("#enemy11").addClass("Hit");
    $("#enemy21").addClass("Hit");
    $("#enemy31").addClass("Hit");
    $("#enemy41").addClass("Hit");
    //col2
    $("#enemy52").addClass("Hit");
    $("#enemy62").addClass("Hit");
    $("#enemy72").addClass("Hit");
    $("#enemy82").addClass("Hit");
    //col3
    $("#enemy93").addClass("Hit");
    $("#enemy103").addClass("Hit");
    //col4
    $("#enemy94").addClass("Hit");
    $("#enemy84").addClass("Hit");
    //col5
    $("#enemy75").addClass("Hit");
    $("#enemy65").addClass("Hit");
    //Col6
    $("#enemy66").addClass("Hit");
    $("#enemy76").addClass("Hit");
    //Col7
    $("#enemy97").addClass("Hit");
    $("#enemy87").addClass("Hit");
    //Col8
    $("#enemy98").addClass("Hit");
    $("#enemy108").addClass("Hit");
    //Col9
    $("#enemy89").addClass("Hit");
    $("#enemy79").addClass("Hit");
    $("#enemy69").addClass("Hit");
    $("#enemy59").addClass("Hit");
    //Col10
    $("#enemy410").addClass("Hit");
    $("#enemy310").addClass("Hit");
    $("#enemy210").addClass("Hit");
    $("#enemy110").addClass("Hit");
}
function Lose(){
    //Col3
    $("#enemy13").addClass("Hit");
    $("#enemy23").addClass("Hit");
    $("#enemy33").addClass("Hit");
    $("#enemy43").addClass("Hit");
    $("#enemy53").addClass("Hit");
    $("#enemy63").addClass("Hit");
    $("#enemy73").addClass("Hit");
    $("#enemy83").addClass("Hit");
    $("#enemy93").addClass("Hit");
    $("#enemy103").addClass("Hit");
    //Row
    $("#enemy104").addClass("Hit");
    $("#enemy105").addClass("Hit");
    $("#enemy106").addClass("Hit");
    $("#enemy107").addClass("Hit");

}

function ClearEnemyBoard(){
    for(let i=0;i<11;i++){
        for(let j=0;j<11;j++){
            $("#enemy"+i+j).css("backgroundImage","");
            $("#enemy"+i+j).css("backgroundImage","");

        }
    }
}