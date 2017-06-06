using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Oceanic
{
	public class AquaticChestplate : ModItem
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

			item.value = 10000;
			item.rare = 2;
			item.defense = 7;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Aquatic Chestplate");
      Tooltip.SetDefault("3% increased melee damage and critical strike chance");
    }


		public override void UpdateEquip(Player player)
		{
			player.meleeCrit += 3;
			player.meleeDamage += 0.03f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "WaterShard", 10);
			recipe.AddIngredient(ItemID.SharkFin, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
