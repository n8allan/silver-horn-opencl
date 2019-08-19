﻿using System;

namespace Cloo
{
    /// <summary>
    /// 
    /// </summary>
    [Flags]
    public enum ComputeCommandQueueFlags : long
    {
        /// <summary> </summary>
        None = 0,
        /// <summary> </summary>
        OutOfOrderExecution = 1 << 0,
        /// <summary> </summary>
        Profiling = 1 << 1
    }
}
