using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace ForgottenMemories.Items.Melee
{
	public class PixieSaber : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 47;
			item.melee = true;
			item.width = 88;
			item.height = 88;

			item.useTime = 30;
			item.useAnimation = 10;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 100000;
			item.rare = 4;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("starproj");
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Pixie Saber");
      Tooltip.SetDefault("Creates stationary exploding stars");
    }

		
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(3) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 64);
			}
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.PixieDust, 25);
			recipe.AddIngredient(ItemID.UnicornHorn, 10);
			recipe.AddIngredient(520, 5);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
