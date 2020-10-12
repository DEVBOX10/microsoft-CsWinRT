﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace WinRT.Interop
{
    [WindowsRuntimeType]
    [Guid("C03F6A43-65A4-9818-987E-E0B810D2A6F2")]
    internal interface IAgileReference
    {
        IObjectReference Resolve(Guid riid);
    }

    [WindowsRuntimeType]
    [Guid("94ea2b94-e9cc-49e0-c0ff-ee64ca8f5b90")]
    public interface IAgileObject
    {
        public static readonly Guid IID = Guid.Parse("94ea2b94-e9cc-49e0-c0ff-ee64ca8f5b90");
    }

    [WindowsRuntimeType]
    [Guid("00000146-0000-0000-C000-000000000046")]
    internal interface IGlobalInterfaceTable
    {
        IntPtr RegisterInterfaceInGlobal(IObjectReference objRef, Guid riid);
        void RevokeInterfaceFromGlobal(IntPtr cookie);
        IObjectReference GetInterfaceFromGlobal(IntPtr cookie, Guid riid);
    }
}

namespace ABI.WinRT.Interop
{
    using global::WinRT;
    using WinRT.Interop;

    [DynamicInterfaceCastableImplementation]
    [Guid("C03F6A43-65A4-9818-987E-E0B810D2A6F2")]
    internal unsafe interface IAgileReference : global::WinRT.Interop.IAgileReference
    {
        [Guid("C03F6A43-65A4-9818-987E-E0B810D2A6F2")]
        public struct Vftbl
        {
            public global::WinRT.Interop.IUnknownVftbl IUnknownVftbl;
            private void* _Resolve;
            public delegate* unmanaged[Stdcall]<IntPtr, ref Guid, out IntPtr, int> Resolve { get => (delegate* unmanaged[Stdcall]<IntPtr, ref Guid, out IntPtr, int>)_Resolve; set => _Resolve = value; }

            public static readonly Vftbl AbiToProjectionVftable;
            public static readonly IntPtr AbiToProjectionVftablePtr;

#if NETSTANDARD2_0
            public delegate int ResolveDelegate(IntPtr thisPtr, Guid* riid, IntPtr* objectReference);
            private static readonly Delegate[] DelegateCache = new Delegate[1];
#endif
            static Vftbl()
            {
                AbiToProjectionVftable = new Vftbl
                {
                    IUnknownVftbl = global::WinRT.Interop.IUnknownVftbl.AbiToProjectionVftbl,
#if NETSTANDARD2_0
                    _Resolve = Marshal.GetFunctionPointerForDelegate(DelegateCache[0] = new ResolveDelegate(Do_Abi_Resolve)).ToPointer(),
#else
                    _Resolve = (delegate* unmanaged<IntPtr, Guid*, IntPtr*, int>)&Do_Abi_Resolve
#endif
                };
                AbiToProjectionVftablePtr = Marshal.AllocHGlobal(Marshal.SizeOf<Vftbl>());
                Marshal.StructureToPtr(AbiToProjectionVftable, AbiToProjectionVftablePtr, false);
            }

#if !NETSTANDARD2_0
            [UnmanagedCallersOnly]
#endif
            private static int Do_Abi_Resolve(IntPtr thisPtr, Guid* riid, IntPtr* objectReference)
            {
                IObjectReference _objectReference = default;

                *objectReference = default;

                try
                {
                    _objectReference = global::WinRT.ComWrappersSupport.FindObject<global::WinRT.Interop.IAgileReference>(thisPtr).Resolve(*riid);
                    *objectReference = _objectReference?.GetRef() ?? IntPtr.Zero;
                }
                catch (Exception __exception__)
                {
                    return __exception__.HResult;
                }
                return 0;
            }
        }

        public static ObjectReference<Vftbl> FromAbi(IntPtr thisPtr) => ObjectReference<Vftbl>.FromAbi(thisPtr);

        IObjectReference global::WinRT.Interop.IAgileReference.Resolve(Guid riid)
        {
            var _obj = ((ObjectReference<Vftbl>)((IWinRTObject)this).GetObjectReferenceForType(typeof(global::WinRT.Interop.IAgileReference).TypeHandle));
            var ThisPtr = _obj.ThisPtr;

            ExceptionHelpers.ThrowExceptionForHR(_obj.Vftbl.Resolve(ThisPtr, ref riid, out IntPtr ptr));
            try
            {
                return ComWrappersSupport.GetObjectReferenceForInterface(ptr);
            }
            finally
            {
                MarshalInspectable<object>.DisposeAbi(ptr);
            }
        }
    }

