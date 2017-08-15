using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading;
using BizHawk.Emulation.Common;
using BizHawk.Emulation.Common.IEmulatorExtensions;
using BizHawk.Emulation.Cores.Nintendo.NES;
using BizHawk.Emulation.Cores.PCEngine;
using BizHawk.Emulation.Cores.Sega.MasterSystem;
using BizHawk.Emulation.Cores.WonderSwan;
using BizHawk.Emulation.Cores.Consoles.Nintendo.QuickNES;
using System.Data.SQLite;
using LuaInterface;

namespace BizHawk.Client.Common
{
	[Description("A library for interacting with the currently loaded emulator core")]
	public sealed class EmulatorLuaLibrary : LuaLibraryBase
	{
		[RequiredService]
		public IEmulator Emulator { get; set; }

		[OptionalService]
		public IDebuggable DebuggableCore { get; set; }

		[OptionalService]
		public IDisassemblable DisassemblableCore { get; set; }

		[OptionalService]
		private IMemoryDomains MemoryDomains { get; set; }

		[OptionalService]
		public IInputPollable InputPollableCore { get; set; }

		[OptionalService]
		public IRegionable RegionableCore { get; set; }

		public Action FrameAdvanceCallback { get; set; }
		public Action YieldCallback { get; set; }

		public EmulatorLuaLibrary(Lua lua)
			: base(lua) { }

		public EmulatorLuaLibrary(Lua lua, Action<string> logOutputCallback)
			: base(lua, logOutputCallback) { }

		public override string Name { get { return "emu"; } }

		[LuaMethodAttributes(
			"displayvsync",
			"Sets the display vsync property of the emulator"
		)]
		public static void DisplayVsync(bool enabled)
		{
			Global.Config.VSync = enabled;
		}
		SQLiteConnection m_dbConnection;
		string connectionString;
		int Frame=0;


		//Custom Database Calls
		//T


		[LuaMethodAttributes(
			"opendatabase",
			"Opens up a DQN SQLite database"
		)]
		public void OpenDatabase()
		{
			SQLiteConnectionStringBuilder connBuilder = new SQLiteConnectionStringBuilder()
			{
				//DataSource = "../../../Super-Meta-MarIO/DQN.db",
				DataSource = "../../Super-Meta-MarIO/DQN.db",
				Version = 3, //SQLite version 
				JournalMode = SQLiteJournalModeEnum.Wal,  //Allows for reads and writes to happen at the same time
				DefaultIsolationLevel = System.Data.IsolationLevel.ReadCommitted,  //This only helps make the database lock left. May be pointless now
				SyncMode = SynchronizationModes.Off //This shortens the delay for do synchronous calls.
			};
			m_dbConnection = new SQLiteConnection(connBuilder.ToString());  
			connectionString = connBuilder.ToString();
			ClearTable();
		}


		[LuaMethodAttributes(
			"sleep",
			"Sleeps Thread"
		)]
		public void Sleep()
		{
			//Thread.Sleep(100);
		}

		/// <summary>
		/// This is just a small function call to clear the main table out.
		/// </summary>
		private void  ClearTable()
		{
			try
			{
				m_dbConnection.Open();
				string sql = string.Format(
					"delete from rewards;"
					);
				SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
				command.ExecuteNonQuery();
				m_dbConnection.Close();
			}
			catch(SQLiteException sqlEX)
			{
			}
			
		}

		[LuaMethodAttributes(
			"createtable",
			"Creates a SQL table rewards for the DQN database" 
		)]
		public void CreateTable()
		{
			string sql = "create TABLE rewards (ID integer  PRIMARY KEY, action VARCHAR(20), score INT, image VARCHAR(1000))";
			SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
			command.ExecuteNonQuery();


			//This table has a 
			//auto incrementing primary key ID, 
			//a action of what button pressed,
			//a score for the reward,
			//an image stored as a custom array type.
			//a done flag which used to do multiprocessing. of bit type 
		}

