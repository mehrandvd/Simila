namespace Simila.Core
{
    class MistakesFactory
    {
        public static IMistakeRepository<T> FromXml<T>(string filename)
        {
            var mistakesRepo = new XmlFileMistakeRepository<T>(filename);

            return mistakesRepo;
        }
    }
}
