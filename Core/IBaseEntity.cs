namespace MuscleCarRentProject.Core
{
    public interface IBaseEntity
    {
        public string ID { get; }
        public byte[] RowVersion { get; }
    }
}
