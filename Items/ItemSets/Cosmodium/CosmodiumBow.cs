using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using ForgottenMemories.Projectiles.Info;

namespace ForgottenMemories.Items.ItemSets.Cosmodium
{
    public class CosmodiumBow : ModItem
    {

        public override void SetDefaults()
        {
            item.name = "Cosmodium Longbow";
            item.damage = 95;
            item.noMelee = true;
            item.ranged = true;
            item.width = 54;
            item.height = 24;
            item.toolTip = "Arrows fired keep their original effect and create leeching energy balls";
            item.useTime = 25;
            item.useAnimation = 25;
            item.useStyle = 5;
            item.shoot = 3;
            item.useAmmo = 40;
            item.knockBack = 2;
            item.value = Terraria.Item.sellPrice(0, 15, 0, 0);
            item.rare = 11;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.shootSpeed = 15f;

        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
				int p = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
				Main.projectile[p].GetModInfo<Info>(mod).Cosmodium = true;
            return false;
        }
		
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "CosmodiumBar", 10);
            recipe.AddTile(412);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
