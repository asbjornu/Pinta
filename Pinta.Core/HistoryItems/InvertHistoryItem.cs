﻿// 
// InvertHistoryItem.cs
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
	// These are actions that can be undone by simply repeating
	// the action: invert colors, rotate 180 degrees, etc
	public class InvertHistoryItem : BaseHistoryItem
	{
		private InvertType type;
		private int layer_index;
		
		public InvertHistoryItem (InvertType type)
		{
			this.type = type;

			switch (type) {
				case InvertType.InvertColors:
					Text = Mono.Unix.Catalog.GetString ("Invert Colors");
					Icon = "Menu.Adjustments.InvertColors.png";
					break;
				case InvertType.Rotate180:
					Text = Mono.Unix.Catalog.GetString ("Rotate 180°");
					Icon = "Menu.Image.Rotate180CW.png";
					break;
				case InvertType.FlipHorizontal:
					Text = Mono.Unix.Catalog.GetString ("Flip Image Horizontal");
					Icon = "Menu.Image.FlipHorizontal.png";
					break;
				case InvertType.FlipVertical:
					Text = Mono.Unix.Catalog.GetString ("Flip Image Vertical");
					Icon = "Menu.Image.FlipVertical.png";
					break;
				case InvertType.Rotate90CW:
					Text = Mono.Unix.Catalog.GetString ("Rotate 90° Clockwise");
					Icon = "Menu.Image.Rotate90CW.png";
					break;
				case InvertType.Rotate90CCW:
					Text = Mono.Unix.Catalog.GetString ("Rotate 90° Counter-Clockwise");
					Icon = "Menu.Image.Rotate90CCW.png";
					break;
			}
		}

		public InvertHistoryItem (InvertType type, int layerIndex)
		{
			this.type = type;
			this.layer_index = layerIndex;

			switch (type) {
				case InvertType.FlipLayerHorizontal:
					Text = Mono.Unix.Catalog.GetString ("Flip Layer Horizontal");
					Icon = "Menu.Image.FlipHorizontal.png";
					break;
				case InvertType.FlipLayerVertical:
					Text = Mono.Unix.Catalog.GetString ("Flip Layer Vertical");
					Icon = "Menu.Image.FlipVertical.png";
					break;
			}
		}
		
		public override void Undo ()
		{
			switch (type) {
				case InvertType.InvertColors:
					PintaCore.Layers.Invert ();
					break;
				case InvertType.Rotate180:
					PintaCore.Layers.RotateImage180 ();
					break;
				case InvertType.FlipHorizontal:
					PintaCore.Layers.FlipImageHorizontal ();
					break;
				case InvertType.FlipVertical:
					PintaCore.Layers.FlipImageVertical ();
					break;
				case InvertType.Rotate90CW:
					PintaCore.Layers.RotateImageCCW ();
					break;
				case InvertType.Rotate90CCW:
					PintaCore.Layers.RotateImageCW ();
					break;
				case InvertType.FlipLayerHorizontal:
					PintaCore.Layers.FlipLayerHorizontal (layer_index);
					break;
				case InvertType.FlipLayerVertical:
					PintaCore.Layers.FlipLayerVertical (layer_index);
					break;
			}
		}

		public override void Redo ()
		{
			switch (type) {
				case InvertType.InvertColors:
					PintaCore.Layers.Invert ();
					break;
				case InvertType.Rotate180:
					PintaCore.Layers.RotateImage180 ();
					break;
				case InvertType.FlipHorizontal:
					PintaCore.Layers.FlipImageHorizontal ();
					break;
				case InvertType.FlipVertical:
					PintaCore.Layers.FlipImageVertical ();
					break;
				case InvertType.Rotate90CW:
					PintaCore.Layers.RotateImageCW ();
					break;
				case InvertType.Rotate90CCW:
					PintaCore.Layers.RotateImageCCW ();
					break;
				case InvertType.FlipLayerHorizontal:
					PintaCore.Layers.FlipLayerHorizontal (layer_index);
					break;
				case InvertType.FlipLayerVertical:
					PintaCore.Layers.FlipLayerVertical (layer_index);
					break;
			}
		}
	}
	
	public enum InvertType
	{
		InvertColors,
		Rotate180,
		FlipHorizontal,
		FlipVertical,
		Rotate90CW,
		Rotate90CCW,
		FlipLayerHorizontal,
		FlipLayerVertical
	}
}
