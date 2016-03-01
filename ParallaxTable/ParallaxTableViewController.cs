using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using System.Collections.Generic;

namespace ParallaxTable
{
	partial class ParallaxTableViewController : UITableViewController
	{
		public ParallaxTableViewController (IntPtr handle) : base (handle)
		{
			
		}
		public override void ViewDidLoad ()
		{
			
			this.TableView.RegisterClassForCellReuse (typeof(CustomTableViewCell), "customCell");
			this.TableView.Source = new DataSource (this.parallaxHeader);

		}
		private class DataSource : UITableViewSource
		{
			private List<string> data;
			private ParallaxHeaderView parallaxHeader;
			public DataSource (ParallaxHeaderView parallaxHeader)
			{
				this.parallaxHeader = parallaxHeader;
				data = new List<string>(){"Brandon", "Winnipeg", "Morden", "Winkler", "Dauphin", "Portage", "Virden", "Souris", "Glenboro", "Minnedosa", "Neepawa", "Shoal Lake", "Reston", "Pipestone", "Melita", "Hartney"};
			}

			public override nint RowsInSection (UITableView tableView, nint section)
			{
				return data.Count;
			}

			public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
			{
				var cell = (CustomTableViewCell) tableView.DequeueReusableCell ("customCell",indexPath);

				cell.TextLabel.Text = data [indexPath.Row];

				return cell;
			}

			public override void Scrolled (UIScrollView scrollView)
			{
				var bottomConstraint = this.parallaxHeader.Constraints[1];
				var topContraint = this.parallaxHeader.Constraints[2];
				if (scrollView.ContentOffset.Y >= 0) { 
					// scrolling down 
					parallaxHeader.ClipsToBounds = true;
					bottomConstraint.Constant = -scrollView.ContentOffset.Y / 2; 
					topContraint.Constant = scrollView.ContentOffset.Y / 2 ; 
				} 
				else { 
					// scrolling up 
					topContraint.Constant = scrollView.ContentOffset.Y; 
					this.parallaxHeader.ClipsToBounds = false;
				} 
			}
		}

			
	}

}
