package crc6467a0c8788a843d1e;


public class AppEngineAndroid
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.zebra.scannercontrol.IDcsSdkApiDelegate,
		com.zebra.scannercontrol.IDcsScannerEventsOnReLaunch
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_dcssdkEventAuxScannerAppeared:(Lcom/zebra/scannercontrol/DCSScannerInfo;Lcom/zebra/scannercontrol/DCSScannerInfo;)V:GetDcssdkEventAuxScannerAppeared_Lcom_zebra_scannercontrol_DCSScannerInfo_Lcom_zebra_scannercontrol_DCSScannerInfo_Handler:Com.Zebra.Scannercontrol.IDcsSdkApiDelegateInvoker, ZebraAndroidScannerLibrary\n" +
			"n_dcssdkEventBarcode:([BII)V:GetDcssdkEventBarcode_arrayBIIHandler:Com.Zebra.Scannercontrol.IDcsSdkApiDelegateInvoker, ZebraAndroidScannerLibrary\n" +
			"n_dcssdkEventBinaryData:([BI)V:GetDcssdkEventBinaryData_arrayBIHandler:Com.Zebra.Scannercontrol.IDcsSdkApiDelegateInvoker, ZebraAndroidScannerLibrary\n" +
			"n_dcssdkEventCommunicationSessionEstablished:(Lcom/zebra/scannercontrol/DCSScannerInfo;)V:GetDcssdkEventCommunicationSessionEstablished_Lcom_zebra_scannercontrol_DCSScannerInfo_Handler:Com.Zebra.Scannercontrol.IDcsSdkApiDelegateInvoker, ZebraAndroidScannerLibrary\n" +
			"n_dcssdkEventCommunicationSessionTerminated:(I)V:GetDcssdkEventCommunicationSessionTerminated_IHandler:Com.Zebra.Scannercontrol.IDcsSdkApiDelegateInvoker, ZebraAndroidScannerLibrary\n" +
			"n_dcssdkEventConfigurationUpdate:(Lcom/zebra/barcode/sdk/sms/ConfigurationUpdateEvent;)V:GetDcssdkEventConfigurationUpdate_Lcom_zebra_barcode_sdk_sms_ConfigurationUpdateEvent_Handler:Com.Zebra.Scannercontrol.IDcsSdkApiDelegateInvoker, ZebraAndroidScannerLibrary\n" +
			"n_dcssdkEventFirmwareUpdate:(Lcom/zebra/scannercontrol/FirmwareUpdateEvent;)V:GetDcssdkEventFirmwareUpdate_Lcom_zebra_scannercontrol_FirmwareUpdateEvent_Handler:Com.Zebra.Scannercontrol.IDcsSdkApiDelegateInvoker, ZebraAndroidScannerLibrary\n" +
			"n_dcssdkEventImage:([BI)V:GetDcssdkEventImage_arrayBIHandler:Com.Zebra.Scannercontrol.IDcsSdkApiDelegateInvoker, ZebraAndroidScannerLibrary\n" +
			"n_dcssdkEventScannerAppeared:(Lcom/zebra/scannercontrol/DCSScannerInfo;)V:GetDcssdkEventScannerAppeared_Lcom_zebra_scannercontrol_DCSScannerInfo_Handler:Com.Zebra.Scannercontrol.IDcsSdkApiDelegateInvoker, ZebraAndroidScannerLibrary\n" +
			"n_dcssdkEventScannerDisappeared:(I)V:GetDcssdkEventScannerDisappeared_IHandler:Com.Zebra.Scannercontrol.IDcsSdkApiDelegateInvoker, ZebraAndroidScannerLibrary\n" +
			"n_dcssdkEventVideo:([BI)V:GetDcssdkEventVideo_arrayBIHandler:Com.Zebra.Scannercontrol.IDcsSdkApiDelegateInvoker, ZebraAndroidScannerLibrary\n" +
			"n_onConnectingToLastConnectedScanner:(Landroid/bluetooth/BluetoothDevice;)V:GetOnConnectingToLastConnectedScanner_Landroid_bluetooth_BluetoothDevice_Handler:Com.Zebra.Scannercontrol.IDcsScannerEventsOnReLaunchInvoker, ZebraAndroidScannerLibrary\n" +
			"n_onLastConnectedScannerDetect:(Landroid/bluetooth/BluetoothDevice;)Z:GetOnLastConnectedScannerDetect_Landroid_bluetooth_BluetoothDevice_Handler:Com.Zebra.Scannercontrol.IDcsScannerEventsOnReLaunchInvoker, ZebraAndroidScannerLibrary\n" +
			"n_onScannerDisconnect:()V:GetOnScannerDisconnectHandler:Com.Zebra.Scannercontrol.IDcsScannerEventsOnReLaunchInvoker, ZebraAndroidScannerLibrary\n" +
			"";
		mono.android.Runtime.register ("ZebraBarcodeScannerSDK.AppEngineAndroid, ZebraBarcodeScannerSDK", AppEngineAndroid.class, __md_methods);
	}


	public AppEngineAndroid ()
	{
		super ();
		if (getClass () == AppEngineAndroid.class) {
			mono.android.TypeManager.Activate ("ZebraBarcodeScannerSDK.AppEngineAndroid, ZebraBarcodeScannerSDK", "", this, new java.lang.Object[] {  });
		}
	}


	public void dcssdkEventAuxScannerAppeared (com.zebra.scannercontrol.DCSScannerInfo p0, com.zebra.scannercontrol.DCSScannerInfo p1)
	{
		n_dcssdkEventAuxScannerAppeared (p0, p1);
	}

	private native void n_dcssdkEventAuxScannerAppeared (com.zebra.scannercontrol.DCSScannerInfo p0, com.zebra.scannercontrol.DCSScannerInfo p1);


	public void dcssdkEventBarcode (byte[] p0, int p1, int p2)
	{
		n_dcssdkEventBarcode (p0, p1, p2);
	}

	private native void n_dcssdkEventBarcode (byte[] p0, int p1, int p2);


	public void dcssdkEventBinaryData (byte[] p0, int p1)
	{
		n_dcssdkEventBinaryData (p0, p1);
	}

	private native void n_dcssdkEventBinaryData (byte[] p0, int p1);


	public void dcssdkEventCommunicationSessionEstablished (com.zebra.scannercontrol.DCSScannerInfo p0)
	{
		n_dcssdkEventCommunicationSessionEstablished (p0);
	}

	private native void n_dcssdkEventCommunicationSessionEstablished (com.zebra.scannercontrol.DCSScannerInfo p0);


	public void dcssdkEventCommunicationSessionTerminated (int p0)
	{
		n_dcssdkEventCommunicationSessionTerminated (p0);
	}

	private native void n_dcssdkEventCommunicationSessionTerminated (int p0);


	public void dcssdkEventConfigurationUpdate (com.zebra.barcode.sdk.sms.ConfigurationUpdateEvent p0)
	{
		n_dcssdkEventConfigurationUpdate (p0);
	}

	private native void n_dcssdkEventConfigurationUpdate (com.zebra.barcode.sdk.sms.ConfigurationUpdateEvent p0);


	public void dcssdkEventFirmwareUpdate (com.zebra.scannercontrol.FirmwareUpdateEvent p0)
	{
		n_dcssdkEventFirmwareUpdate (p0);
	}

	private native void n_dcssdkEventFirmwareUpdate (com.zebra.scannercontrol.FirmwareUpdateEvent p0);


	public void dcssdkEventImage (byte[] p0, int p1)
	{
		n_dcssdkEventImage (p0, p1);
	}

	private native void n_dcssdkEventImage (byte[] p0, int p1);


	public void dcssdkEventScannerAppeared (com.zebra.scannercontrol.DCSScannerInfo p0)
	{
		n_dcssdkEventScannerAppeared (p0);
	}

	private native void n_dcssdkEventScannerAppeared (com.zebra.scannercontrol.DCSScannerInfo p0);


	public void dcssdkEventScannerDisappeared (int p0)
	{
		n_dcssdkEventScannerDisappeared (p0);
	}

	private native void n_dcssdkEventScannerDisappeared (int p0);


	public void dcssdkEventVideo (byte[] p0, int p1)
	{
		n_dcssdkEventVideo (p0, p1);
	}

	private native void n_dcssdkEventVideo (byte[] p0, int p1);


	public void onConnectingToLastConnectedScanner (android.bluetooth.BluetoothDevice p0)
	{
		n_onConnectingToLastConnectedScanner (p0);
	}

	private native void n_onConnectingToLastConnectedScanner (android.bluetooth.BluetoothDevice p0);


	public boolean onLastConnectedScannerDetect (android.bluetooth.BluetoothDevice p0)
	{
		return n_onLastConnectedScannerDetect (p0);
	}

	private native boolean n_onLastConnectedScannerDetect (android.bluetooth.BluetoothDevice p0);


	public void onScannerDisconnect ()
	{
		n_onScannerDisconnect ();
	}

	private native void n_onScannerDisconnect ();

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
