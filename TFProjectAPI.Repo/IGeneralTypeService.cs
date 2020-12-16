using System.Collections.Generic;

namespace TFProjectAPI.Repo
{
    public interface IGeneralTypeService<TGeneralType, TGenYearPurch, GenObjectSearch>
    {
        IEnumerable<TGeneralType> Get();

        TGeneralType Get(int id);

        int IsUsed(int id);

        IEnumerable<TGenYearPurch> GetYP();

        IEnumerable<GenObjectSearch> SearchText(int page, int jump, string search);

        int SearchTextCnt(string search);

        IEnumerable<GenObjectSearch> SearchEAN(int page, int jump, string search);

        int SearchEANcnt(string search);
    }
}
