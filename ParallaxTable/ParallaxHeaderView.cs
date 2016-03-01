using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace ParallaxTable
{
	partial class ParallaxHeaderView : UIView
	{
		public ParallaxHeaderView (IntPtr handle) : base (handle)
		{
		}

		public void Scrolled(UIScrollView scrollView)
		{
			Console.WriteLine (string.Format("{0} {1}",scrollView.ContentInset.Top, scrollView.ContentInset.Bottom));
		}
	}
}
