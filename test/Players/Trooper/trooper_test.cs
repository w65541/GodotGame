// GdUnit generated TestSuite
using Godot;
using GdUnit4;

namespace GdUnitDefaultTestNamespace
{
	using static Assertions;
	using static Utils;

	[TestSuite]
	public class trooperTest
	{
		// TestSuite generated from
		private const string sourceClazzPath = "C:/Users/Filip/Documents/Godot/Players/Trooper/trooper.cs";
		[TestCase]
		public void PassiveTest()
		{
			ISceneRunner runner = ISceneRunner.Load("res://test/TestRoom.tscn");
			trooper tr= runner.FindChild("Trooper") as trooper;
			PasiveTrooper pt= runner.FindChild("PasiveTrooper") as PasiveTrooper;
			pt.level=3;
			BasicLevel l=tr.GetParent<BasicLevel>();
			l.levelcount=30;
			//tr.updateStats();
			pt.activate();
			AssertFloat(tr.stats.count).IsEqual(3);
		}

		
	}
}