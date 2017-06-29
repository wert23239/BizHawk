ButtonNames = {
		"A",
		"B",
		"X",
		"Y",
		"Up",
		"Down",
		"Left",
		"Right",
	}
function ResetPositions()
	NetX = memory.readbyte(0x6D) * 0x100 + memory.readbyte(0x86)
	NetScore = memory.readbyte(0x07D8)*100000+memory.readbyte(0x07D9)*10000+memory.readbyte(0x07DA)*1000
	NetScore = NetScore + memory.readbyte(0x07DB)*100 + memory.readbyte(0x07DC)*10 + memory.readbyte(0x07DC)*1
	NetLevel = 1
	NetWorld = 1
end

Filename="Level11.state"
--[[
GetPostions: Return the postion of Mario Using in game Hex Bits
--]]
function GetPositions()
	--In the classic game the X bit is done using a paging bit first
	--This allows you to have bigger numbers than 256
	marioX = memory.readbyte(0x6D) * 0x100 + memory.readbyte(0x86)
	marioY = memory.readbyte(0x03B8)+16
	marioScore = memory.readbyte(0x7D8)*100000+memory.readbyte(0x07D9)*10000+memory.readbyte(0x07DA)*1000
	marioScore = marioScore+memory.readbyte(0x07DB)*100 + memory.readbyte(0x07DC)*10 + memory.readbyte(0x07DC)*1
	marioLevel = memory.readbyte(0x075C)
	marioWorld = memory.readbyte(0x075F)
	--marioScore= 19
	screenX = memory.readbyte(0x03AD)
	screenY = memory.readbyte(0x03B8)
end


local function SetUpInput()
	controller = {}
	for b = 1,#ButtonNames do
		controller["P1 " .. ButtonNames[b]] = false
	end
	--joypad.set(controller)
	return controller
end

function CalculateFitness()
	fitness= marioX - NetX
	if mode==DEATH_ACTION then
		fitness=fitness-20
	end
end


function PressButton(button)
	Buttons=SetUpInput()
	Button=ButtonNames[button]
	Buttons["P1 "..Button]=true
	--joypad.set(Buttons)
end

function ClearButtons()
	Buttons=SetUpInput()
	Button=ButtonNames[7]
	Buttons["P1 "..Button]=true
	--joypad.set(Buttons)
end

local function GatherReward()
	GetPositions()
	CalculateFitness()
	sql=[[
	PRAGMA read_uncommitted =1;
	update rewards
	set score=]] .. fitness .." WHERE score is NULL"
	--console.writeline(sql)
	emu.writecommand(sql)
	console.writeline("update completed")
end
	
-- client.CreateDatabase()


-- client.OpenDatabase()
-- client.CreateTable()
emu.opendatabase() --opens datbase
savestate.load(Filename) --load Level 1
emu.writecommand([[
 	PRAGMA read_uncommitted =1;
 	insert into rewards (done) values (0);	
 	]])

DEATH_WAIT,DEATH_ACTION,WAIT,ACTION = 0,1,2,3
local ACTIONTIME=50
actionframe=0
ResetPositions()
ClearButtons()
mode=WAIT
fitness=0
while true do
	joypad.set(Buttons)
	if (mode~=DEATH_ACTION and mode~=DEATH_WAIT) and memory.readbyte(0x000E)==11 then
	   if mode==ACTION then
	      mode=DEATH_ACTION      
	   else
	   	  mode=DEATH_WAIT
	   end	  
	end
	if mode==DEATH_ACTION then
		GatherReward()
		emu.writecommand([[
		PRAGMA read_uncommitted =1; 
		insert into rewards (done) values (2);	
		]])
		savestate.load(Filename)
		mode=WAIT
		ClearButtons()
		actionframe=0
	end 
    if mode==WAIT and emu.checktable()==false then
 		PressButton(emu.getbutton())
 		ResetPositions()
 		mode=ACTION
 	end
 	if mode==ACTION then
 		actionframe=actionframe+1
 	end	
 	if actionframe>=ACTIONTIME then
 		mode=WAIT
	    actionframe=0
	    GatherReward()
	    emu.writecommand([[
		PRAGMA read_uncommitted =1;
		insert into rewards (done) values (0);	
		]])
		ClearButtons()
 	end

 	emu.frameadvance()
end