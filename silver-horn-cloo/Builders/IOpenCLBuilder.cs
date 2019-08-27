﻿using Cloo;
using SilverHorn.Cloo.Context;
using SilverHorn.Cloo.Device;
using System;
using System.Collections.Generic;
using System.Text;

namespace SilverHorn.Cloo.Builders
{
    public interface IOpenCLBuilder
    {
        #region Compute Program Constructors
        /// <summary>
        /// Creates a new program from a source code string.
        /// </summary>
        /// <param name="context"> A program. </param>
        /// <param name="source"> The source code for the program. </param>
        /// <remarks> The created program is associated with the devices. </remarks>
        ComputeProgram BuildComputeProgram(IComputeContext context, string source);

        /// <summary>
        /// Creates a new program from an array of source code strings.
        /// </summary>
        /// <param name="context"> A context. </param>
        /// <param name="source"> The source code lines for the program. </param>
        /// <remarks> The created program is associated with the devices. </remarks>
        ComputeProgram BuildComputeProgram(IComputeContext context, string[] source);

        /// <summary>
        /// Creates a new program from a specified list of binaries.
        /// </summary>
        /// <param name="context"> A context. </param>
        /// <param name="binaries"> A list of binaries, one for each item in <paramref name="devices"/>. </param>
        /// <param name="devices"> A subset of the context devices. If <paramref name="devices"/> is <c>null</c>, OpenCL will associate every binary from binaries with a corresponding device from devices. </param>
        ComputeProgram BuildComputeProgram(IComputeContext context, IList<byte[]> binaries, IList<IComputeDevice> devices);
        #endregion



    }
}
