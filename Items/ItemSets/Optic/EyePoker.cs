using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Optic
{
    public class EyePoker : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 12;

            item.melee = true;
            item.width = 19;
            item.height = 19;
            item.scale = 1.1f;
            item.maxStack = 1;
            item.useTime = 30;
            item.useAnimation = 30;
            item.knockBack = 5f;
            item.UseSound = SoundID.Item1;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.useStyle = 5;
            item.value = 27000;
            item.rare = 2;
            item.shoot = mod.ProjectileType("EyePoker");
            item.shootSpeed = 4f;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Eye Poker");
      Tooltip.SetDefault("Be careful!");
    }


        public override void HoldItem(Player player)
        {
            if (Main.rand.Next(1) == 0)
            {
                player.AddBuff(BuffID.Hunter, 2);
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "OpticBar", 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
