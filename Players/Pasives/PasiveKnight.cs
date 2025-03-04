using Godot;
using System;

public partial class PasiveKnight : PasiveBasic
{
	public PasiveKnight(int x) : base(x)
    {
    }

    public override void _Ready()
	{
		data=new itemData{
			name="Pas amunicji"
		};
		switch(level){
			case 1:
				data.opis="Zwieksza obrazenia o 0,3% co poziom";
			break;
			case 2:
				data.opis="Zwieksza obrazenia o 0,6% co poziom";
			break;
			case 3:
				data.opis="Zwieksza obrazenia o 1% co poziom";
			break;
		}
		base._Ready();
	}
	public override void activate(){
		float temp;
		switch(level){
			case 1:
				temp=main.levelcount*0.3f;
				player.stats.damageMult+=temp;
			break;
			case 2:
				temp=main.levelcount*0.6f;
				player.stats.damageMult+=temp;
			break;
			case 3:
				temp=main.levelcount;
				player.stats.damageMult+=temp;
			break;
		}
	}
}
