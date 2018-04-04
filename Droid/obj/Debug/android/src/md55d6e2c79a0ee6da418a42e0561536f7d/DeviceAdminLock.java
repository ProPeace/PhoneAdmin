package md55d6e2c79a0ee6da418a42e0561536f7d;


public class DeviceAdminLock
	extends android.app.admin.DeviceAdminReceiver
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onEnabled:(Landroid/content/Context;Landroid/content/Intent;)V:GetOnEnabled_Landroid_content_Context_Landroid_content_Intent_Handler\n" +
			"n_onDisableRequested:(Landroid/content/Context;Landroid/content/Intent;)Ljava/lang/CharSequence;:GetOnDisableRequested_Landroid_content_Context_Landroid_content_Intent_Handler\n" +
			"n_onDisabled:(Landroid/content/Context;Landroid/content/Intent;)V:GetOnDisabled_Landroid_content_Context_Landroid_content_Intent_Handler\n" +
			"n_onPasswordChanged:(Landroid/content/Context;Landroid/content/Intent;)V:GetOnPasswordChanged_Landroid_content_Context_Landroid_content_Intent_Handler\n" +
			"n_onPasswordFailed:(Landroid/content/Context;Landroid/content/Intent;)V:GetOnPasswordFailed_Landroid_content_Context_Landroid_content_Intent_Handler\n" +
			"n_onPasswordSucceeded:(Landroid/content/Context;Landroid/content/Intent;)V:GetOnPasswordSucceeded_Landroid_content_Context_Landroid_content_Intent_Handler\n" +
			"";
		mono.android.Runtime.register ("Alarm.Droid.DeviceAdminLock, Alarm.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", DeviceAdminLock.class, __md_methods);
	}


	public DeviceAdminLock ()
	{
		super ();
		if (getClass () == DeviceAdminLock.class)
			mono.android.TypeManager.Activate ("Alarm.Droid.DeviceAdminLock, Alarm.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onEnabled (android.content.Context p0, android.content.Intent p1)
	{
		n_onEnabled (p0, p1);
	}

	private native void n_onEnabled (android.content.Context p0, android.content.Intent p1);


	public java.lang.CharSequence onDisableRequested (android.content.Context p0, android.content.Intent p1)
	{
		return n_onDisableRequested (p0, p1);
	}

	private native java.lang.CharSequence n_onDisableRequested (android.content.Context p0, android.content.Intent p1);


	public void onDisabled (android.content.Context p0, android.content.Intent p1)
	{
		n_onDisabled (p0, p1);
	}

	private native void n_onDisabled (android.content.Context p0, android.content.Intent p1);


	public void onPasswordChanged (android.content.Context p0, android.content.Intent p1)
	{
		n_onPasswordChanged (p0, p1);
	}

	private native void n_onPasswordChanged (android.content.Context p0, android.content.Intent p1);


	public void onPasswordFailed (android.content.Context p0, android.content.Intent p1)
	{
		n_onPasswordFailed (p0, p1);
	}

	private native void n_onPasswordFailed (android.content.Context p0, android.content.Intent p1);


	public void onPasswordSucceeded (android.content.Context p0, android.content.Intent p1)
	{
		n_onPasswordSucceeded (p0, p1);
	}

	private native void n_onPasswordSucceeded (android.content.Context p0, android.content.Intent p1);

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
