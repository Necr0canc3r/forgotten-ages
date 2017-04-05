using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace ForgottenMemories.Items.ItemSets.BlizzardSet
{
	public class Galeshard : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Blizzard Shard";
			item.toolTip = "'As icy as death's stare'";
			item.rare = 1;
            item.width = item.height = 38;
            item.maxStack = 999;
            ItemID.Sets.ItemNoGravity[item.type] = true;
           // ItemID.Sets.AnimatesAsSoul[item.type] = true;
            ItemID.Sets.ItemIconPulse[item.type] = true;
        }
        public override void Update(ref float gravity, ref float maxFallSpeed)
        {

        }
        public override DrawAnimation GetAnimation()
        {
            return new DrawAnimationVertical(5, 5);
        }
    }
}
