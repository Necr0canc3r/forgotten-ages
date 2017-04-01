using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace ForgottenMemories.Items.Ranged 
{
	public class PlanetaryShotblaser : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Planetary Shotgun";
			item.damage = 114;
			item.ranged = true;
			item.width = 40;
			item.height = 14;
			item.useTime = 32;
			item.useAnimation = 32;
			item.useStyle = 5;
			AddTooltip("Creates a short-ranged wave and onyx rocks");
			item.knockBack = 6;
			item.value = 1000000;
			item.rare = 10;
			item.UseSound = SoundID.Item36;
			item.autoReuse = true;
			item.shoot = ProjectileID.Bullet;
			item.shootSpeed = 21f;
			item.noMelee = true;
			item.useAmmo =  AmmoID.Bullet;
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-2, 0);
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.OnyxBlaster, 1);
			recipe.AddIngredient(null,"FlameShotgun", 1);
			recipe.AddIngredient(3459, 30);
			recipe.AddIngredient(3457, 30);
			recipe.AddIngredient(3467, 10);
			recipe.AddTile(412);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int d = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("PlanetaryWave"), damage, knockBack, player.whoAmI);
			Main.projectile[d].timeLeft = 15;
			for (int i = 0; i < 3; i++)
			{
				float sX = speedX;
				float sY = speedY;
				sX += (float)Main.rand.Next(-60, 61) * 0.07f;
				sY += (float)Main.rand.Next(-60, 61) * 0.07f;
				int p = Projectile.NewProjectile(position.X, position.Y, sX, sY, 661, damage, knockBack, player.whoAmI); 
				Main.projectile[p].timeLeft = 15;
			}
			int amountOfProjectiles = Main.rand.Next(5, 7);
			for (int i = 0; i < amountOfProjectiles; i++)
			{
				float spX = speedX;
				float spY = speedY;
				spX += (float)Main.rand.Next(-40, 41) * 0.03f;
				spY += (float)Main.rand.Next(-40, 41) * 0.03f;
				Projectile.NewProjectile(position.X, position.Y, spX, spY, type, damage, knockBack, player.whoAmI);
			}
			
			return false;
		}
		
		public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine line2 in list)
            {
                if (line2.mod == "Terraria" && line2.Name == "ItemName")
                {
                    line2.overrideColor = new Color(246, 0, 255);
                }
            }
        }
	}
}