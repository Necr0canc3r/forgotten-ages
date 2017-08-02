using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Optic
{
    public class ThirdEye : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 12;
            item.magic = true;
            item.mana = 5;
            item.width = 16;
            item.height = 17;

            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 4;
            item.value = 27000;
            item.rare = 1;
            item.UseSound = SoundID.Item20;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("PsyBolt");
            item.shootSpeed = 2.25f;
        }

		public override void SetStaticDefaults()
		{
		  DisplayName.SetDefault("The Third Eye");
		  Tooltip.SetDefault("'Predicts the locations of enemies'");
		}


        public override void HoldItem(Player player)
        {
            player.AddBuff(BuffID.Hunter, 2);
        }
    }
}
