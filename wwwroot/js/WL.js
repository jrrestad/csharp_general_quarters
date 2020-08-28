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
    let imageString = "url(../../Content/Images/ExplosionSM.gif?" + new Date().getTime()+")";
    $("#enemy11").css("backgroundImage",imageString);
    $("#enemy21").css("backgroundImage",imageString);
    $("#enemy31").css("backgroundImage",imageString);
    $("#enemy41").css("backgroundImage",imageString);
    //col2
    $("#enemy52").css("backgroundImage",imageString);
    $("#enemy62").css("backgroundImage",imageString);
    $("#enemy72").css("backgroundImage",imageString);
    $("#enemy82").css("backgroundImage",imageString);
    //col3
    $("#enemy93").css("backgroundImage",imageString);
    $("#enemy103").css("backgroundImage",imageString);
    //col4
    $("#enemy94").css("backgroundImage",imageString);
    $("#enemy84").css("backgroundImage",imageString);
    //col5
    $("#enemy75").css("backgroundImage",imageString);
    $("#enemy65").css("backgroundImage",imageString);
    //Col6
    $("#enemy66").css("backgroundImage",imageString);
    $("#enemy76").css("backgroundImage",imageString);
    //Col7
    $("#enemy97").css("backgroundImage",imageString);
    $("#enemy87").css("backgroundImage",imageString);
    //Col8
    $("#enemy98").css("backgroundImage",imageString);
    $("#enemy108").css("backgroundImage",imageString);
    //Col9
    $("#enemy89").css("backgroundImage",imageString);
    $("#enemy79").css("backgroundImage",imageString);
    $("#enemy69").css("backgroundImage",imageString);
    $("#enemy59").css("backgroundImage",imageString);
    //Col10
    $("#enemy410").css("backgroundImage",imageString);
    $("#enemy310").css("backgroundImage",imageString);
    $("#enemy210").css("backgroundImage",imageString);
    $("#enemy110").css("backgroundImage",imageString);
}
function Lose(){
    //Col3
    let imageString = "url(../../Content/Images/ExplosionSM.gif?" + new Date().getTime()+")";
    $("#enemy13").css("backgroundImage",imageString);
    $("#enemy23").css("backgroundImage",imageString);
    $("#enemy33").css("backgroundImage",imageString);
    $("#enemy43").css("backgroundImage",imageString);
    $("#enemy53").css("backgroundImage",imageString);
    $("#enemy63").css("backgroundImage",imageString);
    $("#enemy73").css("backgroundImage",imageString);
    $("#enemy83").css("backgroundImage",imageString);
    $("#enemy93").css("backgroundImage",imageString);
    $("#enemy103").css("backgroundImage",imageString);
    //Row
    $("#enemy104").css("backgroundImage",imageString);
    $("#enemy105").css("backgroundImage",imageString);
    $("#enemy106").css("backgroundImage",imageString);
    $("#enemy107").css("backgroundImage",imageString);

}

function ClearEnemyBoard(){
    for(let i=0;i<11;i++){
        for(let j=0;j<11;j++){
            $("#enemy"+i+j).css("backgroundImage","");
            $("#enemy"+i+j).css("backgroundImage","");

        }
    }
}