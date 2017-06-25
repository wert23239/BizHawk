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


local function GatherInputs()
	local outputs = {}
	for o=1,#ButtonNames do
		local button = "P1 " .. ButtonNames[o]
		outputs[button] = false
	end
	return outputs
end


local function SetUpInput()
	controller = {}
	for b = 1,#ButtonNames do
		controller["P1 " .. ButtonNames[b]] = false
	end
	joypad.set(controller)
	return controller
end

local function PressButton()
	Buttons=SetUpInput()
	Button=ButtonNames[math.random(8)]
	Buttons["P1 "..Button]=true
	reward=5
	joypad.set(Buttons)
	--console.writeline("update "..rowcount)
	emu.addrow(reward,Button)
	--console.writeline("update completed")
end

-- client.CreateDatabase()
-- client.OpenDatabase()
-- client.CreateTable()
emu.opendatabase()
frame=0
lagcount=0
rowcount=0
while true do
	lagcount=0
    if frame>100 and emu.checktable()==false then
 	 	PressButton()
    	--console.writeline(emu.checktable())
    	--console.writeline(emu.checktable())
 	 	rowcount=rowcount+1
 	end
 	frame=frame+1
 	emu.frameadvance()
end