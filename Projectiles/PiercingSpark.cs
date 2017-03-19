using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles {
	public class PiercingSpark : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "Spark";
			projectile.width = 20;
			projectile.height = 20;
			projectile.aiStyle = 0;
			projectile.penetrate = -1;
			projectile.melee = true;
			projectile.friendly = true;
			projectile.alpha = 255;
			projectile.timeLeft = 80;
			projectile.tileCollide = false;
			projectile.light = 0.5f;
		}
		
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 5; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 69);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
		}
		
		public override void AI()
		{
			int dust;
			dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 69, 0f, 0f);
			Main.dust[dust].noGravity = true;
			Main.dust[dust].scale = 1.2f;
			projectile.velocity.X *= 0.96f;
			projectile.velocity.Y *= 0.96f;
		}
	}
}	