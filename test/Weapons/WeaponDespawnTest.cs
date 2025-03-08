using Godot;
using GdUnit4;
using System.Threading.Tasks;

namespace GdUnitDefaultTestNamespace
{
	using static Assertions;
	using static Utils;

	[TestSuite]
	public class WeaponDespawnTest
	{
		// TestSuite generated from
		private const string sourceClazzPath = "C:/Users/Filip/Documents/Godot/Players/Knight.cs";
		[TestCase]
		public async Task Shotgun()
		{
			ISceneRunner runner = ISceneRunner.Load("res://test/TestRoom.tscn");
			await Task.Delay(5000);
			AssertThat(false).IsFalse();
			
		}
		[TestCase]
		public async Task Lance()
		{
			ISceneRunner runner = ISceneRunner.Load("res://test/TestRoom.tscn");
			await Task.Delay(5000);
			AssertThat(false).IsFalse();
			
		}
		[TestCase]
		public async Task Bombard()
		{
			ISceneRunner runner = ISceneRunner.Load("res://test/TestRoom.tscn");
			await Task.Delay(5000);
			AssertThat(false).IsFalse();
			
		}
		[TestCase]
		public async Task Flamer()
		{
			ISceneRunner runner = ISceneRunner.Load("res://test/TestRoom.tscn");
			await Task.Delay(5000);
			AssertThat(false).IsFalse();
			
		}
		[TestCase]
		public async Task Rpg()
		{
			ISceneRunner runner = ISceneRunner.Load("res://test/TestRoom.tscn");
			await Task.Delay(5000);
			AssertThat(false).IsFalse();
			
		}
		[TestCase]
		public async Task Lightning()
		{
			ISceneRunner runner = ISceneRunner.Load("res://test/TestRoom.tscn");
			await Task.Delay(5000);
			AssertThat(false).IsFalse();
			
		}
		[TestCase]
		public async Task Boomerang()
		{
			ISceneRunner runner = ISceneRunner.Load("res://test/TestRoom.tscn");
			await Task.Delay(5000);
			AssertThat(false).IsFalse();
			
		}
		
	}
}