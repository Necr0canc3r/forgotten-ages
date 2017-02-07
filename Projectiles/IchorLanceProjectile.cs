using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles
{
    public class IchorLanceProjectile : ModProjectile
    {
    	
        public override void SetDefaults()
        {
            projectile.name = "Ichor Lance";
			projectile.width = 40;  
			projectile.aiStyle = 19;
			projectile.melee = true; 
			projectile.timeLeft = 90;
			projectile.height = 40;  
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			projectile.penetrate = -1;
			projectile.ownerHitCheck = true;
			projectile.hide = true;
        }

        public override void AI()
        {
        	Main.player[projectile.owner].direction = projectile.direction;
        	Main.player[projectile.owner].heldProj = projectile.whoAmI;
        	Main.player[projectile.owner].itemTime = Main.player[projectile.owner].itemAnimation;
        	projectile.position.X = Main.player[projectile.owner].position.X + (float)(Main.player[projectile.owner].width / 2) - (float)(projectile.width / 2);
        	projectile.position.Y = Main.player[projectile.owner].position.Y + (float)(Main.player[projectile.owner].height / 2) - (float)(projectile.height / 2);
        	projectile.position += projectile.velocity * projectile.ai[0];
        	if(projectile.ai[0] == 0f)
        	{
        		projectile.ai[0] = 3f;
        		projectile.netUpdate = true;
        	}
        	if(Main.player[projectile.owner].itemAnimation < Main.player[projectile.owner].itemAnimationMax / 3)
        	{
        		projectile.ai[0] -= 0.95f;
				if (projectile.localAI[0] == 0f && Main.myPlayer == projectile.owner)
				{
					projectile.localAI[0] = 1f;
					Projectile.NewProjectile(projectile.Center.X + (projectile.velocity.X * 3/4), projectile.Center.Y + (projectile.velocity.Y * 3/4), projectile.velocity.X * 1.4f, projectile.velocity.Y * 1.4f, mod.ProjectileType("IchorSpearTip"), (int)((double)projectile.damage * 0.85f), projectile.knockBack * 0.85f, projectile.owner, 0f, 0f);
				}
        	}
        	else
        	{
        		projectile.ai[0] += 1.2f;
        	}
        	
        	if(Main.player[projectile.owner].itemAnimation == 0)
        	{
        		projectile.Kill();
        	}
        	
        	projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 2.355f;
        	if(projectile.spriteDirection == -1)
        	{
        		projectile.rotation -= 1.57f;
        	}
			
			if (Main.rand.Next(5) == 0)
			{
				int dust;
				dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 64, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
				Main.dust[dust].scale = 1.5f;
			}
        }
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.Next(2) == 0)
			{
				target.AddBuff(69, 360, false);
			}
		}
    }
}