using HarmonyLib;
using Vintagestory.API.Common;

[assembly: ModInfo("KilnTimeViewer",
    Authors = new[] { "Noelle Lavenza" })]

namespace KilnTimeViewer
{
	class KilnTimeViewer : ModSystem
	{
		internal const string ModId = "kilntimeviewer";
		internal static Harmony harmony;

		public override void Start(ICoreAPI api)
		{
			api.World.Logger.Event("started 'KilnTimeViewer' mod");
			// TODO: Change to use a behavior when BEPitKiln.GetBlockInfo calls its base definition
			if (harmony is null)
			{
				harmony = new Harmony(ModId);
				harmony.PatchAll();
			}
		}

		public override void Dispose()
		{
			if (harmony is Harmony)
			{
				harmony.UnpatchAll(harmony.Id);
				harmony = null;
			}
			base.Dispose();
		}
	}
}