using PhotoScope.Core.DTOModels;

namespace PhotoScope.Core.Interfaces
{
    public interface IModelProvider<out T> where T : ObservableModel
    {
        T GetInitialModel();

    }
}