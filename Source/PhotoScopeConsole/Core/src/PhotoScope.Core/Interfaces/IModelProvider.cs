using System;
using PhotoScope.Core.DTOModels;

namespace PhotoScope.Core.Interfaces
{
    /// <summary>
    /// Provides the model of type T (To be used by the UI elements to get the initial DTO model)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IModelProvider<out T>:IDisposable where T : ObservableModel
    {
        T GetInitialModel();

    }
}