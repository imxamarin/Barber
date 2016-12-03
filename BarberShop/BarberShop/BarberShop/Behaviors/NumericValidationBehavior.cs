using System;
using Xamarin.Forms;

namespace BarberShop
{
	public class NumericValidationBehavior
	{

	public static readonly BindableProperty AttachBehaviorProperty =
		BindableProperty.CreateAttached(
			"AttachBehavior",
			typeof(bool),
			typeof(NumericValidationBehavior),
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
			int result;
			bool isValid = int.TryParse(args.NewTextValue, out result);
			((Entry)sender).TextColor = isValid ? Color.Default : Color.Red;
		}
	}
}
