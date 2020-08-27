using TFProjectAPI.Client.Models;
using GM = TFProjectAPI.Global.Models;

namespace TFProjectAPI.Client.Mappers
{
    internal static class GeneralTypeServiceMappers
    {
        internal static GM.GeneralType ToGlobal(this GeneralType gt)
        {
            return new GM.GeneralType() { Id = gt.Id, Name = gt.Name};
        }

        internal static GeneralType ToClient(this GM.GeneralType gt)
        {
            if (gt is null) return null;
            else
                return new GeneralType(gt.Id, gt.Name);
        }

    }
}
