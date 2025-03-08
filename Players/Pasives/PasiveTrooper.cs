using Godot;
using System;

public partial class PasiveTrooper : PasiveBasic
{

    public override void _Ready()
	{
		data=new itemData{
			name="Pas amunicji"
		};
		switch(level){
			case 0:
				data.opis="Zwieksza ilosc pociskow co 40 poziomow";
			break;
			case 1:
				data.opis="Zwieksza ilosc pociskow co 30 poziomow";
			break;
			case 2:
				data.opis="Zwieksza ilosc pociskow co 20 poziomow";
			break;
			case 3:
				data.opis="Zwieksza ilosc pociskow co 10 poziomow";
			break;
		}
		base._Ready();
	}
	public override void activate(){
		int temp;
		switch(level){
			case 1:
				temp=main.levelcount/30;
				player.stats.count+=temp;
			break;
			case 2:
				temp=main.levelcount/20;
				player.stats.count+=temp;
			break;
			case 3:
				temp=main.levelcount/10;
				player.stats.count+=temp;
			break;
		}
	}

    public override void opis()
    {
		data=new itemData{
			name="Pas amunicji"
		};
		switch(level){
			case 0:
				data.opis="Zwieksza ilosc pociskow co 40 poziomow";
			break;
			case 1:
				data.opis="Zwieksza ilosc pociskow co 30 poziomow";
			break;
			case 2:
				data.opis="Zwieksza ilosc pociskow co 20 poziomow";
			break;
			case 3:
				data.opis="Zwieksza ilosc pociskow co 10 poziomow";
			break;
		}
    }

}
