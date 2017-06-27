// the plugin drwas on a canvas the maze, the player image, the player movements and etc. 
var mazeForCanvas;
var myCanvas;
var context;
var mazeData;
var rows;
var cols;
var cellWidth;
var cellHeight;
var startRow;
var startCol;
var exitRow;
var exitCol;
var startImage;
var endImage;
var playerPosCol;
var playerPosRow;

(function ($) {

    $.fn.mazeBoard = function (mazeD, startR, startC, exitR, exitC, playerIm,
        exitIm) {

        myCanvas = document.getElementById("mazeCanvas");
        this.element = $("#mazeCanvas")[0];
        context = this.element.getContext("2d");
        mazeData = mazeD;
        rows = mazeD.length;
        cols = mazeD[0].length;
        cellWidth = mazeCanvas.width / cols;
        cellHeight = mazeCanvas.height / rows;
        startRow = startR;
        startCol = startC;
        exitRow = exitR;
        exitCol = exitC;
        playerPosCol = startC;
        playerPosRow = startR;
        startImage = new Image();
        startImage.src = playerIm;
        endImage = new Image();
        endImage.src = exitIm;

        startImage.onload = function () {
            //document.getElementById("showInput3").innerHTML = startRow + "," + startRow;
            context.drawImage(startImage, startCol * cellWidth, startRow * cellHeight, cellWidth, cellHeight);
        };

        endImage.onload = function () {
            //document.getElementById("showInput4").innerHTML = exitRow + "," + exitRow;
            context.drawImage(endImage, exitCol * cellWidth, exitRow * cellHeight, cellWidth, cellHeight);
        };

        for (var i = 0; i < rows; i++) {
            for (var j = 0; j < cols; j++) {
                if (mazeData[i][j] == 1) {
                    context.fillStyle = "black";
                    context.fillRect(cellWidth * j, cellHeight * i,
                        cellWidth, cellHeight);
                }
                /*
                else if (i == startRow && j == startCol) {
                    startImage.onload = function () {
                        //document.getElementById("showInput3").innerHTML = startRow + "," + startRow;
                        context.drawImage(startImage, startRow * cellWidth,
                            startCol * cellHeight, cellWidth, cellHeight);
                    };
                }
                else if (i == exitRow && j == exitCol) {
                    endImage.onload = function () {
                        //document.getElementById("showInput4").innerHTML = exitRow + "," + exitRow;
                        context.drawImage(endImage, exitRow * cellWidth,
                            exitCol * cellHeight, cellWidth, cellHeight);
                    };
                }*/
            }
        }

        movePlayer = function () {

                const e = event.keyCode;

                var newCol = playerPosCol;
                var newRow = playerPosRow;

                //move left
                if (e == '37') {
                    document.getElementById("showInput1").innerHTML = "LEFT!";
                    var tempCol = playerPosCol - 1;
                    var tempRow = playerPosRow;

                    if ((mazeData[tempRow][tempCol] == 0) || (tempCol == endCol && tempRow == endRow)) {
                        newCol = playerPosCol - 1;
                        newRow = playerPosRow;
                    }
                }
                //move up
                else if (e == '38') {
                    document.getElementById("showInput1").innerHTML = "UP!";
                    var tempCol = playerPosCol;
                    var tempRow = playerPosRow - 1;

                    if ((mazeData[tempRow][tempCol] == 0) || (tempCol == endCol && tempRow == endRow)) {
                        newCol = playerPosCol;
                        newRow = playerPosRow - 1;
                    }
                }
                //move right
                else if (e == '39') {
                    document.getElementById("showInput1").innerHTML = "RIGHT!";
                    var tempCol = playerPosCol + 1;
                    var tempRow = playerPosRow;

                    if ((mazeData[tempRow][tempCol] == 0) || (tempCol == endCol && tempRow == endRow)) {
                        newCol = playerPosCol + 1;
                        newRow = playerPosRow;
                    }
                }
                //move down
                else if (e == '40') {
                    document.getElementById("showInput1").innerHTML = "DOWN!";
                    var tempCol = playerPosCol;
                    var tempRow = playerPosRow + 1;

                    if ((mazeData[tempRow][tempCol] == 0) || (tempCol == endCol && tempRow == endRow)) {
                        newCol = playerPosCol;
                        newRow = playerPosRow + 1;
                    }
                }

                /*
                * in the newRow there is the new player position.
                * first, put a white blank cell in the old position, then put
                * the player image in the new position.
                */

                var posImage = new Image();

                var myCanvas = document.getElementById("mazeCanvas");
                this.element = $("#mazeCanvas")[0];
                var context = this.element.getContext("2d");

                context.fillStyle = "white";
                context.fillRect(cellWidth * playerPosRow, cellHeight * playerPosCol,
                    cellWidth, cellHeight);

                posImage.src = startImage;

               // context.clearRect(newRow * cellWidth, newCol * cellHeight, cellWidth, cellHeight);
                context.drawImage(startImage, newCol * cellWidth, newRow * cellHeight, cellWidth, cellHeight);
            /*
                startImage.onload = function () {
                    document.getElementById("showInput2").innerHTML = "PICCCCC";
                    document.getElementById("showInput3").innerHTML = newRow + "," + newCol;
                    context.drawImage(startImage, newRow * cellWidth, newCol * cellHeight, cellWidth, cellHeight);
                };
            */
          
                document.getElementById("showInput4").innerHTML = playerPosRow + ":" + playerPosCol;
                playerPosRow = newRow;
                playerPosCol = newCol;
            },
/*
        startImage.onload = function () {
            //document.getElementById("showInput3").innerHTML = startRow + "," + startRow;
            context.drawImage(startImage, startRow * cellWidth, startCol * cellHeight, cellWidth, cellHeight);
        };

        endImage.onload = function () {
            //document.getElementById("showInput4").innerHTML = exitRow + "," + exitRow;
            context.drawImage(endImage, exitRow * cellWidth, exitCol * cellHeight, cellWidth, cellHeight);
            };
            */
        mazeForCanvas = {
            mazeData: mazeData,
            startRow: startRow,
            startCol: startCol,
            exitRow: exitRow,
            exitCol: exitCol,
            playerPosRow: startRow,
            playerPosCol: startCol,
            playerImage: startImage,
            exitImage: endImage,
            cellWidth: cellWidth,
            cellHeight: cellHeight,
            canMove: true
        }

        'use strict';
        document.addEventListener('keydown', movePlayer, true);
        //$.fn.mazeBoard.drawMaze = mazeForCanvas.drawMaze;
        //$.fn.mazeBoard.movePlayer = mazeForCanvas.movePlayer;

        return mazeForCanvas;
    }

    //window.addEventListener('keydown', findKey, true);
    })(jQuery)