		[LuaMethodAttributes(
			"updategenetable",
			"Updates Organism Input Output Table"
		)]
		public string UpdateGeneTable(LuaTable Table)
		{
			m_dbConnection.Open();
			string sql = "delete from Genes;";
			SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
			command.ExecuteNonQuery();
			using (var cmd = new SQLiteCommand(m_dbConnection))
			{
				using (var transaction = m_dbConnection.BeginTransaction())
				{
					foreach (var gene in Table.Keys)
					{
						string Value = Table[gene].ToString();
						string[] Keys = gene.ToString().Split();
						cmd.CommandText= string.Format("insert into Genes (Species,Genome,GenomeNum,Gene,GeneContent) values ({0},{1},{2},{3},'{4}');", Keys[0], Keys[1], Keys[2], Keys[3], Value);
						cmd.ExecuteNonQuery();
					}
					transaction.Commit();
				}
			}
			m_dbConnection.Close();
			return ":(";
		}




		[LuaMethodAttributes(
			"addrow",
			"Add a row in the SQL table"
		)]
		public void AddRow(string reward, string action)
		{
			m_dbConnection.Open();
			string sql = string.Format("PRAGMA read_uncommitted =1;insert into rewards (action,score,done) values ('{0}', {1},0);", reward, Int32.Parse("23"));
			SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
			command.ExecuteNonQuery();
			m_dbConnection.Close();
		}

		[LuaMethodAttributes("writecommand", "Runs a SQLite write command which includes CREATE,INSERT, UPDATE. " +
			"Ex: create TABLE rewards (ID integer  PRIMARY KEY, action VARCHAR(20)) ")]
		public string WriteCommand(string query = "")
		{
			if (query == "")
			{
				return "query is empty";
			}
			try
			{
				m_dbConnection.Open();
				string sql = query;
				SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
				command.ExecuteNonQuery();
				m_dbConnection.Close();
				return "Command ran successfully";

			}
			catch (NullReferenceException nullEX)
			{
				return "Database not open.";
			}
			catch (SQLiteException sqlEX)
			{
				m_dbConnection.Close();
				return sqlEX.Message;
			}
		}

		[LuaMethodAttributes(
			"getbutton",
			"Add a row in the SQL table"
		)]
		public int GetButton()
		{
			m_dbConnection.Open();
			const string sql = "PRAGMA read_uncommitted =1;Select action from rewards where score is NULL;";
			SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
			SQLiteDataReader reader = command.ExecuteReader();
			int button = 0;
			if(reader.Read())
			{
				button = Int32.Parse(reader.GetValue(0).ToString());
			}
			reader.Close();
			m_dbConnection.Close();
			return button;
		}

		[LuaMethodAttributes(
			"getgenome",
			"Gain a genome from rewards"
		)]
		public int GetGenome()
		{
			m_dbConnection.Open();
			const string sql = "PRAGMA read_uncommitted =1;Select genome from rewards where score is NULL;";
			SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
			SQLiteDataReader reader = command.ExecuteReader();
			int button = 0;
			if (reader.Read())
			{
				button = Int32.Parse(reader.GetValue(0).ToString());
			}
			reader.Close();
			m_dbConnection.Close();
			return button;
		}


		[LuaMethodAttributes(
			"getspecies",
			"Add a row in the SQL table"
		)]
		public int GetSpecies()
		{
			m_dbConnection.Open();
			const string sql = "PRAGMA read_uncommitted =1;Select species from rewards where score is NULL;";
			SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
			SQLiteDataReader reader = command.ExecuteReader();
			int button = 0;
			if (reader.Read())
			{
				button = Int32.Parse(reader.GetValue(0).ToString());
			}
			reader.Close();
			m_dbConnection.Close();
			return button;
		}

		[LuaMethodAttributes(
			"checktable",
			"Signals to the emulator to resume emulation. Necessary for any lua script while loop or else the emulator will freeze!"
		)]
		public bool CheckTable()
		{
			try
			{
				m_dbConnection.Open();
				string sql = "PRAGMA read_uncommitted =1;Select * from rewards where done =0 or done =2 or done=3;";
				SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
				SQLiteDataReader reader = command.ExecuteReader();
				//Console.WriteLine(reader.HasRows);
				bool x = reader.HasRows;
				reader.Close();
				m_dbConnection.Close();
				return x;

			}
			catch
			{
				return true;
			}

		}


		[LuaMethodAttributes(
			"frameadvance",
			"Signals to the emulator to resume emulation. Necessary for any lua script while loop or else the emulator will freeze!"
		)]
		public void FrameAdvance()
		{
			FrameAdvanceCallback();
		}

