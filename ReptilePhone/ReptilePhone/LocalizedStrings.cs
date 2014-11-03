
using ReptilePhone.Resources;

namespace ReptilePhone
{
     /// <summary>
        /// Provides access to string resources.
        /// </summary>
        public class LocalizedStrings
        {
            private static AppResources _localizedResources = new AppResources();

            public AppResources LocalizedResources1 { get { return _localizedResources; } }
        }
    }

