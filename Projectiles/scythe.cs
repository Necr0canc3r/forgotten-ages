using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	public class scythe : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 28;
			projectile.height = 28;
			projectile.magic = true;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.penetrate = 2;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Scythe");
		}
		
		public override bool PreAI()
		{
			projectile.rotation += 0.3f;
			projectile.ai[0]++;
			if (projectile.ai[0] == 50)
			{
				projectile.velocity *= 17f;
			}
			if (Main.rand.Next(6) == 0)
			{
				int dust = Dust.NewDust(projectile.Center + projectile.velocity, 0, 0, 60, 0f, 0f);
			}
			
			if (Main.rand.Next(6) == 0)
			{
				int dust2 = Dust.NewDust(projectile.Center + projectile.velocity, 0, 0, mod.DustType("reddust"), 0f, 0f);
			}
			
			return false;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(mod.BuffType("DevilsFlame"), 360, false);
		}
	}
}
