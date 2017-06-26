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
local function ResetPositions()
	NetX = memory.readbyte(0x6D) * 0x100 + memory.readbyte(0x86)
	NetScore = memory.readbyte(0x07D8)*100000+memory.readbyte(0x07D9)*10000+memory.readbyte(0x07DA)*1000
	NetScore = NetScore + memory.readbyte(0x07DB)*100 + memory.readbyte(0x07DC)*10 + memory.readbyte(0x07DC)*1
	NetLevel = 1
	NetWorld = 1
end

--[[
GetPostions: Return the postion of Mario Using in game Hex Bits
--]]
local function GetPositions()
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
	joypad.set(controller)
	return controller
end

local function CalculateFitness()
	fitness= marioX - NetX
end


local function PressButton()
	GetPositions()
	CalculateFitness()
	console.writeline(fitness)
	Buttons=SetUpInput()
	Button=ButtonNames[math.random(8)]
	Buttons["P1 "..Button]=true
	reward=5
	--joypad.set(Buttons)
	--console.writeline("update "..rowcount)
	--emu.addrow(reward,Button)
	--console.writeline("update completed")
	ResetPositions()
end



-- client.CreateDatabase()
-- client.OpenDatabase()
-- client.CreateTable()
emu.opendatabase()
frame=0
lagcount=0
rowcount=0
ResetPositions()
while true do
	lagcount=0
  	--if frame>100 and emu.checktable()==false then
 	if frame%100==0 then 	
 	 	PressButton()
 	 	rowcount=rowcount+1
 	end
 	frame=frame+1
 	emu.frameadvance()
end