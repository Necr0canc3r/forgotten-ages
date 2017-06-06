using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Ammo
{
	public class GraniteSolution : ModItem
	{
		public override void SetDefaults()
		{

			item.shoot = mod.ProjectileType("GraniteSolution") - ProjectileID.PureSpray;
			item.ammo = AmmoID.Solution;
			item.width = 10;
			item.height = 12;
			item.value = Item.buyPrice(0, 0, 25, 0);
			item.rare = 3;
			item.maxStack = 999;


			item.consumable = true;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Granite Solution");
      Tooltip.SetDefault("Super gay\nSpreads the granite");
    }

	}
}
