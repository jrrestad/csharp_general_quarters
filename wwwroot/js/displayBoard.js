let board = [
    [0,0,0,0,0,0,0,0,0,0,0],
    [0,0,0,0,0,0,0,0,0,0,0],
    [0,0,0,0,0,0,0,0,0,0,0],
    [0,0,0,0,0,0,0,0,0,0,0],
    [0,0,0,0,0,0,0,0,0,0,0],
    [0,0,0,0,0,0,0,0,0,0,0],
    [0,0,0,0,0,0,0,0,0,0,0],
    [0,0,0,0,0,0,0,0,0,0,0],
    [0,0,0,0,0,0,0,0,0,0,0],
    [0,0,0,0,0,0,0,0,0,0,0],
    [0,0,0,0,0,0,0,0,0,0,0],
];

function displayBoard() {
    var enemyOutput = '';
    for (var i = 0; i < board.length; i ++) {
        enemyOutput += '\n<div class="board-row">\n';
        for (var j = 0; j < board[i].length; j++) {
            if (board[i][j] == 0) {
                enemyOutput += '<div id=enemy' + i + j + '></div>';
            }
        }
        enemyOutput += '\n</div>';
    }
    
    var friendlyOutput = '';
    for (var i = 0; i < board.length; i ++) {
        friendlyOutput += '\n<div class="board-row">\n';
        for (var j = 0; j < board[i].length; j++) {
            if (board[i][j] == 0) {
                friendlyOutput += '<div id=friendly' + i + j + '></div>';
            }
        }
        friendlyOutput += '\n</div>';
    }
    document.getElementById('friendlyMap').innerHTML = friendlyOutput;
    document.getElementById('enemyMap').innerHTML = enemyOutput;
}

displayBoard();

