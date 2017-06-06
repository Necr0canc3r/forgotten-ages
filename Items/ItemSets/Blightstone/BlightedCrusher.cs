using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace ForgottenMemories.Items.ItemSets.Blightstone
{
	public class BlightedCrusher : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 45;
			item.melee = true;
			item.width = 60;
			item.height = 60;

			item.useTime = 14;
			item.crit = 16;
			item.useAnimation = 14;
			item.useStyle = 1;
			item.knockBack = 4;
			item.value = 250000;
			item.rare = 5;
			item.useTurn = true;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Blighted Crusher");
      Tooltip.SetDefault("Critical hits create an explosion and reduce enemy defense");
    }


		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
			target.AddBuff(mod.BuffType("BlightFlame"), 180, false);
			if (crit == true)
			{
				target.defense -= 8;
				Projectile.NewProjectile(target.position.X, target.position.Y, 0f, 0f, mod.ProjectileType("BlightedBoom"), damage, 5f, player.whoAmI, 0f, 0f);
			}
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "blight_bar", 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
