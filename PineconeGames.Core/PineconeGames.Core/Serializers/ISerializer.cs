namespace PineconeGames.Core.Serializers
{
    public interface ISerializer
    {
        string Serialize(object obj);

        T Deserialize<T>(string serializedData) where T : class;
    }
}