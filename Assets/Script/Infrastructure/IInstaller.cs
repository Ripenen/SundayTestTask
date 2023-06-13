namespace Script.Infrastructure
{
    public interface IInstaller<in TAssets>
    {
        public void Install(TAssets assets);
    }
}