<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WMSTest.aspx.cs" Inherits="MOD.UI.Test.WMSTest" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312">
<title>���̲���</title>
<link href="style.css" rel="stylesheet" type="text/css">
<script language="javascript" src="Comm.js"></script>
</head>
<body  OnLoad="PageLoad()" onresize="PageResize()">

<!-- Main Area Begin -->		
<ul id="WholeArea">
    <li>�����<span id="spDown"><a href="mp9setup.exe">��װWindows Media Player 9</a></span></li>
    <li>�����<span id="spPlus"><a href="setup.exe">��װ���</a></span></li>
    <li>ʱ�䣺<span id="spTimeLabel"></span></li>
    <li>������<span id="spMute" onclick="Mute()"><img src="Images/mute_nor.gif"  title="����"  style="cursor:hand"></span></li>
    <li>�������ƣ� <span id="spVolumeSlider" onclick="GoVolume()"><span id="spVolumeCur"></span></span>
    <span id="spVolumeBtn"  style="cursor:hand"  onmousemove="SlideVolume(this)" onmouseup="SlideVolumeOver(this)"><img src="Images/volume_3.gif" style="cursor:hand"></span></li>
    <li>���Ų��1��<div id="Player1Area"  onmousedown="MLClick(Player1)"  onmousemove="MMove(Player1)">
			<OBJECT ID="Player1" CLASSID="CLSID:6BF52A52-394A-11D3-B153-00C04F79FAA6" WIDTH="174" HEIGHT="144" onmousedown="MLClick(this)">
			<PARAM NAME="uiMode" VALUE="none"></PARAM>
			</OBJECT>
		</div></li>
    <li><div id="spanValign"></div></li>     
   
    <li>ʱ��: <span id="spTimeSlider" onclick="GoPosition()"></span></li>
    <li>ʱ��: <span id="spTimePass" onclick="GoPosition()"></span></li>
    <li>ʱ��: <span id="spTimeBtn" onmousedown="DragTimeSlider(this)" ><img src="images/timebtn.gif"></span></li>
    <li></li>
    <li>����/��ͣ: <img id="btnPlay" src="Images/play_nor.gif" onclick="Play(this)" onmouseout="MMout_Play(this)" class="imgbtn" onmouseover="MMover_Play(this)" title="����/��ͣ"></li>
    <li>ֹͣ: <img id="btnStop" src="Images/stop_nor.gif" onclick="Stop()" class="imgbtn" onmouseover="MMover_Stop(this)" onmouseout="MMout_Stop(this);" title="ֹͣ"></li>
    <li>����: <img id="btnFR" class="imgbtn" src="Images/fr_nor.gif" onclick="FastReverse()" title="����" onmouseover="MMover_FR(this)" onmouseout="MMout_FR(this)"></li>
    <li>���: <img id="btnFF" class="imgbtn" src="Images/ff_nor.gif" onclick="FastForward()" title="���"  onmouseover="MMover_FF(this)" onmouseout="MMout_FF(this)"></li>
    <li>ѭ��: <img src="Images/loop_no_nor.gif" id="btnLoop" class="imgbtn"  onclick="SetLoop()" onmouseover="MMover_Loop(this)" onmouseout="MMout_Loop(this);" title="ѭ��/����">&nbsp;
    <img src="Images/full_nor.gif"  onclick="SetFull()" onmouseover="MMover_Full(this)" onmouseout="MMout_Full(this)" title="ȫ��" class="imgbtn"></li>
    <li>��չ�ؼ���<span id="spExControl"></span> </li> 
</ul>


</body>
</html>
