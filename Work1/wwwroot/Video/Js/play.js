var video = document.getElementById('video1');

var playButton = document.getElementById('play-btn');//播放按鈕
var a10Button = document.getElementById('add10-btn');
var b10Button = document.getElementById('ris10-btn');
var fullscreenButton = document.getElementById('full-btn');
var fullscreenImg = document.getElementById('fullscreen-img');
var playscreenImg = document.getElementById('play-img');
var playProgressBar = document.getElementById('progress-bar');
var isDragging = false;
var IsPlay = false;
var timer1;
var mouseTracker = document.getElementById('mouse-tracker');
var controlsContainer = document.getElementById('cont');
var loadProgressBar = document.getElementById('load-progress');
var volumeControl = document.getElementById('volumeControl');
var Voul = document.querySelector('input');

	



//--------
//播放函式
function Yesplay(){
  video.play();
     IsPlay = true;
    playscreenImg.src = pauseButtonUrl  ;
     playscreenImg.alt = "暫停"; 
}
function Noplay(){
 video.pause();
 IsPlay = false;
    playscreenImg.src = playButtonUrl;
 playscreenImg.alt = "播放"; 
}
//-------
//播放進度條



 // 監聽滑鼠按下事件
 playProgressBar.addEventListener('mousedown', function(event) {
  isDragging = true;
  video.pause();
  updateProgressBar(event);
});

//監聽滑鼠移動事件
playProgressBar.addEventListener('mousemove', function(event) {
  if (isDragging) {
    updateProgressBar(event);
  }
});
document.addEventListener('mouseup', function() {
  if (isDragging) {
    isDragging = false;
    if (IsPlay) {
      // 如果拖動進度條前影片是在播放狀態，則恢復播放
      video.play();
    }
    
  }
});
function updateProgressBar(event) {
      // 獲取滑鼠點擊位置相對於進度條容器的百分比位置
      var clickX = event.clientX - playProgressBar.getBoundingClientRect().left;
      var containerWidth = playProgressBar.offsetWidth;

      // 計算點擊位置的百分比
      var percent = (clickX / containerWidth) * 100;
      percent = Math.max(0, Math.min(100, percent));
      //console.log(percent);
      // 更新播放進度條的值
      playProgressBar.value = (clickX / containerWidth) * 100;;

      // 將影片的播放時間設置為相應的位置
      var duration = video.duration;
      video.currentTime = (percent / 100) * duration;
}

var progressBar = document.getElementById('progress-bar');//進度條
video.addEventListener('timeupdate', function() { // 計算進度條的值（百分比）
  progressBar.value = (video.currentTime / video.duration) * 100;
});
//-----------

video.controls = false;
video.addEventListener('contextmenu', function(e) {
  e.preventDefault();
});

mouseTracker.addEventListener('click', function() {
  document.body.style.cursor = 'auto';
  if (video.paused) {
    handleMouseMove()
    Yesplay()
  } else {
    handleMouseMove()
    Noplay()
  }
});

playButton.addEventListener('click', function() {
  
      if (video.paused) {
        Yesplay() 
      } else {
        Noplay() 
      }
    });
a10Button.addEventListener('click', function() {
    video.currentTime += 10;
    });
b10Button.addEventListener('click', function() {
    video.currentTime -= 10;
});
document.addEventListener('keydown', function(event) {

  if (event.keyCode === 37 || event.keyCode === 39) {
      event.preventDefault();
    }
  if (event.keyCode === 32) {
    event.preventDefault();
    // 判斷影片的播放狀態，執行對應的操作
    if (video.paused) {
      Yesplay(); 
    } else {
      Noplay()
    }
  }
  if (event.keyCode === 37) {
      // 向左：倒退10秒
      video.currentTime -= 10;
    } else if (event.keyCode === 39) {
      // 向右：快轉10秒
      video.currentTime += 10;
    }
});

//全螢幕模式
fullscreenButton.addEventListener('click', function() {
  toggleFullscreen();
});
  document.addEventListener('fullscreenchange', handleFullscreenChange);
  document.addEventListener('webkitfullscreenchange', handleFullscreenChange); 
  document.addEventListener('msfullscreenchange', handleFullscreenChange); 

