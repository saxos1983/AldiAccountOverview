using System;
using UIKit;
using System.Drawing;
using CoreGraphics;

namespace AldiAccountOverview.iOS
{
	public class LoadingOverlay : UIView {
		// control declarations
		UIActivityIndicatorView activitySpinner;
		UILabel loadingLabel;
		UIButton actionButton;
		Action actionButtonDelegate;
		string actionButtonText;

		public LoadingOverlay (CGRect frame) : base (frame)
		{
			CreateOverlay ();
		}

		public LoadingOverlay (CGRect frame, Action actionButtonDelegate, string actionButtonText) : base (frame)
		{
			this.actionButtonText = actionButtonText;
			this.actionButtonDelegate = actionButtonDelegate;
			CreateOverlay ();
		}

		public LoadingOverlay(CGRect frame, string overlayTitle) : this(frame)
		{
			loadingLabel.Text = overlayTitle;
		}

		public LoadingOverlay(CGRect frame, string overlayTitle, Action actionButtonDelegate, string actionButtonText) : this(frame, actionButtonDelegate, actionButtonText)
		{
			loadingLabel.Text = overlayTitle;
		}

		private void CreateOverlay ()
		{
			// configurable bits
			BackgroundColor = UIColor.Black;
			Alpha = 0.75f;
			AutoresizingMask = UIViewAutoresizing.FlexibleDimensions;
			nfloat labelHeight = 22;
			nfloat labelWidth = Frame.Width - 20;
			// derive the center x and y
			nfloat centerX = Frame.Width / 2;
			nfloat centerY = Frame.Height / 2;
			// create the activity spinner, center it horizontall and put it 5 points above center x
			activitySpinner = new UIActivityIndicatorView (UIActivityIndicatorViewStyle.WhiteLarge);
			activitySpinner.Frame = new CGRect (centerX - (activitySpinner.Frame.Width / 2), centerY - activitySpinner.Frame.Height - 20, activitySpinner.Frame.Width, activitySpinner.Frame.Height);
			activitySpinner.AutoresizingMask = UIViewAutoresizing.FlexibleMargins;
			AddSubview (activitySpinner);
			activitySpinner.StartAnimating ();
			// create and configure the "Loading Data" label
			loadingLabel = new UILabel (new CGRect (centerX - (labelWidth / 2), centerY + 20, labelWidth, labelHeight));
			loadingLabel.BackgroundColor = UIColor.Clear;
			loadingLabel.TextColor = UIColor.White;
			loadingLabel.Text = "Loading Data...";
			loadingLabel.TextAlignment = UITextAlignment.Center;
			loadingLabel.AutoresizingMask = UIViewAutoresizing.FlexibleMargins;
			AddSubview (loadingLabel);

			// create the action button if an action delegate is defined
			if (actionButtonDelegate != null)
			{
				nfloat buttonWidth = Frame.Width - 60;
				nfloat buttonHeight = 28;
				actionButton = new UIButton (UIButtonType.Custom);
				actionButton.Frame = new CGRect (centerX - (buttonWidth / 2), centerY + 60, buttonWidth, buttonHeight);
				actionButton.TitleLabel.TextColor = UIColor.Black;
				//actionButton.TitleLabel.Frame = actionButton.Frame;
				actionButton.BackgroundColor = UIColor.FromWhiteAlpha(.5f,.5f);
				actionButton.TitleLabel.TextAlignment = UITextAlignment.Center;
				actionButton.AutoresizingMask = UIViewAutoresizing.FlexibleMargins;
				actionButton.Layer.CornerRadius = 10;
				actionButton.ClipsToBounds = true;
				actionButton.TouchUpInside += (sender, e) => {
					this.actionButtonDelegate();
				};
				AddSubview (actionButton);
				actionButton.SetTitle (this.actionButtonText, UIControlState.Normal);
			}
		}

		/// <summary>
		/// Fades out the control and then removes it from the super view
		/// </summary>
		public void Hide ()
		{
			UIView.Animate (
				0.5, // duration
				() => { Alpha = 0; },
				() => { RemoveFromSuperview(); }
			);
		}
	};
}

