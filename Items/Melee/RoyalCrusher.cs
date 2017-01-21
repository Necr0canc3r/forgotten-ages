using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace ForgottenMemories.Items.Melee
{
	public class RoyalCrusher : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Royal Crusher";
			item.damage = 17;
			item.melee = true;
			item.width = 62;
			item.height = 70;
			item.toolTip = "A blade fit for a king";
			item.useTime = 40;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 20000;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("Spark");
			item.shootSpeed = 10;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.GoldBroadsword, 1);
			recipe.AddIngredient(ItemID.PlatinumBroadsword, 1);
			recipe.AddIngredient(ItemID.Ruby, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(6) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 10);
				Main.dust[dust].noGravity = true;
				Main.dust[dust].scale = 1.2f;
			}
			if (Main.rand.Next(6) == 0)
			{
				int dust2 = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 11);
				Main.dust[dust2].scale = 1.2f;
				Main.dust[dust2].noGravity = true;
			}
		}
	}
}
