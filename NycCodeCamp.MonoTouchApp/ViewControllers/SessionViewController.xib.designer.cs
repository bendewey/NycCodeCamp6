// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace NycCodeCamp.MonoTouchApp {
	
	
	// Base type probably should be MonoTouch.UIKit.UIViewController or subclass
	[MonoTouch.Foundation.Register("SessionViewController")]
	public partial class SessionViewController {
		
		private MonoTouch.UIKit.UIView __mt_view;
		
		private MonoTouch.UIKit.UILabel __mt_SessionTitle;
		
		private MonoTouch.UIKit.UILabel __mt_SessionTime;
		
		private MonoTouch.UIKit.UILabel __mt_SessionAbstract;
		
		private MonoTouch.UIKit.UIButton __mt_SpeakerName;
		
		private MonoTouch.UIKit.UIScrollView __mt_Scroller;
		
		private MonoTouch.UIKit.UILabel __mt_SessionRoom;
		
		#pragma warning disable 0169
		[MonoTouch.Foundation.Connect("view")]
		private MonoTouch.UIKit.UIView view {
			get {
				this.__mt_view = ((MonoTouch.UIKit.UIView)(this.GetNativeField("view")));
				return this.__mt_view;
			}
			set {
				this.__mt_view = value;
				this.SetNativeField("view", value);
			}
		}
		
		[MonoTouch.Foundation.Connect("SessionTitle")]
		private MonoTouch.UIKit.UILabel SessionTitle {
			get {
				this.__mt_SessionTitle = ((MonoTouch.UIKit.UILabel)(this.GetNativeField("SessionTitle")));
				return this.__mt_SessionTitle;
			}
			set {
				this.__mt_SessionTitle = value;
				this.SetNativeField("SessionTitle", value);
			}
		}
		
		[MonoTouch.Foundation.Connect("SessionTime")]
		private MonoTouch.UIKit.UILabel SessionTime {
			get {
				this.__mt_SessionTime = ((MonoTouch.UIKit.UILabel)(this.GetNativeField("SessionTime")));
				return this.__mt_SessionTime;
			}
			set {
				this.__mt_SessionTime = value;
				this.SetNativeField("SessionTime", value);
			}
		}
		
		[MonoTouch.Foundation.Connect("SessionAbstract")]
		private MonoTouch.UIKit.UILabel SessionAbstract {
			get {
				this.__mt_SessionAbstract = ((MonoTouch.UIKit.UILabel)(this.GetNativeField("SessionAbstract")));
				return this.__mt_SessionAbstract;
			}
			set {
				this.__mt_SessionAbstract = value;
				this.SetNativeField("SessionAbstract", value);
			}
		}
		
		[MonoTouch.Foundation.Connect("SpeakerName")]
		private MonoTouch.UIKit.UIButton SpeakerName {
			get {
				this.__mt_SpeakerName = ((MonoTouch.UIKit.UIButton)(this.GetNativeField("SpeakerName")));
				return this.__mt_SpeakerName;
			}
			set {
				this.__mt_SpeakerName = value;
				this.SetNativeField("SpeakerName", value);
			}
		}
		
		[MonoTouch.Foundation.Connect("Scroller")]
		private MonoTouch.UIKit.UIScrollView Scroller {
			get {
				this.__mt_Scroller = ((MonoTouch.UIKit.UIScrollView)(this.GetNativeField("Scroller")));
				return this.__mt_Scroller;
			}
			set {
				this.__mt_Scroller = value;
				this.SetNativeField("Scroller", value);
			}
		}
		
		[MonoTouch.Foundation.Connect("SessionRoom")]
		private MonoTouch.UIKit.UILabel SessionRoom {
			get {
				this.__mt_SessionRoom = ((MonoTouch.UIKit.UILabel)(this.GetNativeField("SessionRoom")));
				return this.__mt_SessionRoom;
			}
			set {
				this.__mt_SessionRoom = value;
				this.SetNativeField("SessionRoom", value);
			}
		}
	}
}
