using Godot;
using GdUnit4;
using System.Threading.Tasks;
using System;

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
			Weapon u=runner.FindChild("Shotgun") as Weapon;
			u.Cooldown.Stop();
			u._on_timer_timeout();
			await Task.Delay(100);
			ProjectilePlayer bl=runner.FindChild("ShotgunBullet") as ProjectilePlayer;
			await Task.Delay(5000);
			try
			{
    		bl.Despawn();
			AssertThat(false).IsTrue();
			} catch (ObjectDisposedException e)
			{
   			 AssertThat(true).IsTrue();
			}
			
			runner.Dispose();
		}
		[TestCase]
		public async Task Lance()
		{
			ISceneRunner runner = ISceneRunner.Load("res://test/TestRoom.tscn");
			Weapon u=runner.FindChild("Lance") as Weapon;
			u.Cooldown.Stop();
			u._on_timer_timeout();
			await Task.Delay(100);
			ProjectilePlayer bl=runner.FindChild("Slash") as ProjectilePlayer;
			await Task.Delay(5000);
			try
			{
    		bl.Despawn();
			AssertThat(false).IsTrue();
			} catch (ObjectDisposedException e)
			{
   			 AssertThat(true).IsTrue();
			}
			
			runner.Dispose();
		}
		[TestCase]
		public async Task Bombard()
		{
			ISceneRunner runner = ISceneRunner.Load("res://test/TestRoom.tscn");
			Weapon u=runner.FindChild("Bombardment") as Weapon;
			u.Cooldown.Stop();
			u._on_timer_timeout();
			await Task.Delay(100);
			ProjectilePlayer bl=runner.FindChild("Bombard") as ProjectilePlayer;
			await Task.Delay(5000);
			try
			{
    		bl.Despawn();
			AssertThat(false).IsTrue();
			} catch (ObjectDisposedException e)
			{
   			 AssertThat(true).IsTrue();
			}
			
			runner.Dispose();
			
		}
		[TestCase]
		public async Task Flamer()
		{
			ISceneRunner runner = ISceneRunner.Load("res://test/TestRoom.tscn");
			Weapon u=runner.FindChild("Flamet") as Weapon;
			u.Cooldown.Stop();
			u._on_timer_timeout();
			await Task.Delay(100);
			ProjectilePlayer bl=runner.FindChild("Flame") as ProjectilePlayer;
			await Task.Delay(5000);
			try
			{
    		bl.Despawn();
			AssertThat(false).IsTrue();
			} catch (ObjectDisposedException e)
			{
   			 AssertThat(true).IsTrue();
			}
			
			runner.Dispose();
			
		}
		[TestCase]
		public async Task Rpg()
		{
			ISceneRunner runner = ISceneRunner.Load("res://test/TestRoom.tscn");
			Weapon u=runner.FindChild("RPG") as Weapon;
			u.Cooldown.Stop();
			u._on_timer_timeout();
			await Task.Delay(100);
			ProjectilePlayer bl=runner.FindChild("Rocket") as ProjectilePlayer;
			await Task.Delay(5000);
			try
			{
    		bl.Despawn();
			AssertThat(false).IsTrue();
			} catch (ObjectDisposedException e)
			{
   			 AssertThat(true).IsTrue();
			}
			
			runner.Dispose();
			
		}
		[TestCase]
		public async Task Lightning()
		{
			ISceneRunner runner = ISceneRunner.Load("res://test/TestRoom.tscn");
			Weapon u=runner.FindChild("Lightning") as Weapon;
			u.Cooldown.Stop();
			u._on_timer_timeout();
			await Task.Delay(100);
			ProjectilePlayer bl=runner.FindChild("Bolt") as ProjectilePlayer;
			await Task.Delay(5000);
			try
			{
    		bl.Despawn();
			AssertThat(false).IsTrue();
			} catch (ObjectDisposedException e)
			{
   			 AssertThat(true).IsTrue();
			}
			
			runner.Dispose();
			
		}
		[TestCase]
		public async Task Boomerang()
		{
			ISceneRunner runner = ISceneRunner.Load("res://test/TestRoom.tscn");
			Weapon u=runner.FindChild("Boomerang") as Weapon;
			u.Cooldown.Stop();
			u._on_timer_timeout();
			await Task.Delay(100);
			ProjectilePlayer bl=runner.FindChild("Rang") as ProjectilePlayer;
			await Task.Delay(5000);
			try
			{
    		bl.Despawn();
			AssertThat(false).IsTrue();
			} catch (ObjectDisposedException e)
			{
   			 AssertThat(true).IsTrue();
			}
			
			runner.Dispose();
			
		}
		
	}
}