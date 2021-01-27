using Plugin.Settings;
using Plugin.Settings.Abstractions;


namespace MyFit.helpers
{
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        public static string UserToken
        {
            get
            {
                return AppSettings.GetValueOrDefault<string>("token", "");
            }

            set
            {
                AppSettings.AddOrUpdateValue<string>("token", value);
            }
        }

        public static string UserTotalSteps
        {
            get
            {
                return AppSettings.GetValueOrDefault<string>("totalsteps", "0");
            }

            set
            {
                AppSettings.AddOrUpdateValue<string>("totalsteps", value);
            }
        }

        public static string UserTotalCalories
        {
            get
            {
                return AppSettings.GetValueOrDefault<string>("totalcalories", "0");
            }

            set
            {
                AppSettings.AddOrUpdateValue<string>("totalcalories", value);
            }
        }

        public static string UserFullName
        {
            get
            {
                return AppSettings.GetValueOrDefault<string>("fullname", "");
            }

            set
            {
                AppSettings.AddOrUpdateValue<string>("fullname", value);
            }
        }

        public static string UserWeight
        {
            get
            {
                return AppSettings.GetValueOrDefault<string>("poids", "");
            }

            set
            {
                AppSettings.AddOrUpdateValue<string>("poids", value);
            }
        }

        public static string UserHeight
        {
            get
            {
                return AppSettings.GetValueOrDefault<string>("taille", "");
            }

            set
            {
                AppSettings.AddOrUpdateValue<string>("taille", value);
            }
        }

        public static string UserId
        {
            get
            {
                return AppSettings.GetValueOrDefault<string>("userid", "");
            }

            set
            {
                AppSettings.AddOrUpdateValue<string>("userid", value);
            }
        }

        public static string UserCoursesList
        {
            get
            {
                return AppSettings.GetValueOrDefault<string>("courses", "");
            }

            set
            {
                AppSettings.AddOrUpdateValue<string>("courses", value);
            }
        }
    }
}
