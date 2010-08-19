using System.IO;

namespace XML2List.Interface
{
    public interface IListMaking
    {
        void MakeList(TextWriter streamOut, string[] selectedPaths);
    }
}
