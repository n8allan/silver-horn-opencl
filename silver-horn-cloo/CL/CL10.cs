﻿using NLog;
using SilverHorn.Cloo.Command;
using SilverHorn.Cloo.Context;
using SilverHorn.Cloo.Device;
using SilverHorn.Cloo.Event;
using SilverHorn.Cloo.Kernel;
using SilverHorn.Cloo.Platform;
using SilverHorn.Cloo.Sampler;
using System;
using System.Runtime.InteropServices;
using System.Security;


namespace Cloo.Bindings
{
    /// <summary>
    /// Contains bindings to the OpenCL 1.0 functions.
    /// </summary>
    /// <remarks> See the OpenCL specification for documentation regarding these functions. </remarks>
    [SuppressUnmanagedCodeSecurity]
    public class CL10
    {
        /// <summary>
        /// Логгирование
        /// </summary>
        protected static readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The name of the library that contains the available OpenCL function points.
        /// </summary>
        protected const string libName = "OpenCL.dll";

        /// <summary>
        /// See the OpenCL specification.
        /// </summary>
        [DllImport(libName, EntryPoint = "clGetPlatformIDs")]
        public extern static ComputeErrorCode GetPlatformIDs(
            Int32 num_entries,
            [Out, MarshalAs(UnmanagedType.LPArray)] CLPlatformHandle[] platforms,
            out Int32 num_platforms);

        /// <summary>
        /// See the OpenCL specification.
        /// </summary>
        [DllImport(libName, EntryPoint = "clGetPlatformInfo")]
        public extern static ComputeErrorCode GetPlatformInfo(
            CLPlatformHandle platform,
            ComputePlatformInfo param_name,
            IntPtr param_value_size,
            IntPtr param_value,
            out IntPtr param_value_size_ret);

        /// <summary>
        /// See the OpenCL specification.
        /// </summary>
        [DllImport(libName, EntryPoint = "clGetDeviceIDs")]
        public extern static ComputeErrorCode GetDeviceIDs(
            CLPlatformHandle platform,
            ComputeDeviceTypes device_type,
            Int32 num_entries,
            [Out, MarshalAs(UnmanagedType.LPArray)] CLDeviceHandle[] devices,
            out Int32 num_devices);

        /// <summary>
        /// See the OpenCL specification.
        /// </summary>
        [DllImport(libName, EntryPoint = "clGetDeviceInfo")]
        public extern static ComputeErrorCode GetDeviceInfo(
            CLDeviceHandle device,
            ComputeDeviceInfo param_name,
            IntPtr param_value_size,
            IntPtr param_value,
            out IntPtr param_value_size_ret);

        /// <summary>
        /// See the OpenCL specification.
        /// </summary>
        [DllImport(libName, EntryPoint = "clCreateBuffer")]
        public extern static CLMemoryHandle CreateBuffer(
            CLContextHandle context,
            ComputeMemoryFlags flags,
            IntPtr size,
            IntPtr host_ptr,
            out ComputeErrorCode errcode_ret);

        /// <summary>
        /// See the OpenCL specification.
        /// </summary>
        [DllImport(libName, EntryPoint = "clCreateImage2D")]
        public extern static CLMemoryHandle CreateImage2D(
            CLContextHandle context,
            ComputeMemoryFlags flags,
            ref ComputeImageFormat image_format,
            IntPtr image_width,
            IntPtr image_height,
            IntPtr image_row_pitch,
            IntPtr host_ptr,
            out ComputeErrorCode errcode_ret);

        /// <summary>
        /// See the OpenCL specification.
        /// </summary>
        [DllImport(libName, EntryPoint = "clCreateImage3D")]
        public extern static CLMemoryHandle CreateImage3D(
            CLContextHandle context,
            ComputeMemoryFlags flags,
            ref ComputeImageFormat image_format,
            IntPtr image_width,
            IntPtr image_height,
            IntPtr image_depth,
            IntPtr image_row_pitch,
            IntPtr image_slice_pitch,
            IntPtr host_ptr,
            out ComputeErrorCode errcode_ret);

