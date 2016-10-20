namespace ActivitiDotNet.Configuration
{
    public class AuthorizationManager
    {
        #region Variables
        private static AuthorizationManager _instantce = null;
        private string _username;
        private string _password;
        #endregion

        #region Properties
        public static AuthorizationManager Instance
        {
            get
            {
                if (_instantce == null)
                {
                    _instantce = new AuthorizationManager();
                }

                return _instantce;
            }
        }

        internal string Username
        {
            get
            {
                return _username;
            }
        }

        internal string Password
        {
            get
            {
                return _password;
            }
        }

        #endregion

        public void Login(string username, string password)
        {
            _username = username;
            _password = password;
        }
    }
}
