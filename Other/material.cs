using Godot;
using System;

public struct material
	{ 
        public string name="";
        public long amount =0;
        public material()
    {
    }
    public void setAmount(long x){amount=x;}
}