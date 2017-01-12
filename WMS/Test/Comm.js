// global var
var Rate = 0.818182;
var curSelPlayer;
var bLoop = false;
var bMute = false;
var bAutoStop = true;
var nModel;
var PageWidth,PageHeight,availWidth,availHeight;
var nMinWidth = "530";
var nMinHeight = "250";
var nOffX_1,nOffY_1,nOffX_2,nOffY_2;
var nOffsetX,nOffsetY;
var bTimeSlider = false;
var nHtmlType = 1;


var objSetup;
// Page Load
function PageLoad()
{
	
	var bOk = true;
	if (!ChkMediaPlay()){
		bOk = false;
	}
	
	if (bOk)
	{
		bOk = TurnSeg();
		if (bOk)
		{
			GetInitVolume();
			OnTimeOut();
		}
	}
}





function Init(){
	InitExControl();
	InitTimeSlider();
}
// 




function UpdateLayer(){
	window.spTimeSlider.style.width = availWidth - 5;
	window.spVolumeBtn.style.left = parseInt(window.spVolumeSlider.offsetLeft) + parseInt(window.spVolumeCur.style.pixelWidth);
}





function FastForward()
{
	var bPlay = false;
	if (document.Player1.playState == 4)
		bPlay = true;

	for(var i=1; i <= nChlCount; i++)
	{
		objPlayer = eval("document.Player"+i);
		if (bPlay)
			objPlayer.Controls.play();
		else
			objPlayer.Controls.fastForward();
	}
	window.btnFF.src = (document.Player1.playState == 4)?"Images/ff_down.gif":"Images/ff_nor.gif";
	window.btnFR.src = "Images/fr_nor.gif";
}

function FastReverse()
{
	var bPlay = false;
	if (document.Player1.playState == 5)
		bPlay = true;

	for(var i=1; i <= nChlCount; i++)
	{
		objPlayer = eval("document.Player"+i);
		if (bPlay)
			objPlayer.Controls.play();
		else
			objPlayer.Controls.fastReverse();
	}
	window.btnFR.src = (document.Player1.playState == 5)?"Images/fr_down.gif":"Images/fr_nor.gif";
	window.btnFF.src = "Images/ff_nor.gif";
}

function SetPlayPosition(nCurPosition)
{
	
	if (nCurPosition != 0)
	{
		for(var i=1; i <= nChlCount; i++)
		{
			objPlayer = eval("document.Player"+i);
			objPlayer.Controls.currentPosition = parseInt(nCurPosition);
		}		
	}
}

function Mute()
{
	bMute = !document.Player1.settings.mute;
	for(var i=1; i <= nChlCount; i++)
	{
		objPlayer = eval("document.Player"+i);
		objPlayer.settings.mute = bMute;
	}
	window.spMute.innerHTML = bMute?"<img src='Images/mute_down.gif' title=\"声音\" style=\"cursor:hand\">":"<img src='Images/mute_nor.gif' title=\"静音\" style=\"cursor:hand\">";
}

function GoPosition()
{
	if (document.Player1.playState == 2 || document.Player1.playState == 3
		|| document.Player1.playState == 4 || document.Player1.playState == 5)
	{
		var nLeftPix = event.offsetX;
		var nDuration	= document.Player1.currentMedia.Duration;
		var nPosition =  Math.round(nDuration * nLeftPix / window.spTimeSlider.style.pixelWidth)
		if (document.Player1.playState == 4 || document.Player1.playState == 5)
			Play();

		SetPlayPosition(nPosition);

		window.spTimePass.style.pixelWidth = nLeftPix ;
		window.spTimeBtn.style.left = parseInt(window.spTimeSlider.offsetLeft) + parseInt(window.spTimePass.style.pixelWidth);
	}
}

function DragTimeSlider(obj)
{
	if (document.Player1.playState == 2 || document.Player1.playState == 3
		|| document.Player1.playState == 4 || document.Player1.playState == 5)
	{
		if(event.button == 1)
		{
			obj.setCapture();
			var nMin = 15;
			var nMax = window.spTimeSlider.style.pixelWidth;
			var nOffX,nLeftPix
			function obj.onmousemove()
			{
				nOffX = event.clientX;
				nLeftPix = nOffX - nMin;
				if (nOffX >= nMin && nOffX <= nMax)
				{
					try{
						bTimeSlider = true;
						obj.style.left = nOffX;
						window.spTimePass.style.pixelWidth = nLeftPix ;
					}catch(e){
						bTimeSlider = false;
					}
				}
				
			}

			function obj.onmouseup()
			{
				var nDuration	= document.Player1.currentMedia.Duration;
				var nPosition =  Math.round(nDuration * nLeftPix / window.spTimeSlider.style.pixelWidth);
				SetPlayPosition(nPosition);

				obj.releaseCapture();
				obj = false;
				bTimeSlider = false;
			}
		}
	}
}


function SetLoop()
{
	bLoop = !bLoop;
	
			objPlayer = document.Player1;
			if(bLoop)
				objPlayer.settings.playCount = 1000;
			else
				objPlayer.settings.playCount = 1;
	
	
	window.btnLoop.src = bLoop?"Images/loop_yes_nor.gif":"Images/loop_no_nor.gif";
}

function SetFull()
{	for(var i=1; i <= nChlCount; i++)
	{
		objPlayer = eval("document.Player"+i);
		objPlayer.fullScreen ;
	}
	if (curSelPlayer != null)
	{
		if (curSelPlayer.playState == 3)
		{
			curSelPlayer.fullScreen = 1;
		}
		else
			alert("全屏仅在播放状态下有效!");
	}
	else
	{
		if (nChlCount == 1 && document.Player1.playState == 3)
			document.Player1.fullScreen = 1;
		else
			alert("请选择要全屏的片断!");
	}

}

