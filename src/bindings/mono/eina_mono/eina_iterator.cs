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
using System.Collections.Generic;
using System.ComponentModel;

using static Eina.TraitFunctions;
using static Eina.IteratorNativeFunctions;

namespace Eina
{

[EditorBrowsable(EditorBrowsableState.Never)]
public static class IteratorNativeFunctions
{
    [DllImport(efl.Libs.Eina)] internal static extern void
        eina_iterator_free(IntPtr iterator);
    [DllImport(efl.Libs.Eina)] internal static extern IntPtr
        eina_iterator_container_get(IntPtr iterator);
    [DllImport(efl.Libs.Eina)] [return: MarshalAs(UnmanagedType.U1)] internal static extern bool
        eina_iterator_next(IntPtr iterator, out IntPtr data);
    [DllImport(efl.Libs.Eina)] internal static extern void
        eina_iterator_foreach(IntPtr iterator, IntPtr callback, IntPtr fdata);
    [DllImport(efl.Libs.Eina)] [return: MarshalAs(UnmanagedType.U1)] internal static extern bool
        eina_iterator_lock(IntPtr iterator);
    [DllImport(efl.Libs.Eina)] [return: MarshalAs(UnmanagedType.U1)] internal static extern bool
        eina_iterator_unlock(IntPtr iterator);

    [DllImport(efl.Libs.Eina)] internal static extern IntPtr
        eina_carray_iterator_new(IntPtr array);
}

/// <summary>Wrapper around a native Eina iterator.
/// <para>Since EFL 1.23.</para>
/// </summary>
public class Iterator<T> : IEnumerable<T>, IDisposable
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public IntPtr Handle {get;set;} = IntPtr.Zero;
    /// <summary>Whether this wrapper owns the native iterator.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    public bool Own {get;set;} = true;

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Iterator(IntPtr handle, bool own)
    {
        Handle = handle;
        Own = own;
    }

    /// <summary>
    ///   Finalizer to be called from the Garbage Collector.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    ~Iterator()
    {
        Dispose(false);
    }

    /// <summary>Disposes of this wrapper, releasing the native array if owned.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <param name="disposing">True if this was called from <see cref="Dispose()"/> public method. False if
    /// called from the C# finalizer.</param>
    protected virtual void Dispose(bool disposing)
    {
        var h = Handle;
        Handle = IntPtr.Zero;
        if (h == IntPtr.Zero)
        {
            return;
        }

        if (Own)
        {
            if (disposing)
            {
                eina_iterator_free(h);
            }
            else
            {
                Efl.Eo.Globals.ThreadSafeFreeCbExec(eina_iterator_free, h);
            }
        }
    }

    /// <summary>Releases the native resources held by this instance.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>Releases the native resources held by this instance.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    public void Free()
    {
        Dispose();
    }

    /// <summary>
    ///   Releases the native iterator.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <returns>The native array.</returns>
    public IntPtr Release()
    {
        IntPtr h = Handle;
        Handle = IntPtr.Zero;
        return h;
    }

    /// <summary>Sets own.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <param name="own">If own the object.</param>
    public void SetOwnership(bool own)
    {
        Own = own;
    }

    /// <summary>
    ///   Go to the next one.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    ///
    public bool Next(out T res)
    {
        IntPtr data;
        if (!eina_iterator_next(Handle, out data))
        {
            res = default(T);
            return false;
        }

        res = NativeToManaged<T>(data);

        return true;
    }

    /// <summary>
    ///   Locks the container of the iterator.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <returns>true on success, false otherwise.</returns>
    public bool Lock()
    {
        return eina_iterator_lock(Handle);
    }

    /// <summary>
    ///   Unlocks the container of the iterator.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    /// <returns>true on success, false otherwise.</returns>
    public bool Unlock()
    {
        return eina_iterator_unlock(Handle);
    }

    /// <summary> Gets an Enumerator for this iterator.
    /// <para>Since EFL 1.23.</para>
    /// </summary>
    public IEnumerator<T> GetEnumerator()
    {
        for (T curr; Next(out curr);)
        {
            yield return curr;
        }
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

}
