using System.Linq;

namespace PoKey.BL.Model
{
    public class DatabaseSaver : IDataSaveMode
    {
        public User Load(string name)
        {
            using var db = new PoKeyContext();
            var result = db.Set<User>().Where(u => u.Name == name).FirstOrDefault();
            if (result is null)
            {
                result = new User(name);
                Save(result);
            }
            return result;
        }

        public void Save(User item)
        {
            using var db = new PoKeyContext();
            db.Users.Add(item);

            db.SaveChanges();
        }
    }
}