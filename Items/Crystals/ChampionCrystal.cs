using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Crystals
{
	public class ChampionCrystal : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Champion Crystal";
			item.width = 10;
			item.height = 10;
			item.noMelee = true; 
			item.value = 10000;
			item.rare = 2;
			item.maxStack = 999;
		}
}
}