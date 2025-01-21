namespace Matching
{
    public partial class MainPage : ContentPage
    {
        Button lastClicked;
        bool findingMatch = false;
        int matchesFound;
        int tenthsOfSecondsElapsed = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void PlayAgainButton_Clicked(object sender, EventArgs e)
        {
            AnimalButtons.IsVisible = true;
            PlayAgainButton.IsVisible = false;
            MatchesFoundLbl.IsVisible = true;


            List<string> animalList = [
                "🦁", "🦁", 
                "🐻","🐻",
                "🐶","🐶",
                "🐱","🐱",
                "🐟","🐟",
                "🐘","🐘",
                "🐫","🐫",
                "🐌","🐌",
                ];

            foreach (var button in AnimalButtons.Children.OfType<Button>())
            {
                int index = Random.Shared.Next(animalList.Count);
                string nextEmoji = animalList[index];
                button.Text = nextEmoji;
                animalList.RemoveAt(index);
            };

            Dispatcher.StartTimer(TimeSpan.FromSeconds(.1), TimerTick);
        }

        private bool TimerTick()
        {
            if (!this.IsLoaded) return false;

            tenthsOfSecondsElapsed++;
            TimeElapsed.Text = "Time elapsed: " + (tenthsOfSecondsElapsed / 10F).ToString("0.0s");

            if (PlayAgainButton.IsVisible) {
                   tenthsOfSecondsElapsed = 0;
                return false;
            }

            return true;
                
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (sender is Button buttonClicked)
            {
                if (!string.IsNullOrWhiteSpace(buttonClicked.Text) && (findingMatch == false))
                    {
                    buttonClicked.BackgroundColor = Colors.Salmon;
                    lastClicked = buttonClicked;
                    findingMatch = true;
                }
                else
                {
                    if ((buttonClicked != lastClicked) && (buttonClicked.Text == lastClicked.Text)) {
                        matchesFound++;
                        MatchesFoundLbl.Text = "Matches Found: " + matchesFound.ToString();
                        lastClicked.Text = " ";
                        buttonClicked.Text = " ";
                    }
                    lastClicked.BackgroundColor = Colors.LightBlue;
                    buttonClicked.BackgroundColor = Colors.LightBlue;
                    findingMatch = false;

                }
            }
            if (matchesFound == 8) {
                matchesFound = 0;
                AnimalButtons.IsVisible = false;
                PlayAgainButton.IsVisible = true;
            }
        }
    }

}
