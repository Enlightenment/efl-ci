/*
 * Copyright 2019 by its authors. See AUTHORS.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
#pragma warning disable 1591

#define CODE_ANALYSIS

using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Security.Permissions;
using System.Security;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using System.Globalization;

using static Eina.EinaNative.UnsafeNativeMethods;
using static Eina.TraitFunctions;


namespace Eina
{

namespace EinaNative
{

// Structs to be passed from/to C when dealing with containers and
// optional values.
[StructLayout(LayoutKind.Sequential)]
[EditorBrowsable(EditorBrowsableState.Never)]
struct Value_Array
{
    public IntPtr subtype;
    public uint step;
    public IntPtr subarray;
}

[StructLayout(LayoutKind.Sequential)]
[EditorBrowsable(EditorBrowsableState.Never)]
struct Value_List
{
    public IntPtr subtype;
    public IntPtr sublist;
}

[SuppressUnmanagedCodeSecurityAttribute]
[EditorBrowsable(EditorBrowsableState.Never)]
static internal class UnsafeNativeMethods
{
    [DllImport(efl.Libs.Eina)]
    internal static extern IntPtr eina_value_new(IntPtr type);

    [DllImport(efl.Libs.Eina)]
    internal static extern void eina_value_free(IntPtr type);

    [DllImport(efl.Libs.Eina)]
    internal static extern IntPtr eina_value_type_name_get(IntPtr type);

    [DllImport(efl.Libs.Eina)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_convert(IntPtr handle, IntPtr convert);

    // Wrapped and helper methods
    [DllImport(efl.Libs.CustomExports)]
    internal static extern int eina_value_sizeof();

    [DllImport(efl.Libs.CustomExports, CharSet=CharSet.Ansi)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_set_wrapper_string(IntPtr handle, string value);

    [DllImport(efl.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_set_wrapper_uchar(IntPtr handle, byte value);

    [DllImport(efl.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_set_wrapper_char(IntPtr handle, sbyte value);

    [DllImport(efl.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_set_wrapper_short(IntPtr handle, short value);

    [DllImport(efl.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_set_wrapper_ushort(IntPtr handle, ushort value);

    [DllImport(efl.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_set_wrapper_int(IntPtr handle, int value);

    [DllImport(efl.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_set_wrapper_uint(IntPtr handle, uint value);

    [DllImport(efl.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_set_wrapper_long(IntPtr handle, long value);

    [DllImport(efl.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_set_wrapper_ulong(IntPtr handle, ulong value);

    [DllImport(efl.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_set_wrapper_float(IntPtr handle, float value);

    [DllImport(efl.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_set_wrapper_double(IntPtr handle, double value);

    [DllImport(efl.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_set_wrapper_ptr(IntPtr handle, IntPtr value);

    [DllImport(efl.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_setup_wrapper(IntPtr handle, IntPtr type);

    [DllImport(efl.Libs.CustomExports)]
    internal static extern void eina_value_flush_wrapper(IntPtr handle);

    [DllImport(efl.Libs.CustomExports)]
    internal static extern IntPtr eina_value_type_get_wrapper(IntPtr handle);

    [DllImport(efl.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_get_wrapper(IntPtr handle, out IntPtr output);

    [DllImport(efl.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_get_wrapper(IntPtr handle, out Value_List output);

    [DllImport(efl.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_get_wrapper(IntPtr handle, out Value_Array output);

    [DllImport(efl.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_get_wrapper(IntPtr handle, out byte output);

    [DllImport(efl.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_get_wrapper(IntPtr handle, out sbyte output);

    [DllImport(efl.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_get_wrapper(IntPtr handle, out short output);

    [DllImport(efl.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_get_wrapper(IntPtr handle, out ushort output);

    [DllImport(efl.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_get_wrapper(IntPtr handle, out int output);

    [DllImport(efl.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_get_wrapper(IntPtr handle, out uint output);

    [DllImport(efl.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_get_wrapper(IntPtr handle, out long output);

    [DllImport(efl.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_get_wrapper(IntPtr handle, out ulong output);

    [DllImport(efl.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_get_wrapper(IntPtr handle, out float output);

    [DllImport(efl.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_get_wrapper(IntPtr handle, out double output);

    [DllImport(efl.Libs.CustomExports)]
    internal static extern int eina_value_compare_wrapper(IntPtr handle, IntPtr other);

    [DllImport(efl.Libs.Eina, CharSet=CharSet.Ansi)]
    [return:
     MarshalAs(UnmanagedType.CustomMarshaler,
	       MarshalTypeRef=typeof(Efl.Eo.StringPassOwnershipMarshaler))]
    internal static extern string eina_value_to_string(IntPtr handle); // We take ownership of the returned string.

    [DllImport(efl.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_array_setup_wrapper(IntPtr handle, IntPtr subtype, uint step);

    [DllImport(efl.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_list_setup_wrapper(IntPtr handle, IntPtr subtype);

    [DllImport(efl.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_container_append_wrapper_string(IntPtr handle, string data);

    [DllImport(efl.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_container_append_wrapper_ptr(IntPtr handle, IntPtr data);

    [DllImport(efl.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_container_append_wrapper_char(IntPtr handle, sbyte data);

    [DllImport(efl.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_container_append_wrapper_uchar(IntPtr handle, byte data);

    [DllImport(efl.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_container_append_wrapper_short(IntPtr handle, short data);

    [DllImport(efl.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_container_append_wrapper_ushort(IntPtr handle, ushort data);

    [DllImport(efl.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_container_append_wrapper_int(IntPtr handle, int data);

    [DllImport(efl.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_container_append_wrapper_uint(IntPtr handle, uint data);

    [DllImport(efl.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_container_append_wrapper_long(IntPtr handle, long data);

    [DllImport(efl.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_container_append_wrapper_ulong(IntPtr handle, ulong data);

    [DllImport(efl.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_container_append_wrapper_float(IntPtr handle, float data);

    [DllImport(efl.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_container_append_wrapper_double(IntPtr handle, double data);

    [DllImport(efl.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_list_append_wrapper(IntPtr handle, IntPtr data);

    [DllImport(efl.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_container_get_wrapper(IntPtr handle, int index, out IntPtr output);

    [DllImport(efl.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_container_get_wrapper(IntPtr handle, int index, out sbyte output);

    [DllImport(efl.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_container_get_wrapper(IntPtr handle, int index, out byte output);

    [DllImport(efl.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_container_get_wrapper(IntPtr handle, int index, out short output);

    [DllImport(efl.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_container_get_wrapper(IntPtr handle, int index, out ushort output);

    [DllImport(efl.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_container_get_wrapper(IntPtr handle, int index, out int output);

    [DllImport(efl.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_container_get_wrapper(IntPtr handle, int index, out uint output);

    [DllImport(efl.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_container_get_wrapper(IntPtr handle, int index, out long output);

    [DllImport(efl.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_container_get_wrapper(IntPtr handle, int index, out ulong output);

    [DllImport(efl.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_container_get_wrapper(IntPtr handle, int index, out float output);

    [DllImport(efl.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_container_get_wrapper(IntPtr handle, int index, out double output);

    [DllImport(efl.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_list_get_wrapper(IntPtr handle, int index, out IntPtr output);

    [DllImport(efl.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_container_set_wrapper_string(IntPtr handle, int index, string value);

    [DllImport(efl.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_container_set_wrapper_ptr(IntPtr handle, int index, IntPtr value);

    [DllImport(efl.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_container_set_wrapper_uchar(IntPtr handle, int index, byte value);

    [DllImport(efl.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_container_set_wrapper_char(IntPtr handle, int index, sbyte value);

    [DllImport(efl.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_container_set_wrapper_short(IntPtr handle, int index, short value);

    [DllImport(efl.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_container_set_wrapper_ushort(IntPtr handle, int index, ushort value);

    [DllImport(efl.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_container_set_wrapper_int(IntPtr handle, int index, int value);

    [DllImport(efl.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_container_set_wrapper_uint(IntPtr handle, int index, uint value);

    [DllImport(efl.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_container_set_wrapper_long(IntPtr handle, int index, long value);

    [DllImport(efl.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_container_set_wrapper_ulong(IntPtr handle, int index, ulong value);

    [DllImport(efl.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_container_set_wrapper_float(IntPtr handle, int index, float value);

    [DllImport(efl.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_container_set_wrapper_double(IntPtr handle, int index, double value);

    [DllImport(efl.Libs.CustomExports)]
    internal static extern IntPtr eina_value_array_subtype_get_wrapper(IntPtr handle);

    [DllImport(efl.Libs.CustomExports)]
    internal static extern IntPtr eina_value_list_subtype_get_wrapper(IntPtr handle);

    [DllImport(efl.Libs.CustomExports)]
    internal static extern uint eina_value_array_count_wrapper(IntPtr handle);

    [DllImport(efl.Libs.CustomExports)]
    internal static extern uint eina_value_list_count_wrapper(IntPtr handle);

    [DllImport(efl.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_optional_empty_is_wrapper(IntPtr handle, [MarshalAsAttribute(UnmanagedType.U1)] out bool empty);

    [DllImport(efl.Libs.Eina)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_optional_pset(IntPtr handle, IntPtr subtype, ref byte value);

    [DllImport(efl.Libs.Eina)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_optional_pset(IntPtr handle, IntPtr subtype, ref sbyte value);

    [DllImport(efl.Libs.Eina)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_optional_pset(IntPtr handle, IntPtr subtype, ref short value);

    [DllImport(efl.Libs.Eina)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_optional_pset(IntPtr handle, IntPtr subtype, ref ushort value);

    [DllImport(efl.Libs.Eina)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_optional_pset(IntPtr handle, IntPtr subtype, ref int value);

    [DllImport(efl.Libs.Eina)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_optional_pset(IntPtr handle, IntPtr subtype, ref uint value);

    [DllImport(efl.Libs.Eina)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_optional_pset(IntPtr handle, IntPtr subtype, ref long value);

    [DllImport(efl.Libs.Eina)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_optional_pset(IntPtr handle, IntPtr subtype, ref ulong value);

    [DllImport(efl.Libs.Eina)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_optional_pset(IntPtr handle, IntPtr subtype, ref float value);

    [DllImport(efl.Libs.Eina)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_optional_pset(IntPtr handle, IntPtr subtype, ref double value);

    [DllImport(efl.Libs.Eina, CharSet=CharSet.Ansi)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_optional_pset(IntPtr handle, IntPtr subtype, ref string value);

    [DllImport(efl.Libs.Eina)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_optional_pset(IntPtr handle, IntPtr subtype, ref IntPtr value);

    [DllImport(efl.Libs.Eina)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_optional_pset(IntPtr handle, IntPtr subtype, IntPtr value);

    [DllImport(efl.Libs.Eina)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_optional_reset(IntPtr handle);

    [DllImport(efl.Libs.Eina)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_optional_pget(IntPtr handle, out Eina.EinaNative.Value_Array output);

    [DllImport(efl.Libs.Eina)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_optional_pget(IntPtr handle, out Eina.EinaNative.Value_List output);

    [DllImport(efl.Libs.Eina)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_optional_pget(IntPtr handle, out IntPtr output);

    [DllImport(efl.Libs.Eina)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_optional_pget(IntPtr handle, out byte output);

    [DllImport(efl.Libs.Eina)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_optional_pget(IntPtr handle, out sbyte output);

    [DllImport(efl.Libs.Eina)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_optional_pget(IntPtr handle, out short output);

    [DllImport(efl.Libs.Eina)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_optional_pget(IntPtr handle, out ushort output);

    [DllImport(efl.Libs.Eina)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_optional_pget(IntPtr handle, out int output);

    [DllImport(efl.Libs.Eina)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_optional_pget(IntPtr handle, out uint output);

    [DllImport(efl.Libs.Eina)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_optional_pget(IntPtr handle, out long output);

    [DllImport(efl.Libs.Eina)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_optional_pget(IntPtr handle, out ulong output);

    [DllImport(efl.Libs.Eina)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_optional_pget(IntPtr handle, out float output);

    [DllImport(efl.Libs.Eina)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_optional_pget(IntPtr handle, out double output);

    [DllImport(efl.Libs.CustomExports)]
    internal static extern IntPtr eina_value_optional_type_get_wrapper(IntPtr handle);

    [DllImport(efl.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_pset_wrapper(IntPtr handle, ref Eina.EinaNative.Value_Array ptr);

    [DllImport(efl.Libs.CustomExports)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_pset_wrapper(IntPtr handle, ref Eina.EinaNative.Value_List ptr);

    [DllImport(efl.Libs.Eina)]
    [return: MarshalAsAttribute(UnmanagedType.U1)]
    internal static extern bool eina_value_copy(IntPtr src, IntPtr dest);

    // Supported types

    // 8 bits byte
    [DllImport(efl.Libs.CustomExports)]
    internal static extern IntPtr type_byte();
    [DllImport(efl.Libs.CustomExports)]
    internal static extern IntPtr type_sbyte();

    // 16 bits short
    [DllImport(efl.Libs.CustomExports)]
    internal static extern IntPtr type_short();
    [DllImport(efl.Libs.CustomExports)]
    internal static extern IntPtr type_ushort();

    // 32 bits ints
    [DllImport(efl.Libs.CustomExports)]
    internal static extern IntPtr type_int32();
    [DllImport(efl.Libs.CustomExports)]
    internal static extern IntPtr type_uint32();

    // 64 bit longs
    [DllImport(efl.Libs.CustomExports)]
    internal static extern IntPtr type_long();
    [DllImport(efl.Libs.CustomExports)]
    internal static extern IntPtr type_ulong();

    // In C# long and int 64 are synonyms, but in Eina Value they are separate types.
    [DllImport(efl.Libs.CustomExports)]
    internal static extern IntPtr type_int64();
    [DllImport(efl.Libs.CustomExports)]
    internal static extern IntPtr type_uint64();

    // Floating point
    [DllImport(efl.Libs.CustomExports)]
    internal static extern IntPtr type_float();
    [DllImport(efl.Libs.CustomExports)]
    internal static extern IntPtr type_double();

    [DllImport(efl.Libs.CustomExports)]
    internal static extern IntPtr type_string();

    // Collections
    [DllImport(efl.Libs.CustomExports)]
    internal static extern IntPtr type_array();
    [DllImport(efl.Libs.CustomExports)]
    internal static extern IntPtr type_list();
    [DllImport(efl.Libs.CustomExports)]
    internal static extern IntPtr type_hash();

    // Optional
    [DllImport(efl.Libs.CustomExports)]
    internal static extern IntPtr type_optional();

    // Error
    [DllImport(efl.Libs.CustomExports)]
    internal static extern IntPtr type_error();

    // Error
    [DllImport(efl.Libs.CustomExports)]
    internal static extern IntPtr type_object();
}
}

/// <summary>Struct for passing Values by value to Unmanaged functions.
///
/// <para>Used internally by the marshalling code.</para>
///
/// <para>Since EFL 1.23.</para>
/// </summary>
[StructLayout(LayoutKind.Sequential)]
[EditorBrowsable(EditorBrowsableState.Never)]
public struct ValueNative
{
    public IntPtr Type;
    public IntPtr Value; // Actually an Eina_Value_Union, but it is padded to 8 bytes.

    public override string ToString()
    {
        return $"ValueNative<Type:0x{Type.ToInt64():x}, Value:0x{Value.ToInt64():x}>";
    }
}

/// <summary>Exception for failures when setting an container item.
///
/// <para>Since EFL 1.23.</para>
/// </summary>
[Serializable]
public class SetItemFailedException : Exception
{
    /// <summary>
    /// Default constructor.
    ///
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    public SetItemFailedException() : base()
    {
    }

    /// <summary>
    /// Most commonly used contructor. Allows setting a custom message.
    ///
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <param name="msg">The message of the exception.</param>
    public SetItemFailedException(string msg) : base(msg)
    {
    }

    /// <summary>
    /// Wraps an inner exception.
    ///
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <param name="msg">The message of the exception.</param>
    /// <param name="inner">The exception to be wrapped.</param>
    public SetItemFailedException(string msg, Exception inner) : base(msg, inner)
    {
    }

    /// <summary>
    /// Serializable constructor.
    ///
    /// <para>Since EFL 1.23.</para>
    /// <param name="info">Serialized object data about the exception.</param>
    /// <param name="context">Contextual information about the source or destination.</param>
    /// </summary>
    protected SetItemFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}

/// <summary>Exception for methods that must have been called on a container.
///
/// <para>Since EFL 1.23.</para>
/// </summary>
[Serializable]
public class InvalidValueTypeException: Exception
{
    /// <summary>
    /// Default constructor.
    ///
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    public InvalidValueTypeException() : base()
    {
    }

    /// <summary>
    /// Most commonly used contructor. Allows setting a custom message.
    ///
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <param name="msg">The message of the exception.</param>
    public InvalidValueTypeException(string msg) : base(msg)
    {
    }

    /// <summary>
    /// Wraps an inner exception.
    ///
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <param name="msg">The message of the exception.</param>
    /// <param name="inner">The exception to be wrapped.</param>
    public InvalidValueTypeException(string msg, Exception inner) : base(msg, inner)
    {
    }

    /// <summary>
    /// Serializable constructor.
    ///
    /// <para>Since EFL 1.23.</para>
    /// <param name="info">Serialized object data about the exception.</param>
    /// <param name="context">Contextual information about the source or destination.</param>
    /// </summary>
    protected InvalidValueTypeException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}


/// <summary>Managed-side Enum to represent Eina_Value_Type constants.
///
/// <para>Since EFL 1.23.</para>
/// </summary>
public enum ValueType
{
    /// <summary>Signed 8 bit integer. Same as 'sbyte'.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    SByte,
    /// <summary>Unsigned 8 bit integer. Same as 'byte'.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    Byte,
    /// <summary>Signed 16 bit integer. Same as 'short'.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    Short,
    /// <summary>Unsigned 16 bit integer. Same as 'ushort'.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    UShort,
    /// <summary>Signed 32 bit integer. Same as 'int'.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    Int32,
    /// <summary>Unsigned 32 bit integer. Same as 'uint'.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    UInt32,
    /// <summary>Signed long integer. Same as 'long'.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    Long,
    /// <summary>Unsigned long integer. Same as 'ulong'.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    ULong,
    /// <summary>Signed 64 bit integer. Same as 'long'.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    Int64,
    /// <summary>Unsigned 64 bit integer. Same as 'ulong'.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    UInt64,
    /// <summary>4-byte float. Same as 'float'.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    Float,
    /// <summary>8-byte double. Same as 'double'.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    Double,
    /// <summary>Strings.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    String,
    /// <summary>Array of Value items.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    Array,
    /// <summary>Linked list of Value items.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    List,
    /// <summary>Map of string keys to Value items.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    Hash,
    /// <summary>Optional (aka empty) values.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    Optional,
    /// <summary>Error values.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    Error,
    /// <summary>Eo Object values.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    Object,
    /// <summary>Empty values.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    Empty,
}

/// <summary>Extension methods for <see cref="Eina.ValueType" />.
///
/// <para>Since EFL 1.23.</para>
/// </summary>
static class ValueTypeMethods
{
    /// <summary>Checks if this type is a numeric value.
    ///
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <returns>Whether this type is a numeric one.</returns>
    public static bool IsNumeric(this ValueType val)
    {
        switch (val)
        {
            case ValueType.SByte:
            case ValueType.Byte:
            case ValueType.Short:
            case ValueType.UShort:
            case ValueType.Int32:
            case ValueType.UInt32:
            case ValueType.Long:
            case ValueType.ULong:
            case ValueType.Int64:
            case ValueType.UInt64:
            case ValueType.Float:
            case ValueType.Double:
                return true;
            default:
                return false;
        }
    }

    /// <summary>Checks if this type is a string value.
    ///
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <returns>Whether this type is a string.</returns>
    public static bool IsString(this ValueType val)
    {
        switch (val)
        {
            case ValueType.String:
                return true;
            default:
                return false;
        }
    }

    /// <summary>Checks if this type is a container value.
    ///
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <returns>Whether this type is a container.</returns>
    public static bool IsContainer(this ValueType val)
    {
        switch (val)
        {
            case ValueType.Array:
            case ValueType.List:
            case ValueType.Hash:
                return true;
            default:
                return false;
        }
    }

    /// <summary>Checks if this type is optional. (i.e. can be empty).
    ///
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <returns>Whether this type is optional.</returns>
    public static bool IsOptional(this ValueType val)
    {
        return val == ValueType.Optional;
    }

    /// <summary>Checks if this type represents an error value.
    ///
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <returns>Whether this type is a error one.</returns>
    public static bool IsError(this ValueType val)
    {
        return val == ValueType.Error;
    }

    /// <summary>Checks if this type is an <see cref="Efl.Object" />.
    ///
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <returns>Whether this type is an <see cref="Efl.Object" />.</returns>
    public static bool IsObject(this ValueType val)
    {
        return val == ValueType.Object;
    }

    /// <summary>Returns the Marshal.SizeOf for the given ValueType native structure.
    ///
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static int MarshalSizeOf(this ValueType val)
    {
        switch (val)
        {
            case ValueType.Array:
                return Marshal.SizeOf(typeof(EinaNative.Value_Array));
            case ValueType.List:
                return Marshal.SizeOf(typeof(EinaNative.Value_List));
            default:
                return 0;
        }
    }
}

/// <summary>Boxing class for custom marshalling of ValueType enums.
///
/// <para>As custom marshalling of enums (and other value types) is not supported, use
/// use this boxing class as an intermediate at the Marshalling API level (like in
/// marshall_type_impl.hh in the generator). User-facing API still uses Eina.ValueType
/// normally.</para>
///
/// Since EFL 1.23.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
public class ValueTypeBox
{
    public ValueType _payload;

    public ValueTypeBox(ValueType v)
    {
        _payload = v;
    }

    public static implicit operator ValueTypeBox(ValueType v)
    {
        return new ValueTypeBox(v);
    }

    public static implicit operator ValueType(ValueTypeBox box)
    {
        if (box == null)
        {
            return Eina.ValueType.Empty;
        }

        return box._payload;
    }
}

internal static class ValueTypeBridge
{
    private static Dictionary<ValueType, IntPtr> ManagedToNative = new Dictionary<ValueType, IntPtr>();
    private static Dictionary<IntPtr, ValueType> NativeToManaged = new Dictionary<IntPtr, ValueType>();
    private static Dictionary<System.Type, ValueType> StandardToManaged = new Dictionary<System.Type, ValueType>();
    private static Dictionary<ValueType, System.Type> ManagedToStandard = new Dictionary<ValueType, System.Type>();
    private static bool TypesLoaded; // CLR defaults to false;

    public static ValueType GetManaged(IntPtr native)
    {
        if (!TypesLoaded)
        {
            LoadTypes();
        }

        try
        {
            return NativeToManaged[native];
        }
        catch (KeyNotFoundException)
        {
            var name_ptr = eina_value_type_name_get(native);
            var name = Marshal.PtrToStringAnsi(name_ptr);
            throw new Efl.EflException($"Unknown native eina value Type: 0x{native.ToInt64():x} with name {name}");
        }
    }

    public static IntPtr GetNative(ValueType valueType)
    {
        if (!TypesLoaded)
        {
            LoadTypes();
        }

        return ManagedToNative[valueType];
    }

    /// <summary>Returns the Eina.Value type associated with the given C# type.</summary>
    public static ValueType GetManaged(System.Type type)
    {
        ValueType v;
        if (StandardToManaged.TryGetValue(type, out v))
        {
            return v;
        }
        else
        {
            if (typeof(Efl.Object).IsAssignableFrom(type))
            {
                return ValueType.Object;
            }
            throw new Efl.EflException($"Unknown value type mapping for C# type {type}");
        }
    }

    /// <summary>Returns the System.Type associated with the given Eina.Value type.</summary>
    /// <param name="valueType">The intermediate type as returned by <see cref="Eina.Value.GetValueType()" />.</param>
    /// <returns>The associated C# type with this value type.</returns>
    public static System.Type GetStandard(ValueType valueType)
    {
        System.Type ret = null;
        if (ManagedToStandard.TryGetValue(valueType, out ret))
        {
            return ret;
        }
        else
        {
            throw new Efl.EflException($"Unknown C# type mapping for value type {valueType}");
        }
    }

    private static void LoadTypes()
    {
        Eina.Config.Init(); // Make sure eina is initialized.

        ManagedToNative.Add(ValueType.SByte, type_sbyte());
        NativeToManaged.Add(type_sbyte(), ValueType.SByte);
        StandardToManaged.Add(typeof(sbyte), ValueType.SByte);
        ManagedToStandard.Add(ValueType.SByte, typeof(sbyte));

        ManagedToNative.Add(ValueType.Byte, type_byte());
        NativeToManaged.Add(type_byte(), ValueType.Byte);
        StandardToManaged.Add(typeof(byte), ValueType.Byte);
        ManagedToStandard.Add(ValueType.Byte, typeof(byte));

        ManagedToNative.Add(ValueType.Short, type_short());
        NativeToManaged.Add(type_short(), ValueType.Short);
        StandardToManaged.Add(typeof(short), ValueType.Short);
        ManagedToStandard.Add(ValueType.Short, typeof(short));

        ManagedToNative.Add(ValueType.UShort, type_ushort());
        NativeToManaged.Add(type_ushort(), ValueType.UShort);
        StandardToManaged.Add(typeof(ushort), ValueType.UShort);
        ManagedToStandard.Add(ValueType.UShort, typeof(ushort));

        ManagedToNative.Add(ValueType.Int32, type_int32());
        NativeToManaged.Add(type_int32(), ValueType.Int32);
        StandardToManaged.Add(typeof(int), ValueType.Int32);
        ManagedToStandard.Add(ValueType.Int32, typeof(int));

        ManagedToNative.Add(ValueType.UInt32, type_uint32());
        NativeToManaged.Add(type_uint32(), ValueType.UInt32);
        StandardToManaged.Add(typeof(uint), ValueType.UInt32);
        ManagedToStandard.Add(ValueType.UInt32, typeof(uint));

        ManagedToNative.Add(ValueType.Long, type_long());
        NativeToManaged.Add(type_long(), ValueType.Long);
        ManagedToStandard.Add(ValueType.Long, typeof(long));

        ManagedToNative.Add(ValueType.ULong, type_ulong());
        NativeToManaged.Add(type_ulong(), ValueType.ULong);
        ManagedToStandard.Add(ValueType.ULong, typeof(ulong));

        ManagedToNative.Add(ValueType.Int64, type_int64());
        NativeToManaged.Add(type_int64(), ValueType.Int64);
        StandardToManaged.Add(typeof(long), ValueType.Int64);
        ManagedToStandard.Add(ValueType.Int64, typeof(long));

        ManagedToNative.Add(ValueType.UInt64, type_uint64());
        NativeToManaged.Add(type_uint64(), ValueType.UInt64);
        StandardToManaged.Add(typeof(ulong), ValueType.UInt64);
        ManagedToStandard.Add(ValueType.UInt64, typeof(ulong));

        ManagedToNative.Add(ValueType.Float, type_float());
        NativeToManaged.Add(type_float(), ValueType.Float);
        StandardToManaged.Add(typeof(float), ValueType.Float);
        ManagedToStandard.Add(ValueType.Float, typeof(float));

        ManagedToNative.Add(ValueType.Double, type_double());
        NativeToManaged.Add(type_double(), ValueType.Double);
        StandardToManaged.Add(typeof(double), ValueType.Double);
        ManagedToStandard.Add(ValueType.Double, typeof(double));

        ManagedToNative.Add(ValueType.String, type_string());
        NativeToManaged.Add(type_string(), ValueType.String);
        StandardToManaged.Add(typeof(string), ValueType.String);
        ManagedToStandard.Add(ValueType.String, typeof(string));

        ManagedToNative.Add(ValueType.Array, type_array());
        NativeToManaged.Add(type_array(), ValueType.Array);

        ManagedToNative.Add(ValueType.List, type_list());
        NativeToManaged.Add(type_list(), ValueType.List);

        ManagedToNative.Add(ValueType.Hash, type_hash());
        NativeToManaged.Add(type_hash(), ValueType.Hash);

        ManagedToNative.Add(ValueType.Optional, type_optional());
        NativeToManaged.Add(type_optional(), ValueType.Optional);

        ManagedToNative.Add(ValueType.Error, type_error());
        NativeToManaged.Add(type_error(), ValueType.Error);
        StandardToManaged.Add(typeof(Eina.Error), ValueType.Error);
        ManagedToStandard.Add(ValueType.Error, typeof(Eina.Error));

        ManagedToNative.Add(ValueType.Object, type_object());
        NativeToManaged.Add(type_object(), ValueType.Object);
        // We don't use `typeof(Efl.Object)` directly in the StandartToManaged dictionary as typeof(myobj) may
        // return a different type. For ManagedToStandard, we make use of C# generics covariance to create
        // an collection of Efl.Objects when unwrapping.
        ManagedToStandard.Add(ValueType.Object, typeof(Efl.Object));

        ManagedToNative.Add(ValueType.Empty, IntPtr.Zero);
        NativeToManaged.Add(IntPtr.Zero, ValueType.Empty);

        TypesLoaded = true;
    }
}

/// <summary>Wrapper around Eina.Value generic storage.
///
/// <para>Eina.Value is EFL's main workhorse to deal with storing generic data in
/// a uniform way.</para>
///
/// <para>It comes with predefined types for numbers, strings, arrays, lists, hashes,
/// blobs and structs. It is able to convert between data types, including
/// to and from strings.</para>
///
/// <para>Since EFL 1.23.</para>
/// </summary>
public class Value : IDisposable, IComparable<Value>, IEquatable<Value>
{

    // Unmanaged type - Managed type mapping
    // Ok EINA_VALUE_TYPE_UCHAR: unsigned char -- byte
    // Ok EINA_VALUE_TYPE_USHORT: unsigned short -- ushort
    // Ok EINA_VALUE_TYPE_UINT: unsigned int -- uint
    // Ok EINA_VALUE_TYPE_ULONG: unsigned long -- ulong
    // Ok EINA_VALUE_TYPE_UINT64: uint64_t -- ulong
    // Ok EINA_VALUE_TYPE_CHAR: char -- sbyte
    // Ok EINA_VALUE_TYPE_SHORT: short -- short
    // Ok EINA_VALUE_TYPE_INT: int -- int
    // Ok EINA_VALUE_TYPE_LONG: long -- long
    // OK EINA_VALUE_TYPE_INT64: int64_t -- long
    // Ok EINA_VALUE_TYPE_FLOAT: float -- float
    // Ok EINA_VALUE_TYPE_DOUBLE: double -- double
    // EINA_VALUE_TYPE_STRINGSHARE: const char * -- string
    // Ok EINA_VALUE_TYPE_STRING: const char * -- string
    // Ok EINA_VALUE_TYPE_ARRAY: Eina_Value_Array -- Eina.Array?
    // Ok EINA_VALUE_TYPE_LIST: Eina_Value_List -- Eina.List?
    // EINA_VALUE_TYPE_HASH: Eina_Value_Hash -- Eina.Hash?
    // EINA_VALUE_TYPE_TIMEVAL: struct timeval -- FIXME
    // EINA_VALUE_TYPE_BLOB: Eina_Value_Blob -- FIXME
    // EINA_VALUE_TYPE_STRUCT: Eina_Value_Struct -- FIXME


    internal IntPtr Handle { get; set;}

    /// <summary> Whether this wrapper owns (can free) the native value.
    ///
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <value>The kind of ownership of this wrapper.</value>
    public Ownership Ownership { get; protected set;}

    private bool Disposed;

    /// <summary> Whether this is an Optional value (meaning it can have a value or not).
    ///
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <value>True if this value may contain no value.</value>
    public bool Optional
    {
        get
        {
            return GetValueType() == Eina.ValueType.Optional;
        }

        /* protected set {
            // Should we expose this?
            // Something like {
            //    flush(handle)/free(handle)
            //    handle = eina_value_optional_empty_new()
            // }
         } */
    }

    /// <summary> Whether this wrapper is actually empty/uninitialized (zeroed).
    ///
    /// <para>This is different from an <see cref="Eina.ValueType.Optional" /> value. An
    /// <c>Optional</c> value is an initialized value that may or may not hold a value,
    /// while an <see cref="Eina.ValueType.Empty" /> value is an uninitialized value and it
    /// should be initialized (e.g. with <see cref="Eina.Value.Setup(Eina.ValueType)" />)
    /// with a non-empty value to actually store/retrieve values.</para>
    ///
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <value><c>true</c> if this value is unintialized.</value>
    public bool Empty
    {
        get
        {
            SanityChecks();
            return GetValueType() == Eina.ValueType.Empty;
        }
    }

    /// <summary> Whether this optional value is empty.
    ///
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <value><c>true</c> if this optional value is empty.</value>
    public bool OptionalEmpty
    {
        get
        {
            OptionalSanityChecks();
            bool empty;
            if (!eina_value_optional_empty_is_wrapper(this.Handle, out empty))
            {
                throw new System.InvalidOperationException("Couldn't get the empty information");
            }
            else
            {
                return empty;
            }
        }
    }

    private static IntPtr Alloc()
    {
        return eina_value_new(type_int32());
    }

    private static void Free(IntPtr ptr)
    {
        eina_value_free(ptr);
    }

    // Constructor to be used by the "FromContainerDesc" methods.
    private Value()
    {
        this.Handle = Alloc();

        if (this.Handle == IntPtr.Zero)
        {
            throw new OutOfMemoryException("Failed to allocate memory for Eina.Value");
        }

        this.Ownership = Ownership.Managed;
        MemoryNative.Memset(this.Handle, 0, eina_value_sizeof());
    }

    /// <summary>Creates a new Value from the given C# value.
    ///
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <param name="obj">The object to be wrapped.</param>
    public Value(object obj) : this()
    {
        var objType = obj.GetType();

        if (objType == typeof(sbyte))
        {
            Setup(ValueType.SByte);
            Set((sbyte)obj);
        }
        else if (objType == typeof(byte))
        {
            Setup(ValueType.Byte);
            Set((byte)obj);
        }
        else if (objType == typeof(short))
        {
            Setup(ValueType.Short);
            Set((short)obj);
        }
        else if (objType == typeof(ushort))
        {
            Setup(ValueType.UShort);
            Set((ushort)obj);
        }
        else if (objType == typeof(int))
        {
            Setup(ValueType.Int32);
            Set((int)obj);
        }
        else if (objType == typeof(uint))
        {
            Setup(ValueType.UInt32);
            Set((uint)obj);
        }
        else if (objType == typeof(long))
        {
            Setup(ValueType.Int64);
            Set((long)obj);
        }
        else if (objType == typeof(ulong))
        {
            Setup(ValueType.UInt64);
            Set((ulong)obj);
        }
        else if (objType == typeof(float))
        {
            Setup(ValueType.Float);
            Set((float)obj);
        }
        else if (objType == typeof(double))
        {
            Setup(ValueType.Double);
            Set((double)obj);
        }
        else if (objType == typeof(string))
        {
            Setup(ValueType.String);
            Set(obj as string);
        }
        else if (typeof(Efl.Object).IsAssignableFrom(objType))
        {
            Setup(ValueType.Object);
            Set(obj as Efl.Object);
        }
        else
        {
            // Container type conversion is supported only from IEnumerable<T>
            if (!obj.GetType().GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IEnumerable<>)))
            {
                throw new ArgumentException($"Unsupported type for direct construction: {objType}");
            }

            Type[] genericArguments = objType.GetGenericArguments();
            if (genericArguments.Length != 1)
            {
                throw new ArgumentException($"Unsupported type for direct construction: {objType}");
            }

            var genericArg = genericArguments[0];

            var argValueType = ValueTypeBridge.GetManaged(genericArg);

            Setup(ValueType.Array, argValueType);

            foreach (var item in obj as System.Collections.IEnumerable)
            {
                Append(item);
            }

        }
    }

    /// <summary>Creates a new Value from the given native pointer.
    ///
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Value(IntPtr handle, Ownership ownership = Ownership.Managed)
    {
        this.Handle = handle;
        this.Ownership = ownership;
    }

    /// <summary>Creates a new value storage for values of type <c>type</c>.
    ///
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <param name="type">The type of the value that will be stored.</param>
    public Value(ValueType type)
    {
        if (type.IsContainer())
        {
            throw new ArgumentException("To use container types you must provide a subtype");
        }

        this.Handle = Alloc();
        if (this.Handle == IntPtr.Zero)
        {
            throw new OutOfMemoryException("Failed to allocate memory for Eina.Value");
        }

        // Initialize to EINA_VALUE_EMPTY before performing any other operation on this value.
        MemoryNative.Memset(this.Handle, 0, eina_value_sizeof());

        this.Ownership = Ownership.Managed;
        Setup(type);
    }

    /// <summary>Constructor for container values, like Array, Hash. It also requires an extra parameter
    /// with the type of the contained items.
    ///
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <param name="containerType">The type of the container to store values.</param>
    /// <param name="subtype">The type of the values contained.</param>
    /// <param name="step">Amount to increase the capacity of the container by when it needs to grow.</param>
    public Value(ValueType containerType, ValueType subtype, uint step = 0)
    {
        if (!containerType.IsContainer())
        {
            throw new ArgumentException("First type must be a container type.");
        }

        this.Handle = Alloc();
        this.Ownership = Ownership.Managed;

        Setup(containerType, subtype, step);
    }

    /// <summary>Deep copies the given eina Value.
    ///
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <param name="v">The value to be copied.</param>
    public Value(Value v)
    {
        Handle = Alloc();
        if (!eina_value_copy(v.Handle, this.Handle))
        {
            throw new System.InvalidOperationException("Failed to copy value to managed memory.");
        }

        Disposed = false;
        Ownership = Ownership.Managed;
    }

    /// <summary>Constructor to build value from Values_Natives passed by value from C.</summary>
    internal Value(ValueNative value)
    {
        IntPtr tmp = IntPtr.Zero;
        try
        {
            this.Handle = Alloc();
            if (value.Type == IntPtr.Zero) // Got an EINA_VALUE_EMPTY by value.
            {
                MemoryNative.Memset(this.Handle, 0, Marshal.SizeOf(typeof(ValueNative)));
            }
            else
            {
                // We allocate this intermediate ValueNative using malloc to allow freeing with
                // free(), avoiding a call to eina_value_flush that would wipe the underlying value contents
                // for pointer types like string.
                tmp = MemoryNative.Alloc(Marshal.SizeOf(typeof(ValueNative)));
                Marshal.StructureToPtr<ValueNative>(value, tmp, false); // Can't get the address of a struct directly.

                // Copy is used to deep copy the pointed payload (e.g. strings) inside this struct, so we can own this value.
                if (!eina_value_copy(tmp, this.Handle))
                {
                    throw new System.InvalidOperationException("Failed to copy value to managed memory.");
                }
            }
        }
        catch
        {
            Free(this.Handle);
            throw;
        }
        finally
        {
            if (tmp != IntPtr.Zero)
            {
                MemoryNative.Free(tmp);
            }
        }

        this.Ownership = Ownership.Managed;
    }

    /// <summary>Type-specific constructor, for convenience.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <param name="x">The value to be wrapped.</param>
    public Value(byte x) : this(ValueType.Byte)
    {
        if (!Set(x))
        {
            throw new InvalidOperationException("Couldn't set value.");
        }
    }

    /// <summary>Type-specific constructor, for convenience.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <param name="x">The value to be wrapped.</param>
    public Value(sbyte x) : this(ValueType.SByte)
    {
        if (!Set(x))
        {
            throw new InvalidOperationException("Couldn't set value.");
        }
    }

    /// <summary>Type-specific constructor, for convenience.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <param name="x">The value to be wrapped.</param>
    public Value(short x) : this(ValueType.Short)
    {
        if (!Set(x))
        {
            throw new InvalidOperationException("Couldn't set value.");
        }
    }

    /// <summary>Type-specific constructor, for convenience.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <param name="x">The value to be wrapped.</param>
    public Value(ushort x) : this(ValueType.UShort)
    {
        if (!Set(x))
        {
            throw new InvalidOperationException("Couldn't set value.");
        }
    }

    /// <summary>Type-specific constructor, for convenience.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <param name="x">The value to be wrapped.</param>
    public Value(int x) : this(ValueType.Int32)
    {
        if (!Set(x))
        {
            throw new InvalidOperationException("Couldn't set value.");
        }
    }

    /// <summary>Type-specific constructor, for convenience.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <param name="x">The value to be wrapped.</param>
    public Value(uint x) : this(ValueType.UInt32)
    {
        if (!Set(x))
        {
            throw new InvalidOperationException("Couldn't set value.");
        }
    }

    /// <summary>Type-specific constructor, for convenience.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <param name="x">The value to be wrapped.</param>
    public Value(long x) : this(ValueType.Long)
    {
        if (!Set(x))
        {
            throw new InvalidOperationException("Couldn't set value.");
        }
    }

    /// <summary>Type-specific constructor, for convenience.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <param name="x">The value to be wrapped.</param>
    public Value(ulong x) : this(ValueType.ULong)
    {
        if (!Set(x))
        {
            throw new InvalidOperationException("Couldn't set value.");
        }
    }

    /// <summary>Type-specific constructor, for convenience.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <param name="x">The value to be wrapped.</param>
    public Value(float x) : this(ValueType.Float)
    {
        if (!Set(x))
        {
            throw new InvalidOperationException("Couldn't set value.");
        }
    }

    /// <summary>Type-specific constructor, for convenience.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <param name="x">The value to be wrapped.</param>
    public Value(double x) : this(ValueType.Double)
    {
        if (!Set(x))
        {
            throw new InvalidOperationException("Couldn't set value.");
        }
    }

    /// <summary>Type-specific constructor, for convenience.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <param name="x">The value to be wrapped.</param>
    public Value(string x) : this(ValueType.String)
    {
        if (!Set(x))
        {
            throw new InvalidOperationException("Couldn't set value.");
        }
    }

    /// <summary>Implicit conversion from managed value to native struct representation.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static implicit operator ValueNative(Value v)
    {
        return v.GetNative();
    }

    /// <summary>Implicit conversion from native struct representation to managed wrapper.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static implicit operator Value(ValueNative v)
    {
        return new Value(v);
    }

    /// <summary>Implicit conversion.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    public static implicit operator Value(byte x)
    {
        var v = new Eina.Value(ValueType.Byte);
        v.Set(x);

        return v;
    }

    /// <summary>Implicit conversion.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    public static implicit operator byte(Value v)
    {
        byte b;
        v.Get(out b);

        return b;
    }

    /// <summary>Implicit conversion.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    public static implicit operator Value(sbyte x)
    {
        var v = new Eina.Value(ValueType.SByte);
        v.Set(x);

        return v;
    }

    /// <summary>Implicit conversion.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    public static implicit operator sbyte(Value v)
    {
        sbyte b;
        v.Get(out b);

        return b;
    }

    /// <summary>Implicit conversion.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    public static implicit operator Value(short x)
    {
        var v = new Eina.Value(ValueType.Short);
        v.Set(x);

        return v;
    }

    /// <summary>Implicit conversion.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    public static implicit operator short(Value v)
    {
        short b;
        v.Get(out b);

        return b;
    }

    /// <summary>Implicit conversion.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    public static implicit operator Value(ushort x)
    {
        var v = new Eina.Value(ValueType.UShort);
        v.Set(x);

        return v;
    }

    /// <summary>Implicit conversion.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    public static implicit operator ushort(Value v)
    {
        ushort b;
        v.Get(out b);

        return b;
    }

    /// <summary>Implicit conversion.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    public static implicit operator Value(int x)
    {
        var v = new Eina.Value(ValueType.Int32);
        v.Set(x);

        return v;
    }

    /// <summary>Implicit conversion.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    public static implicit operator int(Value v)
    {
        int b;
        v.Get(out b);

        return b;
    }

    /// <summary>Implicit conversion.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    public static implicit operator Value(uint x)
    {
        var v = new Eina.Value(ValueType.UInt32);
        v.Set(x);

        return v;
    }

    /// <summary>Implicit conversion.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    public static implicit operator uint(Value v)
    {
        uint b;
        v.Get(out b);

        return b;
    }

    /// <summary>Implicit conversion.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    public static implicit operator Value(long x)
    {
        var v = new Eina.Value(ValueType.Long);
        v.Set(x);

        return v;
    }

    /// <summary>Implicit conversion.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    public static implicit operator long(Value v)
    {
        long b;
        v.Get(out b);

        return b;
    }

    /// <summary>Implicit conversion.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    public static implicit operator Value(ulong x)
    {
        var v = new Eina.Value(ValueType.ULong);
        v.Set(x);

        return v;
    }

    /// <summary>Implicit conversion.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    public static implicit operator ulong(Value v)
    {
        ulong b;
        v.Get(out b);

        return b;
    }

    /// <summary>Implicit conversion.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    public static implicit operator Value(float x)
    {
        var v = new Eina.Value(ValueType.Float);
        v.Set(x);

        return v;
    }

    /// <summary>Implicit conversion.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    public static implicit operator float(Value v)
    {
        float b;
        v.Get(out b);

        return b;
    }

    /// <summary>Implicit conversion.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    public static implicit operator Value(double x)
    {
        var v = new Eina.Value(ValueType.Double);
        v.Set(x);

        return v;
    }

    /// <summary>Implicit conversion.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    public static implicit operator double(Value v)
    {
        double b;
        v.Get(out b);

        return b;
    }

    /// <summary>Implicit conversion.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    public static implicit operator Value(string x)
    {
        var v = new Eina.Value(ValueType.String);
        v.Set(x);

        return v;
    }

    /// <summary>Implicit conversion.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    public static implicit operator string(Value v)
    {
        string b;
        v.Get(out b);

        return b;
    }

    /// <summary>Unwrap the value into its underlying C# value.
    ///
    /// <para>Useful for methods like <see crev="PropertyInfo.SetValue(object, object)" />
    /// as it will unpack the value to it correct C# type.</para>
    ///
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <returns>The managed value wrapped by this value.</returns>
    public object Unwrap()
    {
        switch (GetValueType())
        {
            case ValueType.SByte:
                {
                    sbyte o;
                    Get(out o);
                    return o;
                }
            case ValueType.Byte:
                {
                    byte o;
                    Get(out o);
                    return o;
                }
            case ValueType.Short:
                {
                    short o;
                    Get(out o);
                    return o;
                }
            case ValueType.UShort:
                {
                    ushort o;
                    Get(out o);
                    return o;
                }
            case ValueType.Int32:
                {
                    int o;
                    Get(out o);
                    return o;
                }
            case ValueType.UInt32:
                {
                    uint o;
                    Get(out o);
                    return o;
                }
            case ValueType.Int64:
            case ValueType.Long:
                {
                    long o;
                    Get(out o);
                    return o;
                }
            case ValueType.UInt64:
            case ValueType.ULong:
                {
                    ulong o;
                    Get(out o);
                    return o;
                }
            case ValueType.Float:
                {
                    float o;
                    Get(out o);
                    return o;
                }
            case ValueType.Double:
                {
                    double o;
                    Get(out o);
                    return o;
                }
            case ValueType.String:
                {
                    string o;
                    Get(out o);
                    return o;
                }
            case ValueType.Object:
                {
                    Efl.Object o;
                    Get(out o);
                    return o;
                }
            case ValueType.Array:
            case ValueType.List:
                {
                    // Eina Array and Lists will be unwrapped into a System.Collections.Generic.List<T>
                    // usually to be handled as IEnumerable<T> through LINQ.
                    var genericType = ValueTypeBridge.GetStandard(GetValueSubType());
                    Type[] typeArgs = { genericType };
                    var containerType = typeof(System.Collections.Generic.List<>);
                    var retType = containerType.MakeGenericType(typeArgs);
                    object ret = Activator.CreateInstance(retType);

                    var addMeth = retType.GetMethod("Add");

                    if (addMeth == null)
                    {
                        throw new InvalidOperationException("Failed to get Add() method of container to wrap value");
                    }

                    for (int i = 0; i < Count(); i++)
                    {
                        object[] args = new object[]{ this[i] };
                        addMeth.Invoke(ret, args);
                    }

                    return ret;
                }
            default:
                throw new InvalidOperationException($"Unsupported value type to unwrap: {GetValueType()}");
        }
    }

    // Efl.Object conversions are made explicit to avoid ambiguity between
    // Set(Efl.Object) and Set(Value) when dealing with classes derived from
    // Efl.Object.
    /// <summary>Explicit conversion from EFL objects.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    public static explicit operator Value(Efl.Object obj)
    {
        var v = new Eina.Value(ValueType.Object);
        v.Set(obj);
        return v;
    }

    /// <summary>Explicit conversion from Value to Efl.Objects.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    public static explicit operator Efl.Object(Value v)
    {
        Efl.Object obj;
        v.Get(out obj);

        return obj;
    }

    /// <summary>Creates an Value instance from a given array description.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    private static Value FromArrayDesc(Eina.EinaNative.Value_Array arrayDesc)
    {
        Value value = new Value();
        value.Setup(ValueType.Array, ValueType.String); // Placeholder values to be overwritten by the following pset call.

        eina_value_pset_wrapper(value.Handle, ref arrayDesc);
        return value;
    }

    /// <summary>Creates an Value instance from a given array description.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    private static Value FromListDesc(Eina.EinaNative.Value_List listDesc)
    {
        Value value = new Value();
        value.Setup(ValueType.List, ValueType.String); // Placeholder values to be overwritten by the following pset call.

        eina_value_pset_wrapper(value.Handle, ref listDesc);
        return value;
    }

    /// <summary>Releases the ownership of the underlying value to C.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    public void ReleaseOwnership()
    {
        this.Ownership = Ownership.Unmanaged;
    }

    /// <summary>Takes the ownership of the underlying value to the Managed runtime.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    public void TakeOwnership()
    {
        this.Ownership = Ownership.Managed;
    }

    /// <summary>Public method to explicitly free the wrapped eina value.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>Actually free the wrapped eina value. Can be called from Dispose() or through the Garbage Collector.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <param name="disposing"><c>true</c> if called from the method <see cref="Dispose()" />
    /// <c>false</c> if called from the Garbage Collector.</param>
    protected virtual void Dispose(bool disposing)
    {
        if (this.Ownership == Ownership.Unmanaged)
        {
            Disposed = true;
            return;
        }

        if (!Disposed && (Handle != IntPtr.Zero))
        {
            // No need to call flush as eina_value_free already calls it for us.
            if (disposing)
            {
                Free(this.Handle);
            }
            else
            {
                Efl.Eo.Globals.ThreadSafeFreeCbExec(eina_value_free, this.Handle);
            }
        }

        Disposed = true;
    }

    /// <summary>Finalizer to be called from the Garbage Collector.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    ~Value()
    {
        Dispose(false);
    }

    /// <summary>Returns the native handle wrapped by this object.</summary>
    /// <value>The native pointer wrapped by this object.</value>
    public IntPtr NativeHandle
    {
        get
        {
            if (Disposed)
            {
                throw new ObjectDisposedException($"Value at 0x{this.Handle.ToInt64():x}");
            }

            return this.Handle;
        }
    }

    /// <summary>Converts this storage to type 'type'.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <returns><c>true</c> if the configuration was successul.</returns>
    public bool Setup(ValueType type)
    {
        if (Disposed)
        {
            throw new ObjectDisposedException($"Value at 0x{this.Handle.ToInt64():x}");
        }

        // Can't call setup with Empty value type (would give an eina error)
        if (type == Eina.ValueType.Empty)
        {
            // Need to cleanup as it may point to payload outside the underlying Eina_Value (like arrays and strings).
            if (!Empty)
            {
                eina_value_flush_wrapper(this.Handle);
            }

            MemoryNative.Memset(this.Handle, 0, eina_value_sizeof());

            return true;
        }

        if (type.IsContainer())
        {
            throw new ArgumentException("To setup a container you must provide a subtype.");
        }

        return eina_value_setup_wrapper(this.Handle, ValueTypeBridge.GetNative(type));
    }

    /// <summary>Converts the storage type of this value to the container type <c>containerType</c>.
    ///
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <param name="containerType">The type of the container to store values.</param>
    /// <param name="subtype">The type of the values contained.</param>
    /// <param name="step">Amount to increase the capacity of the container by when it needs to grow.</param>
    /// <returns><c>true</c> if the configuration was successul.</returns>
    public bool Setup(ValueType containerType, ValueType subtype, uint step = 0)
    {
        IntPtr native_subtype = ValueTypeBridge.GetNative(subtype);
        bool ret = false;
        switch (containerType)
        {
            case ValueType.Array:
                ret = eina_value_array_setup_wrapper(this.Handle, native_subtype, step);
                break;
            case ValueType.List:
                ret = eina_value_list_setup_wrapper(this.Handle, native_subtype);
                break;
        }

        return ret;
    }

    private void SanityChecks()
    {
        if (Disposed)
        {
            throw new ObjectDisposedException($"Value at 0x{this.Handle.ToInt64():x}");
        }
    }

    private void ContainerSanityChecks(int targetIndex = -1)
    {
        SanityChecks();
        uint size = 0;
        ValueType type = GetValueType();

        if (!type.IsContainer())
        {
                throw new InvalidValueTypeException("Value type must be a container");
        }

        if (targetIndex == -1)  // Some methods (e.g. append) don't care about size
        {
            return;
        }

        switch (type)
        {
            case ValueType.Array:
                size = eina_value_array_count_wrapper(this.Handle);
                break;
            case ValueType.List:
                size = eina_value_list_count_wrapper(this.Handle);
                break;
        }

        if (targetIndex >= size)
        {
                throw new System.ArgumentOutOfRangeException(
                        $"Index {targetIndex} is larger than max array index {size-1}");
        }
    }

    private void OptionalSanityChecks()
    {
        SanityChecks();
        ValueType type = GetValueType();

        if (!type.IsOptional())
        {
            throw new InvalidValueTypeException("Value is not an Optional one");
        }
    }

    /// <summary>Get a ValueNative struct with the *value* pointed by this Eina.Value.</summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public ValueNative GetNative()
    {
        SanityChecks();
        ValueNative value = (ValueNative)Marshal.PtrToStructure(this.Handle, typeof(ValueNative));
        return value;
    }

    /// <summary>Sets the contained value.
    ///
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <param name="value">The value to be stored.</param>
    /// <returns><c>true</c> if the value was successfully stored.</returns>
    public bool Set(byte value)
    {
        SanityChecks();

        if (this.Optional)
        {
            return eina_value_optional_pset(this.Handle,
                                            ValueTypeBridge.GetNative(ValueType.Byte),
                                            ref value);
        }

        if (!GetValueType().IsNumeric())
        {
            throw (new ArgumentException(
                        "Trying to set numeric value on a non-numeric Eina.Value"));
        }

        return eina_value_set_wrapper_uchar(this.Handle, value);
    }

    /// <summary>Sets the contained value.
    ///
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <param name="value">The value to be stored.</param>
    /// <returns><c>true</c> if the value was successfully stored.</returns>
    public bool Set(sbyte value)
    {
        SanityChecks();

        if (this.Optional)
        {
            return eina_value_optional_pset(this.Handle,
                                            ValueTypeBridge.GetNative(ValueType.SByte),
                                            ref value);
        }

        if (!GetValueType().IsNumeric())
        {
            throw (new ArgumentException(
                        "Trying to set numeric value on a non-numeric Eina.Value"));
        }

        return eina_value_set_wrapper_char(this.Handle, value);
    }

    /// <summary>Sets the contained value.
    ///
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <param name="value">The value to be stored.</param>
    /// <returns><c>true</c> if the value was successfully stored.</returns>
    public bool Set(short value)
    {
        SanityChecks();

        if (this.Optional)
        {
            return eina_value_optional_pset(this.Handle,
                                            ValueTypeBridge.GetNative(ValueType.Short),
                                            ref value);
        }

        if (!GetValueType().IsNumeric())
        {
            throw (new ArgumentException(
                        "Trying to set numeric value on a non-numeric Eina.Value"));
        }

        return eina_value_set_wrapper_short(this.Handle, value);
    }

    /// <summary>Sets the contained value.
    ///
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <param name="value">The value to be stored.</param>
    /// <returns><c>true</c> if the value was successfully stored.</returns>
    public bool Set(ushort value)
    {
        SanityChecks();

        if (this.Optional)
        {
            return eina_value_optional_pset(this.Handle,
                                            ValueTypeBridge.GetNative(ValueType.UShort),
                                            ref value);
        }

        if (!GetValueType().IsNumeric())
        {
            throw (new ArgumentException(
                        "Trying to set numeric value on a non-numeric Eina.Value"));
        }

        return eina_value_set_wrapper_ushort(this.Handle, value);
    }

    /// <summary>Sets the contained value.
    ///
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <param name="value">The value to be stored.</param>
    /// <returns><c>true</c> if the value was successfully stored.</returns>
    public bool Set(uint value)
    {
        SanityChecks();

        if (this.Optional)
        {
            return eina_value_optional_pset(this.Handle,
                                            ValueTypeBridge.GetNative(ValueType.UInt32),
                                            ref value);
        }

        if (!GetValueType().IsNumeric())
        {
            throw (new ArgumentException(
                        "Trying to set numeric value on a non-numeric Eina.Value"));
        }

        return eina_value_set_wrapper_uint(this.Handle, value);
    }

    /// <summary>Sets the contained value.
    ///
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <param name="value">The value to be stored.</param>
    /// <returns><c>true</c> if the value was successfully stored.</returns>
    public bool Set(int value)
    {
        SanityChecks();

        if (this.Optional)
        {
            return eina_value_optional_pset(this.Handle,
                                            ValueTypeBridge.GetNative(ValueType.Int32),
                                            ref value);
        }

        if (!GetValueType().IsNumeric())
        {
            throw (new ArgumentException(
                        "Trying to set numeric value on a non-numeric Eina.Value"));
        }

        return eina_value_set_wrapper_int(this.Handle, value);
    }

    /// <summary>Sets the contained value.
    ///
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <param name="value">The value to be stored.</param>
    /// <returns><c>true</c> if the value was successfully stored.</returns>
    public bool Set(ulong value)
    {
        SanityChecks();

        if (this.Optional)
        {
            return eina_value_optional_pset(this.Handle,
                                            ValueTypeBridge.GetNative(ValueType.ULong),
                                            ref value);
        }

        if (!GetValueType().IsNumeric())
        {
            throw (new ArgumentException(
                        "Trying to set numeric value on a non-numeric Eina.Value"));
        }

        return eina_value_set_wrapper_ulong(this.Handle, value);
    }

    /// <summary>Sets the contained value.
    ///
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <param name="value">The value to be stored.</param>
    /// <returns><c>true</c> if the value was successfully stored.</returns>
    public bool Set(long value)
    {
        SanityChecks();

        if (this.Optional)
        {
            return eina_value_optional_pset(this.Handle,
                                            ValueTypeBridge.GetNative(ValueType.Long),
                                            ref value);
        }

        if (!GetValueType().IsNumeric())
        {
            throw (new ArgumentException(
                        "Trying to set numeric value on a non-numeric Eina.Value"));
        }

        return eina_value_set_wrapper_long(this.Handle, value);
    }

    /// <summary>Sets the contained value.
    ///
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <param name="value">The value to be stored.</param>
    /// <returns><c>true</c> if the value was successfully stored.</returns>
    public bool Set(float value)
    {
        SanityChecks();

        if (this.Optional)
        {
            return eina_value_optional_pset(this.Handle,
                                            ValueTypeBridge.GetNative(ValueType.Float),
                                            ref value);
        }

        if (!GetValueType().IsNumeric())
        {
            throw (new ArgumentException(
                        "Trying to set numeric value on a non-numeric Eina.Value"));
        }

        return eina_value_set_wrapper_float(this.Handle, value);
    }

    /// <summary>Sets the contained value.
    ///
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <param name="value">The value to be stored.</param>
    /// <returns><c>true</c> if the value was successfully stored.</returns>
    public bool Set(double value)
    {
        SanityChecks();

        if (this.Optional)
        {
            return eina_value_optional_pset(this.Handle,
                                            ValueTypeBridge.GetNative(ValueType.Double),
                                            ref value);
        }

        if (!GetValueType().IsNumeric())
        {
            throw (new ArgumentException(
                        "Trying to set numeric value on a non-numeric Eina.Value"));
        }

        return eina_value_set_wrapper_double(this.Handle, value);
    }

    /// <summary>Sets the contained value.
    ///
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <param name="value">The value to be stored.</param>
    /// <returns><c>true</c> if the value was successfully stored.</returns>
    public bool Set(string value)
    {
        SanityChecks();

        if (this.Optional)
        {
            return eina_value_optional_pset(this.Handle,
                                            ValueTypeBridge.GetNative(ValueType.String),
                                            ref value);
        }

        if (!GetValueType().IsString())
        {
            throw (new ArgumentException(
                        "Trying to set string value on a non-string Eina.Value"));
        }

        // No need to worry about ownership as eina_value_set will copy the passed string.
        return eina_value_set_wrapper_string(this.Handle, value);
    }

    /// <summary>Sets the contained value.
    ///
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <param name="value">The value to be stored.</param>
    /// <returns><c>true</c> if the value was successfully stored.</returns>
    public bool Set(Eina.Error value)
    {
        SanityChecks();

        int error_code = value;

        if (this.Optional)
        {
            return eina_value_optional_pset(this.Handle,
                                            ValueTypeBridge.GetNative(ValueType.Error),
                                            ref error_code);
        }

        return eina_value_set_wrapper_int(this.Handle, error_code);
    }

    /// <summary>Sets the contained value.
    ///
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <param name="value">The value to be stored.</param>
    /// <returns><c>true</c> if the value was successfully stored.</returns>
    public bool Set(Efl.Object value)
    {
        SanityChecks();

        if (this.Optional)
        {
            IntPtr ptr = value.NativeHandle;
            return eina_value_optional_pset(this.Handle,
                                            ValueTypeBridge.GetNative(ValueType.Object),
                                            ref ptr);
        }
        return eina_value_set_wrapper_ptr(this.Handle, value.NativeHandle);
    }

    /// <summary>Stores the given value into this value. This value's <see cref="Eina.Value.Optional" /> must
    /// be <c>true</c>.
    ///
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <param name="value">The value to be stored.</param>
    /// <returns><c>true</c> if the value was successfully stored.</returns>
    public bool Set(Value value)
    {
        OptionalSanityChecks();
        ValueType subtype = value.GetValueType();

        IntPtr ptr_val = MemoryNative.Alloc(subtype.MarshalSizeOf());
        IntPtr native_type = ValueTypeBridge.GetNative(subtype);

        try
        {
            switch (subtype)
            {
                // PSet on Container types require an Eina_Value_<Container>, which is the structure
                // that contains subtype, etc.
                case ValueType.Array:
                    EinaNative.Value_Array value_array;
                    if (!eina_value_get_wrapper(value.Handle, out value_array))
                    {
                        return false;
                    }

                    Marshal.StructureToPtr(value_array, ptr_val, false);
                    break;
                case ValueType.List:
                    EinaNative.Value_List value_list;
                    if (!eina_value_get_wrapper(value.Handle, out value_list))
                    {
                        return false;
                    }

                    Marshal.StructureToPtr(value_list, ptr_val, false);
                    break;
                default:
                    throw new InvalidValueTypeException("Only containers can be passed as raw Eina.Values");
            }

            return eina_value_optional_pset(this.Handle, native_type, ptr_val);
        }
        finally
        {
            MemoryNative.Free(ptr_val);
        }
    }

    /// <summary>Gets the currently stored value as a byte.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <param name="value">The target variable to receive the value.</param>
    /// <returns>True if the value was correctly retrieved.</returns>
    public bool Get(out byte value)
    {
        SanityChecks();
        if (this.Optional)
        {
            return eina_value_optional_pget(this.Handle, out value);
        }
        else
        {
            return eina_value_get_wrapper(this.Handle, out value);
        }
    }

    /// <summary>Gets the currently stored value as a sbyte.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <param name="value">The target variable to receive the value.</param>
    /// <returns>True if the value was correctly retrieved.</returns>
    public bool Get(out sbyte value)
    {
        SanityChecks();
        if (this.Optional)
        {
            return eina_value_optional_pget(this.Handle, out value);
        }
        else
        {
            return eina_value_get_wrapper(this.Handle, out value);
        }
    }

    /// <summary>Gets the currently stored value as a short.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <param name="value">The target variable to receive the value.</param>
    /// <returns>True if the value was correctly retrieved.</returns>
    public bool Get(out short value)
    {
        SanityChecks();
        if (this.Optional)
        {
            return eina_value_optional_pget(this.Handle, out value);
        }
        else
        {
            return eina_value_get_wrapper(this.Handle, out value);
        }
    }

    /// <summary>Gets the currently stored value as an ushort.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <param name="value">The target variable to receive the value.</param>
    /// <returns>True if the value was correctly retrieved.</returns>
    public bool Get(out ushort value)
    {
        SanityChecks();
        if (this.Optional)
        {
            return eina_value_optional_pget(this.Handle, out value);
        }
        else
        {
            return eina_value_get_wrapper(this.Handle, out value);
        }
    }

    /// <summary>Gets the currently stored value as an int.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <param name="value">The target variable to receive the value.</param>
    /// <returns>True if the value was correctly retrieved.</returns>
    public bool Get(out int value)
    {
        SanityChecks();
        if (this.Optional)
        {
            return eina_value_optional_pget(this.Handle, out value);
        }
        else
        {
            return eina_value_get_wrapper(this.Handle, out value);
        }
    }

    /// <summary>Gets the currently stored value as an uint.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <param name="value">The target variable to receive the value.</param>
    /// <returns>True if the value was correctly retrieved.</returns>
    public bool Get(out uint value)
    {
        SanityChecks();
        if (this.Optional)
        {
            return eina_value_optional_pget(this.Handle, out value);
        }
        else
        {
            return eina_value_get_wrapper(this.Handle, out value);
        }
    }

    /// <summary>Gets the currently stored value as a long.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <param name="value">The target variable to receive the value.</param>
    /// <returns>True if the value was correctly retrieved.</returns>
    public bool Get(out long value)
    {
        SanityChecks();
        if (this.Optional)
        {
            return eina_value_optional_pget(this.Handle, out value);
        }
        else
        {
            return eina_value_get_wrapper(this.Handle, out value);
        }
    }

    /// <summary>Gets the currently stored value as an ulong.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <param name="value">The target variable to receive the value.</param>
    /// <returns>True if the value was correctly retrieved.</returns>
    public bool Get(out ulong value)
    {
        SanityChecks();
        if (this.Optional)
        {
            return eina_value_optional_pget(this.Handle, out value);
        }
        else
        {
            return eina_value_get_wrapper(this.Handle, out value);
        }
    }

    /// <summary>Gets the currently stored value as a float.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <param name="value">The target variable to receive the value.</param>
    /// <returns>True if the value was correctly retrieved.</returns>
    public bool Get(out float value)
    {
        SanityChecks();
        if (this.Optional)
        {
            return eina_value_optional_pget(this.Handle, out value);
        }
        else
        {
            return eina_value_get_wrapper(this.Handle, out value);
        }
    }

    /// <summary>Gets the currently stored value as a double.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <param name="value">The target variable to receive the value.</param>
    /// <returns>True if the value was correctly retrieved.</returns>
    public bool Get(out double value)
    {
        SanityChecks();
        if (this.Optional)
        {
            return eina_value_optional_pget(this.Handle, out value);
        }
        else
        {
            return eina_value_get_wrapper(this.Handle, out value);
        }
    }

    /// <summary>Gets the currently stored value as a string.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <param name="value">The target variable to receive the value.</param>
    /// <returns>True if the value was correctly retrieved.</returns>
    public bool Get(out string value)
    {
        SanityChecks();
        IntPtr output = IntPtr.Zero;
        if (this.Optional)
        {
            if (!eina_value_optional_pget(this.Handle, out output))
            {
                value = String.Empty;
                return false;
            }
        }
        else if (!eina_value_get_wrapper(this.Handle, out output))
        {
            value = String.Empty;
            return false;
        }

        value = StringConversion.NativeUtf8ToManagedString(output);
        return true;
    }

    /// <summary>Gets the currently stored value as an Eina.Error.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <param name="value">The target variable to receive the value.</param>
    /// <returns>True if the value was correctly retrieved.</returns>
    public bool Get(out Eina.Error value)
    {
        SanityChecks();
        bool ret;
        int intermediate; // It seems out doesn't play well with implicit operators...
        if (this.Optional)
        {
            ret = eina_value_optional_pget(this.Handle, out intermediate);
        }
        else
        {
            ret = eina_value_get_wrapper(this.Handle, out intermediate);
        }

        value = intermediate;

        return ret;
    }

    /// <summary>Gets the currently stored value as an <see cref="Efl.Object"/>.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <param name="obj">The target variable to receive the value.</param>
    /// <returns>True if the value was correctly retrieved.</returns>
    public bool Get(out Efl.Object obj)
    {
        // FIXME Implement me
        SanityChecks();
        IntPtr ptr;
        bool ret;

        if (this.Optional)
        {
            ret = eina_value_optional_pget(this.Handle, out ptr);
        }
        else
        {
            ret = eina_value_get_wrapper(this.Handle, out ptr);
        }

        if (ret)
        {
            obj = (Efl.Object) Efl.Eo.Globals.CreateWrapperFor(ptr);
        }
        else
        {
            obj = null;
        }

        return ret;
    }


    /// <summary>Gets the currently stored value as a complex (e.g. container) <see cref="Eina.Value" />.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <param name="value">The target variable to receive the value.</param>
    /// <returns>True if the value was correctly retrieved.</returns>
    public bool Get(out Value value)
    {
        SanityChecks();
        value = null;

        if (!this.Optional)
        {
            throw new InvalidValueTypeException("Values can only be retreived");
        }

        IntPtr nativeType = eina_value_optional_type_get_wrapper(this.Handle);
        ValueType managedType = ValueTypeBridge.GetManaged(nativeType);

        switch (managedType)
        {
            case ValueType.Array:
                Eina.EinaNative.Value_Array array_desc;

                if (!eina_value_optional_pget(this.Handle, out array_desc))
                {
                    return false;
                }

                value = Value.FromArrayDesc(array_desc);
                break;
            case ValueType.List:
                Eina.EinaNative.Value_List list_desc;

                if (!eina_value_optional_pget(this.Handle, out list_desc))
                {
                    return false;
                }

                value = Value.FromListDesc(list_desc);
                break;
        }

        return true;
    }

    /// <summary>Gets the 'Type' this value is currently configured to store.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <returns>The type of the value stored in this object.</returns>
    public ValueType GetValueType()
    {
        if (Disposed)
        {
            throw new ObjectDisposedException(base.GetType().Name);
        }

        IntPtr native_type = eina_value_type_get_wrapper(this.Handle);
        return ValueTypeBridge.GetManaged(native_type);
    }

    /// <summary>Stores in <c>destination</c> a value converted from this one.
    ///
    /// <para>If the types of this value and <c>destination</c> differ, the library
    /// searches this value's type for a conversion function to the type of <c>destination</c>.
    /// If no such conversion is available, it searches the destination's type for a
    /// function converting from the type of this value.</para>
    ///
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <example>
    /// <code>
    /// var value = new Eina.Value("3.14"); // Type is string
    /// var dest = new Eina.Value(Eina.ValueType.Float); // Type is float
    /// value.ConvertTo(dest);
    /// // Dest now contains 3.14.
    /// </code>
    ///
    /// </example>
    /// <param name="destination">The object to receive the converted value.</param>
    /// <returns><c>true</c> if the value was successfully converted.</returns>
    public bool ConvertTo(Value destination)
    {
        if (destination == null)
        {
            return false;
        }

        SanityChecks();

        return eina_value_convert(this.Handle, destination.Handle);
    }

    /// <summary>Compare two <see cref="Eina.Value" />.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <param name="other">The object to be compared to.</param>
    /// <returns><c>-1</c>, <c>0</c> or <c>1</c> if this value is respectively smaller than, equal to or greater than
    /// the <c>other</c>.</returns>
    public int CompareTo(Value other)
    {
        if (object.ReferenceEquals(other, null))
        {
            return 1;
        }

        SanityChecks();
        other.SanityChecks();
        return eina_value_compare_wrapper(this.Handle, other.Handle);
    }

    /// <summary>Compare two values.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <param name="lhs">The left value.</param>
    /// <param name="rhs">The right value.</param>
    /// <returns><c>-1</c>, <c>0</c> or <c>1</c> if <c>lhs</c> is respectively
    /// smaller than, equal to or greater than the <c>rhs</c>.</returns>
    public static int Compare(Value lhs, Value rhs)
    {
        if (object.ReferenceEquals(lhs, rhs))
            return 0;
        if (object.ReferenceEquals(lhs, null))
            return -1;

        return lhs.CompareTo(rhs);
    }

    /// <summary>Returns whether this value is equal to the given object.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <param name="obj">The object to be compared to.</param>
    /// <returns><c>true</c> if this value is equal to <c>other</c>.</returns>
    public override bool Equals(object obj)
    {
        if (obj == null)
        {
            return false;
        }

        return this.Equals(obj as Value);
    }

    /// <summary>Returns whether this value is equal to the given value.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <param name="other">The value to be compared to.</param>
    /// <returns><c>true</c> if this value is equal to <c>other</c>.</returns>
    public bool Equals(Value other) => this.CompareTo(other) == 0;

    /// <summary>Gets the hash code for this value.
    ///
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <returns>The hash code of this value.</returns>
    public override int GetHashCode()
    {
        return this.Handle.ToInt32();
    }

    /// <summary>Returns whether both values are null or <c>lhs</c> is equal to <c>rhs</c>.
    ///
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <param name="lhs">The left hand side of the operator.</param>
    /// <param name="rhs">The right hand side of the operator.</param>
    /// <returns><c>true</c> if both parameters are <c>null</c> or if <c>lhs</c> is equal
    /// to <c>lhs</c>.</returns>
    public static bool operator==(Value lhs, Value rhs)
    {
        if (object.ReferenceEquals(lhs, null))
            return  object.ReferenceEquals(rhs, null);

        return lhs.Equals(rhs);
    }

    /// <summary>Returns whether <c>lhs</c> is different from <c>rhs</c>.
    ///
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <param name="lhs">The left hand side of the operator.</param>
    /// <param name="rhs">The right hand side of the operator.</param>
    /// <returns><c>true</c> if <c>lhs</c> is different from <c>rhs</c>.</returns>
    public static bool operator!=(Value lhs, Value rhs) => !(lhs == rhs);

    /// <summary>Returns whether <c>lhs</c> is less than <c>rhs</c>.
    ///
    /// <para>If either parameter is <c>null</c>, <c>false</c> is returned.</para>
    ///
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <param name="lhs">The left hand side of the operator.</param>
    /// <param name="rhs">The right hand side of the operator.</param>
    /// <returns><c>true</c> if <c>lhs</c> is less than <c>rhs</c>.</returns>
    public static bool operator<(Value lhs, Value rhs) => (Compare(lhs, rhs) < 0);

    /// <summary>Returns whether <c>lhs</c> is greater than <c>rhs</c>.
    ///
    /// <para>If either parameter is <c>null</c>, <c>false</c> is returned.</para>
    ///
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <param name="lhs">The left hand side of the operator.</param>
    /// <param name="rhs">The right hand side of the operator.</param>
    /// <returns><c>true</c> if <c>lhs</c> is greater than <c>rhs</c>.</returns>
    public static bool operator>(Value lhs, Value rhs) => rhs < lhs;

    /// <summary>
    ///   Returns whether <c>lhs</c> is equal or less than <c>rhs</c>.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <param name="lhs">The left hand side of the operator.</param>
    /// <param name="rhs">The right hand side of the operator.</param>
    /// <returns><c>true</c> if <c>lhs</c> is equal
    /// or less than <c>rhs</c>.</returns>
    public static bool operator<=(Value lhs, Value rhs) => !(lhs > rhs);

    /// <summary>
    ///   Returns whether <c>lhs</c> is equal or greater than <c>rhs</c>.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <param name="lhs">The left hand side of the operator.</param>
    /// <param name="rhs">The right hand side of the operator.</param>
    /// <returns><c>true</c> if <c>lhs</c> is equal
    /// or greater than <c>rhs</c>.</returns>
    public static bool operator>=(Value lhs, Value rhs) => !(lhs < rhs);


    /// <summary>Converts value to string.
    ///
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <returns>A string representation of this value.</returns>
    public override String ToString()
    {
        SanityChecks();
        return eina_value_to_string(this.Handle);

    }

    /// <summary>Empties an optional Eina.Value, freeing what was previously contained.
    ///
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <returns><c>true</c> if the operation was successful.</returns>
    public bool Reset()
    {
        OptionalSanityChecks();
        return eina_value_optional_reset(this.Handle);
    }

    // Container value methods

    /// <summary>Gets the number of elements in this container value.
    ///
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <returns>The number of elements.</returns>
    public int Count()
    {
        ContainerSanityChecks();
        switch (GetValueType())
        {
            case ValueType.Array:
                return (int)eina_value_array_count_wrapper(this.Handle);
            case ValueType.List:
                return (int)eina_value_list_count_wrapper(this.Handle);
        }

        return -1;
    }

    /// <summary>Appends new values to this container.
    ///
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <param name="o">The new value to be appended.</param>
    /// <returns><c>true</c> if the value was successfully appended.</returns>
    public bool Append(object o)
    {
        ContainerSanityChecks();

        switch (GetValueSubType())
        {
            case ValueType.SByte:
                {
                    sbyte b = Convert.ToSByte(o, CultureInfo.CurrentCulture);
                    return eina_value_container_append_wrapper_char(this.Handle, b);
                }

            case ValueType.Byte:
                {
                    byte b = Convert.ToByte(o, CultureInfo.CurrentCulture);
                    return eina_value_container_append_wrapper_uchar(this.Handle, b);
                }

            case ValueType.Short:
                {
                    short b = Convert.ToInt16(o, CultureInfo.CurrentCulture);
                    return eina_value_container_append_wrapper_short(this.Handle, b);
                }

            case ValueType.UShort:
                {
                    ushort b = Convert.ToUInt16(o, CultureInfo.CurrentCulture);
                    return eina_value_container_append_wrapper_ushort(this.Handle, b);
                }

            case ValueType.Int32:
                {
                    int x = Convert.ToInt32(o, CultureInfo.CurrentCulture);
                    return eina_value_container_append_wrapper_int(this.Handle, x);
                }

            case ValueType.UInt32:
                {
                    uint x = Convert.ToUInt32(o, CultureInfo.CurrentCulture);
                    return eina_value_container_append_wrapper_uint(this.Handle, x);
                }

            case ValueType.Long:
            case ValueType.Int64:
                {
                    long x = Convert.ToInt64(o, CultureInfo.CurrentCulture);
                    return eina_value_container_append_wrapper_long(this.Handle, x);
                }

            case ValueType.ULong:
            case ValueType.UInt64:
                {
                    ulong x = Convert.ToUInt64(o, CultureInfo.CurrentCulture);
                    return eina_value_container_append_wrapper_ulong(this.Handle, x);
                }

            case ValueType.Float:
                {
                    float x = Convert.ToSingle(o, CultureInfo.CurrentCulture);
                    return eina_value_container_append_wrapper_float(this.Handle, x);
                }

            case ValueType.Double:
                {
                    double x = Convert.ToDouble(o, CultureInfo.CurrentCulture);
                    return eina_value_container_append_wrapper_double(this.Handle, x);
                }

            case ValueType.String:
                {
                    string x = Convert.ToString(o, CultureInfo.CurrentCulture);
                    return eina_value_container_append_wrapper_string(this.Handle, x);
                }
            case ValueType.Object:
                {
                    var x = (Efl.Object) o;
                    return eina_value_container_append_wrapper_ptr(this.Handle, x.NativeHandle);
                }
        }

        return false;
    }

    /// <summary>Indexer for this container.
    ///
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <param name="i">The index of the element to be accessed/set.</param>
    public object this[int i]
    {
        get
        {
            ContainerSanityChecks(i);

            switch (GetValueSubType())
            {
                case ValueType.SByte:
                    {
                        sbyte ret = default(sbyte);
                        eina_value_container_get_wrapper(this.Handle, i, out ret);
                        return ret;
                    }

                case ValueType.Byte:
                    {
                        byte ret = default(byte);
                        eina_value_container_get_wrapper(this.Handle, i, out ret);
                        return ret;
                    }

                case ValueType.Short:
                    {
                        short ret = default(short);
                        eina_value_container_get_wrapper(this.Handle, i, out ret);
                        return ret;
                    }

                case ValueType.UShort:
                    {
                        ushort ret = default(ushort);
                        eina_value_container_get_wrapper(this.Handle, i, out ret);
                        return ret;
                    }

                case ValueType.Int32:
                    {
                        int ret = default(int);
                        eina_value_container_get_wrapper(this.Handle, i, out ret);
                        return ret;
                    }

                case ValueType.UInt32:
                    {
                        uint ret = default(uint);
                        eina_value_container_get_wrapper(this.Handle, i, out ret);
                        return ret;
                    }

                case ValueType.Long:
                case ValueType.Int64:
                    {
                        long ret = default(long);
                        eina_value_container_get_wrapper(this.Handle, i, out ret);
                        return ret;
                    }

                case ValueType.ULong:
                case ValueType.UInt64:
                    {
                        ulong ret = default(ulong);
                        eina_value_container_get_wrapper(this.Handle, i, out ret);
                        return ret;
                    }

                case ValueType.Float:
                    {
                        float ret = default(float);
                        eina_value_container_get_wrapper(this.Handle, i, out ret);
                        return ret;
                    }

                case ValueType.Double:
                    {
                        double ret = default(double);
                        eina_value_container_get_wrapper(this.Handle, i, out ret);
                        return ret;
                    }

                case ValueType.String:
                    {
                        // Using intptr as using string as the arg type in the DllImport'd function would
                        // make mono take ownership of the string.
                        IntPtr ptr = IntPtr.Zero;
                        eina_value_container_get_wrapper(this.Handle, i, out ptr);
                        return Eina.StringConversion.NativeUtf8ToManagedString(ptr);
                    }
                case ValueType.Object:
                    {
                        IntPtr ptr = IntPtr.Zero;
                        eina_value_container_get_wrapper(this.Handle, i, out ptr);
                        return Efl.Eo.Globals.CreateWrapperFor(ptr);
                    }

                default:
                    throw new InvalidOperationException("Subtype not supported.");
            }
        }
        set
        {
            ContainerSanityChecks(i);

            switch (GetValueSubType())
            {
                case ValueType.SByte:
                    {
                        sbyte v = Convert.ToSByte(value,
                                                  CultureInfo.CurrentCulture);
                        eina_value_container_set_wrapper_char(this.Handle, i, v);
                        break;
                    }

                case ValueType.Byte:
                    {
                        byte v = Convert.ToByte(value,
                                                CultureInfo.CurrentCulture);
                        eina_value_container_set_wrapper_uchar(this.Handle, i, v);
                        break;
                    }

                case ValueType.Short:
                    {
                        short x = Convert.ToInt16(value,
                                                  CultureInfo.CurrentCulture);
                        eina_value_container_set_wrapper_short(this.Handle, i, x);
                        break;
                    }

                case ValueType.UShort:
                    {
                        ushort x = Convert.ToUInt16(value,
                                                    CultureInfo.CurrentCulture);
                        eina_value_container_set_wrapper_ushort(this.Handle, i, x);
                        break;
                    }

                case ValueType.Int32:
                    {
                        int x = Convert.ToInt32(value,
                                                CultureInfo.CurrentCulture);
                        eina_value_container_set_wrapper_int(this.Handle, i, x);
                        break;
                    }

                case ValueType.UInt32:
                    {
                        uint x = Convert.ToUInt32(value,
                                                  CultureInfo.CurrentCulture);
                        eina_value_container_set_wrapper_uint(this.Handle, i, x);
                        break;
                    }

                case ValueType.Long:
                case ValueType.Int64:
                    {
                        long x = Convert.ToInt64(value,
                                                 CultureInfo.CurrentCulture);
                        eina_value_container_set_wrapper_long(this.Handle, i, x);
                        break;
                    }

                case ValueType.ULong:
                case ValueType.UInt64:
                    {
                        ulong x = Convert.ToUInt64(value,
                                                   CultureInfo.CurrentCulture);
                        eina_value_container_set_wrapper_ulong(this.Handle, i, x);
                        break;
                    }

                case ValueType.Float:
                    {
                        float x = Convert.ToSingle(value,
                                                   CultureInfo.CurrentCulture);
                        eina_value_container_set_wrapper_float(this.Handle, i, x);
                        break;
                    }

                case ValueType.Double:
                    {
                        double x = Convert.ToDouble(value, CultureInfo.CurrentCulture);
                        eina_value_container_set_wrapper_double(this.Handle, i, x);
                        break;
                    }

                case ValueType.String:
                    {
                        string x = Convert.ToString(value,
                                                    CultureInfo.CurrentCulture);
                        eina_value_container_set_wrapper_string(this.Handle, i, x);
                        break;
                    }
                case ValueType.Object:
                    {
                        Efl.Object x = (Efl.Object)value;
                        eina_value_container_set_wrapper_ptr(this.Handle, i, x.NativeHandle);
                        break;
                    }
            }
        }
    }

    /// <summary>Gets the type of the values in this container value.
    ///
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <returns>The <see cref="Eina.ValueType" /> of the values contained in this container.</returns>
    public ValueType GetValueSubType()
    {
        ContainerSanityChecks();

        IntPtr native_subtype = IntPtr.Zero;

        switch (GetValueType())
        {
            case ValueType.Array:
                native_subtype = eina_value_array_subtype_get_wrapper(this.Handle);
                break;
            case ValueType.List:
                native_subtype = eina_value_list_subtype_get_wrapper(this.Handle);
                break;
        }

        return ValueTypeBridge.GetManaged(native_subtype);
    }
}

