using Godot;
using System;

public struct characterStatus
	{
		public string name="";
		public int level=1;
        public int skill=1;
        public int unlocked=0;

    public characterStatus()
    {
    }
    public string toString()
    {
        return "1:"+level+":"+skill;
    }
}