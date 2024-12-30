using Ryujinx.HLE.Loaders.Processes;

namespace Ryujinx.Ava.Utilities
{
    public static class TitleHelper
    {
        public static string ActiveApplicationTitle(ProcessResult activeProcess, string applicationVersion, string pauseString = "")
        {
            if (activeProcess == null)
                return string.Empty;

            string titleNameSection = string.IsNullOrWhiteSpace(activeProcess.Name) ? string.Empty : $" {activeProcess.Name}";
            string titleVersionSection = string.IsNullOrWhiteSpace(activeProcess.DisplayVersion) ? string.Empty : $" v{activeProcess.DisplayVersion}";
            string titleIdSection = $" ({activeProcess.ProgramIdText.ToUpper()})";
            string titleArchSection = activeProcess.Is64Bit ? " (64-bit)" : " (32-bit)";

            string appTitle = $"Ryujinx {applicationVersion} -{titleNameSection}{titleVersionSection}{titleIdSection}{titleArchSection}";

            return !string.IsNullOrEmpty(pauseString)
                ? appTitle + $" ({pauseString})"
                : appTitle;
        }
    }
}