using System;
using System.Collections.Generic;


namespace CastleGrimtol.Project
{
    public class Item : IItem
    {
        public string Name { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public string Description { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }



        public Item(string name, string description)
        {
            Name = name;
            Description = description;
        }



    }
}