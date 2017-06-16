@echo off
setlocal
set LUA_PATH=C:\Program Files (x86)\Lua\5.1\lua/?.lua;C:\Program Files (x86)\Lua\5.1\lua/?/init.lua;;.\?.lua;C:\Program Files (x86)\Lua\5.1\lua\?.lua;C:\Program Files (x86)\Lua\5.1\lua\?\init.lua;C:\Program Files (x86)\Lua\5.1\?.lua;C:\Program Files (x86)\Lua\5.1\?\init.lua;C:\Program Files (x86)\Lua\5.1\lua\?.luac;%LUA_PATH%
set LUA_CPATH=C:\Program Files (x86)\Lua\5.1\clibs/?.dll;.\?.dll;.\?51.dll;C:\Program Files (x86)\Lua\5.1\?.dll;C:\Program Files (x86)\Lua\5.1\?51.dll;C:\Program Files (x86)\Lua\5.1\clibs\?.dll;C:\Program Files (x86)\Lua\5.1\clibs\?51.dll;C:\Program Files (x86)\Lua\5.1\loadall.dll;C:\Program Files (x86)\Lua\5.1\clibs\loadall.dll;%LUA_CPATH%
"C:/Program Files (x86)/Lua/5.1/lua" -lluarocks.loader "C:\Program Files (x86)\Lua\5.1\rocks/luastatic/0.0.8-1/bin/luastatic.lua" %*
endlocal
