using Facade.OtherSystems;

namespace Facade;

public static class Program
{
    public static void Main(string[] args)
    {
        var homeFacade = new HomeFacade(new Light(), new SmartTV(new List<string> { "1", "2", "3" }));
        homeFacade.TurnOnTheLight();
        homeFacade.OnTV();
        
        homeFacade.SwitchChannelTV(3);
        homeFacade.OffTV();
        
        homeFacade.OnTV();
    }
}