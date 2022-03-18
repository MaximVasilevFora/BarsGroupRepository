var cvs = document.getElementById("mainCanvas");
var ctx = cvs.getContext("2d");

var bird = new Image();
var background = new Image();
var deadLine = new Image();
var topTube = new Image();
var bottomTube = new Image();

var fly = new Audio();
var score_audio = new Audio();
fly.src = "audio/fly.mp3";
score_audio.src = "audio/score.mp3";

bird.src = "image/bird.png";
background.src = "image/background.png";
deadLine.src = "image/deadLine.png";
topTube.src = "image/topTube.png";
bottomTube.src = "image/bottomTube.png";

var gap = 90;

document.addEventListener("keydown", moveUp);

function moveUp(){
	yPos -= 25;
	fly.play();
}

var pipe = [];

pipe[0] = {
	x: cvs.width,
	y: 0
};

var xPos = 10;
var yPos = 150;
var speed = 1.5;
score = 0;

function draw(){
	ctx.drawImage(background, 0, 0);
		for(var i = 0; i < pipe.length; i++){
			ctx.drawImage(topTube, pipe[i].x, pipe[i].y);
			ctx.drawImage(bottomTube, pipe[i].x, pipe[i].y + topTube.height + gap);
			pipe[i].x--;

			if(pipe[i].x == 125){
				pipe.push({x : cvs.width, y : Math.floor(Math.random() * topTube.height) - topTube.height});
			}
			if(xPos + bird.width >= pipe[i].x
 				&& xPos <= pipe[i].x + topTube.width
 				&& (yPos <= pipe[i].y + topTube.height
				 || yPos + bird.height >= pipe[i].y + topTube.height + gap) 
 				|| yPos + bird.height >= cvs.height - deadLine.height) {
 				location.reload(); // Перезагрузка страницы
 			}
 			if(pipe[i].x == 5){
 				score++;
 				score_audio.play();
 			}
		}
 	ctx.drawImage(deadLine, 0, cvs.height - deadLine.height);
 	ctx.drawImage(bird, xPos, yPos);
 	yPos += speed;

 	ctx.fillStyle = "#000";
 	ctx.font = "24px Verdana";
 	ctx.fillText("Счет: " + score, 10, cvs.height - 20);

 	requestAnimationFrame(draw);
}

bottomTube.onload = draw;

