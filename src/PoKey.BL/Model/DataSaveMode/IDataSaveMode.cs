namespace PoKey.BL.Model;

public interface IDataSaveMode
{
    void Save(User item);

     User Load(string name);
}