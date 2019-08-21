﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Cloo.Bindings;

namespace Cloo
{
    /// <summary>
    /// Represents an OpenCL platform.
    /// </summary>
    /// <remarks> The host plus a collection of devices managed by the OpenCL framework that allow an application to share resources and execute kernels on devices in the platform. </remarks>
    /// <seealso cref="ComputeDevice"/>
    /// <seealso cref="ComputeKernel"/>
    /// <seealso cref="ComputeResource"/>
    public class ComputePlatform : ComputeObject
    {
        #region Fields

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ReadOnlyCollection<ComputeDevice> devices;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly ReadOnlyCollection<string> extensions;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly string name;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static ReadOnlyCollection<ComputePlatform> platforms;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly string profile;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly string vendor;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly string version;

        #endregion

        #region Properties

        /// <summary>
        /// The handle of the <see cref="ComputePlatform"/>.
        /// </summary>
        public CLPlatformHandle Handle { get; protected set; }

        /// <summary>
        /// Gets a read-only collection of <see cref="ComputeDevice"/>s available on the <see cref="ComputePlatform"/>.
        /// </summary>
        /// <value> A read-only collection of <see cref="ComputeDevice"/>s available on the <see cref="ComputePlatform"/>. </value>
        public ReadOnlyCollection<ComputeDevice> Devices => devices;

        /// <summary>
        /// Gets a read-only collection of extension names supported by the <see cref="ComputePlatform"/>.
        /// </summary>
        /// <value> A read-only collection of extension names supported by the <see cref="ComputePlatform"/>. </value>
        public ReadOnlyCollection<string> Extensions => extensions;

        /// <summary>
        /// Gets the <see cref="ComputePlatform"/> name.
        /// </summary>
        /// <value> The <see cref="ComputePlatform"/> name. </value>
        public string Name => name;

        /// <summary>
        /// Gets a read-only collection of available <see cref="ComputePlatform"/>s.
        /// </summary>
        /// <value> A read-only collection of available <see cref="ComputePlatform"/>s. </value>
        /// <remarks> The collection will contain no items, if no OpenCL platforms are found on the system. </remarks>
        public static ReadOnlyCollection<ComputePlatform> Platforms => platforms;

        /// <summary>
        /// Gets the name of the profile supported by the <see cref="ComputePlatform"/>.
        /// </summary>
        /// <value> The name of the profile supported by the <see cref="ComputePlatform"/>. </value>
        public string Profile => profile;

        /// <summary>
        /// Gets the <see cref="ComputePlatform"/> vendor.
        /// </summary>
        /// <value> The <see cref="ComputePlatform"/> vendor. </value>
        public string Vendor => vendor;

        /// <summary>
        /// Gets the OpenCL version string supported by the <see cref="ComputePlatform"/>.
        /// </summary>
        /// <value> The OpenCL version string supported by the <see cref="ComputePlatform"/>. It has the following format: <c>OpenCL[space][major_version].[minor_version][space][vendor-specific information]</c>. </value>
        public string Version => version;

        #endregion

        #region Constructors

        static ComputePlatform()
        {
            lock (typeof(ComputePlatform))
            {
                try
                {
                    if (platforms != null)
                    {
                        return;
                    }

                    CLPlatformHandle[] handles;
                    var error = CL10.GetPlatformIDs(0, null, out int handlesLength);
                    ComputeException.ThrowOnError(error);
                    handles = new CLPlatformHandle[handlesLength];

                    error = CL10.GetPlatformIDs(handlesLength, handles, out handlesLength);
                    ComputeException.ThrowOnError(error);

                    var platformList = new List<ComputePlatform>(handlesLength);
                    foreach (CLPlatformHandle handle in handles)
                    {
                        platformList.Add(new ComputePlatform(handle));
                    }
                    platforms = platformList.AsReadOnly();
                }
                catch (DllNotFoundException)
                {
                    platforms = new List<ComputePlatform>().AsReadOnly();
                }
            }
        }

        private ComputePlatform(CLPlatformHandle handle)
        {
            Handle = handle;
            SetID(Handle.Value);

            string extensionString = GetStringInfo<CLPlatformHandle, ComputePlatformInfo>(Handle, ComputePlatformInfo.Extensions,
                CL10.GetPlatformInfo);
            extensions = new ReadOnlyCollection<string>(extensionString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));

