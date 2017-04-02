﻿using Terraria;
using Terraria.ModLoader;

namespace ForgottenMemories.Buffs
{
	public class EaterMinion : ModBuff
	{
		public override void SetDefaults()
		{
			Main.buffName[Type] = "Eater minion";
			Main.buffTip[Type] = "An eater of souls fight for you";
			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = true;
		}
		
		public override void Update(Player player, ref int buffIndex)
		{
			TgemPlayer modPlayer = player.GetModPlayer<TgemPlayer>(mod);
			if (player.ownedProjectileCounts[mod.ProjectileType("EaterMinion")] > 0)
			{
				modPlayer.EaterMinion = true;
			}
			if (!modPlayer.EaterMinion)
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