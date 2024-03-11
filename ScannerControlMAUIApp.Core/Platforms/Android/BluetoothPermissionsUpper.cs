using static Microsoft.Maui.ApplicationModel.Permissions;

namespace ScannerControlMAUIApp.Core.Platforms.Android;

internal class BluetoothPermissionsUpper : BasePlatformPermission
{
#if ANDROID
    public override (string androidPermission, bool isRuntime)[] RequiredPermissions =>
        new List<(string permission, bool isRuntime)>
        {
            (global::Android.Manifest.Permission.BluetoothAdvertise, true),
            (global::Android.Manifest.Permission.BluetoothScan, true),
            (global::Android.Manifest.Permission.BluetoothConnect, true),
            (global::Android.Manifest.Permission.AccessFineLocation, true),
            (global::Android.Manifest.Permission.PostNotifications, true),

        }.ToArray();
#endif
}

