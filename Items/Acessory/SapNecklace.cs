using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Acessory 
{
	public class SapNecklace : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Sap Necklace";
			item.width = 24;
			item.height = 28;
			item.toolTip = "Summon attacks have a chance to create balls of sap";
			item.toolTip2 = "Increased Max Minions";
			item.value = 50000;
			item.rare = 8;
			item.accessory = true;
			item.expert = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			((EnergyPlayer)player.GetModPlayer(mod, "EnergyPlayer")).sapBall = true;
			player.maxMinions += 1;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "AmberCrystal", 1);
			recipe.AddIngredient(ItemID.PygmyNecklace, 1);
			recipe.AddTile(114);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}