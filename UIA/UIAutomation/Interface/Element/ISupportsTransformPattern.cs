﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/8/2013
 * Time: 10:28 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;
    
    public interface ISupportsTransformPattern
    {
        IUiElement Move(double x, double y);
        IUiElement Resize(double width, double height);
        IUiElement Rotate(double degrees);
        bool CanMove { get; }
        bool CanResize { get; }
        bool CanRotate { get; }
    }
}

