using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles.GhastlyEnt
{
	public class GhastlyKnife : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "Ghastly Knife";
			projectile.width = 10;
			projectile.height = 30;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.thrown = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 1000;
		}
		
		public override void Kill(int timeLeft)
		{
			if (Main.rand.Next(3) == 0)
        	{
        		Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height, mod.ItemType("GhastlyKnife"));
        	}
			for (int i = 0; i < 5; i++)
			{
				int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 64, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
			int amountOfProjectiles = Main.rand.Next(2, 5);
			
			for (int i = 0; i < amountOfProjectiles; ++i)
				{
					float sX = (float)Main.rand.Next(-60, 61) * 0.1f;
					float sY = (float)Main.rand.Next(-60, 61) * 0.1f;
					int z = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, sX, sY, mod.ProjectileType("Woodchip"), projectile.damage / 2, 5f, projectile.owner);
					Main.projectile[z].ranged = false;
					Main.projectile[z].thrown = true;
				}
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y);
		}
		
		public override void AI()
		{
			if (projectile.velocity.X >= 0)
			{
				projectile.velocity.X -= 0.10f;
			}
			if (projectile.velocity.X <= 0)
			{
				projectile.velocity.X += 0.10f;
			}
			if (projectile.velocity.X == 0)
			{
				projectile.velocity.X -= 0f;
			}
			projectile.velocity.Y += 0.10f;
			if (Main.rand.Next(5) == 0)
			{
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 64, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			}
		}
	}
}