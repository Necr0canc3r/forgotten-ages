using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Summon
{
	public class DesertStaff : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Desert Staff";
			item.damage = 33;
			item.summon = true;
			item.mana = 10;
			item.width = 19;
			item.height = 19;
			item.toolTip = "Creates a shadowflame spirit to fight for you";
			item.useTime = 36;
			item.UseSound = SoundID.Item20;
			item.useAnimation = 36;
			item.useStyle = 1;
			item.noMelee = true;
            item.knockBack = 2f;
            item.buffType = mod.BuffType("ShadowflameSpirit");
            item.buffTime = 3600;
			item.value = 50000;
			item.rare = 4;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("ShadowflameSpirit");
			item.shootSpeed = 10f;
		}
	}
}