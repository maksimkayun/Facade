using Facade.OtherSystems;

namespace Facade;

public class HomeFacade
{
    private Light _light { get; set; }
    private SmartTV _tv { get; set; }
    private int lastChannelNum { get; set; }
    
    public HomeFacade(Light light, SmartTV tv)
    {
        _light = light;
        _tv = tv;
        lastChannelNum = 0;
    }

    /// <summary>
    /// Включение света
    /// </summary>
    /// <remarks>Всё ещё использование старого метода Switch</remarks>
    public void TurnOnTheLight()
    {
        if (!_light.IsEnable)
            _light.Switch();
    }
    
    /// <summary>
    /// Выключение света
    /// </summary>
    /// <remarks>Используем новый метод TurnOffTheLight вместо Switch</remarks>
    public void TurnOffTheLight() => _light.TurnOffTheLight();

    /// <summary>
    /// Включаем ТВ, если "помним" последний канал - сразу переключаем на него
    /// </summary>
    public void OnTV()
    {
        var enabled = _tv.On();
        if (enabled && lastChannelNum > 0)
        {
            _tv.SwitchToChannel(lastChannelNum);
        }
    }

    /// <summary>
    /// Переключение на выбранный канал с сохранением последнего канала
    /// </summary>
    /// <param name="number"></param>
    public void SwitchChannelTV(int number)
    {
        var switchSuccess = _tv.SwitchToChannel(number);
        if (switchSuccess)
        {
            lastChannelNum = number;
        }
    }
    
    /// <summary>
    /// Включаем ТВ, если "помним" последний канал - сразу переключаем на него
    /// </summary>
    public void OffTV() => _tv.Off();
}