/// <summary> Custom marshaler to convert value pointers to managed values and back,
/// without changing ownership.</summary>
[EditorBrowsable(EditorBrowsableState.Never)]
public class ValueMarshaler : ICustomMarshaler
{
    /// <summary>Creates a managed value from a C pointer, whitout taking ownership of it.</summary>
    public object MarshalNativeToManaged(IntPtr pNativeData)
    {
        return new Value(pNativeData, Ownership.Unmanaged);
    }

    /// <summary>Retrieves the C pointer from a given managed value,
    /// keeping the managed ownership.</summary>
    public IntPtr MarshalManagedToNative(object managedObj)
    {
        try
        {
            Value v = (Value)managedObj;
            return v.Handle;
        }
        catch (InvalidCastException)
        {
            return IntPtr.Zero;
        }
    }

    public void CleanUpNativeData(IntPtr pNativeData)
    {
    }

    public void CleanUpManagedData(object managedObj)
    {
    }

    public int GetNativeDataSize()
    {
        return -1;
    }

    public static ICustomMarshaler GetInstance(string cookie)
    {
        if (marshaler == null)
        {
            marshaler = new ValueMarshaler();
        }

        return marshaler;
    }

    static private ValueMarshaler marshaler;
}

/// <summary> Custom marshaler to convert value pointers to managed values and back,
/// also transferring the ownership to the other side.</summary>
[EditorBrowsable(EditorBrowsableState.Never)]
public class ValueMarshalerOwn : ICustomMarshaler
{
    /// <summary>Creates a managed value from a C pointer, taking the ownership.</summary>
    public object MarshalNativeToManaged(IntPtr pNativeData)
    {
        return new Value(pNativeData, Ownership.Managed);
    }

