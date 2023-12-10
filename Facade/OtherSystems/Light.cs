namespace Facade.OtherSystems;

public class Light
{
    private bool isEnable { get; set; }
    public void TurnOnTheLight()
    {
    }

    public void TurnOffTheLight()
    {
    }

    [Obsolete("Use the new method TurnOnTheLight or")]
    public bool Switch() => isEnable = !isEnable;

    public bool IsEnable => isEnable;
}