function toggleFullscreen() {
  if (!document.fullscreenElement && !document.webkitFullscreenElement && !document.msFullscreenElement) {
    // 進入全螢幕模式
    
    if (document.documentElement.requestFullscreen) {
      document.documentElement.requestFullscreen();
    } else if (document.documentElement.webkitRequestFullscreen) {
      document.documentElement.webkitRequestFullscreen();
    } else if (document.documentElement.msRequestFullscreen) {
      document.documentElement.msRequestFullscreen();
    }
  } else {
    // 退出全螢幕模式
    if (document.exitFullscreen) {
      document.exitFullscreen();
    } else if (document.webkitExitFullscreen) {
      document.webkitExitFullscreen();
    } else if (document.msExitFullscreen) { 
      document.msExitFullscreen();
    }
  }
}
function handleFullscreenChange() {
  if (document.fullscreenElement || document.webkitFullscreenElement || document.msFullscreenElement) {
    // 進入全螢幕模式，將按鈕內容修改為「取消全螢幕」
      fullscreenImg.src = normalScreenUrl;
    fullscreenImg.alt = "取消全螢幕";
  } else {
    // 退出全螢幕模式，將按鈕內容修改為「全螢幕」
      fullscreenImg.src = fullScreenUrl; // 切換圖片為進入全螢幕的圖標
      fullscreenImg.alt = "全螢幕"; // 更新 alt 文本
  }
}
//-----------------
//隱藏
mouseTracker.addEventListener('mousemove', handleMouseMove);
var muteButton = document.getElementById('Sound-btn');
function handleMouseMove() {
  document.body.style.cursor = 'auto';
  controlsContainer.style.opacity = 1;
  clearTimeout(timer1);
  timer1 = setTimeout(function() {
    document.body.style.cursor = 'none';
    controlsContainer.style.opacity = 0;
  }, 1000);
}
function handleMouseEnter() {
  document.body.style.cursor = 'auto';
  controlsContainer.style.opacity = 1;
  clearTimeout(timer1);
}
//------

//靜音
var muteButton = document.getElementById('Sound-btn');
var muteIMG = document.getElementById('sound');


//調整音量

Voul.value=video.volume;
document.addEventListener('DOMContentLoaded', function() { // 拉感及時變化
  var Vtemp ;
  Voul.addEventListener('mouseenter', function() {
    var tem = Voul.value*100;
    Voul.addEventListener('click', function() {
      tem = Voul.value*100;
      bg(tem);
    });
    Voul.addEventListener('mousemove', function() {
      tem = Voul.value*100;
      bg(tem);
    });
  });
  function bg(tem) {
    Voul.style.backgroundImage = '-webkit-linear-gradient(left ,rgb(255, 0, 221) 0%,rgb(255, 0, 221) ' + tem + '%,#fff ' + tem + '%, #fff 100%)';
    video.volume = Voul.value;
    if (Voul.value > 0) {
      video.muted = false;
        muteIMG.src = soundOnUrl;
    } else {
      video.muted = true;
        muteIMG.src = soundOffUrl;
    }
  }
  muteButton.addEventListener('click', function() {
    // 如果影片是靜音的，取消靜音；否則，靜音
    if (video.muted) {
      Voul.value = Vtemp;
      tem = Voul.value*100;
      bg(tem);
      video.muted = false;
        muteIMG.src = soundOnUrl;
    } else {
      Vtemp = Voul.value;
      Voul.value = 0;
      tem = Voul.value*100;
      bg(tem);
      video.muted = true;
        muteIMG.src = soundOffUrl;
    }
  });
});

  //---
  //--------影片速度---------//
  var speed0_1x = document.getElementById('speed0_1x');
  var speed0_25x = document.getElementById('speed0_25x')
  var speedNormal = document.getElementById('speedNormal');
  var speed1_5x = document.getElementById('speed1_5x');
  var speed2x = document.getElementById('speed2x')

  function setSpeed(speed) {
    video.playbackRate = speed;
  }


  speedNormal.addEventListener('click', function() {
    setSpeed(1);
});

speed1_5x.addEventListener('click', function() {
    setSpeed(1.5);
});

speed2x.addEventListener('click', function() {
    setSpeed(2);
});

speed0_1x.addEventListener('click', function() {
  setSpeed(0.1);
});

speed0_25x.addEventListener('click', function() {
  setSpeed(0.25);
});




  //-----------------------//