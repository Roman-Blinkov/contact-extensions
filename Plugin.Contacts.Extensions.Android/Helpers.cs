
using Android.App;
using Android.Content;
using Android.Widget;

namespace Plugin.Contacts.Extensions.Android
{
    public static class Helpers
    {
        public static void StartActivity(this Intent intent)
        {
            try
            {
                intent.SetFlags(ActivityFlags.ClearTop);
                intent.SetFlags(ActivityFlags.NewTask);

                Application.Context.StartActivity(intent);
            }
            catch (ActivityNotFoundException ex)
            {
                // no app found
            }
        }
    }
}