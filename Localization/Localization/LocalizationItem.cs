using System.ComponentModel;

public class LocalizationItem : INotifyPropertyChanged
{
	private string language = string.Empty;
	private Dictionary<string,string> stringsCollections = new Dictionary<string, string>();

    public LocalizationItem(string language,Dictionary<string,string> stringsCollections)
	{
		this.language = language;
		this.stringsCollections = stringsCollections;
	}

    public Dictionary<string, string> StringsCollections
    {
		get => stringsCollections;
		set
		{
			if (stringsCollections != value)
			{
                stringsCollections = value;
				OnPropertyChanged(nameof(stringsCollections));
			}
		}
	}

	public string Language
	{
		get => language;
		set
		{
			if (language != value)
			{
                language = value;
				OnPropertyChanged(nameof(language));
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected virtual void OnPropertyChanged(string propertyName)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