        /// <summary>
        /// See the OpenCL specification.
        /// </summary>
        [DllImport(libName, EntryPoint = "clRetainMemObject")]
        public extern static ComputeErrorCode RetainMemObject(
            CLMemoryHandle memobj);

        /// <summary>
        /// See the OpenCL specification.
        /// </summary>
        [DllImport(libName, EntryPoint = "clReleaseMemObject")]
        public extern static ComputeErrorCode ReleaseMemObject(
            CLMemoryHandle memobj);

        /// <summary>
        /// See the OpenCL specification.
        /// </summary>
        [DllImport(libName, EntryPoint = "clGetSupportedImageFormats")]
        public extern static ComputeErrorCode GetSupportedImageFormats(
            CLContextHandle context,
            ComputeMemoryFlags flags,
            ComputeMemoryType image_type,
            Int32 num_entries,
            [Out, MarshalAs(UnmanagedType.LPArray)] ComputeImageFormat[] image_formats,
            out Int32 num_image_formats);

        /// <summary>
        /// See the OpenCL specification.
        /// </summary>
        [DllImport(libName, EntryPoint = "clGetMemObjectInfo")]
        public extern static ComputeErrorCode GetMemObjectInfo(
            CLMemoryHandle memobj,
            ComputeMemoryInfo param_name,
            IntPtr param_value_size,
            IntPtr param_value,
            out IntPtr param_value_size_ret);

        /// <summary>
        /// See the OpenCL specification.
        /// </summary>
        [DllImport(libName, EntryPoint = "clGetImageInfo")]
        public extern static ComputeErrorCode GetImageInfo(
            CLMemoryHandle image,
            ComputeImageInfo param_name,
            IntPtr param_value_size,
            IntPtr param_value,
            out IntPtr param_value_size_ret);

        

        /// <summary>
        /// See the OpenCL specification.
        /// </summary>
        [DllImport(libName, EntryPoint = "clUnloadCompiler")]
        public extern static ComputeErrorCode UnloadCompiler();

        

        

        

        

        

        

        

        

        /// <summary>
        /// See the OpenCL specification.
        /// </summary>
        [DllImport(libName, EntryPoint = "clWaitForEvents")]
        public extern static ComputeErrorCode WaitForEvents(
            Int32 num_events,
            [MarshalAs(UnmanagedType.LPArray)] CLEventHandle[] event_list);

        /// <summary>
        /// See the OpenCL specification.
        /// </summary>
        [DllImport(libName, EntryPoint = "clGetEventInfo")]
        public extern static ComputeErrorCode GetEventInfo(
            CLEventHandle @event,
            ComputeEventInfo param_name,
            IntPtr param_value_size,
            IntPtr param_value,
            out IntPtr param_value_size_ret);

        /// <summary>
        /// See the OpenCL specification.
        /// </summary>
        [DllImport(libName, EntryPoint = "clRetainEvent")]
        public extern static ComputeErrorCode RetainEvent(
            CLEventHandle @event);

        /// <summary>
        /// See the OpenCL specification.
        /// </summary>
        [DllImport(libName, EntryPoint = "clReleaseEvent")]
        public extern static ComputeErrorCode ReleaseEvent(
            CLEventHandle @event);

        /// <summary>
        /// See the OpenCL specification.
        /// </summary>
        [DllImport(libName, EntryPoint = "clGetEventProfilingInfo")]
        public extern static ComputeErrorCode GetEventProfilingInfo(
            CLEventHandle @event,
            ComputeCommandProfilingInfo param_name,
            IntPtr param_value_size,
            IntPtr param_value,
            out IntPtr param_value_size_ret);

        /// <summary>
        /// See the OpenCL specification.
        /// </summary>
        [DllImport(libName, EntryPoint = "clFlush")]
        public extern static ComputeErrorCode Flush(
            CLCommandQueueHandle command_queue);