		[LuaMethodAttributes(
			"framecount",
			"Returns the current frame count"
		)]
		public int FrameCount()
		{
			return Emulator.Frame;
		}

		[LuaMethodAttributes(
			"disassemble",
			"Returns the disassembly object (disasm string and length int) for the given PC address. Uses System Bus domain if no domain name provided"
		)]
		public object Disassemble(uint pc, string name = "")
		{
			try
			{
				if (DisassemblableCore == null)
				{
					throw new NotImplementedException();
				}

				int l;
				MemoryDomain domain = MemoryDomains.SystemBus;

				if (!string.IsNullOrEmpty(name))
					domain = MemoryDomains[name];

				var d = DisassemblableCore.Disassemble(domain, pc, out l);
				return new { disasm = d, length = l };
			}
			catch (NotImplementedException)
			{
				Log(string.Format(
					"Error: {0} does not yet implement disassemble()",
					Emulator.Attributes().CoreName));
				return null;
			}
		}

		// TODO: what about 64 bit registers?
		[LuaMethodAttributes(
			"getregister",
			"returns the value of a cpu register or flag specified by name. For a complete list of possible registers or flags for a given core, use getregisters"
		)]
		public int GetRegister(string name)
		{
			try
			{
				if (DebuggableCore == null)
				{
					throw new NotImplementedException();
				}

				var registers = DebuggableCore.GetCpuFlagsAndRegisters();
				return registers.ContainsKey(name)
					? (int)registers[name].Value
					: 0;
			}
			catch (NotImplementedException)
			{

				Log(string.Format(
					"Error: {0} does not yet implement getregister()",
					Emulator.Attributes().CoreName));
				return 0;
			}
		}

		[LuaMethodAttributes(
			"getregisters",
			"returns the complete set of available flags and registers for a given core"
		)]
		public LuaTable GetRegisters()
		{
			var table = Lua.NewTable();

			try
			{
				if (DebuggableCore == null)
				{
					throw new NotImplementedException();
				}

				foreach (var kvp in DebuggableCore.GetCpuFlagsAndRegisters())
				{
					table[kvp.Key] = kvp.Value.Value;
				}
			}
			catch (NotImplementedException)
			{
				Log(string.Format(
					"Error: {0} does not yet implement getregisters()",
					Emulator.Attributes().CoreName));
			}

			return table;
		}

		[LuaMethodAttributes(
			"setregister",
			"sets the given register name to the given value"
		)]
		public void SetRegister(string register, int value)
		{
			try
			{
				if (DebuggableCore == null)
				{
					throw new NotImplementedException();
				}

				DebuggableCore.SetCpuRegister(register, value);
			}
			catch (NotImplementedException)
			{
				Log(string.Format(
					"Error: {0} does not yet implement setregister()",
					Emulator.Attributes().CoreName));
			}
		}

		[LuaMethodAttributes(
			"totalexecutedcycles",
			"gets the total number of executed cpu cycles"
		)]
		public int TotalExecutedycles()
		{
			try
			{
				if (DebuggableCore == null)
				{
					throw new NotImplementedException();
				}

				return DebuggableCore.TotalExecutedCycles;
			}
			catch (NotImplementedException)
			{
				Log(string.Format(
					"Error: {0} does not yet implement totalexecutedcycles()",
					Emulator.Attributes().CoreName));

				return 0;
			}
		}

		[LuaMethodAttributes(
			"getsystemid",
			"Returns the ID string of the current core loaded. Note: No ROM loaded will return the string NULL"
		)]
		public static string GetSystemId()
		{
			return Global.Game.System;
		}

		[LuaMethodAttributes(
			"islagged",
			"Returns whether or not the current frame is a lag frame"
		)]
		public bool IsLagged()
		{
			if (InputPollableCore != null)
			{
				return InputPollableCore.IsLagFrame;
			}
			else
			{
				Log(string.Format("Can not get lag information, {0} does not implement IInputPollable", Emulator.Attributes().CoreName));
				return false;
			}
		}

		[LuaMethodAttributes(
			"setislagged",
			"Sets the lag flag for the current frame. If no value is provided, it will default to true"
		)]
		public void SetIsLagged(bool value = true)
		{
			if (InputPollableCore != null)
			{
				InputPollableCore.IsLagFrame = value;
			}
			else
			{
				Log(string.Format("Can not set lag information, {0} does not implement IInputPollable", Emulator.Attributes().CoreName));
			}
		}

