using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simila.Studio
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public SimilaProfile CurrentProfile { get; set; } = new SimilaProfile();

        public void Log(string text)
        {
            Invoke(new MethodInvoker(delegate()
            {
                listBoxLog.Items.Add($"[{DateTime.Now:HH:mm:ss}]: {text}");
            }));
        }

        private int _allRowsCount = 0;
        private int _doneRowsCount = 0;

        private void buttonLoadFile_Click(object sender, EventArgs e)
        {
            Log("Loading text file...");

            var dirtySourceDirectory = Path.Combine(Directory.GetCurrentDirectory(), @"DirtySources");
            var initDirectory =
                Directory.Exists(dirtySourceDirectory) ? dirtySourceDirectory : Directory.GetCurrentDirectory();

            var openFileDialog = new OpenFileDialog
            {
                Filter = @"Dirty Source|*.txt",
                Multiselect = false,
                InitialDirectory = initDirectory
            };

            if (openFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                var filename = openFileDialog.FileName;
                var textInstanceSource = new RawFileTextInstanceSource(filename);

                var instances = textInstanceSource.GetTextInstances();
                Log($"{instances.Count} instances loaded.");

                var similarityResults =
                (
                    from instance in instances
                    let ct = instance.ClearedText = ClearText(instance.Text)
                    select new SimilarityResult()
                    {
                        Original = instance,
                    }
                ).ToList();

                similarityResultBindingSource.DataSource = similarityResults;
                progressBarCalcStatus.Visible = true;
                PopulateSimilarities(similarityResults);
            }
        }

        static Regex regexNumber = new Regex(@"[\d-]*[@*/\\]");

        private string ClearText(string originalText)
        {
            if (string.IsNullOrWhiteSpace(originalText))
                return originalText;

            originalText = regexNumber.Replace(originalText, String.Empty).ReplaceYK();

            var parts = originalText
                .Split(' ')
                .Where(part => !CurrentProfile.DirtyWords.Contains(part));

            var clearedText = string.Join(" ", parts);
            return clearedText;
        }

        private void PopulateSimilarities(List<SimilarityResult> similarityResults)
        {
            var simila = GetSimila();
            _allRowsCount = similarityResults.Count;
            Log("Starting algorithm...");
            Task.Factory.StartNew(() =>
                {
                    Parallel.ForEach(similarityResults, (thisSimilarityResult, state, index) =>
                    {
                        var similars = Enumerable.Range(1, 5).Select(i => new SimilarInstance() { SimilarityRate = 0 }).ToList();
                        SimilarInstance minInstance = similars[0];

                        for (var i= index+1; i<similarityResults.Count ; i++)
                        {
                            var otherSimilarityResult = similarityResults[(int) i];
                            if (thisSimilarityResult == otherSimilarityResult || Math.Abs(thisSimilarityResult.OriginalCleared.Length-otherSimilarityResult.OriginalCleared.Length) > 4)
                                continue;

                            var similarityRate =
                                simila.GetSimilarityPercent(
                                    thisSimilarityResult.Original.ClearedText,
                                    otherSimilarityResult.Original.ClearedText);

                            if (similarityRate > 0.45 && similarityRate > minInstance.SimilarityRate)
                            {
                                minInstance.SimilarityRate = similarityRate;
                                minInstance.Similar = otherSimilarityResult.Original;

                                minInstance = similars.First(s =>
                                    s.SimilarityRate == similars.Min(sm => sm.SimilarityRate));
                            }
                        }

                        thisSimilarityResult.OtherSimilars.AddRange(similars.Where(s => s.Similar != null));

                        //var similarInstancesQuery =
                        //    from otherSimilarityResult in similarityResults
                        //    let similarityRate =
                        //    simila.GetSimilarityPercent(
                        //        thisSimilarityResult.Original.ClearedText,
                        //        otherSimilarityResult.Original.ClearedText)
                        //    where thisSimilarityResult != otherSimilarityResult
                        //          && similarityRate > 0.45
                        //    orderby similarityRate descending
                        //    select new SimilarInstance()
                        //    {
                        //        Similar = otherSimilarityResult.Original,
                        //        SimilarityRate = similarityRate
                        //    };


                        //thisSimilarityResult.OtherSimilars =
                        //    similarInstancesQuery
                        //        .Take(10)
                        //        .ToList();

                        var mostSimilar =
                            thisSimilarityResult.OtherSimilars.FirstOrDefault(s => s.SimilarityRate >= .7);
                        thisSimilarityResult.Similar = mostSimilar?.Similar;
                        thisSimilarityResult.SimilarityRate = mostSimilar?.SimilarityRate;
                        Interlocked.Increment(ref _doneRowsCount);
                    });
                })
                .ContinueWith((t) =>
                {
                    if (!t.IsFaulted)
                        Log("Finding Similars done.");
                    else
                    {
                        Log($"Error in finding similars: {t.Exception}");
                    }
                });


        }

        private Core.Simila GetSimila()
        {
            var simila =  new Core.Simila();

            //var resolver = simila.Resolver;

            //var similaStudioWordMistakeRepository = new SimilaStudioWordMistakeRepository(CurrentProfile);
            //var similaStudioCharacterMistakeRepository = new SimilaStudioCharacterMistakeRepository(CurrentProfile);


            //resolver.RegisterInstance(StringComparisonOptions.None);

            //resolver.RegisterInstance<IMistakeRepository<Word>>(similaStudioWordMistakeRepository);
            //resolver.RegisterInstance<IMistakeRepository<char>>(similaStudioCharacterMistakeRepository);

            //resolver.RegisterType<ISimilarityResolver<string>, PhraseSimilarityResolverLevenstein>();
            //resolver.RegisterInstance<ISimilarityResolver<Word>>(
            //        new WordSimilarityResolverDefault(
            //        new CharacterSimilarityResolverDefault(new SimilaStudioCharacterMistakeRepository(CurrentProfile), StringComparisonOptions.None),
            //        new MistakeBasedSimilarityResolver<Word>(
            //             new SimilaStudioWordMistakeRepository(CurrentProfile)
            //             )
            //        )
            //    );

            //resolver.RegisterType<ISimilarityResolver<char>, CharacterSimilarityResolverDefault>();
            //resolver.RegisterType<IMistakeBasedSimilarityResolver<Word>, MistakeBasedSimilarityResolver<Word>>();
            //resolver.RegisterInstance<IMistakeRepository<char>>(new SimilaStudioCharacterMistakeRepository(CurrentProfile));
            //resolver.RegisterInstance<IMistakeRepository<Word>>(new SimilaStudioWordMistakeRepository(CurrentProfile));

            return simila;
        }

        private void toolStripButtonLoad_Click(object sender, EventArgs e)
        {
            var profile = new SimilaProfile();
            var profileDirectory = Path.Combine(Directory.GetCurrentDirectory(), @"Profiles");
            var initDirectory =
                Directory.Exists(profileDirectory) ? profileDirectory : Directory.GetCurrentDirectory();

            var openFileDialog = new OpenFileDialog
            {
                Filter = @"Simila Profile|*.similaprofile",
                Multiselect = false,
                InitialDirectory = initDirectory
            };

            if (openFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                var filename = openFileDialog.FileName;
                profile.LoadProfile(filename);
            }

            CurrentProfile = profile;
            SyncFormWithProfile();
        }

        private void SyncFormWithProfile()
        {
            textBoxDirtyWords.Text = string.Join(Environment.NewLine, CurrentProfile.DirtyWords);
            dataGridViewCharMistakeInstance.DataSource = CurrentProfile.CharMistakes;
            dataGridViewWordMistakeInstance.DataSource = CurrentProfile.WordMistakes;
        }

        private void SyncProfileWithForm()
        {
            CurrentProfile.DirtyWords = textBoxDirtyWords.Text?.Split('\r', '\n').ToList();
        }

        private void timerProgressUpdater_Tick(object sender, EventArgs e)
        {
            var maximum = Math.Max(_allRowsCount, _doneRowsCount);
            progressBarCalcStatus.Maximum = maximum;
            progressBarCalcStatus.Value = _doneRowsCount;
            labelProgress.Text = $@"{_doneRowsCount}/{_allRowsCount}";
            if (_doneRowsCount == _allRowsCount)
                progressBarCalcStatus.Visible = labelProgress.Visible = false;
            else
                progressBarCalcStatus.Visible = labelProgress.Visible = true;

            Application.DoEvents();
        }
    }
}
