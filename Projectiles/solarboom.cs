using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles {
	public class solarboom : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "Solar Detonator";
			projectile.width = 100;
			projectile.height = 100;
			projectile.aiStyle = -1;
			projectile.penetrate = 5;
			projectile.melee = true;
			projectile.friendly = true;
			projectile.alpha = 255;
			projectile.timeLeft = 3;
			projectile.tileCollide = false;
			projectile.light = 0.5f;
		}
		
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 20; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6);
				Main.dust[dust].scale = 3f;
				Main.dust[dust].noGravity = true;
			}
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
		}
		
		public override void AI()
		{
			if (Main.rand.Next(5) == 0)
			{
				int dust;
				dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(189, 180, false);
		}
	}
}	