        /// <summary>
        /// See the OpenCL specification.
        /// </summary>
        [DllImport(libName, EntryPoint = "clFinish")]
        public extern static ComputeErrorCode Finish(
            CLCommandQueueHandle command_queue);

        /// <summary>
        /// See the OpenCL specification.
        /// </summary>
        [DllImport(libName, EntryPoint = "clEnqueueReadBuffer")]
        public extern static ComputeErrorCode EnqueueReadBuffer(
            CLCommandQueueHandle command_queue,
            CLMemoryHandle buffer,
            [MarshalAs(UnmanagedType.Bool)] bool blocking_read,
            IntPtr offset,
            IntPtr cb,
            IntPtr ptr,
            Int32 num_events_in_wait_list,
            [MarshalAs(UnmanagedType.LPArray)] CLEventHandle[] event_wait_list,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 1)] CLEventHandle[] new_event);

        /// <summary>
        /// See the OpenCL specification.
        /// </summary>
        [DllImport(libName, EntryPoint = "clEnqueueWriteBuffer")]
        public extern static ComputeErrorCode EnqueueWriteBuffer(
            CLCommandQueueHandle command_queue,
            CLMemoryHandle buffer,
            [MarshalAs(UnmanagedType.Bool)] bool blocking_write,
            IntPtr offset,
            IntPtr cb,
            IntPtr ptr,
            Int32 num_events_in_wait_list,
            [MarshalAs(UnmanagedType.LPArray)] CLEventHandle[] event_wait_list,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 1)] CLEventHandle[] new_event);

        /// <summary>
        /// See the OpenCL specification.
        /// </summary>
        [DllImport(libName, EntryPoint = "clEnqueueCopyBuffer")]
        public extern static ComputeErrorCode EnqueueCopyBuffer(
            CLCommandQueueHandle command_queue,
            CLMemoryHandle src_buffer,
            CLMemoryHandle dst_buffer,
            IntPtr src_offset,
            IntPtr dst_offset,
            IntPtr cb,
            Int32 num_events_in_wait_list,
            [MarshalAs(UnmanagedType.LPArray)] CLEventHandle[] event_wait_list,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 1)] CLEventHandle[] new_event);

        /// <summary>
        /// See the OpenCL specification.
        /// </summary>
        [DllImport(libName, EntryPoint = "clEnqueueReadImage")]
        public extern static ComputeErrorCode EnqueueReadImage(
            CLCommandQueueHandle command_queue,
            CLMemoryHandle image,
            [MarshalAs(UnmanagedType.Bool)] bool blocking_read,
            ref SysIntX3 origin,
            ref SysIntX3 region,
            IntPtr row_pitch,
            IntPtr slice_pitch,
            IntPtr ptr,
            Int32 num_events_in_wait_list,
            [MarshalAs(UnmanagedType.LPArray)] CLEventHandle[] event_wait_list,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 1)] CLEventHandle[] new_event);

        /// <summary>
        /// See the OpenCL specification.
        /// </summary>
        [DllImport(libName, EntryPoint = "clEnqueueWriteImage")]
        public extern static ComputeErrorCode EnqueueWriteImage(
            CLCommandQueueHandle command_queue,
            CLMemoryHandle image,
            [MarshalAs(UnmanagedType.Bool)] bool blocking_write,
            ref SysIntX3 origin,
            ref SysIntX3 region,
            IntPtr input_row_pitch,
            IntPtr input_slice_pitch,
            IntPtr ptr,
            Int32 num_events_in_wait_list,
            [MarshalAs(UnmanagedType.LPArray)] CLEventHandle[] event_wait_list,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 1)] CLEventHandle[] new_event);

        /// <summary>
        /// See the OpenCL specification.
        /// </summary>
        [DllImport(libName, EntryPoint = "clEnqueueCopyImage")]
        public extern static ComputeErrorCode EnqueueCopyImage(
            CLCommandQueueHandle command_queue,
            CLMemoryHandle src_image,
            CLMemoryHandle dst_image,
            ref SysIntX3 src_origin,
            ref SysIntX3 dst_origin,
            ref SysIntX3 region,
            Int32 num_events_in_wait_list,
            [MarshalAs(UnmanagedType.LPArray)] CLEventHandle[] event_wait_list,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 1)] CLEventHandle[] new_event);

        /// <summary>
        /// See the OpenCL specification.
        /// </summary>
        [DllImport(libName, EntryPoint = "clEnqueueCopyImageToBuffer")]
        public extern static ComputeErrorCode EnqueueCopyImageToBuffer(
            CLCommandQueueHandle command_queue,
            CLMemoryHandle src_image,
            CLMemoryHandle dst_buffer,
            ref SysIntX3 src_origin,
            ref SysIntX3 region,
            IntPtr dst_offset,
            Int32 num_events_in_wait_list,
            [MarshalAs(UnmanagedType.LPArray)] CLEventHandle[] event_wait_list,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 1)] CLEventHandle[] new_event);

        /// <summary>
        /// See the OpenCL specification.
        /// </summary>
        [DllImport(libName, EntryPoint = "clEnqueueCopyBufferToImage")]
        public extern static ComputeErrorCode EnqueueCopyBufferToImage(
            CLCommandQueueHandle command_queue,
            CLMemoryHandle src_buffer,
            CLMemoryHandle dst_image,
            IntPtr src_offset,
            ref SysIntX3 dst_origin,
            ref SysIntX3 region,
            Int32 num_events_in_wait_list,
            [MarshalAs(UnmanagedType.LPArray)] CLEventHandle[] event_wait_list,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 1)] CLEventHandle[] new_event);

        /// <summary>
        /// See the OpenCL specification.
        /// </summary>
        [DllImport(libName, EntryPoint = "clEnqueueMapBuffer")]
        public extern static IntPtr EnqueueMapBuffer(
            CLCommandQueueHandle command_queue,
            CLMemoryHandle buffer,
            [MarshalAs(UnmanagedType.Bool)] bool blocking_map,
            ComputeMemoryMappingFlags map_flags,
            IntPtr offset,
            IntPtr cb,
            Int32 num_events_in_wait_list,
            [MarshalAs(UnmanagedType.LPArray)] CLEventHandle[] event_wait_list,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 1)] CLEventHandle[] new_event,
            out ComputeErrorCode errcode_ret);

        /// <summary>
        /// See the OpenCL specification.
        /// </summary>
        [DllImport(libName, EntryPoint = "clEnqueueMapImage")]
        public extern static IntPtr EnqueueMapImage(
            CLCommandQueueHandle command_queue,
            CLMemoryHandle image,
            [MarshalAs(UnmanagedType.Bool)] bool blocking_map,
            ComputeMemoryMappingFlags map_flags,
            ref SysIntX3 origin,
            ref SysIntX3 region,
            out IntPtr image_row_pitch,
            out IntPtr image_slice_pitch,
            Int32 num_events_in_wait_list,
            [MarshalAs(UnmanagedType.LPArray)] CLEventHandle[] event_wait_list,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 1)] CLEventHandle[] new_event,
            out ComputeErrorCode errcode_ret);

        /// <summary>
        /// See the OpenCL specification.
        /// </summary>
        [DllImport(libName, EntryPoint = "clEnqueueUnmapMemObject")]
        public extern static ComputeErrorCode EnqueueUnmapMemObject(
            CLCommandQueueHandle command_queue,
            CLMemoryHandle memobj,
            IntPtr mapped_ptr,
            Int32 num_events_in_wait_list,
            [MarshalAs(UnmanagedType.LPArray)] CLEventHandle[] event_wait_list,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 1)] CLEventHandle[] new_event);

        /// <summary>
        /// See the OpenCL specification.
        /// </summary>
        [DllImport(libName, EntryPoint = "clEnqueueNDRangeKernel")]
        public extern static ComputeErrorCode EnqueueNDRangeKernel(
            CLCommandQueueHandle command_queue,
            CLKernelHandle kernel,
            Int32 work_dim,
            [MarshalAs(UnmanagedType.LPArray)] IntPtr[] global_work_offset,
            [MarshalAs(UnmanagedType.LPArray)] IntPtr[] global_work_size,
            [MarshalAs(UnmanagedType.LPArray)] IntPtr[] local_work_size,
            Int32 num_events_in_wait_list,
            [MarshalAs(UnmanagedType.LPArray)] CLEventHandle[] event_wait_list,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 1)] CLEventHandle[] new_event);

        /// <summary>
        /// See the OpenCL specification.
        /// </summary>
        [DllImport(libName, EntryPoint = "clEnqueueTask")]
        public extern static ComputeErrorCode EnqueueTask(
            CLCommandQueueHandle command_queue,
            CLKernelHandle kernel,
            Int32 num_events_in_wait_list,
            [MarshalAs(UnmanagedType.LPArray)] CLEventHandle[] event_wait_list,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 1)] CLEventHandle[] new_event);

        // <summary>
        // See the OpenCL specification.
        // </summary>
        /*
        [DllImport(libName, EntryPoint = "clEnqueueNativeKernel")]
        public extern static ComputeErrorCode EnqueueNativeKernel(
            CLCommandQueueHandle command_queue,
            IntPtr user_func,
            IntPtr args,
            IntPtr cb_args,
            Int32 num_mem_objects,
            IntPtr* mem_list,
            IntPtr* args_mem_loc,
            Int32 num_events_in_wait_list,
            [MarshalAs(UnmanagedType.LPArray)] CLEventHandle[] event_wait_list,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeConst=1)] CLEventHandle[] new_event);
        */

        /// <summary>
        /// See the OpenCL specification.
        /// </summary>
        [DllImport(libName, EntryPoint = "clEnqueueMarker")]
        public extern static ComputeErrorCode EnqueueMarker(
            CLCommandQueueHandle command_queue,
            out CLEventHandle new_event);

        /// <summary>
        /// See the OpenCL specification.
        /// </summary>
        [DllImport(libName, EntryPoint = "clEnqueueWaitForEvents")]
        public extern static ComputeErrorCode EnqueueWaitForEvents(
            CLCommandQueueHandle command_queue,
            Int32 num_events,
            [MarshalAs(UnmanagedType.LPArray)] CLEventHandle[] event_list);

        /// <summary>
        /// See the OpenCL specification.
        /// </summary>
        [DllImport(libName, EntryPoint = "clEnqueueBarrier")]
        public extern static ComputeErrorCode EnqueueBarrier(
            CLCommandQueueHandle command_queue);


        /// <summary>
        /// Gets the extension function address for the given function name,
        /// or NULL if a valid function can not be found. The client must
        /// check to make sure the address is not NULL, before using or 
        /// calling the returned function address.
        /// </summary>
        [DllImport(libName, EntryPoint = "clGetExtensionFunctionAddress")]
        public extern static IntPtr GetExtensionFunctionAddress(
            String func_name);

        /**************************************************************************************/
        // CL/GL Sharing API

        /// <summary>
        /// See the OpenCL specification.
        /// </summary>
        [DllImport(libName, EntryPoint = "clCreateFromGLBuffer")]
        public extern static CLMemoryHandle CreateFromGLBuffer(
            CLContextHandle context,
            ComputeMemoryFlags flags,
            Int32 bufobj,
            out ComputeErrorCode errcode_ret);

        /// <summary>
        /// See the OpenCL specification.
        /// </summary>
        [DllImport(libName, EntryPoint = "clCreateFromGLTexture2D")]
        public extern static CLMemoryHandle CreateFromGLTexture2D(
            CLContextHandle context,
            ComputeMemoryFlags flags,
            Int32 target,
            Int32 miplevel,
            Int32 texture,
            out ComputeErrorCode errcode_ret);

        /// <summary>
        /// See the OpenCL specification.
        /// </summary>
        [DllImport(libName, EntryPoint = "clCreateFromGLTexture3D")]
        public extern static CLMemoryHandle CreateFromGLTexture3D(
            CLContextHandle context,
            ComputeMemoryFlags flags,
            Int32 target,
            Int32 miplevel,
            Int32 texture,
            out ComputeErrorCode errcode_ret);

        /// <summary>
        /// See the OpenCL specification.
        /// </summary>
        [DllImport(libName, EntryPoint = "clCreateFromGLRenderbuffer")]
        public extern static CLMemoryHandle CreateFromGLRenderbuffer(
            CLContextHandle context,
            ComputeMemoryFlags flags,
            Int32 renderbuffer,
            out ComputeErrorCode errcode_ret);

        /// <summary>
        /// See the OpenCL specification.
        /// </summary>
        [DllImport(libName, EntryPoint = "clGetGLObjectInfo")]
        public extern static ComputeErrorCode GetGLObjectInfo(
            CLMemoryHandle memobj,
            out ComputeGLObjectType gl_object_type,
            out Int32 gl_object_name);

        /// <summary>
        /// See the OpenCL specification.
        /// </summary>
        [DllImport(libName, EntryPoint = "clGetGLTextureInfo")]
        public extern static ComputeErrorCode GetGLTextureInfo(
            CLMemoryHandle memobj,
            ComputeGLTextureInfo param_name,
            IntPtr param_value_size,
            IntPtr param_value,
            out IntPtr param_value_size_ret);

        /// <summary>
        /// See the OpenCL specification.
        /// </summary>
        [DllImport(libName, EntryPoint = "clEnqueueAcquireGLObjects")]
        public extern static ComputeErrorCode EnqueueAcquireGLObjects(
            CLCommandQueueHandle command_queue,
            Int32 num_objects,
            [MarshalAs(UnmanagedType.LPArray)] CLMemoryHandle[] mem_objects,
            Int32 num_events_in_wait_list,
            [MarshalAs(UnmanagedType.LPArray)] CLEventHandle[] event_wait_list,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 1)] CLEventHandle[] new_event);

        /// <summary>
        /// See the OpenCL specification.
        /// </summary>
        [DllImport(libName, EntryPoint = "clEnqueueReleaseGLObjects")]
        public extern static ComputeErrorCode EnqueueReleaseGLObjects(
            CLCommandQueueHandle command_queue,
            Int32 num_objects,
            [MarshalAs(UnmanagedType.LPArray)] CLMemoryHandle[] mem_objects,
            Int32 num_events_in_wait_list,
            [MarshalAs(UnmanagedType.LPArray)] CLEventHandle[] event_wait_list,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 1)] CLEventHandle[] new_event);
    }

    /// <summary>
    /// A callback function that can be registered by the application to report information on errors that occur in the context.
    /// </summary>
    /// <param name="errorInfo"> An error string. </param>
    /// <param name="clDataPtr"> A pointer to binary data that is returned by the OpenCL implementation that can be used to log additional information helpful in debugging the error.</param>
    /// <param name="clDataSize"> The size of the binary data that is returned by the OpenCL. </param>
    /// <param name="userDataPtr"> The pointer to the optional user data specified in <paramref name="userDataPtr"/> argument of context constructor. </param>
    /// <remarks> This callback function may be called asynchronously by the OpenCL implementation. It is the application's responsibility to ensure that the callback function is thread-safe. </remarks>
    public delegate void ComputeContextNotifier(String errorInfo, IntPtr clDataPtr, IntPtr clDataSize, IntPtr userDataPtr);

    /// <summary>
    /// A callback function that can be registered by the application to report the program build status.
    /// </summary>
    /// <param name="programHandle"> The handle of the program being built. </param>
    /// <param name="notifyDataPtr"> The pointer to the optional user data specified in <paramref name="notifyDataPtr"/> argument of build. </param>
    /// <remarks> This callback function may be called asynchronously by the OpenCL implementation. It is the application's responsibility to ensure that the callback function is thread-safe. </remarks>
    public delegate void ComputeProgramBuildNotifier(CLProgramHandle programHandle, IntPtr notifyDataPtr);
}