    /// <summary>Retrieves the C pointer from a given managed value,
    /// transferring the ownership to the unmanaged side, which should release it
    /// when not needed. </summary>
    public IntPtr MarshalManagedToNative(object managedObj)
    {
        try
        {
            Value v = (Value)managedObj;
            v.ReleaseOwnership();
            return v.Handle;
        }
        catch (InvalidCastException)
        {
            return IntPtr.Zero;
        }
    }

    public void CleanUpNativeData(IntPtr pNativeData)
    {
    }

    public void CleanUpManagedData(object managedObj)
    {
    }

    public int GetNativeDataSize()
    {
        return -1;
    }

    public static ICustomMarshaler GetInstance(string cookie)
    {
        if (marshaler == null)
        {
            marshaler = new ValueMarshalerOwn();
        }

        return marshaler;
    }

    static private ValueMarshalerOwn marshaler;
}

/// <summary> Custom marshaler to convert value type pointers to managed boxed enum values
/// and back.</summary>
[EditorBrowsable(EditorBrowsableState.Never)]
public class ValueTypeMarshaler : ICustomMarshaler
{
    /// <summary>Creates a boxed ValueType enum value from a C pointer.</summary>
    public object MarshalNativeToManaged(IntPtr pNativeData)
    {
        var r = ValueTypeBridge.GetManaged(pNativeData);
        return new ValueTypeBox(r);
    }
    public static readonly Eina.ValueType vtype;

    /// <summary>Retrieves the C pointer from a given boxed enum value type.</summary>
    public IntPtr MarshalManagedToNative(object managedObj)
    {
        ValueTypeBox v = (ValueTypeBox)managedObj;
        return ValueTypeBridge.GetNative(v);
    }

    public void CleanUpNativeData(IntPtr pNativeData)
    {
    }

    public void CleanUpManagedData(object managedObj)
    {
    }

    public int GetNativeDataSize()
    {
        return -1;
    }

    public static ICustomMarshaler GetInstance(string cookie)
    {
        if (marshaler == null)
        {
            marshaler = new ValueTypeMarshaler();
        }

        return marshaler;
    }

    static private ValueTypeMarshaler marshaler;
}

}
