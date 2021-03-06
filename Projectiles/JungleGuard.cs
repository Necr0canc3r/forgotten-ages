﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
    public class JungleGuard : ModProjectile
    {
    	int timer = 0;
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.BabySlime);
            Main.projPet[projectile.type] = true;
            ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
            aiType = ProjectileID.BabySlime;
			projectile.penetrate = -1;
			projectile.tileCollide = false;
			projectile.minionSlots = 0;
			projectile.friendly = false;
			Main.projFrames[projectile.type] = 6;
			projectile.timeLeft = 300;
			projectile.width = 44;
			projectile.height = 26;
        }
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Slime Guard");
		}

        public override void AI()
        {
			Vector2 move = Vector2.Zero;
			float distance = 400f;
			bool target = false;
			for (int k = 0; k < 200; k++)
			{
				if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5)
				{
					Vector2 newMove = Main.npc[k].Center - projectile.Center;
					float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
					if (distanceTo < distance)
					{
						newMove.Normalize();
						move = newMove;
						distance = distanceTo;
						target = true;
					}
				}
			}
			timer++;
			if (target && timer >= 50)
			{
				int proj = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, move.X * 15f, move.Y * 15f, 374, projectile.damage, 5f, projectile.owner);
				timer = 0;
			}
		}
		
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 10; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 44);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
		}
        
		public override bool MinionContactDamage()
        {
            return false;
        }
		
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (projectile.penetrate == 0)
            {
                projectile.Kill();
            }
            return false;
        }
    }
}
