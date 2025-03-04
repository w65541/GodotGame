using Godot;
using System;

public partial class PasiveWizard : PasiveBasic
{
	public PasiveWizard(int x) : base(x)
    {
    }

    public override void _Ready()
	{
		data=new itemData{
			name="Pas amunicji"
		};
		switch(level){
			case 1:
				data.opis="Zwieksza szybkosc strzalu o 0,3% co poziom (maks 50%)";
			break;
			case 2:
				data.opis="Zwieksza szybkosc strzalu o 0,6% co poziom (maks 50%)";
			break;
			case 3:
				data.opis="Zwieksza szybkosc strzalu o 1% co poziom (maks 50%)";
			break;
		}
		base._Ready();
	}
	public override void activate(){
		float temp;
		switch(level){
			case 1:
				temp=main.levelcount*0.03f;
				if(temp>0.5f) temp=0.5f;
				player.stats.fireRate-=temp;
			break;
			case 2:
				temp=main.levelcount*0.06f;
				if(temp>0.5f) temp=0.5f;
				player.stats.damageMult-=temp;
			break;
			case 3:
				temp=main.levelcount*0.1f;
				if(temp>0.5f) temp=0.5f;
				player.stats.damageMult-=temp;
			break;
		}
	}
}
