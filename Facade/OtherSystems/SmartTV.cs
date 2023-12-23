namespace Facade.OtherSystems;

public class SmartTV
{
    private readonly List<string> _channels;
    private string _currentChannel;

    private static string _lastChannel =  string.Empty;
    private bool isEnabled;

    public SmartTV(List<string> channels)
    {
        _channels = new List<string>(channels);
        _currentChannel = _channels.FirstOrDefault() ?? "none";
        isEnabled = false;
    }

    [Obsolete("Outdated method, use the TurnOnTheTV method")]
    public bool On()
    {
        isEnabled = true;
        return isEnabled;
    }
    
    public bool TurnOnTheTV()
    {
        isEnabled = true;
        if (_lastChannel != string.Empty)
        {
            _currentChannel = _channels.FirstOrDefault(ch=>ch.Equals(_lastChannel)) ?? "1";
        }

        return isEnabled;
    }
    public bool SwitchToChannel(int number)
    {
        if (number <= _channels.Count && number > 0)
        {
            _currentChannel = _channels[number - 1];
            _lastChannel = _currentChannel;
            Console.WriteLine($"Now TV on {_currentChannel}");
        }
        else
        {
            return false;
        }

        return true;
    }

    public int GetCurrentChannel => _channels.IndexOf(_currentChannel) + 1;

    public void Off() => isEnabled = false;
}