    [DynamicInterfaceCastableImplementation]
    [Guid("94ea2b94-e9cc-49e0-c0ff-ee64ca8f5b90")]
    interface IAgileObject : global::WinRT.Interop.IAgileObject
    {
        [Guid("94ea2b94-e9cc-49e0-c0ff-ee64ca8f5b90")]
        public struct Vftbl
        {
            public global::WinRT.Interop.IUnknownVftbl IUnknownVftbl;

            public static readonly Vftbl AbiToProjectionVftable;
            public static readonly IntPtr AbiToProjectionVftablePtr;

            static Vftbl()
            {
                AbiToProjectionVftable = new Vftbl
                {
                    IUnknownVftbl = global::WinRT.Interop.IUnknownVftbl.AbiToProjectionVftbl,
                };
                AbiToProjectionVftablePtr = Marshal.AllocHGlobal(Marshal.SizeOf<Vftbl>());
                Marshal.StructureToPtr(AbiToProjectionVftable, AbiToProjectionVftablePtr, false);
            }
        }

        public static ObjectReference<Vftbl> FromAbi(IntPtr thisPtr) => ObjectReference<Vftbl>.FromAbi(thisPtr);

    }

    [Guid("00000146-0000-0000-C000-000000000046")]
    internal unsafe class IGlobalInterfaceTable : global::WinRT.Interop.IGlobalInterfaceTable
    {
        [Guid("00000146-0000-0000-C000-000000000046")]
        [StructLayout(LayoutKind.Sequential)]
        public struct Vftbl
        {
            public global::WinRT.Interop.IUnknownVftbl IUnknownVftbl;
            private void* _RegisterInterfaceInGlobal;
            public delegate* unmanaged[Stdcall]<IntPtr, IntPtr, ref Guid, out IntPtr, int> RegisterInterfaceInGlobal => (delegate* unmanaged[Stdcall]<IntPtr, IntPtr, ref Guid, out IntPtr, int>)_RegisterInterfaceInGlobal;
            private void* _RevokeInterfaceFromGlobal;
            public delegate* unmanaged[Stdcall]<IntPtr, IntPtr, int> RevokeInterfaceFromGlobal => (delegate* unmanaged[Stdcall]<IntPtr, IntPtr, int>)_RevokeInterfaceFromGlobal;
            private void* _GetInterfaceFromGlobal;
            public delegate* unmanaged[Stdcall]<IntPtr, IntPtr, ref Guid, out IntPtr, int> GetInterfaceFromGlobal => (delegate* unmanaged[Stdcall]<IntPtr, IntPtr, ref Guid, out IntPtr, int>)_GetInterfaceFromGlobal;
        }

        public static ObjectReference<Vftbl> FromAbi(IntPtr thisPtr) => ObjectReference<Vftbl>.FromAbi(thisPtr);

        public static implicit operator IGlobalInterfaceTable(IObjectReference obj) => (obj != null) ? new IGlobalInterfaceTable(obj) : null;
        public static implicit operator IGlobalInterfaceTable(ObjectReference<Vftbl> obj) => (obj != null) ? new IGlobalInterfaceTable(obj) : null;
        protected readonly ObjectReference<Vftbl> _obj;
        public IntPtr ThisPtr => _obj.ThisPtr;
        public ObjectReference<I> AsInterface<I>() => _obj.As<I>();
        public A As<A>() => _obj.AsType<A>();

        public IGlobalInterfaceTable(IObjectReference obj) : this(obj.As<Vftbl>()) { }
        public IGlobalInterfaceTable(ObjectReference<Vftbl> obj)
        {
            _obj = obj;
        }

        public IntPtr RegisterInterfaceInGlobal(IObjectReference objRef, Guid riid)
        {
            ExceptionHelpers.ThrowExceptionForHR(_obj.Vftbl.RegisterInterfaceInGlobal(ThisPtr, objRef.ThisPtr, ref riid, out IntPtr cookie));
            return cookie;

        }

        public void RevokeInterfaceFromGlobal(IntPtr cookie)
        {
            ExceptionHelpers.ThrowExceptionForHR(_obj.Vftbl.RevokeInterfaceFromGlobal(ThisPtr, cookie));
        }

        public IObjectReference GetInterfaceFromGlobal(IntPtr cookie, Guid riid)
        {
            ExceptionHelpers.ThrowExceptionForHR(_obj.Vftbl.GetInterfaceFromGlobal(ThisPtr, cookie, ref riid, out IntPtr ptr));
            try
            {
                return ComWrappersSupport.GetObjectReferenceForInterface(ptr);
            }
            finally
            {
                MarshalInspectable<object>.DisposeAbi(ptr);
            }
        }
    }
}