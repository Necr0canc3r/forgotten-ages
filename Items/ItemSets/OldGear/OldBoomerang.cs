using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace ForgottenMemories.Items.ItemSets.OldGear
{
    public class OldBoomerang : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Ancient Boomerang";
            item.damage = 11;            
            item.melee = true;
            item.width = 30;
            item.height = 30;
            item.toolTip = "Fires 3 boomerangs";
            item.useTime = 25;
            item.useAnimation = 25;
            item.noUseGraphic = true;
            item.useStyle = 1;
            item.knockBack = 3;
            item.value = 10000;
            item.rare = 1;
            item.shootSpeed = 12f;
            item.shoot = mod.ProjectileType ("OldBoom");
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }
		
		 public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float spread = 45f * 0.0174f;
			float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
			double startAngle = Math.Atan2(speedX, speedY)- spread/2;
			double deltaAngle = spread/3f;
			double offsetAngle;
			int i;
			for (i = 0; i < 3;i++ )
			{
				offsetAngle = startAngle + deltaAngle * i;
				Terraria.Projectile.NewProjectile(position.X, position.Y, baseSpeed*(float)Math.Sin(offsetAngle), baseSpeed*(float)Math.Cos(offsetAngle), item.shoot, damage, knockBack, item.owner);
			}
			return false;
		}
		
        public override bool CanUseItem(Player player)       //this make that you can shoot only 1 boomerang at once
        {
            for (int i = 0; i < 1000; ++i)
            {
                if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == item.shoot)
                {
                    return false;
                }
            }
            return true;
        }
        public override void AddRecipes()
        {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.DirtBlock, 1);
                recipe.SetResult(this);
                recipe.AddRecipe();
        }
    }
}