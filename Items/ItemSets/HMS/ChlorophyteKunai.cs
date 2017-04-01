using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.HMS
{
	public class ChlorophyteKunai : ModItem
	{

		public override void SetDefaults()
		{
			item.damage = 52;
			item.thrown = true;
			item.shoot = mod.ProjectileType("ChlorophyteKunai");
			item.name = "Chlorophyte Kunai";
			AddTooltip("Explodes into spore clouds on hit");
			item.consumable = true;
			item.shootSpeed = 14f;
			item.useTime = 14;
			item.useAnimation = 14;
			item.consumable = true;
			item.maxStack = 999;
			item.useStyle = 1;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.value = 100;
			item.rare = 7;
			item.shootSpeed = 15f;
			item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 150);
			recipe.AddRecipe();
		}
	}
}