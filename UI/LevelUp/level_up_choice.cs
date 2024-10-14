using Godot;
using System;

public partial class level_up_choice : TextureButton
{
	RichTextLabel name,level,opis;
	TextureRect sprite;
	//Sprite2D sprite;
	Levelable item;
	Node2D player;
	string path;
	levelupmenu parent;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		parent=GetParent<levelupmenu>();
		name=GetChild<RichTextLabel>(0);
		level=GetChild<RichTextLabel>(1);
		opis=GetChild<RichTextLabel>(2);
		sprite=GetChild<TextureRect>(3);
		player=GetParent().GetParent<Player>();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public itemData toDel;
	public void updateNew(itemData x)
	{
		name.Text=x.name;
		level.Text="Lv "+x.level;
		opis.Text=x.opis;
		var tex = (Texture2D)GD.Load(x.sprite); 
		sprite.Texture=tex;
		item=null;
		path=x.scene;
		toDel=x;
	}
	public void updateOld(Levelable x)
	{
		item=x;
		name.Text=x.GetItemData().name;
		level.Text="Lv "+x.GetItemData().level;
		opis.Text=x.GetItemData().opis;
		var tex =(Texture2D) GD.Load(x.GetItemData().sprite); 
		sprite.Texture=tex;
		toDel.name=null;
	}


	public void _on_button_up()
	{
		if(item!=null)
		{
			item.levelup();
		}else{
			

			
			for (int i = 0; i < parent.weapons.Count; i++)
			{
				if(parent.weapons[i].name.Equals(name.Text)){
					
					parent.weapons.RemoveAt(i);}
			}
			for (int i = 0; i < parent.items.Count; i++)
			{
				if(parent.items[i].name.Equals(name.Text)){
					
					parent.items.RemoveAt(i);}
			}
			

			var s=GD.Load<PackedScene>(path);
			var instance=s.Instantiate();
			player.AddChild(instance);
		}
		GetTree().Paused = !GetTree().Paused;
		parent.Visible=false;
	}
}
