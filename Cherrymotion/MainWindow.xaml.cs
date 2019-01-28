using KMCCC.Authentication;
using KMCCC.Launcher;
using System.Linq;
using System.Windows;
using Version = KMCCC.Launcher.Version;

namespace Cherrymotion
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var core = LauncherCore.Create();
            var Launchversion = core.GetVersion("1.13.2");
            var result = App.launcherCore.Launch(new LaunchOptions
            {
                Version = Launchversion, //Ver为Versions里你要启动的版本名字
                MaxMemory = 1024, //最大内存，int类型
                Authenticator = new OfflineAuthenticator("incotnigo"), //离线启动，ZhaiSoul那儿为你要设置的游戏名
                                                                       //Authenticator = new YggdrasilLogin("邮箱", "密码", true), // 正版启动，最后一个为是否twitch登录
                Mode = LaunchMode.MCLauncher,

                Server = new ServerInfo { Address = "180.101.116.73", Port = 31203 },
                //Size = new WindowSize { Heighta = 768, Width = 1024 } 
            });
            if (!result.Success)
            {
                MessageBox.Show(result.ErrorMessage, result.ErrorType.ToString());
                void NoJAVA(ErrorType results)
                {
                    MessageBox.Show("你系统的Java有异常，可能你非正常途径删除过Java，请尝试重新安装Java\n详细信息：" + result.ErrorMessage, "错误");
                }

                switch (result.ErrorType)
                {
                    case ErrorType.NoJAVA:
                        NoJAVA(ErrorType.NoJAVA);
                        break;
                    case ErrorType.AuthenticationFailed:
                        MessageBox.Show(this, "正版验证失败！请检查你的账号密码", "账号错误\n详细信息：" + result.ErrorMessage);
                        break;
                    case ErrorType.UncompressingFailed:
                        MessageBox.Show(this, "可能的多开或文件损坏，请确认文件完整且不要多开\n如果你不是多开游戏的话，请检查libraries文件夹是否完整\n详细信息：" + result.ErrorMessage, "可能的多开或文件损坏");
                        break;
                    default:
                        MessageBox.Show(this,
                            result.ErrorMessage + "\n" +
                            (result.Exception == null ? string.Empty : result.Exception.StackTrace),
                            "启动错误，请将此窗口截图向开发者寻求帮助");
                        break;
                }
            }

        }

        private void Maxmemory_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void Minmemory_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void Internet_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}
