using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles.InfoA
{
	
	public class Info : GlobalProjectile
	{
		public bool Paradox = false;
		public bool TrueHR = false;
		public bool Cosmodium = false;
		public bool Shroom = false;
		public bool Flamethrower = false;
		public bool Terra = false;
		public bool Titanium = false;
		public bool Planetary = false;
		public bool Split = false;
		public bool wtf = false;
		public bool BlightedBow = false;
		public bool FrostCrystal = false;
		public bool SnowSplit = false;
		
		public override bool InstancePerEntity {get{return true;}}
		
		public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
		{
			if (Flamethrower == true)
			{
				target.immune[projectile.owner] = 5;
			}
			
			if (SnowSplit == true || FrostCrystal == true)
			{
				target.AddBuff(BuffID.Frostburn, 180);
			}
			
			if (Main.rand.Next(2) == 0 && Paradox == true)
			{
				int z = Projectile.NewProjectile(projectile.Center.X + projectile.velocity.X * 100f, projectile.Center.Y + projectile.velocity.Y * 100f, projectile.velocity.X * -1, projectile.velocity.Y * -1, projectile.type, projectile.damage, 0f, projectile.owner, 0f, 0f);
				Main.projectile[z].GetGlobalProjectile<Info>(mod).Paradox = true;
				Main.projectile[z].tileCollide = false;
				Main.projectile[z].penetrate = 1;
			}
			if (BlightedBow == true)
			{
				target.AddBuff(mod.BuffType("BlightFlame"), 360, false);
			}
			
			if (Main.rand.Next(2) == 0 && Planetary == true)
			{
				Player player = Main.player[projectile.owner];
				Vector2 newMove = projectile.Center - player.Center;
				float memes = newMove.X * 15f;
				float memes2 = newMove.Y * 15f;
				memes += (float)Main.rand.Next(-40, 41) * 0.1f;
				memes2 += (float)Main.rand.Next(-40, 41) * 0.1f;
				int z = Projectile.NewProjectile(player.Center.X, player.Center.Y, memes, memes2, projectile.type, projectile.damage, 0f, projectile.owner, 0f, 0f);
				if(Main.rand.Next(3) == 0)
				{
					Main.projectile[z].GetGlobalProjectile<Info>(mod).Planetary = true;
				}
			}
		}
		
		public override void Kill(Projectile projectile, int timeLeft)
		{
			if (TrueHR == true)
			{
				int amountOfProjectiles = Main.rand.Next(1, 3);
				
				for (int i = 0; i < amountOfProjectiles; ++i)
				{
					float sX = (float)Main.rand.Next(-60, 61) * 0.2f;
					float sY = (float)Main.rand.Next(-60, 61) * 0.2f;
					Projectile.NewProjectile(projectile.position.X, projectile.position.Y, sX, sY, mod.ProjectileType("HallowEnergy"), 12, 5f, projectile.owner);
					
				}
			}
			
			if (Split == true && projectile.timeLeft == 0)
			{
				Vector2 origVect = new Vector2(projectile.velocity.X, projectile.velocity.Y);
				Vector2 newVect2 = origVect.RotatedBy(-System.Math.PI / 30);
				Vector2 newVect3 = origVect.RotatedBy(System.Math.PI / 30);
				Vector2 newVect4 = origVect.RotatedBy(-System.Math.PI / 60);
				Vector2 newVect5 = origVect.RotatedBy(System.Math.PI / 60);
				int ok1 = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, origVect.X, origVect.Y, projectile.type, (int)(projectile.damage*0.6), projectile.knockBack, projectile.owner);
				int ok2 = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, newVect2.X, newVect2.Y, projectile.type, (int)(projectile.damage*0.6), projectile.knockBack, projectile.owner);
				int ok3 = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, newVect3.X, newVect3.Y, projectile.type, (int)(projectile.damage*0.6), projectile.knockBack, projectile.owner);
				int ok4 = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, newVect4.X, newVect4.Y, projectile.type, (int)(projectile.damage*0.6), projectile.knockBack, projectile.owner);
				int ok5 = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, newVect5.X, newVect5.Y, projectile.type, (int)(projectile.damage*0.6), projectile.knockBack, projectile.owner);
				Main.projectile[ok1].GetGlobalProjectile<Info>(mod).wtf = true;
				Main.projectile[ok2].GetGlobalProjectile<Info>(mod).wtf = true;
				Main.projectile[ok3].GetGlobalProjectile<Info>(mod).wtf = true;
				Main.projectile[ok4].GetGlobalProjectile<Info>(mod).wtf = true;
				Main.projectile[ok5].GetGlobalProjectile<Info>(mod).wtf = true;
			}
			
			if (SnowSplit == true)
			{
				Vector2 origVect = new Vector2(-projectile.velocity.X / 2, -projectile.velocity.Y / 2);
				Vector2 newVect2 = origVect.RotatedBy(-System.Math.PI / Main.rand.Next(30));
				Vector2 newVect3 = origVect.RotatedBy(System.Math.PI / Main.rand.Next(30));
				if (Main.rand.Next(2) == 0)
				{
					int ok1 = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, origVect.X, origVect.Y, projectile.type, (int)(projectile.damage*0.6), projectile.knockBack, projectile.owner);
				}
				int ok2 = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, newVect2.X, newVect2.Y, projectile.type, (int)(projectile.damage*0.6), projectile.knockBack, projectile.owner);
				int ok3 = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, newVect3.X, newVect3.Y, projectile.type, (int)(projectile.damage*0.6), projectile.knockBack, projectile.owner);
			}
			
			if (Cosmodium == true)
			{
				int amountOfProjectiles = Main.rand.Next(2, 4);
				
				for (int i = 0; i < amountOfProjectiles; ++i)
				{
					float sX = (float)Main.rand.Next(-60, 61) * 0.2f;
					float sY = (float)Main.rand.Next(-60, 61) * 0.2f;
					int B = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, sX, sY, mod.ProjectileType("CosmodiumBolt2"), projectile.damage, 5f, projectile.owner);
					Main.projectile[B].magic = false;
					Main.projectile[B].ranged = true;
				}
			}
			
			if (Titanium == true)
			{
				int amountOfProjectiles = Main.rand.Next(1, 4);
				
				for (int i = 0; i < amountOfProjectiles; ++i)
				{
					float sX = (float)Main.rand.Next(-60, 61) * 0.2f;
					float sY = (float)Main.rand.Next(-60, 61) * 0.2f;
					Projectile.NewProjectile(projectile.position.X, projectile.position.Y, sX, sY, 126, 15, 5f, projectile.owner);
				}
			}
			
			if (Terra == true)
			{
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, 0f, mod.ProjectileType("TerraBoom"), 30, 5f, projectile.owner);
			}
		}
		public override void AI(Projectile projectile)
		{
			if (TrueHR == true)
			{
				int dust;
				dust = Dust.NewDust(projectile.Center + projectile.velocity, 0, 0, mod.DustType("bluedust"), 0f, 0f);
				Main.dust[dust].scale = 0.9f;
				Main.dust[dust].noGravity = true;
				int hitler;
				hitler = Dust.NewDust(projectile.Center + projectile.velocity, 0, 0, mod.DustType("pinkdust"), 0f, 0f);
				Main.dust[hitler].scale = 0.9f;
				Main.dust[hitler].noGravity = true;
			}
			
			if (Terra == true)
			{
				int dust;
				dust = Dust.NewDust(projectile.Center + projectile.velocity, 0, 0, 74, 0f, 0f);
				Main.dust[dust].scale = 0.9f;
				Main.dust[dust].noGravity = true;
			}
			
			if (BlightedBow == true)
			{
				int dust;
				dust = Dust.NewDust(projectile.Center, 0, 0, 65, 0f, 0f);
				Main.dust[dust].scale = 1.2f;
				Main.dust[dust].noGravity = true;
			}
			
			if (wtf == true && projectile.velocity.X == 0 && projectile.velocity.Y == 0)
			{
				projectile.Kill();
			}
			
			if (Shroom == true)
			{
				Vector2 targetPos = projectile.Center;
				float targetDist = 350f;
				bool targetAcquired = false;
				
				for (int i = 0; i < 200; i++)
				{
					if (Main.npc[i].CanBeChasedBy(projectile) && Collision.CanHit(projectile.Center, 1, 1, Main.npc[i].Center, 1, 1) && Main.npc[i].immune[projectile.owner] == 0)
					{
						float dist = projectile.Distance(Main.npc[i].Center);
						if (dist < targetDist)
						{
							targetDist = dist;
							targetPos = Main.npc[i].Center;
							targetAcquired = true;
						}
					}
				}
				
				if (targetAcquired)
				{
					float homingSpeedFactor = 4f;
					Vector2 homingVect = targetPos - projectile.Center;
					float dist = projectile.Distance(targetPos);
					dist = homingSpeedFactor / dist;
					homingVect *= dist;

					projectile.velocity = (projectile.velocity * 20 + homingVect) / 21f;
				}
			}
		}
	}
}