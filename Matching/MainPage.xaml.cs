namespace Matching
{
    public partial class MainPage : ContentPage
    {
 
        public MainPage()
        {
            InitializeComponent();
        }

        private void PlayAgainButton_Clicked(object sender, EventArgs e)
        {
            AnimalButtons.IsVisible = true;
            PlayAgainButton.IsVisible = false;

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
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }

}
