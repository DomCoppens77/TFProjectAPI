using System.Collections.Generic;

namespace TFProjectAPI.Repo
{
    public interface IGeneralTypeService<TGeneralType>
    {
        IEnumerable<TGeneralType> Get();

        TGeneralType Get(int id);

        int IsUsed(int id);
    }
}
