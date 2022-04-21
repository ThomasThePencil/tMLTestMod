using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace tMLTestMod.Globals
{
	public class TestGlobalItem : GlobalItem
	{
	}

	public class TestGlobalProjectile : GlobalProjectile
	{
	}

	public class TestGlobalNPC : GlobalNPC
	{
		public override bool AppliesToEntity(NPC entity, bool lateInstantiation) => entity.type == NPCID.Princess;
		public override void SetTownNPCProfile(NPC npc, Dictionary<int, ITownNPCProfile> database)
		{
			database[npc.type] = new PrincessClaireProfile();
		}
	}

	public class PrincessClaireProfile : ITownNPCProfile
	{
		public int RollVariation() => 0;
		public string GetNameForVariant(NPC npc) => "Claire";

		public Asset<Texture2D> GetTextureNPCShouldUse(NPC npc)
		{
			if (npc.IsABestiaryIconDummy && !npc.ForcePartyHatOn)
				return ModContent.Request<Texture2D>("tMLTestMod/NPCs/TownNPCs/PrincessClaire_Default");

			if (npc.altTexture == 1)
				return ModContent.Request<Texture2D>("tMLTestMod/NPCs/TownNPCs/PrincessClaire_Party");

			return ModContent.Request<Texture2D>("tMLTestMod/NPCs/TownNPCs/PrincessClaire_Default");
		}

		public int GetHeadTextureIndex(NPC npc) => NPCHeadID.Princess;
	}
}