﻿using Terraria;
using Terraria.ModLoader;

namespace ForgottenMemories.Buffs
{
	public class ShadowflameSpirit : ModBuff
	{
		public override void SetDefaults()
		{
			Main.buffName[Type] = "Shadowflame Spirit";
			Main.buffTip[Type] = "A malevolent spirit fights for you";
			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = true;
		}
		
		public override void Update(Player player, ref int buffIndex)
		{
			TgemPlayer modPlayer = player.GetModPlayer<TgemPlayer>(mod);
			if (player.ownedProjectileCounts[mod.ProjectileType("ShadowflameSpirit")] > 0)
			{
				modPlayer.ShadowflameSpirit = true;
			}
			if (!modPlayer.ShadowflameSpirit)
			{
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else
			{
				player.buffTime[buffIndex] = 18000;
			}
		}
	}
}