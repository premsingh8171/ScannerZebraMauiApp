package mono.com.zebra.barcode.sdk.sms;


public class ConfigurationUpdateEventListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.zebra.barcode.sdk.sms.ConfigurationUpdateEventListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onConfigurationUpdateEventReceived:(Lcom/zebra/barcode/sdk/sms/ConfigurationUpdateEventArgs;)V:GetOnConfigurationUpdateEventReceived_Lcom_zebra_barcode_sdk_sms_ConfigurationUpdateEventArgs_Handler:Com.Zebra.Barcode.Sdk.Sms.IConfigurationUpdateEventListenerInvoker, ZebraAndroidScannerLibrary\n" +
			"";
		mono.android.Runtime.register ("Com.Zebra.Barcode.Sdk.Sms.IConfigurationUpdateEventListenerImplementor, ZebraAndroidScannerLibrary", ConfigurationUpdateEventListenerImplementor.class, __md_methods);
	}


	public ConfigurationUpdateEventListenerImplementor ()
	{
		super ();
		if (getClass () == ConfigurationUpdateEventListenerImplementor.class) {
			mono.android.TypeManager.Activate ("Com.Zebra.Barcode.Sdk.Sms.IConfigurationUpdateEventListenerImplementor, ZebraAndroidScannerLibrary", "", this, new java.lang.Object[] {  });
		}
	}


	public void onConfigurationUpdateEventReceived (com.zebra.barcode.sdk.sms.ConfigurationUpdateEventArgs p0)
	{
		n_onConfigurationUpdateEventReceived (p0);
	}

	private native void n_onConfigurationUpdateEventReceived (com.zebra.barcode.sdk.sms.ConfigurationUpdateEventArgs p0);

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
