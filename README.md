PhoneCommonStrings intends to jumpstart localized Windows Phone projects by providing common strings, used by many Windows Phone applications, pre-localized into all languages supported by the platform.# UsageFirst, add via NuGet ([PhoneCommonStrings](http://nuget.org/packages/PhoneCommonStrings)) or clone/build and add a reference to PhoneCommonStrings.dllThen configure your project with the locales of the languages you want to use as described in [How to: Build a Localized Application for Windows Phone](http://msdn.microsoft.com/en-us/library/ff637520%28v=VS.92%29.aspx) on MSDN.Then add the supplied accessor to `Application.Resources` in App.xaml:    <Application    	...    	xmlns:pcs="clr-namespace:PhoneCommonStrings;assembly=PhoneCommonStrings"    	>    	    <Application.Resources>    		<pcs:CommonStringsAccessor x:Key="PhoneCommonStrings" />    	</Application.Resources>And bind to strings as needed:    <Button Content="{Binding AboutPage.SendFeedbackAction, {StaticResource PhoneCommonStrings}}" />*NOTE: [BindableApplicationBar](http://nuget.org/packages/BindableApplicationBar) is recommended for localized application bar content*Alternatively, you can reference strings directly:    SomeButton.Text = PhoneCommonStrings.Actions.AddAction;# StringsStrings are available in several categories, including: actions, statuses, theme colors, settings page and about page.For more information, see [Strings](http://github.com/richardszalay/phone-common-strings/wiki/Strings) or clone the repo and run the sample application.Translations are obtained from credible sources used elsewhere on the phone (not machine translations). For individual string source details, see [Sources](http://github.com/richardszalay/phone-common-strings/wiki/Sources)# LicensePhoneCommonStrings is provided under the [MIT license](https://github.com/richardszalay/phone-common-strings/blob/master/LICENSE), which allows use for any purpose (including commercial projects).# ContributeContributions are happily accepted. Please refer to the [wiki](http://github.com/richardszalay/phone-common-strings/wiki/Contribute) for more information.