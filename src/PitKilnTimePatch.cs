using System;
using System.Text;
using HarmonyLib;
using Vintagestory.API.Common;
using Vintagestory.API.Config;
using Vintagestory.GameContent;

namespace KilnTimeViewer {
	[HarmonyPatch]
	public static class PitKilnTimePatch
	{
		private const string FinishTimeLangKey = KilnTimeViewer.ModId + ":pitkiln-finish-time";

		[HarmonyPostfix]
		[HarmonyPatch(typeof(BlockEntityPitKiln), nameof(BlockEntityPitKiln.GetBlockInfo))]
		public static void GetBlockInfoPatch(BlockEntityPitKiln __instance, StringBuilder dsc, InventoryGeneric ___inventory)
		{
			if (!__instance.Lit || ___inventory.Empty)
			{
				return;
			}

			var timeRemaining = __instance.BurningUntilTotalHours - __instance.Api.World.Calendar.TotalHours;
			var roundedHours = Math.Round(timeRemaining);

			dsc.AppendLine(Lang.Get(FinishTimeLangKey, roundedHours));
		}
	}
}