using System.Collections.Generic;

namespace ProtoApp
{
    public abstract class AssetCollection
    {
        protected readonly IDictionary<AssetIdentifier, string> Assets;

        protected AssetCollection()
        {
            Assets = new Dictionary<AssetIdentifier, string>();

            BuildAssets();
        }

        protected void BuildAssets() {}

        public string FindAsset(AssetIdentifier assetId)
        {
            return Assets.ContainsKey(assetId) ? Assets[assetId] : default(string);
        }
    }
}