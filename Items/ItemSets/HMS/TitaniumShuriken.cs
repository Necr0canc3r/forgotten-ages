using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.HMS
{
    public class TitaniumShurikenP : ModProjectile
    {
		int counter = 0;
        public override void SetDefaults()
        {
            projectile.width = 22;
            projectile.height = 22;
            projectile.penetrate = 4;
            projectile.aiStyle = -1;
			projectile.thrown = true;
			projectile.friendly = true;
            projectile.ignoreWater = true;
			projectile.tileCollide = false;
            projectile.timeLeft = 25;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Titanium Shuriken");
		}

        public override void Kill(int timeLeft)
        {
        	if (Main.rand.Next(12) == 0)
        	{
        		Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height, mod.ItemType("TitaniumShuriken"));
        	}
			for (int i = 0; i < 5; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 146);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y);
        }
		
		public override void AI()
		{
			Vector2 perturbedSpeed = new Vector2(projectile.velocity.X, projectile.velocity.Y).RotatedBy(MathHelper.Lerp(-(.5f/3.14f), (.5f / 3.14f), (1f / (3f - 1f))));
			Vector2 move = Vector2.Zero;
			Vector2 newMove = Main.MouseWorld - projectile.Center;
			if (counter == 0)
			{
				newMove.Normalize();
				move = newMove;
				projectile.velocity = (move * 14f);
				counter++;
			}
		}
    }

    public class TitaniumShuriken : ModItem
	{

        public override void SetDefaults()
        {

            item.damage = 34;
            item.shoot = mod.ProjectileType("TitaniumShurikenP");
            item.name = "Titanium Shuriken";
		}
    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Titanium Shuriken");
      Tooltip.SetDefault("Attacks at your cursor's location");
    }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TitaniumBar, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 20);
            recipe.AddRecipe();
        }
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int amountOfProjectiles = 3;
			for (int i = 0; i < amountOfProjectiles; ++i)
			{
				Vector2 mouse = Main.MouseWorld;
				mouse.X += Main.rand.Next(-300, 301);
				mouse.Y += Main.rand.Next(-300, 301);
				Projectile.NewProjectile(mouse.X, mouse.Y, 0f, 0f, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}
    }
}
