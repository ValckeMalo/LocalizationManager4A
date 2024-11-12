using System.ComponentModel;

public class LocalizationItem : INotifyPropertyChanged
{
	private string _key;
	private List<string> _languages;

	public string Key
	{
		get => _key;
		set
		{
			if (_key != value)
			{
				_key = value;
				OnPropertyChanged(nameof(Key));
			}
		}
	}

	public List<string> Languages
	{
		get => _languages;
		set
		{
			if (_languages != value)
			{
				_languages = value;
				OnPropertyChanged(nameof(Languages));
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected virtual void OnPropertyChanged(string propertyName)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
