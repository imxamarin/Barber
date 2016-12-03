using System;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace BarberShop
{
	public class EmailValidationBehavior : Behavior<Entry>
	{
		const string emailRegex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
		@"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";

	public	static readonly BindablePropertyKey IsValidPropertyKey = BindableProperty.CreateReadOnly("IsValid", typeof(bool), typeof(EmailValidationBehavior), false);

		public static readonly BindableProperty IsValidProperty = IsValidPropertyKey.BindableProperty;

	public	static readonly BindablePropertyKey ErrorMessagePropertyKey = BindableProperty.CreateReadOnly("ErrorMessage", typeof(string), typeof(EmailValidationBehavior), null);

		public static BindableProperty ErrorMessageProperty = ErrorMessagePropertyKey.BindableProperty;


	public	static readonly BindablePropertyKey SmrdayKey = BindableProperty.CreateReadOnly("Smrda", typeof(int), typeof(EmailValidationBehavior), 1);

		public static readonly BindableProperty SmrdaProperty = SmrdayKey.BindableProperty;

		public bool IsValid
		{
			get { return (bool)base.GetValue(IsValidProperty); }
			private set { base.SetValue(IsValidPropertyKey, value); }
		}
		public int Smrda
		{
			get { return (int)base.GetValue(SmrdaProperty); }
			private set { base.SetValue(SmrdayKey, value); }

		}

		public string ErrorMessage
		{
			get { return (string)GetValue(ErrorMessageProperty); }

			set { SetValue(ErrorMessageProperty, value); }
		}


		void HandleTextChanged(object sender, TextChangedEventArgs e)
		{


			IsValid = (Regex.IsMatch(e.NewTextValue, emailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
			((Entry)sender).TextColor = IsValid ? Color.Default : Color.Red;

			if (String.IsNullOrEmpty(e.OldTextValue))
				Smrda = 0;
			else
			{
				Smrda = 1;

				ErrorMessage = "Please enter email address";
				return;
			}
			if (!IsValid)
				ErrorMessage = "Please enter valid email address";
			else
				ErrorMessage = "";

		}


		protected override void OnAttachedTo(Entry bindable)
		{
			bindable.TextChanged += HandleTextChanged;
		}
		protected override void OnDetachingFrom(Entry bindable)
		{
			bindable.TextChanged -= HandleTextChanged;
		}
	}
}