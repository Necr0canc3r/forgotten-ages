using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Acessory 
{
	public class Blessed_Pearl : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 24;
			item.height = 28;

			AddTooltip("Taking damage when under half of your max health will restore even more health");
			AddTooltip("Increased length of invincibility");
			AddTooltip("'Protect it, and it will protect you'");
			item.value = 101500;
			item.rare = 4;
			item.accessory = true;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Blessed Pearl");
      Tooltip.SetDefault("Taking over 15 damage has a 1/2 chance to restore 15 health");
    }

		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CrossNecklace);
			recipe.AddIngredient(null, "Pearl");
			recipe.AddTile(114);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			((EnergyPlayer)player.GetModPlayer(mod, "EnergyPlayer")).pearl2 = true;
			player.longInvince = true;
		}
		
		public override bool CanEquipAccessory(Player player, int slot)
		{
			if (((EnergyPlayer)player.GetModPlayer(mod, "EnergyPlayer")).pearl == true)
			{
				return false;
			}
			
			else
			{
				return true;
			}
		}
	}	
}
