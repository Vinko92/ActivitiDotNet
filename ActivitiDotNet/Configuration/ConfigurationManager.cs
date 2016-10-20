namespace ActivitiDotNet.Configuration
{
    public class ConfigurationManager
    {
        #region Variables
        private static ConfigurationManager _instance = null;
        private string _baseUrl;
        #endregion

        #region Properties
        public string BaseUrl
        {
            get
            {
                return _baseUrl;
            }
            set
            {
                _baseUrl = value;
            }
        }
        public static ConfigurationManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ConfigurationManager();
                }

                return _instance;
            }
        }

        #endregion

        public ConfigurationManager AddBaseUrl(string baseUrl)
        {
            _baseUrl = baseUrl;

            return Instance;
        }

        public ConfigurationManager AddProtocol(string baseUrl)
        {
            _baseUrl = baseUrl;

            return Instance;
        }
    }
}