		[LuaMethodAttributes(
			"lagcount",
			"Returns the current lag count"
		)]
		public int LagCount()
		{
			if (InputPollableCore != null)
			{
				return InputPollableCore.LagCount;
			}
			else
			{
				Log(string.Format("Can not get lag information, {0} does not implement IInputPollable", Emulator.Attributes().CoreName));
				return 0;
			}
		}

		[LuaMethodAttributes(
			"setlagcount",
			"Sets the current lag count"
		)]
		public void SetLagCount(int count)
		{
			if (InputPollableCore != null)
			{
				InputPollableCore.LagCount = count;
			}
			else
			{
				Log(string.Format("Can not set lag information, {0} does not implement IInputPollable", Emulator.Attributes().CoreName));
			}
		}

		[LuaMethodAttributes(
			"limitframerate",
			"sets the limit framerate property of the emulator"
		)]
		public static void LimitFramerate(bool enabled)
		{
			Global.Config.ClockThrottle = enabled;
		}

		[LuaMethodAttributes(
			"minimizeframeskip",
			"Sets the autominimizeframeskip value of the emulator"
		)]
		public static void MinimizeFrameskip(bool enabled)
		{
			Global.Config.AutoMinimizeSkipping = enabled;
		}

		[LuaMethodAttributes(
			"setrenderplanes",
			"Toggles the drawing of sprites and background planes. Set to false or nil to disable a pane, anything else will draw them"
		)]
		public void SetRenderPlanes(params bool[] luaParam)
		{
			if (Emulator is NES)
			{
				// in the future, we could do something more arbitrary here.
				// but this isn't any worse than the old system
				var nes = Emulator as NES;
				var s = nes.GetSettings();
				s.DispSprites = (bool)luaParam[0];
				s.DispBackground = (bool)luaParam[1];
				nes.PutSettings(s);
			}
			else if (Emulator is QuickNES)
			{
				var quicknes = Emulator as QuickNES;
				var s = quicknes.GetSettings();
				// this core doesn't support disabling BG
				bool showsp = GetSetting(0, luaParam);
				if (showsp && s.NumSprites == 0)
					s.NumSprites = 8;
				else if (!showsp && s.NumSprites > 0)
					s.NumSprites = 0;
				quicknes.PutSettings(s);
			}
			else if (Emulator is PCEngine)
			{
				var pce = Emulator as PCEngine;
				var s = pce.GetSettings();
				s.ShowOBJ1 = GetSetting(0, luaParam);
				s.ShowBG1 = GetSetting(1, luaParam);
				if (luaParam.Length > 2)
				{
					s.ShowOBJ2 = GetSetting(2, luaParam);
					s.ShowBG2 = GetSetting(3, luaParam);
				}

				pce.PutSettings(s);
			}
			else if (Emulator is SMS)
			{
				var sms = Emulator as SMS;
				var s = sms.GetSettings();
				s.DispOBJ = GetSetting(0, luaParam);
				s.DispBG = GetSetting(1, luaParam);
				sms.PutSettings(s);
			}
			else if (Emulator is WonderSwan)
			{
				var ws = Emulator as WonderSwan;
				var s = ws.GetSettings();
				s.EnableSprites = GetSetting(0, luaParam);
				s.EnableFG = GetSetting(1, luaParam);
				s.EnableBG = GetSetting(2, luaParam);
				ws.PutSettings(s);
			}
		}

		private static bool GetSetting(int index, bool[] settings)
		{
			if (index < settings.Length)
			{
				return settings[index];
			}

			return true;
		}

		[LuaMethodAttributes(
			"yield",
			"allows a script to run while emulation is paused and interact with the gui/main window in realtime "
		)]
		public void Yield()
		{
			YieldCallback();
		}

		[LuaMethodAttributes(
			"getdisplaytype",
			"returns the display type (PAL vs NTSC) that the emulator is currently running in"
		)]
		public string GetDisplayType()
		{
			if (RegionableCore != null)
			{
				return RegionableCore.Region.ToString();
			}

			return string.Empty;
		}
	}
}
