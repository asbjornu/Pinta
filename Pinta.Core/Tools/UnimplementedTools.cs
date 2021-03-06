// 
// UnimplementedTools.cs
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
	// This is just to get them to show up in the toolbox
	// until they get implemented
	public class ZoomTool : BaseTool
	{
		public override string Name {
			get { return "Zoom"; }
		}
		public override string Icon {
			get { return "Tools.Zoom.png"; }
		}
	}
		
	public class MagicWandTool : BaseTool
	{
		public override string Name {
			get { return "Magic Wand"; }
		}
		public override string Icon {
			get { return "Tools.MagicWand.png"; }
		}
	}
		
	public class PanTool : BaseTool
	{
		public override string Name {
			get { return "Pan"; }
		}
		public override string Icon {
			get { return "Tools.Pan.png"; }
		}
	}
		
	public class PaintBucketTool : BaseTool
	{
		public override string Name {
			get { return "Paint Bucket"; }
		}
		public override string Icon {
			get { return "Tools.PaintBucket.png"; }
		}
	}
		
	public class GradientTool : BaseTool
	{
		public override string Name {
			get { return "Gradient"; }
		}
		public override string Icon {
			get { return "Tools.Gradient.png"; }
		}
	}
			
	public class CloneStampTool : BaseTool
	{
		public override string Name {
			get { return "Clone Stamp"; }
		}
		public override string Icon {
			get { return "Tools.CloneStamp.png"; }
		}
	}
			
	public class RecolorTool : BaseTool
	{
		public override string Name {
			get { return "Recolor"; }
		}
		public override string Icon {
			get { return "Tools.Recolor.png"; }
		}
	}
			
	public class TextTool : BaseTool
	{
		public override string Name {
			get { return "Text"; }
		}
		public override string Icon {
			get { return "Tools.Text.png"; }
		}
	}
			
	public class LineCurveTool : BaseTool
	{
		public override string Name {
			get { return "Line / Curve"; }
		}
		public override string Icon {
			get { return "Tools.Line.png"; }
		}
	}
}
