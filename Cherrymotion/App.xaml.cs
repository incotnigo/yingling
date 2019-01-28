using KMCCC.Launcher;
using System.Windows;

namespace Cherrymotion

{
    public partial class App : Application
    {
        public static LauncherCore launcherCore = LauncherCore.Create(
            new LauncherCoreCreationOption(
                gameRootPath: null,
                javaPath: "C:/Program Files/Java/jdk1.8.0_201/bin/java.ex",
                versionLocator: null
            ));
    }
}
