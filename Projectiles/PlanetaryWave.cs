using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
	public class PlanetaryWave : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 150;
			projectile.height = 30;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.penetrate = 3;
			projectile.timeLeft = 28;
			projectile.alpha = 255;
			projectile.light = 0.5f;
			projectile.extraUpdates = 1;
			projectile.tileCollide = false;
			projectile.scale = 1.3f;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Planetary Wave");
			aiType = ProjectileID.Bullet;
		}
		
		public override void AI()
		{
			if (Main.rand.Next(5) == 0)
			{
				int dust;
				dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 128, projectile.velocity.X * -1f, projectile.velocity.Y * -1f);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
			if (Main.rand.Next(3) == 0)
			{
				int dust;
				dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 61, projectile.velocity.X * -1f, projectile.velocity.Y * -1f);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
		}
		
	}
}