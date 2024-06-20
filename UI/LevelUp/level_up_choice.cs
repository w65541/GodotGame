using Godot;
using System;

public partial class level_up_choice : TextureButton
{
	RichTextLabel name,level,opis;
	TextureRect sprite;
	Levelable item;
	Node2D player;
	string path;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		name=GetChild<RichTextLabel>(0);
		level=GetChild<RichTextLabel>(1);
		opis=GetChild<RichTextLabel>(2);
		sprite=GetChild<TextureRect>(3);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public void updateNew(itemData x)
	{
		name.Text=x.name;
		level.Text="Lv "+x.level;
		opis.Text=x.opis;
		var tex=new CompressedTexture2D();
		tex.LoadPath=x.sprite;
		sprite.Texture=tex;
		item=null;
		path=x.scene;
	}
	public void updateOld(Levelable x)
	{
		item=x;
		name.Text=x.GetItemData().name;
		level.Text="Lv "+x.GetItemData().level;
		opis.Text=x.GetItemData().opis;
		var tex=new CompressedTexture2D();
		tex.LoadPath=x.GetItemData().sprite;
		sprite.Texture=tex;
	}


	public void _on_button_up()
	{
		if(item!=null)
		{
			item.levelup();
		}else{
			var s=GD.Load<PackedScene>(path);
			var instance=s.Instantiate();
			player.AddChild(instance);
		}
	}
}
