using System;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace BarberShop
{
	public class MailValidation : Behavior<Entry>
	{
		const string emailRegex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
		@"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";

		public static readonly BindableProperty AttachBehaviorProperty =
		BindableProperty.CreateAttached(
			"AttachBehavior",
			typeof(bool),
				typeof(MailValidation),
			false,
			propertyChanged: OnAttachBehaviorChanged);

		public static bool GetAttachBehavior(BindableObject view)
		{
			return (bool)view.GetValue(AttachBehaviorProperty);
		}

		public static void SetAttachBehavior(BindableObject view, bool value)
		{
			view.SetValue(AttachBehaviorProperty, value);
		}

		static void OnAttachBehaviorChanged(BindableObject view, object oldValue, object newValue)
		{
			var entry = view as Entry;
			if (entry == null)
			{
				return;
			}

			bool attachBehavior = (bool)newValue;
			if (attachBehavior)
			{
				entry.TextChanged += OnEntryTextChanged;
			}
			else {
				entry.TextChanged -= OnEntryTextChanged;
			}
		}

		static void OnEntryTextChanged(object sender, TextChangedEventArgs args)
		{
	
			bool IsValid = (Regex.IsMatch(args.NewTextValue, emailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
			((Entry)sender).TextColor = IsValid ? Color.White : Color.Black;

		
		}


	}
}
