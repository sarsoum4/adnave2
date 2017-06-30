
var startRow;
var startCol;
var endRow;
var endCol;
var myMazeBoard;
var flag = false;

document.getElementById("btnAddMaze").onclick = checkValidity;

function load() {
    var lRows = localStorage.getItem("mazeRows");
    if (lRows) {
        document.getElementById("mazeRow").value = lRows;
    }

    var lCols = localStorage.getItem("mazeCols");
    if (lCols) {
        document.getElementById("mazeCol").value = lCols;
    }
}

function checkValidity() {

    var mName = document.getElementById("mazeName").value;
    var mRow = document.getElementById("mazeRow").value;
    var mCol = document.getElementById("mazeCol").value;

    if ((!mName) || (!mRow) || (!mCol)) {
        alert("Some input is missing!");
    }
    else {
        sendToServer();
    }
}

function sendToServer() {

    var mName = document.getElementById("mazeName").value;
    var mRow = document.getElementById("mazeRow").value;
    var mCol = document.getElementById("mazeCol").value;

    var apiUrl = "api/Maze/5?" + "name=" + mName + "&rows=" + mRow +
        "&cols=" + mCol;

    $.getJSON(apiUrl).done(function (data) {
        var mazeRep = data.Maze;
        var startRow = data.Start.Row;
        var startCol = data.Start.Col;
        var endRow = data.End.Row;
        var endCol = data.End.Col;

        //get the maze representation, and put it in a 2D matrix
        var splitMazeRep = mazeRep.split('');

        var arrRow = [];

        for (var i = 0; i < mRow; i++) {
            arrRow[i] = [];
            var imCol = i * mCol;
            for (var j = 0; j < mCol; j++) {
                arrRow[i][j] = splitMazeRep[imCol + j];
            };
        };

        var mazeData = arrRow;
        myMazeBoard = $.fn.mazeBoard(
            mName,
            mazeData, // the matrix containing the maze cells
            startRow, startCol, // initial position of the player
            endRow, endCol, // the exit position
            "pooh.gif", // player's icon (of type Image)
            "hJar.jpg", // exit's icon (of type Image)
        );
        //myMazeBoard.drawMaze();
    });
    flag = true;
}
