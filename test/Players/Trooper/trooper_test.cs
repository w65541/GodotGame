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
			AssertString("AbcD".ToLower()).IsEqual("abcd");
		}

		
	}
}