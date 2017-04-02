using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Projectiles
{
	public class XFlowStarYellow : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "X-Flow Star";
			projectile.width = 72;
			projectile.height = 72;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 260;
			projectile.alpha = 20;
			projectile.tileCollide = false;
		}
		
		public override void AI()
		{
			int dust;
			dust = Dust.NewDust(projectile.Center + projectile.velocity, 0, 0, 64, 0f, 0f);
			Main.dust[dust].scale = 0.7f;
			Main.dust[dust].noGravity = true;
			if (projectile.timeLeft <= 240)
			{
				projectile.tileCollide = true;
			}
		}
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 5; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 64);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
		}
	}
}