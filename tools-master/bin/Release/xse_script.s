#org 0x22BC18
	lockall
	applymovement 0xFF 0x82725A6
	waitmovement 0x0
	showmoney 0x0 0x0
	nop

	msgbox 0x82A4F74 MSG_YESNO
	compare 0x800D 0x1
	if 0x1 goto 0x822BC48
	msgbox 0x82A4FD7 MSG_KEEPOPEN
	goto 0x822BD06
#org 0x822BC48
	checkitem 0x111 0x1
	compare 0x800D 0x0
	if 0x1 goto 0x822BCEA
	call 0x822BCBF
	checkmoney 0x1F4 0x0
	compare 0x800D 0x0
	if 0x1 goto 0x822BCF8
	sound 0x5F
	msgbox 0x82A501B MSG_KEEPOPEN
	paymoney 0x1F4 0x0
	updatemoney 0x0 0x0
	nop

	msgbox 0x82A5036 MSG_KEEPOPEN
	fanfare 0x172
	preparemsg 0x82A5052
	waitfanfare
	msgbox 0x82A506F MSG_KEEPOPEN
	closeonkeypress
	hidemoney 0x0 0x0
	applymovement 0xFF 0x822BD18
	waitmovement 0x0
	special 0xD0
	setvar 0x40A4 0x2
	clearflag 0x5D
	warp 0x1A 0x3 0xFF 0x20 0x21
	waitstate
	end
#org 0x822BD06
	closeonkeypress
	hidemoney 0x0 0x0
	applymovement 0xFF 0x822BD16
	waitmovement 0x0
	releaseall
	end
#org 0x822BCEA
	msgbox 0x82A5105 MSG_KEEPOPEN
	goto 0x822BD06
#org 0x822BCBF
	countpokemon
	compare 0x800D 0x6
	if 0x5 goto 0x822BCE9
	special2 0x800D 0x132
	compare 0x800D 0x1
	if 0x1 goto 0x822BCE9
	msgbox 0x82A50E5 MSG_KEEPOPEN
	goto 0x822BD06
#org 0x822BCF8
	msgbox 0x82A4FF7 MSG_KEEPOPEN
	goto 0x822BD06
#org 0x822BCE9
	return
#org 0x82A4F74
欢迎来到野生原野区！
花500$就可以尽情地捕捉宝可梦！
你要进行原野区活动吗。
#org 0x82A4FD7
好的，
欢迎下次再来！
#org 0x82A501B
请先付500$.
#org 0x82A5036
请收好你的原野球.
#org 0x82A506F
游戏结束的时候你会收到通知，
在那之前，请尽情地玩吧.
野生的宝可梦们在等着你去发现！
#org 0x82A5105
很抱歉，
似乎你还没有能量方块盒.
使用能量方块会使
原野区活动变得更有趣的.
拿到能量方块盒再来吧，
你可以在水静市选美大厅
索要到能量方块盒.
#org 0x82A50E5
很抱歉，
你的电脑盒子满了.
#org 0x82A4FF7
抱歉，
你带的钱不够.
