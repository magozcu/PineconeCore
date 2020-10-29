using System;

namespace PineconeGames.Core.Patterns
{
    public class Singleton<T> where T : class
    {
        #region Variables

        public static T Instance
        {
            get
            {
                lock (_padlock)
                {
                    if (_instance == null)
                    {
                        try
                        {
                            _instance = Activator.CreateInstance<T>();
                        }
                        catch(Exception ex)
                        {
                            string err = ex.Message;
                        }
                    }

                    return _instance;
                }
            }
        }

        private static T _instance = null;

        private static object _padlock = new object();

        #endregion
    }
}