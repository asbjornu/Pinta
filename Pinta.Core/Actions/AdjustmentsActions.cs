// 
// AdjustmentsActions.cs
//  
// Author:
//       Jonathan Pobst <monkey@jpobst.com>
// 
// Copyright (c) 2010 Jonathan Pobst
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;

namespace Pinta.Core
{
	public class AdjustmentsActions
	{
		public Gtk.Action AutoLevel { get; private set; }
		public Gtk.Action BlackAndWhite { get; private set; }
		public Gtk.Action BrightnessContrast { get; private set; }
		public Gtk.Action Curves { get; private set; }
		public Gtk.Action HueSaturation { get; private set; }
		public Gtk.Action InvertColors { get; private set; }
		public Gtk.Action Levels { get; private set; }
		public Gtk.Action Posterize { get; private set; }
		public Gtk.Action Sepia { get; private set; }

		public AdjustmentsActions ()
		{
			Gtk.IconFactory fact = new Gtk.IconFactory ();
			fact.Add ("Menu.Adjustments.AutoLevel.png", new Gtk.IconSet (PintaCore.Resources.GetIcon ("Menu.Adjustments.AutoLevel.png")));
			fact.Add ("Menu.Adjustments.BlackAndWhite.png", new Gtk.IconSet (PintaCore.Resources.GetIcon ("Menu.Adjustments.BlackAndWhite.png")));
			fact.Add ("Menu.Adjustments.BrightnessAndContrast.png", new Gtk.IconSet (PintaCore.Resources.GetIcon ("Menu.Adjustments.BrightnessAndContrast.png")));
			fact.Add ("Menu.Adjustments.Curves.png", new Gtk.IconSet (PintaCore.Resources.GetIcon ("Menu.Adjustments.Curves.png")));
			fact.Add ("Menu.Adjustments.HueAndSaturation.png", new Gtk.IconSet (PintaCore.Resources.GetIcon ("Menu.Adjustments.HueAndSaturation.png")));
			fact.Add ("Menu.Adjustments.InvertColors.png", new Gtk.IconSet (PintaCore.Resources.GetIcon ("Menu.Adjustments.InvertColors.png")));
			fact.Add ("Menu.Adjustments.Levels.png", new Gtk.IconSet (PintaCore.Resources.GetIcon ("Menu.Adjustments.Levels.png")));
			fact.Add ("Menu.Adjustments.Sepia.png", new Gtk.IconSet (PintaCore.Resources.GetIcon ("Menu.Adjustments.Sepia.png")));
			fact.AddDefault ();
			
			AutoLevel = new Gtk.Action ("AutoLevel", Mono.Unix.Catalog.GetString ("Auto Level"), null, "Menu.Adjustments.AutoLevel.png");
			BlackAndWhite = new Gtk.Action ("BlackAndWhite", Mono.Unix.Catalog.GetString ("Black and White"), null, "Menu.Adjustments.BlackAndWhite.png");
			BrightnessContrast = new Gtk.Action ("BrightnessContrast", Mono.Unix.Catalog.GetString ("Brightness / Contrast"), null, "Menu.Adjustments.BrightnessAndContrast.png");
			Curves = new Gtk.Action ("Curves", Mono.Unix.Catalog.GetString ("Curves"), null, "Menu.Adjustments.Curves.png");
			HueSaturation = new Gtk.Action ("HueSaturation", Mono.Unix.Catalog.GetString ("Hue / Saturation"), null, "Menu.Adjustments.HueAndSaturation.png");
			InvertColors = new Gtk.Action ("InvertColors", Mono.Unix.Catalog.GetString ("Invert Colors"), null, "Menu.Adjustments.InvertColors.png");
			Levels = new Gtk.Action ("Levels", Mono.Unix.Catalog.GetString ("Levels"), null, "Menu.Adjustments.Levels.png");
			Posterize = new Gtk.Action ("Posterize", Mono.Unix.Catalog.GetString ("Posterize"), null, null);
			Sepia = new Gtk.Action ("Sepia", Mono.Unix.Catalog.GetString ("Sepia"), null, "Menu.Adjustments.Sepia.png");
			
			BrightnessContrast.Sensitive = false;
			Curves.Sensitive = false;
			HueSaturation.Sensitive = false;
			Levels.Sensitive = false;
			Posterize.Sensitive = false;
		}

