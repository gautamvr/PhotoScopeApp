using System;

namespace PhotoScope.Core.DTOModels
{
    /// <summary>
    ///     This is the abstract base class from every model class should extend.
    ///     This class essentially defines the Id that identifies the model instance.
    /// </summary>
    public abstract class BaseModel : ObservableModel
    {
        /// <summary>
        ///     A unique identifier for the Item.
        /// </summary>
        public string Id { get; } = Guid.NewGuid().ToString();

        protected BaseModel()
        {
        }

        /// <summary>
        ///     Check for equality of the models
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return obj is BaseModel comparingModel && comparingModel.Id.Equals(Id);
        }

        /// <summary>
        ///     Overrides the hashcode and provide the default implementation
        /// </summary>
        /// <returns>
        ///     Hashcode value
        /// </returns>
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
