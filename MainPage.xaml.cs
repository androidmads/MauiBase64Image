namespace MauiBase64Image;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnEncodeClicked(object sender, EventArgs e)
	{
        using var imageEncodeStream = await FileSystem.OpenAppPackageFileAsync("icon.png");
        using var memoryStream = new MemoryStream();

        imageEncodeStream.CopyTo(memoryStream);
        base64Result.Text = Convert.ToBase64String(memoryStream.ToArray());
    }

    private void OnDecodeClicked(object sender, EventArgs e)
    {
        var imageBytes = Convert.FromBase64String(base64Result.Text);
        MemoryStream imageDecodeStream = new(imageBytes);
        imagePreview.Source = ImageSource.FromStream(() => imageDecodeStream);
    }
}

