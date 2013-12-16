﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/26/2012
 * Time: 12:27 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System.Windows.Forms;

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;
    
    // 20120823
    //using System.Windows.Automation;
    
    
    /// <summary>
    /// Description of SetUiaControlKeysCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UiaControlKeys")]
    public class SetUiaControlKeysCommand : HasControlInputCmdletBase
    {
        #region Parameters
        [Parameter(Mandatory = true,
                   Position = 0)]
        [AllowEmptyString]
        public string Text { get; set; }
//        [Parameter(Mandatory = false)]
//        public SwitchParameter RightClick { get; set; }
//        [Parameter(Mandatory = false)]
//        public SwitchParameter MidClick { get; set; }
//        [Parameter(Mandatory = false)]
//        public SwitchParameter Alt { get; set; }
//        [Parameter(Mandatory = false)]
//        public SwitchParameter Shift { get; set; }
//        [Parameter(Mandatory = false)]
//        public SwitchParameter Ctrl { get; set; }
//        [Parameter(Mandatory = false)]
//        public SwitchParameter DoubleClick { get; set; }
//        [Parameter(Mandatory = false)]
//        public int X { get; set; }
//        [Parameter(Mandatory = false)]
//        public int Y { get; set; }
//        [Parameter(Mandatory = false)]
//        public SwitchParameter Wait { get; set; }
        #endregion Parameters
        
        
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            if (!CheckAndPrepareInput(this)) { return; }
            
            foreach (IUiElement inputObject in InputObject) {

            try {
                SendKeys.SendWait(Text);
                WriteObject(this, true);
            }
            catch (Exception eKeys) {
                // 20131216 
//                ErrorRecord err = 
//                    new ErrorRecord(
//                        new Exception("Failed to send keys to a control"),
//                        "SendKeysFailed",
//                        ErrorCategory.InvalidResult,
//                        null);
//                string controlName = string.Empty;
//                try {
//                    controlName = inputObject.Current.Name;
//                }
//                catch {}
//                err.ErrorDetails = 
//                    new ErrorDetails(
//                        "Failed to send keys to " + 
//                        controlName + 
//                        "\r\n" + 
//                        eKeys.Message);
//                WriteError(this, err, true);
                
                this.WriteError(
                    this,
                    "Failed to send keys to a control",
                    "SendKeysFailed",
                    ErrorCategory.InvalidResult,
                    true);
            }

            } // 20120823

        }
    }
}
