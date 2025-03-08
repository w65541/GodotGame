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
		int temp=0;
		main=(BasicLevel) GetTree().GetFirstNodeInGroup("Main");
		player=(Player) GetTree().GetFirstNodeInGroup("Player");
		GD.Print("StartPas");
		switch(level){
			case 0:
				temp=main.levelcount/40;
				player.stats.count+=temp;
				GD.Print("Level 0");
			break;
			case 1:
				temp=main.levelcount/30;
				player.stats.count+=temp;
				GD.Print("Level 1");
			break;
			case 2:
				temp=main.levelcount/20;
				player.stats.count+=temp;
				GD.Print("Level 2");
			break;
			case 3:
				temp=main.levelcount/10;
				player.stats.count+=temp;
				GD.Print("Level 3");
			break;
		}
		GD.Print("temp="+temp);
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
