using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Essences.UndeadEssence 
{
	public class LeechingBow : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 14;
			item.ranged = true;
			item.width = 50;
			item.height = 50;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = 5;
			item.knockBack = 5;
			item.value = 30000;
            item.rare = 3;
			item.useAmmo = 40;
			item.UseSound = SoundID.Item5;
			item.shoot = mod.ProjectileType("LeechingArrow");
			item.shootSpeed = 15f;
			item.scale = 1.1f;

			item.noMelee = true;
			item.autoReuse = true;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Leeching Bow");
      Tooltip.SetDefault("Shoots life leeching arrows");
    }

		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int amountOfProjectiles = 2;
			for (int i = 0; i < amountOfProjectiles; ++i)
			{
				float sX = speedX;
				float sY = speedY;
				sX += (float)Main.rand.Next(-60, 61) * 0.02f;
				sY += (float)Main.rand.Next(-60, 61) * 0.02f;
				Projectile.NewProjectile(position.X, position.Y, sX, sY, mod.ProjectileType("LeechingArrow"), damage, knockBack, player.whoAmI);
			}
			return false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "UndeadEnergy", 10);
			recipe.AddIngredient(ItemID.Bone, 20);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
