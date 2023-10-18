using Lux_Lunae.Resources.Database;
using SQLite;

namespace Lux_Lunae
{
    public partial class App : Application
    {

        public static SQLiteConnection sqlConn;
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();


            string filename = FileSystem.AppDataDirectory + "sqlitedata";
            sqlConn = new SQLiteConnection(filename);
            sqlConn.CreateTable<LatinNounDef>();
            sqlConn.CreateTable<LatinVerbDef>();
            sqlConn.CreateTable<LatinAdjectiveDef>();
            sqlConn.CreateTable<LatinPrepositionDef>();
            sqlConn.CreateTable<LatinAdverbDef>();
            sqlConn.CreateTable<LatinConjunctionDef>();

            Shell.Current.GoToAsync("//delve");
        }
    }
}