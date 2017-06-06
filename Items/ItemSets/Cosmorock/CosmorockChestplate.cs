using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Cosmorock
{
	public class CosmorockChestplate : ModItem
	{
		public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
		{
			equips.Add(EquipType.Body);
			return true;
		}

		public override void SetDefaults()
		{

			item.width = 18;
			item.height = 18;

			item.value = 250000;
			item.rare = 4;
			item.defense = 18;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Cosmic Chestplate");
      Tooltip.SetDefault("+50 Max Health");
    }


		public override void UpdateEquip(Player player)
		{
			player.statLifeMax2 += 50;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SpaceRockFragment", 18);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
