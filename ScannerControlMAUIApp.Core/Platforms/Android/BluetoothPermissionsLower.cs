using static Microsoft.Maui.ApplicationModel.Permissions;

namespace ScannerControlMAUIApp.Core.Platforms.Android;

internal class BluetoothPermissionsLower : BasePlatformPermission
{
#if ANDROID
    public override (string androidPermission, bool isRuntime)[] RequiredPermissions =>
        new List<(string permission, bool isRuntime)>
        {
            (global::Android.Manifest.Permission.AccessFineLocation, true),
            (global::Android.Manifest.Permission.AccessCoarseLocation, true)

        }.ToArray();
#endif
}

