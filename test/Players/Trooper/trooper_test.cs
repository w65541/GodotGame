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
		public void _PhysicsProcess()
		{
			AssertString("AbcD".ToLower()).IsEqual("abcd");
		}

		[TestCase]
		public void CooldownSpecial()
		{
			AssertNotYetImplemented();
		}
	}
}