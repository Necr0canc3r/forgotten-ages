using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Events;
using System;

namespace ForgottenMemories.NPCs.Granite
{
	public class GraniteProtector : ModNPC
	{
		int counter = 0;
		public override void SetDefaults()
		{
			npc.width = 48;
			npc.height = 36;
			npc.damage = 48;
			npc.defense = 8;
			npc.lifeMax = 40;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = 70f;
			npc.knockBackResist = 1f;
			npc.aiStyle = 14;
			aiType = -1;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Granite Protector");
			Main.npcFrameCount[npc.type] = 6;
		}
		
		public override void FindFrame(int frameHeight)
		{
			npc.frameCounter++;
			if (npc.frameCounter >= 6)
			{
				npc.frame.Y += frameHeight;
				
				if (npc.frame.Y >= Main.npcFrameCount[npc.type] * frameHeight)
				{
					npc.frameCounter = 0;
					npc.frame.Y = 0;
				}
			} 
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = (int)Main.tile[x, y].type;
			return (tile == 368) ? 0.3f : 0f;
		}
		
		public override void NPCLoot()
		{
			int amountToDrop = Main.rand.Next(10,25);
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Granite, amountToDrop);	

			if (Main.rand.Next(20) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ProtectorStab"), 0);	
			}
		}
	
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = (int)(npc.lifeMax * 1f);
			npc.damage = (int)(npc.damage * 1f);
		}
	}
}