		#region Initialization
		public void CreateMainMenu (Gtk.Menu menu)
		{
			menu.Remove (menu.Children[1]);
			
			menu.Append (AutoLevel.CreateAcceleratedMenuItem (Gdk.Key.L, Gdk.ModifierType.ControlMask | Gdk.ModifierType.ShiftMask));
			menu.Append (BlackAndWhite.CreateAcceleratedMenuItem (Gdk.Key.G, Gdk.ModifierType.ControlMask | Gdk.ModifierType.ShiftMask));
			//menu.Append (BrightnessContrast.CreateAcceleratedMenuItem (Gdk.Key.C, Gdk.ModifierType.ControlMask | Gdk.ModifierType.ShiftMask));
			//menu.Append (Curves.CreateAcceleratedMenuItem (Gdk.Key.M, Gdk.ModifierType.ControlMask | Gdk.ModifierType.ShiftMask));
			//menu.Append (HueSaturation.CreateAcceleratedMenuItem (Gdk.Key.U, Gdk.ModifierType.ControlMask | Gdk.ModifierType.ShiftMask));
			menu.Append (InvertColors.CreateAcceleratedMenuItem (Gdk.Key.I, Gdk.ModifierType.ControlMask | Gdk.ModifierType.ShiftMask));
			//menu.Append (Levels.CreateAcceleratedMenuItem (Gdk.Key.L, Gdk.ModifierType.ControlMask));
			//menu.Append (Posterize.CreateAcceleratedMenuItem (Gdk.Key.P, Gdk.ModifierType.ControlMask | Gdk.ModifierType.ShiftMask));
			menu.Append (Sepia.CreateAcceleratedMenuItem (Gdk.Key.E, Gdk.ModifierType.ControlMask | Gdk.ModifierType.ShiftMask));
		}

		public void RegisterHandlers ()
		{
			Sepia.Activated += HandleSepiaActivated;
			InvertColors.Activated += HandleInvertColorsActivated;
			BlackAndWhite.Activated += HandleBlackAndWhiteActivated;
			AutoLevel.Activated += HandleAutoLevelActivated;
		}
		#endregion

		#region Action Handlers
		private void HandleBlackAndWhiteActivated (object sender, EventArgs e)
		{
			PintaCore.Layers.FinishSelection ();

			SimpleHistoryItem hist = new SimpleHistoryItem ("Menu.Adjustments.BlackAndWhite.png", Mono.Unix.Catalog.GetString ("Black and White"));
			hist.TakeSnapshotOfLayer (PintaCore.Layers.CurrentLayerIndex);
			
			PintaCore.Layers.Desaturate ();
			PintaCore.History.PushNewItem (hist);
		}

		private void HandleInvertColorsActivated (object sender, EventArgs e)
		{
			PintaCore.Layers.FinishSelection ();

			PintaCore.Layers.Invert ();
			PintaCore.History.PushNewItem (new InvertHistoryItem (InvertType.InvertColors));
		}

		private void HandleSepiaActivated (object sender, EventArgs e)
		{
			PintaCore.Layers.FinishSelection ();

			SimpleHistoryItem hist = new SimpleHistoryItem ("Menu.Adjustments.Sepia.png", Mono.Unix.Catalog.GetString ("Sepia"));
			hist.TakeSnapshotOfLayer (PintaCore.Layers.CurrentLayerIndex);

			PintaCore.Layers.Sepia ();
			PintaCore.History.PushNewItem (hist);
		}
		
		private void HandleAutoLevelActivated (object sender, EventArgs e)
		{
			PintaCore.Layers.FinishSelection ();

			SimpleHistoryItem hist = new SimpleHistoryItem ("Menu.Adjustments.AutoLevel.png", Mono.Unix.Catalog.GetString ("Auto Level"));
			hist.TakeSnapshotOfLayer (PintaCore.Layers.CurrentLayerIndex);

			PintaCore.Layers.CurrentLayer.AutoLevel ();
			PintaCore.Workspace.Invalidate ();

			PintaCore.History.PushNewItem (hist);
		}
		#endregion
	}
}
