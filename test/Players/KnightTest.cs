// GdUnit generated TestSuite
using Godot;
using GdUnit4;
using System.Threading.Tasks;

namespace GdUnitDefaultTestNamespace
{
	using static Assertions;
	using static Utils;

	[TestSuite]
	public class KnightTest
	{
		// TestSuite generated from
		private const string sourceClazzPath = "C:/Users/Filip/Documents/Godot/Players/Knight.cs";
		[TestCase]
		public async Task horseTest()
		{
			ISceneRunner runner = ISceneRunner.Load("res://test/TestRoom.tscn");
			Knight k= runner.FindChild("Knight") as Knight;
			k.horseOn();
			AssertThat(k.horse).IsTrue();

			await Task.Delay(3100);
			AssertThat(k.horse).IsFalse();
			
		}
		[TestCase]
		public async Task chargeTest()
		{
			ISceneRunner runner = ISceneRunner.Load("res://test/TestRoom.tscn");
			Knight k= runner.FindChild("Knight") as Knight;
			k.charge();
			AssertThat(k.charging).IsTrue();
			
			await Task.Delay(10100);
			AssertThat(k.charging).IsFalse();
			
		}
	}
}
