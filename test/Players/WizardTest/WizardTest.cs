// GdUnit generated TestSuite
using Godot;
using GdUnit4;
using System.Threading.Tasks;
namespace GdUnitDefaultTestNamespace
{
	using static Assertions;
	using static Utils;

	[TestSuite]
	public class WizardTest
	{
		// TestSuite generated from
		private const string sourceClazzPath = "C:/Users/Filip/Documents/Godot/Players/Wizard/Wizard.cs";
		[TestCase]
		public async Task SpecialTest()
		{
			ISceneRunner runner = ISceneRunner.Load("res://test/TestRoom.tscn");
			Wizard k= runner.FindChild("Wizard") as Wizard;
			k.special();
			AssertThat(k.specialReady).IsFalse();
			AssertThat(k.stats.fireRate<=0.5f);
			await Task.Delay(5100);
			AssertThat(k.stats.fireRate>=0.5f);
		}
	}
}