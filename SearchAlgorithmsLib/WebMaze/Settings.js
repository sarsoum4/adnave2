
function saveChanges() {
    var rows = document.getElementById("mRow").value;
    localStorage.setItem("mazeRows", rows);

    var cols = document.getElementById("mCol").value;
    localStorage.setItem("mazeCols", cols);
}

function load() {
    var lRows = localStorage.getItem("mazeRows");
    if (lRows) {
        document.getElementById("mRow").value = lRows;
    }

    var lCols = localStorage.getItem("mazeCols");
    if (lCols) {
        document.getElementById("mCol").value = lCols;
    }

    var lAlgo = localStorage.getItem("algoText");
    if (lCols) {
        document.getElementById("textAlgo2").value = lCols;
    }
}

function BFSAlgo() {
    localStorage.algo = 0;
    localStorage.setItem("algo", "0");
    localStorage.setItem("algoText", "You choose BFS");
    document.getElementById("textAlgo2").innerHTML = "You choose BFS"
}

function DFSAlgo() {
    localStorage.algo = 1;
    localStorage.setItem("algo", "1");
    localStorage.setItem("algoText", "You choose DFS");
    document.getElementById("textAlgo2").innerHTML = "You choose DFS"
}