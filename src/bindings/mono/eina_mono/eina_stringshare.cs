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

using System;
using System.Runtime.InteropServices;
using System.ComponentModel;


namespace Eina
{

// TODO: move all native functions to a "NativeMethods" class
[EditorBrowsable(EditorBrowsableState.Never)]
public static partial class NativeMethods
{
    [DllImport(efl.Libs.Eina)] internal static extern IntPtr
        eina_stringshare_add(IntPtr str);
    [DllImport(efl.Libs.Eina)] internal static extern System.IntPtr
        eina_stringshare_add_length(IntPtr str, UInt32 slen);
    [DllImport(efl.Libs.Eina)] internal static extern void
        eina_stringshare_del(IntPtr str);
    [DllImport(efl.Libs.CustomExports)] internal static extern void
        efl_mono_native_stringshare_del_ref(IntPtr str);
    [DllImport(efl.Libs.CustomExports)] internal static extern IntPtr
        efl_mono_native_stringshare_del_addr_get();
}

/// <summary>
/// Placeholder type to interact with the native type Eina_Stringshare, mainly for eina containers.
///
/// <para>Since EFL 1.23.</para>
/// </summary>
/// <remarks>
/// Using System.String and merely converting this type to it (by cast or implicitly)
/// is recommended for simplicity and ease of use.
///
/// This type is just a System.String wrapper that works as a placeholder for
/// instrumentalizing proper interaction with native EFL API that demands
/// strings to be stringshares.
///
/// Both C strings and eina stringshares are bound as regular strings in EFL#,
/// as working directly with these types would demand unnecessary hassle from
/// the user viewpoint.
/// But for eina containers this distinction is important, and since C# generics
/// do not provide a convenient way of dealing with the same type requiring
/// a different management based on some other condition (at least not without
/// compromising the usability for other types), we use this string wrapper
/// in order to signal this distinction.
///
/// Implements equality/inequality methods for easier comparison with strings and
/// other Stringshare objects. For more specific operations convert to a string.
/// </remarks>
public class Stringshare : IEquatable<Stringshare>, IEquatable<string>
{
    /// <summary>
    /// Main constructor. Wrap the given string.
    /// Have private acess to avoid wrapping a null reference,
    /// use convertion or the factory method to create a new instance.
    /// <para>Since EFL 1.23.</para>
    /// <see cref="Create(string)"/>
    /// <see cref="implicit operator Stringshare(string)"/>
    /// </summary>
    /// <param name="s">The string to be wrapped.</param>
    private Stringshare(string s)
    {
        Str = s;
    }

    /// <summary>
    /// Auto-implemented property that holds the wrapped string value.
    /// </summary>
    public string Str { get; private set; }

    /// <summary>
    /// Factory method to instantiate a new object.
    /// Get a wrappper for the given string or a null reference if the given
    /// string reference is also null.
    /// <para>Since EFL 1.23.</para>
    /// <seealso cref="implicit operator Stringshare(string)"/>
    /// </summary>
    /// <param name="s">The string to be wrapped.</param>
    /// <returns>
    /// A new instance wrapping the given string, or a null reference if
    /// the given string reference is also null.
    /// </returns>
    public static Stringshare Create(string s)
    {
        if (s == null)
        {
            return null;
        }

        return new Stringshare(s);
    }

    /// <summary>
    /// Implicit convertion to string.
    /// </summary>
    public static implicit operator string(Stringshare ss)
    {
        if (ReferenceEquals(null, ss))
        {
            return null;
        }

        return ss.Str;
    }

    /// <summary>
    /// Implicit convertion from string to Stringshare.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <remarks>
    /// Note that this method can be used to create an instance of this class,
    /// either via an explicit cast or an implicit convertion.
    /// <seealso cref="Create(string)"/>
    /// </remarks>
    public static implicit operator Stringshare(string s)
    {
        if (ReferenceEquals(null, s))
        {
            return null;
        }

        return new Stringshare(s);
    }

    /// <summary>
    /// Check two Stringshare objects for equality.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <returns>
    /// True if both wrapped strings have the same content or if both
    /// references are null, false otherwise.
    /// </returns>
    public static bool operator==(Stringshare ss1, Stringshare ss2)
    {
        return ((string)ss1) == ((string)ss2);
    }


    /// <summary>
    /// Check two Stringshare objects for inequality.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <returns>
    /// True if the wrapped strings have different content or if one reference is null
    /// and the other is not, false otherwise.
    /// </returns>
    public static bool operator!=(Stringshare ss1, Stringshare ss2)
    {
        return !(ss1 == ss2);
    }

    /// <summary>
    /// Returns the wrapped string.
    /// <para>Since EFL 1.23.</para>
    /// <seealso cref="Str"/>
    /// <seealso cref="Get()"/>
    /// </summary>
    /// <returns>The wrapped string. Same as the property Str.</returns>
    public override string ToString()
    {
        return Str;
    }

    /// <summary>
    /// Override of GetHashCode for consistency with user-defined equality methods.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <returns>
    /// The wrapped string hash code.
    /// </returns>
    public override int GetHashCode()
    {
        return Str.GetHashCode();
    }

    /// <summary>
    /// Check the given object for equality.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <param name="other">The string to be compare to.</param>
    /// <returns>
    /// True if the given object is the same object or if it is another Stringshare object
    /// and both wrapped strings are equal or if it is a string object and its content
    /// is the same of the wrapped string.
    /// In any other case it returns false.
    /// </returns>
    public override bool Equals(object other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        if (other.GetType() == typeof(string))
        {
            return this.Str == (string)other;
        }

        return other.GetType() == typeof(Stringshare) && this == ((Stringshare)other);
    }

    /// <summary>
    /// Check the given Stringshare for equality.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <param name="other">The string share to compare to.</param>
    /// <returns>
    /// True if the given Stringshare object is not null and its wrapped string
    /// have the same content of this.Str, false otherwise.
    /// </returns>
    public bool Equals(Stringshare other)
    {
        return this == other;
    }

    /// <summary>
    /// Check the given Stringshare for equality.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <param name="other">The string to compare to.</param>
    /// <returns>
    /// True if the given string is not null and the wrapped string have the same
    /// content of the given string, false otherwise.
    /// </returns>
    public bool Equals(string other)
    {
        return this.Str == other;
    }

    /// <summary>
    /// Get the wrapped string.
    /// <para>Since EFL 1.23.</para>
    /// <seealso cref="Str"/>
    /// <seealso cref="ToString()"/>
    /// </summary>
    /// <returns>The wrapped string. Same as the property Str.</returns>
    public string Get()
    {
        return Str;
    }
}

}
