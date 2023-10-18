using Lux_Lunae.Resources.Database;
using System.Diagnostics;

namespace Lux_Lunae
{
    public partial class DailyPage : ContentPage
    {
        int count = 0;

        public DailyPage()
        {
            InitializeComponent();
            boi.Clicked += OnCounterClicked;
        }

        async private void OnCounterClicked(object sender, EventArgs e)
        {
            await LoadWords();
            List<LatinNounDef> words = App.sqlConn.Table<LatinNounDef>().ToList();
            Random random = new Random();
            dQuestion.Text = words[(random.Next(0, words.Count))].Word;
        }

        async Task LoadWords()
        {
            //App.sqlConn.Insert();
            App.sqlConn.DeleteAll<LatinConjunctionDef>();
            App.sqlConn.DeleteAll<LatinPrepositionDef>();
            App.sqlConn.DeleteAll<LatinAdverbDef>();
            App.sqlConn.DeleteAll<LatinNounDef>();
            App.sqlConn.DeleteAll<LatinAdjectiveDef>();
            App.sqlConn.DeleteAll<LatinVerbDef>();


            using var stream = await FileSystem.OpenAppPackageFileAsync("CoreListDefault.txt");
            using var reader = new StreamReader(stream);
            string line = reader.ReadLine();
            line = reader.ReadLine();
            while (line != null)
            {

                List<String> s = FormatLatinWord(line);

                if (s[4] == "Conjunction") { App.sqlConn.Insert(new LatinConjunctionDef(s)); }
                if (s[4] == "Preposition") { App.sqlConn.Insert(new LatinPrepositionDef(s)); }
                if (s[4] == "Adverb")      { App.sqlConn.Insert(new LatinAdverbDef(s)); }
                if (s[4] == "Noun")        { App.sqlConn.Insert(new LatinNounDef(s)); }
                if (s[4] == "Adjective")   { App.sqlConn.Insert(new LatinAdjectiveDef(s)); }
                if (s[4] == "Verb")        { App.sqlConn.Insert(new LatinVerbDef(s)); }

                line = reader.ReadLine();
            }
        }

        private List<String> FormatLatinWord(string line) {
            List<String> ret = new List<String>();

            try
            {
                bool inQuotes = false;
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] == '"')
                    {
                        inQuotes = !inQuotes;
                    }

                    if (!inQuotes && line[i] == ',')
                    {
                        string toAdd = line.Substring(0, i);

                        if (toAdd[0] == ',') { toAdd = toAdd.Substring(1); }
                        if (toAdd[0] == '"') { toAdd = toAdd.Substring(1); }
                        if (toAdd[toAdd.Length - 1] == '"') { toAdd = toAdd.Substring(0, toAdd.Length - 1); }

                        ret.Add(toAdd);
                        line = line.Substring(i);
                        i = 0;
                    }
                }

                {
                    string toAdd = line;

                    if (toAdd[0] == ',') { toAdd = toAdd.Substring(1); }
                    if (toAdd[0] == '"') { toAdd = toAdd.Substring(1); }
                    if (toAdd[toAdd.Length - 1] == '"') { toAdd = toAdd.Substring(0, toAdd.Length - 1); }

                    ret.Add(toAdd);
                }



                string partOfSpeech = ret[2];
                int split = partOfSpeech.IndexOf(":");
                string extraPOS = "";
                if (split != -1)
                {
                    extraPOS = partOfSpeech.Substring(split + 1).Trim();
                    partOfSpeech = partOfSpeech.Substring(0, split);
                }

                ret.RemoveAt(2);
                ret.Add(partOfSpeech);
                ret.Add(extraPOS);

            }
            catch {
                Debug.Assert(true);
            }



            return ret;
        }

    }
}
//public const double MyFontSize = 28;
//x:Static Member=mycdoe:MainPage.MyFontSize




