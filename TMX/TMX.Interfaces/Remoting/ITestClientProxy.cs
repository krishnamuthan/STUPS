﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/20/2014
 * Time: 1:05 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces.Remoting
{
    using System;
    using Tmx.Interfaces.Internal;
    
    /// <summary>
    /// Description of ITestClientProxy.
    /// </summary>
    public interface ITestClientProxy
    {
        Guid Id { get; set; }
        int TaskId { get; set; }
        string TaskName { get; set; }
        Guid TestRunId { get; set; }
        Guid TestHostId { get; set; }
    }
}
