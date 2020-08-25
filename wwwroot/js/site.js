// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

$( document ).ready(function() {
    console.log( "ready!" );
    $(".enemyMap").mousemove(function(event){
        var X = event.pageX - $(this).offset().left;
        var Y = event.pageY - $(this).offset().top;
        console.log(X + ", "+ Y);
    });
});




// Write your JavaScript code.
let board = [
    [0,1,2,3,4,5,6,7,8,9,10],
    ["A",0,0,0,0,0,0,0,0,0,0],
    ["B",0,0,0,0,0,0,0,0,0,0],
    ["C",0,0,0,0,0,0,0,0,0,0],
    ["D",0,0,0,0,0,0,0,0,0,0],
    ["E",0,0,0,0,0,0,0,0,0,0],
    ["F",0,0,0,0,0,0,0,0,0,0],
    ["G",0,0,0,0,0,0,0,0,0,0],
    ["H",0,0,0,0,0,0,0,0,0,0],
    ["I",0,0,0,0,0,0,0,0,0,0],
    ["J",0,0,0,0,0,0,0,0,0,0],
];

function displayBoard() {
    var output = '';

    for (var i = 0; i < board.length; i ++) {
        output += '\n<div>\n';
        for (var j = 0; j < board[i].length; j++) {
            if (board[i][j] == 0) {
                output += '<div class="board-square"></div>';
            } else if (board[i][j] == 1) {
                output += '<div class="board-square"><p>1</p></div>';
            } else if (board[i][j] == 2) {
                output += '<div class="board-square"><p>2<p></div>';
            } else if (board[i][j] == 3) {
                output += '<div class="board-square"><p>3<p></div>';
            } else if (board[i][j] == 4) {
                output += '<div class="board-square"><p>4<p></div>';
            } else if (board[i][j] == 5) {
                output += '<div class="board-square"><p>5<p></div>';
            } else if (board[i][j] == 6) {
                output += '<div class="board-square"><p>6<p></div>';
            } else if (board[i][j] == 7) {
                output += '<div class="board-square"><p>7<p></div>';
            } else if (board[i][j] == 8) {
                output += '<div class="board-square"><p>8<p></div>';
            } else if (board[i][j] == 9) {
                output += '<div class="board-square"><p>9<p></div>';
            } else if (board[i][j] == 10) {
                output += '<div class="board-square"><p>10<p></div>';
            } else if (board[i][j] == "A") {
                output += '<div class="board-square"><p>A<p></div>';
            } else if (board[i][j] == "B") {
                output += '<div class="board-square"><p>B<p></div>';
            } else if (board[i][j] == "C") {
                output += '<div class="board-square"><p>C<p></div>';
            } else if (board[i][j] == "D") {
                output += '<div class="board-square"><p>D<p></div>';
            } else if (board[i][j] == "E") {
                output += '<div class="board-square"><p>E<p></div>';
            } else if (board[i][j] == "F") {
                output += '<div class="board-square"><p>F<p></div>';
            } else if (board[i][j] == "G") {
                output += '<div class="board-square"><p>G<p></div>';
            } else if (board[i][j] == "H") {
                output += '<div class="board-square"><p>H<p></div>';
            } else if (board[i][j] == "I") {
                output += '<div class="board-square"><p>I<p></div>';
            } else if (board[i][j] == "J") {
                output += '<div class="board-square"><p>J<p></div>';
            }
            
        }
        output += '\n</div>';
    }
    document.getElementById('board').innerHTML = output;
}

displayBoard();