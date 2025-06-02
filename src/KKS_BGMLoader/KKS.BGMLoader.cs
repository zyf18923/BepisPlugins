using BepInEx;
using BepisPlugins;
using XUnity.ResourceRedirector;

namespace BGMLoader
{
    [BepInProcess(Constants.GameProcessName)]
    [BepInPlugin(GUID, PluginName, Version)]
    [BepInDependency(XUnity.ResourceRedirector.Constants.PluginData.Identifier)]
    public partial class BGMLoader : BaseUnityPlugin
    {
        private static bool TryGetOverrideFileName(IAssetLoadingContext context, out string overrideFileName)
        {
            overrideFileName = null;

            //kks_song_00 or kks_bgm_00
            var isBgm = context.Parameters.Name.Length == 9 && context.Parameters.Name.StartsWith("hse_ks", System.StringComparison.InvariantCultureIgnoreCase);
            if (!isBgm) return false;

            var parts = context.Parameters.Name.Split('_');
            if (parts.Length != 3) return false;

            overrideFileName = $"{parts[1].ToUpper()}{int.Parse(parts[2]):00}.wav";
            return true;
        }
    }
}
