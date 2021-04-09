using System.IO;


namespace DemoEnvironmentVaultTool
{
    class LocalFileOperations
    {
        public void CreateTemp()
        {
            if (!Directory.Exists(Constants.tempPath))
                Directory.CreateDirectory(Constants.tempPath);

        }
        public void CreateMoreInfoPath()
        {
            if (!Directory.Exists(Constants.moreInfoPath))
                Directory.CreateDirectory(Constants.moreInfoPath);
        }
     

        public void ClearTemp()
        {
            if (Directory.Exists(Constants.tempPath))
                Directory.Delete(Constants.tempPath, true);
            if (Directory.Exists(Constants.updateTempPath))
                Directory.Delete(Constants.updateTempPath, true);

        }
        public void ClearUpdateTempPath()
        {
            if (Directory.Exists(Constants.updateTempPath))
                Directory.Delete(Constants.updateTempPath, true);
        }
        public void ClearMoreInfoPath()
        {
            if (Directory.Exists(Constants.moreInfoPath))
                Directory.Delete(Constants.moreInfoPath, true);
        }

    }
}
