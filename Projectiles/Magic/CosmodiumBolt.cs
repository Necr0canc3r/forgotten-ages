using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles.Magic
{
    public class CosmodiumBolt : ModProjectile
    {
        public override void SetDefaults()
        {
			projectile.hostile = false;
			projectile.magic = true;
			projectile.name = "Cosmodium Bolt";
			projectile.width = 10;
			projectile.height = 10;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.penetrate = 1;
			projectile.alpha = 255;
			projectile.timeLeft = 90;

        }
		
				public override bool PreAI()
		{
                int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 242, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            Main.dust[dust].noGravity = true;
            Main.dust[dust].scale = 2f;
            projectile.velocity.X *= 0.98f;
            projectile.velocity.Y *= 0.99f;
			return true;
		}

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 43);
            for (int k = 0; k < 15; k++)
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 242, projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
            }
            for (int h = 0; h < 10; h++)
            {
                Vector2 vel = new Vector2(0, -1);
                float rand = Main.rand.NextFloat() * 6.283f;
                vel = vel.RotatedBy(rand);
                vel *= 10f;
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel.X, vel.Y, mod.ProjectileType("CosmodiumBolt2"), projectile.damage, 0, projectile.owner);
            }
        }

    }
}