// init time slider
function InitTimeSlider()
{
	window.spTimeSlider.style.width = availWidth - 5;
	window.spTimePass.style.width=0;
}

function OnTimeOut()
{
	var nCurPos	 =  Math.round(document.Player1.controls.currentPosition);
	var nDuration = Math.round(document.Player1.currentMedia.duration);

	if (nCurPos > nDuration)
		nCurPos = nCurPos - nDuration;
	if (!bTimeSlider)
	{	
		window.spTimePass.style.pixelWidth = parseInt(parseInt(window.spTimeSlider.style.pixelWidth) * nCurPos / nDuration);
		window.spTimeBtn.style.left = parseInt(window.spTimeSlider.offsetLeft) + parseInt(window.spTimePass.style.pixelWidth);
	}
	window.spTimeLabel.innerText = ConvertToTime(nCurPos) + " / " + ConvertToTime(nDuration);
	if (nSegCount > 1)
	{
		if (nCurSegIndex <= nSegCount && nCurSegIndex != 0){
			if (document.Player1.playState != 3){
				PlayForSeg();
			}
				
		}
		else if((nCurSegIndex == 0) && bLoop){
			if (document.Player1.playState != 3)
				PlayForSeg();
		}
	}

	setTimeout("OnTimeOut()",1000);
}


function PlayerStateChange()
{
	if (document.Player1.playState == 1)
	{
		window.btnPlay.src = "Images/play_nor.gif";
		
		if (bAutoStop)
		{
			if (nSegCount > 1)
			{
				TurnSeg();
			}			
		}
	//	
	}
}


function ConvertToTime(nTime)
{
	var nHour	= Math.round((nTime - 1800) / 3600);
	var nMin	= Math.round(((nTime % 3600) - 30)/ 60);
	var nSec	= Math.round((nTime % 3600) % 60);

	var strsHour	= ConvertToString(nHour);
	var strMin		= ConvertToString(nMin);
	var strSec		= ConvertToString(nSec);
	
	return strsHour + ":" + strMin + ":" + strSec;	
}

function ConvertToString(nValue)
{
	var strReturn;
	if (nValue < 10)
		strReturn = "0" + nValue;
	else
		strReturn = nValue;
	return strReturn;
}



// Chk local mediaplay version
function ChkMediaPlay()
{
	var nMajor = 0;
	try
	{
		var strVersion = document.Player1.versionInfo;
		if (strVersion != null)
		{
			var arrVersion = strVersion.split(".");
			nMajor = parseInt(arrVersion[0]);
		}
		if (nMajor < 9)
		{
			alert("您没有安装Windows Media Player 9,请先安装!");
			return false;
		}
	}
	catch(e)
	{
		alert("您没有安装Windows Media Player 9,请先安装!");
		return false;
	}
	return true;
}


// mouse status

function MMover_Play(obj)
{
	if (document.Player1.playState != 3)
		obj.src = "Images/play_hot.gif";
	else
		obj.src = "Images/pause_hot.gif";

}
function MMout_Play(obj)
{
	if ((document.Player1.playState == 3) || (document.Player1.playState == 9))
		obj.src = "Images/pause_nor.gif";
	else
		obj.src = "Images/play_nor.gif";	
}

function MMover_Stop(obj)
{
	obj.src = "Images/stop_hot.gif";
}

function MMout_Stop(obj)
{
	obj.src = "Images/stop_nor.gif";
}
function MMover_FF(obj)
{
	obj.src = "Images/ff_hot.gif";
}
function MMout_FF(obj)
{
	obj.src = (document.Player1.playState == 4)?"Images/ff_down.gif":"Images/ff_nor.gif";;
}

function MMover_FR(obj)
{
	obj.src = "Images/fr_hot.gif";
}
function MMout_FR(obj)
{
	obj.src = (document.Player1.playState == 5)?"Images/fr_down.gif":"Images/fr_nor.gif";;
}
function MMover_Loop(obj)
{
	if (bLoop)
		obj.src = "Images/loop_yes_hot.gif";
	else
		obj.src = "Images/loop_no_hot.gif";
}

function MMout_Loop(obj)
{
	if (bLoop)
		obj.src = "Images/loop_yes_nor.gif";
	else
		obj.src = "Images/loop_no_nor.gif";
}

function MMover_Full(obj)
{
	obj.src = "Images/full_hot.gif";
}

function MMout_Full(obj)
{
	obj.src = "Images/full_nor.gif";
}

function MMover_M1(obj)
{
	obj.src="Images/m1_hot.gif";
}
function MMout_M1(obj)
{
	obj.src = "Images/m1_nor.gif";
}

function MMover_M2(obj)
{
	obj.src="Images/m2_hot.gif";
}
function MMout_M2(obj)
{
	obj.src = "Images/m2_nor.gif";
}

function MMover_M3(obj)
{
	obj.src="Images/m3_hot.gif";
}
function MMout_M3(obj)
{
	obj.src = "Images/m3_nor.gif";
}

function MMover_LR(obj)
{
	obj.src="Images/lr_hot.gif";
}
function MMout_LR(obj)
{
	obj.src = "Images/lr_nor.gif";
}

function MMover_TB(obj)
{
	obj.src="Images/tb_hot.gif";
}
function MMout_TB(obj)
{
	obj.src = "Images/tb_nor.gif";
}

