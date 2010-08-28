using System.IO;

namespace XML2List
{
    public interface IListMaking
    {
        void MakeList(TextWriter streamOut, string[] selectedPaths);
    }
}
