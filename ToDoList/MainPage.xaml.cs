using System.Diagnostics;
using System.Runtime.ExceptionServices;

namespace ToDoList;

public partial class MainPage : ContentPage
{
    public static IEnumerable<Note> noteList = new List<Note>();
    public static IEnumerable<Note> scrap = new List<Note>();
    List<Note> temp = new List<Note>();
    public MainPage()
	{
		InitializeComponent();
    }
    private void editTitle(object sender, EventArgs e)
    {
        edit.Focus();
        edit.Text = title.Text;
        edit.IsVisible = true;
        title.IsVisible = false;
    }
    void onComplete(object sender, EventArgs e)
    {
        edit.IsVisible = false;
        title.Text = edit.Text;
        title.IsVisible = true;
    }
    async void newNote(object sender, EventArgs e)
    {
        Note newNote = new Note { text = await DisplayPromptAsync("New Note", "Emter text"), isChecked = false };
        temp.Add(newNote);
        noteList = temp;
        noteDisplay.ItemsSource = scrap;
        noteDisplay.ItemsSource = noteList;
    }

    public class Note
    {
        public string text { get; set; }
        public bool isChecked { get; set; }
    }
}

