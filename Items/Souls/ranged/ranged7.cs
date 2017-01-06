using Terraria.ID;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;


namespace ForgottenMemories.Items.Souls.ranged

{
	public class ranged7 : ModItem
	{
		public override void SetDefaults()
		{

			item.name = "Ranged Level 7";
			item.width = 40;
			item.height = 40;
			item.toolTip = "+ 12% Ranged Damage";
			item.toolTip2 = "Compatible with Forgotten Memories";
			item.value = 0;
			item.rare = 10;
			item.accessory = true;
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}
		public override DrawAnimation GetAnimation()
		{
			return new DrawAnimationVertical(5, 4);
		}
		public override void UpdateEquip(Player player)
		{
			player.rangedDamage += 0.12f;
		}
		public override void AddRecipes()

		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "soul", 1000);
			recipe.AddIngredient(null, "ExterminationCrystal", 5);
			recipe.AddIngredient(null, "ranged6", 1);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}