            name = GetStringInfo<CLPlatformHandle, ComputePlatformInfo>(Handle, ComputePlatformInfo.Name, CL10.GetPlatformInfo);
            profile = GetStringInfo<CLPlatformHandle, ComputePlatformInfo>(Handle, ComputePlatformInfo.Profile, CL10.GetPlatformInfo);
            vendor = GetStringInfo<CLPlatformHandle, ComputePlatformInfo>(Handle, ComputePlatformInfo.Vendor, CL10.GetPlatformInfo);
            version = GetStringInfo<CLPlatformHandle, ComputePlatformInfo>(Handle, ComputePlatformInfo.Version, CL10.GetPlatformInfo);
            QueryDevices();
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Gets a <see cref="ComputePlatform"/> of a specified handle.
        /// </summary>
        /// <param name="handle"> The handle of the queried <see cref="ComputePlatform"/>. </param>
        /// <returns> The <see cref="ComputePlatform"/> of the matching handle or <c>null</c> if none matches. </returns>
        public static ComputePlatform GetByHandle(IntPtr handle)
        {
            foreach (ComputePlatform platform in Platforms)
            {
                if (platform.Handle.Value == handle)
                {
                    return platform;
                }
            }
            return null;
        }

        /// <summary>
        /// Gets the first matching <see cref="ComputePlatform"/> of a specified name.
        /// </summary>
        /// <param name="platformName"> The name of the queried <see cref="ComputePlatform"/>. </param>
        /// <returns> The first <see cref="ComputePlatform"/> of the specified name or <c>null</c> if none matches. </returns>
        public static ComputePlatform GetByName(string platformName)
        {
            foreach (ComputePlatform platform in Platforms)
            {
                if (platform.Name.Equals(platformName))
                {
                    return platform;
                }
            }
            return null;
        }

        /// <summary>
        /// Gets the first matching <see cref="ComputePlatform"/> of a specified vendor.
        /// </summary>
        /// <param name="platformVendor"> The vendor of the queried <see cref="ComputePlatform"/>. </param>
        /// <returns> The first <see cref="ComputePlatform"/> of the specified vendor or <c>null</c> if none matches. </returns>
        public static ComputePlatform GetByVendor(string platformVendor)
        {
            foreach (ComputePlatform platform in Platforms)
            {
                if (platform.Vendor.Equals(platformVendor))
                {
                    return platform;
                }
            }
            return null;
        }

        /// <summary>
        /// Gets a read-only collection of available <see cref="ComputeDevice"/>s on the <see cref="ComputePlatform"/>.
        /// </summary>
        /// <returns> A read-only collection of the available <see cref="ComputeDevice"/>s on the <see cref="ComputePlatform"/>. </returns>
        /// <remarks> This method resets the <c>ComputePlatform.Devices</c>. This is useful if one or more of them become unavailable (<c>ComputeDevice.Available</c> is <c>false</c>) after a <see cref="ComputeContext"/> and <see cref="ComputeCommandQueue"/>s that use the <see cref="ComputeDevice"/> have been created and commands have been queued to them. Further calls will trigger an <c>OutOfResourcesComputeException</c> until this method is executed. You will also need to recreate any <see cref="ComputeResource"/> that was created on the no longer available <see cref="ComputeDevice"/>. </remarks>
        public ReadOnlyCollection<ComputeDevice> QueryDevices()
        {
            var error = CL10.GetDeviceIDs(Handle, ComputeDeviceTypes.All, 0, null, out int handlesLength);
            ComputeException.ThrowOnError(error);

            var handles = new CLDeviceHandle[handlesLength];
            error = CL10.GetDeviceIDs(Handle, ComputeDeviceTypes.All, handlesLength, handles, out handlesLength);
            ComputeException.ThrowOnError(error);

            var devices = new ComputeDevice[handlesLength];
            for (int i = 0; i < handlesLength; i++)
            {
                devices[i] = new ComputeDevice(this, handles[i]);
            }
            this.devices = new ReadOnlyCollection<ComputeDevice>(devices);
            return this.devices;
        }

        #endregion
    }
}
