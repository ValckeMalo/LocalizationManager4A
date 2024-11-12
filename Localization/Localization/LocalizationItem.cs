using System.ComponentModel;

public class LocalizationItem : INotifyPropertyChanged
{
	private string language = string.Empty;
	private StringValueKey stringsCollections;

    public LocalizationItem(string language, StringValueKey stringsCollections)
	{
		this.language = language;
		this.stringsCollections = stringsCollections;
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

	public StringValueKey StringsCollections
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

	public event PropertyChangedEventHandler? PropertyChanged;
	protected virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public class StringValueKey : INotifyPropertyChanged
{
	private string key;
	private string value;

	public string Key
	{
		get => key;
		set
		{
			key = value;
			OnPropertyChanged(nameof(key));
		}
	}

	public string Value
	{
		get => value;
		set
		{
			value = value;
			OnPropertyChanged(nameof(value));
		}
	}

	public event PropertyChangedEventHandler? PropertyChanged;
	protected virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
