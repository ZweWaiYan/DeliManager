// =============================================================================
// <summary>

using System;
using System.Collections.Generic;

/// <summary>
/// 型変換拡張メソッド定義クラスです。
/// </summary>
public static class TypeConvertExtension
{
    #region 強制型変換

    #region bool

    /// <summary>
    /// <see cref="bool"/> を型変換します。
    /// </summary>
    /// <typeparam name="T">変換対象の型。</typeparam>
    /// <param name="target">変換対象の <see cref="bool"/> 。</param>
    /// <returns>
    /// 変換結果。
    /// <para>※型変換に失敗した場合は、型ごとの規定値を返します。</para>
    /// </returns>
    public static T To<T>(this bool target)
    {
        return target.To<bool, T>();
    }

    /// <summary>
    /// <see cref="bool"/> を型変換します。（規定値指定あり）
    /// </summary>
    /// <typeparam name="T">変換対象の型。</typeparam>
    /// <param name="target">変換対象の <see cref="bool"/> 。</param>
    /// <param name="defaultValue">規定値。</param>
    /// <returns>
    /// 変換結果。
    /// <para>※型変換に失敗した場合は、指定された規定値を返します。</para>
    /// </returns>
    public static T To<T>(this bool target, T defaultValue)
    {
        return target.To<bool, T>(defaultValue);
    }

    /// <summary>
    /// <see cref="bool"/> を型変換します。（例外発生時処理指定あり）
    /// </summary>
    /// <typeparam name="T">変換対象の型。</typeparam>
    /// <param name="target">変換対象の <see cref="bool"/> 。</param>
    /// <param name="throwException">例外発生時に例外を throw するか？</param>
    /// <returns>
    /// 変換結果。
    /// <para>※型変換に失敗した場合は、型ごとの規定値を返します。または、例外を発生させます。</para>
    /// </returns>
    /// <exception cref="InvalidCastException">型変換に失敗しました。</exception>
    /// <exception cref="FormatException">型変換に失敗しました。</exception>
    /// <exception cref="OverflowException">型変換に失敗しました。</exception>
    public static T To<T>(this bool target, bool throwException)
    {
        return target.To<bool, T>(throwException);
    }

    #endregion

    #region byte

    /// <summary>
    /// <see cref="byte"/> を型変換します。
    /// </summary>
    /// <typeparam name="T">変換対象の型。</typeparam>
    /// <param name="target">変換対象の <see cref="byte"/> 。</param>
    /// <returns>
    /// 変換結果。
    /// <para>※型変換に失敗した場合は、型ごとの規定値を返します。</para>
    /// </returns>
    public static T To<T>(this byte target)
    {
        return target.To<byte, T>();
    }

    /// <summary>
    /// <see cref="byte"/> を型変換します。（規定値指定あり）
    /// </summary>
    /// <typeparam name="T">変換対象の型。</typeparam>
    /// <param name="target">変換対象の <see cref="byte"/> 。</param>
    /// <param name="defaultValue">規定値。</param>
    /// <returns>
    /// 変換結果。
    /// <para>※型変換に失敗した場合は、指定された規定値を返します。</para>
    /// </returns>
    public static T To<T>(this byte target, T defaultValue)
    {
        return target.To<byte, T>(defaultValue);
    }

    /// <summary>
    /// <see cref="byte"/> を型変換します。（例外発生時処理指定あり）
    /// </summary>
    /// <typeparam name="T">変換対象の型。</typeparam>
    /// <param name="target">変換対象の <see cref="byte"/> 。</param>
    /// <param name="throwException">例外発生時に例外を throw するか？</param>
    /// <returns>
    /// 変換結果。
    /// <para>※型変換に失敗した場合は、型ごとの規定値を返します。または、例外を発生させます。</para>
    /// </returns>
    /// <exception cref="InvalidCastException">型変換に失敗しました。</exception>
    /// <exception cref="FormatException">型変換に失敗しました。</exception>
    /// <exception cref="OverflowException">型変換に失敗しました。</exception>
    public static T To<T>(this byte target, bool throwException)
    {
        return target.To<byte, T>(throwException);
    }

    #endregion

    #region sbyte

    /// <summary>
    /// <see cref="sbyte"/> を型変換します。
    /// </summary>
    /// <typeparam name="T">変換対象の型。</typeparam>
    /// <param name="target">変換対象の <see cref="sbyte"/> 。</param>
    /// <returns>
    /// 変換結果。
    /// <para>※型変換に失敗した場合は、型ごとの規定値を返します。</para>
    /// </returns>
    public static T To<T>(this sbyte target)
    {
        return target.To<sbyte, T>();
    }

    /// <summary>
    /// <see cref="sbyte"/> を型変換します。（規定値指定あり）
    /// </summary>
    /// <typeparam name="T">変換対象の型。</typeparam>
    /// <param name="target">変換対象の <see cref="sbyte"/> 。</param>
    /// <param name="defaultValue">規定値。</param>
    /// <returns>
    /// 変換結果。
    /// <para>※型変換に失敗した場合は、指定された規定値を返します。</para>
    /// </returns>
    public static T To<T>(this sbyte target, T defaultValue)
    {
        return target.To<sbyte, T>(defaultValue);
    }

    /// <summary>
    /// <see cref="sbyte"/> を型変換します。（例外発生時処理指定あり）
    /// </summary>
    /// <typeparam name="T">変換対象の型。</typeparam>
    /// <param name="target">変換対象の <see cref="sbyte"/> 。</param>
    /// <param name="throwException">例外発生時に例外を throw するか？</param>
    /// <returns>
    /// 変換結果。
    /// <para>※型変換に失敗した場合は、型ごとの規定値を返します。または、例外を発生させます。</para>
    /// </returns>
    /// <exception cref="InvalidCastException">型変換に失敗しました。</exception>
    /// <exception cref="FormatException">型変換に失敗しました。</exception>
    /// <exception cref="OverflowException">型変換に失敗しました。</exception>
    public static T To<T>(this sbyte target, bool throwException)
    {
        return target.To<sbyte, T>(throwException);
    }

    #endregion

    #region decimal

    /// <summary>
    /// <see cref="decimal"/> を型変換します。
    /// </summary>
    /// <typeparam name="T">変換対象の型。</typeparam>
    /// <param name="target">変換対象の <see cref="decimal"/> 。</param>
    /// <returns>
    /// 変換結果。
    /// <para>※型変換に失敗した場合は、型ごとの規定値を返します。</para>
    /// </returns>
    public static T To<T>(this decimal target)
    {
        return target.To<decimal, T>();
    }

    /// <summary>
    /// <see cref="decimal"/> を型変換します。（規定値指定あり）
    /// </summary>
    /// <typeparam name="T">変換対象の型。</typeparam>
    /// <param name="target">変換対象の <see cref="decimal"/> 。</param>
    /// <param name="defaultValue">規定値。</param>
    /// <returns>
    /// 変換結果。
    /// <para>※型変換に失敗した場合は、指定された規定値を返します。</para>
    /// </returns>
    public static T To<T>(this decimal target, T defaultValue)
    {
        return target.To<decimal, T>(defaultValue);
    }

    /// <summary>
    /// <see cref="decimal"/> を型変換します。（例外発生時処理指定あり）
    /// </summary>
    /// <typeparam name="T">変換対象の型。</typeparam>
    /// <param name="target">変換対象の <see cref="decimal"/> 。</param>
    /// <param name="throwException">例外発生時に例外を throw するか？</param>
    /// <returns>
    /// 変換結果。
    /// <para>※型変換に失敗した場合は、型ごとの規定値を返します。または、例外を発生させます。</para>
    /// </returns>
    /// <exception cref="InvalidCastException">型変換に失敗しました。</exception>
    /// <exception cref="FormatException">型変換に失敗しました。</exception>
    /// <exception cref="OverflowException">型変換に失敗しました。</exception>
    public static T To<T>(this decimal target, bool throwException)
    {
        return target.To<decimal, T>(throwException);
    }

    #endregion

    #region double

    /// <summary>
    /// <see cref="double"/> を型変換します。
    /// </summary>
    /// <typeparam name="T">変換対象の型。</typeparam>
    /// <param name="target">変換対象の <see cref="double"/> 。</param>
    /// <returns>
    /// 変換結果。
    /// <para>※型変換に失敗した場合は、型ごとの規定値を返します。</para>
    /// </returns>
    public static T To<T>(this double target)
    {
        return target.To<double, T>();
    }

    /// <summary>
    /// <see cref="double"/> を型変換します。（規定値指定あり）
    /// </summary>
    /// <typeparam name="T">変換対象の型。</typeparam>
    /// <param name="target">変換対象の <see cref="double"/> 。</param>
    /// <param name="defaultValue">規定値。</param>
    /// <returns>
    /// 変換結果。
    /// <para>※型変換に失敗した場合は、指定された規定値を返します。</para>
    /// </returns>
    public static T To<T>(this double target, T defaultValue)
    {
        return target.To<double, T>(defaultValue);
    }

    /// <summary>
    /// <see cref="double"/> を型変換します。（例外発生時処理指定あり）
    /// </summary>
    /// <typeparam name="T">変換対象の型。</typeparam>
    /// <param name="target">変換対象の <see cref="double"/> 。</param>
    /// <param name="throwException">例外発生時に例外を throw するか？</param>
    /// <returns>
    /// 変換結果。
    /// <para>※型変換に失敗した場合は、型ごとの規定値を返します。または、例外を発生させます。</para>
    /// </returns>
    /// <exception cref="InvalidCastException">型変換に失敗しました。</exception>
    /// <exception cref="FormatException">型変換に失敗しました。</exception>
    /// <exception cref="OverflowException">型変換に失敗しました。</exception>
    public static T To<T>(this double target, bool throwException)
    {
        return target.To<double, T>(throwException);
    }

    #endregion

    #region float

    /// <summary>
    /// <see cref="float"/> を型変換します。
    /// </summary>
    /// <typeparam name="T">変換対象の型。</typeparam>
    /// <param name="target">変換対象の <see cref="float"/> 。</param>
    /// <returns>
    /// 変換結果。
    /// <para>※型変換に失敗した場合は、型ごとの規定値を返します。</para>
    /// </returns>
    public static T To<T>(this float target)
    {
        return target.To<float, T>();
    }

    /// <summary>
    /// <see cref="float"/> を型変換します。（規定値指定あり）
    /// </summary>
    /// <typeparam name="T">変換対象の型。</typeparam>
    /// <param name="target">変換対象の <see cref="float"/> 。</param>
    /// <param name="defaultValue">規定値。</param>
    /// <returns>
    /// 変換結果。
    /// <para>※型変換に失敗した場合は、指定された規定値を返します。</para>
    /// </returns>
    public static T To<T>(this float target, T defaultValue)
    {
        return target.To<float, T>(defaultValue);
    }

    /// <summary>
    /// <see cref="float"/> を型変換します。（例外発生時処理指定あり）
    /// </summary>
    /// <typeparam name="T">変換対象の型。</typeparam>
    /// <param name="target">変換対象の <see cref="float"/> 。</param>
    /// <param name="throwException">例外発生時に例外を throw するか？</param>
    /// <returns>
    /// 変換結果。
    /// <para>※型変換に失敗した場合は、型ごとの規定値を返します。または、例外を発生させます。</para>
    /// </returns>
    /// <exception cref="InvalidCastException">型変換に失敗しました。</exception>
    /// <exception cref="FormatException">型変換に失敗しました。</exception>
    /// <exception cref="OverflowException">型変換に失敗しました。</exception>
    public static T To<T>(this float target, bool throwException)
    {
        return target.To<float, T>(throwException);
    }

    #endregion

    #region int

    /// <summary>
    /// <see cref="int"/> を型変換します。
    /// </summary>
    /// <typeparam name="T">変換対象の型。</typeparam>
    /// <param name="target">変換対象の <see cref="int"/> 。</param>
    /// <returns>
    /// 変換結果。
    /// <para>※型変換に失敗した場合は、型ごとの規定値を返します。</para>
    /// </returns>
    public static T To<T>(this int target)
    {
        return target.To<int, T>();
    }

    /// <summary>
    /// <see cref="int"/> を型変換します。（規定値指定あり）
    /// </summary>
    /// <typeparam name="T">変換対象の型。</typeparam>
    /// <param name="target">変換対象の <see cref="int"/> 。</param>
    /// <param name="defaultValue">規定値。</param>
    /// <returns>
    /// 変換結果。
    /// <para>※型変換に失敗した場合は、指定された規定値を返します。</para>
    /// </returns>
    public static T To<T>(this int target, T defaultValue)
    {
        return target.To<int, T>(defaultValue);
    }

    /// <summary>
    /// <see cref="int"/> を型変換します。（例外発生時処理指定あり）
    /// </summary>
    /// <typeparam name="T">変換対象の型。</typeparam>
    /// <param name="target">変換対象の <see cref="int"/> 。</param>
    /// <param name="throwException">例外発生時に例外を throw するか？</param>
    /// <returns>
    /// 変換結果。
    /// <para>※型変換に失敗した場合は、型ごとの規定値を返します。または、例外を発生させます。</para>
    /// </returns>
    /// <exception cref="InvalidCastException">型変換に失敗しました。</exception>
    /// <exception cref="FormatException">型変換に失敗しました。</exception>
    /// <exception cref="OverflowException">型変換に失敗しました。</exception>
    public static T To<T>(this int target, bool throwException)
    {
        return target.To<int, T>(throwException);
    }

    #endregion

    #region uint

    /// <summary>
    /// <see cref="uint"/> を型変換します。
    /// </summary>
    /// <typeparam name="T">変換対象の型。</typeparam>
    /// <param name="target">変換対象の <see cref="uint"/> 。</param>
    /// <returns>
    /// 変換結果。
    /// <para>※型変換に失敗した場合は、型ごとの規定値を返します。</para>
    /// </returns>
    public static T To<T>(this uint target)
    {
        return target.To<uint, T>();
    }

    /// <summary>
    /// <see cref="uint"/> を型変換します。（規定値指定あり）
    /// </summary>
    /// <typeparam name="T">変換対象の型。</typeparam>
    /// <param name="target">変換対象の <see cref="uint"/> 。</param>
    /// <param name="defaultValue">規定値。</param>
    /// <returns>
    /// 変換結果。
    /// <para>※型変換に失敗した場合は、指定された規定値を返します。</para>
    /// </returns>
    public static T To<T>(this uint target, T defaultValue)
    {
        return target.To<uint, T>(defaultValue);
    }

    /// <summary>
    /// <see cref="uint"/> を型変換します。（例外発生時処理指定あり）
    /// </summary>
    /// <typeparam name="T">変換対象の型。</typeparam>
    /// <param name="target">変換対象の <see cref="uint"/> 。</param>
    /// <param name="throwException">例外発生時に例外を throw するか？</param>
    /// <returns>
    /// 変換結果。
    /// <para>※型変換に失敗した場合は、型ごとの規定値を返します。または、例外を発生させます。</para>
    /// </returns>
    /// <exception cref="InvalidCastException">型変換に失敗しました。</exception>
    /// <exception cref="FormatException">型変換に失敗しました。</exception>
    /// <exception cref="OverflowException">型変換に失敗しました。</exception>
    public static T To<T>(this uint target, bool throwException)
    {
        return target.To<uint, T>(throwException);
    }

    #endregion

    #region long

    /// <summary>
    /// <see cref="long"/> を型変換します。
    /// </summary>
    /// <typeparam name="T">変換対象の型。</typeparam>
    /// <param name="target">変換対象の <see cref="long"/> 。</param>
    /// <returns>
    /// 変換結果。
    /// <para>※型変換に失敗した場合は、型ごとの規定値を返します。</para>
    /// </returns>
    public static T To<T>(this long target)
    {
        return target.To<long, T>();
    }

    /// <summary>
    /// <see cref="long"/> を型変換します。（規定値指定あり）
    /// </summary>
    /// <typeparam name="T">変換対象の型。</typeparam>
    /// <param name="target">変換対象の <see cref="long"/> 。</param>
    /// <param name="defaultValue">規定値。</param>
    /// <returns>
    /// 変換結果。
    /// <para>※型変換に失敗した場合は、指定された規定値を返します。</para>
    /// </returns>
    public static T To<T>(this long target, T defaultValue)
    {
        return target.To<long, T>(defaultValue);
    }

    /// <summary>
    /// <see cref="long"/> を型変換します。（例外発生時処理指定あり）
    /// </summary>
    /// <typeparam name="T">変換対象の型。</typeparam>
    /// <param name="target">変換対象の <see cref="long"/> 。</param>
    /// <param name="throwException">例外発生時に例外を throw するか？</param>
    /// <returns>
    /// 変換結果。
    /// <para>※型変換に失敗した場合は、型ごとの規定値を返します。または、例外を発生させます。</para>
    /// </returns>
    /// <exception cref="InvalidCastException">型変換に失敗しました。</exception>
    /// <exception cref="FormatException">型変換に失敗しました。</exception>
    /// <exception cref="OverflowException">型変換に失敗しました。</exception>
    public static T To<T>(this long target, bool throwException)
    {
        return target.To<long, T>(throwException);
    }

    #endregion

    #region ulong

    /// <summary>
    /// <see cref="ulong"/> を型変換します。
    /// </summary>
    /// <typeparam name="T">変換対象の型。</typeparam>
    /// <param name="target">変換対象の <see cref="ulong"/> 。</param>
    /// <returns>
    /// 変換結果。
    /// <para>※型変換に失敗した場合は、型ごとの規定値を返します。</para>
    /// </returns>
    public static T To<T>(this ulong target)
    {
        return target.To<ulong, T>();
    }

    /// <summary>
    /// <see cref="ulong"/> を型変換します。（規定値指定あり）
    /// </summary>
    /// <typeparam name="T">変換対象の型。</typeparam>
    /// <param name="target">変換対象の <see cref="ulong"/> 。</param>
    /// <param name="defaultValue">規定値。</param>
    /// <returns>
    /// 変換結果。
    /// <para>※型変換に失敗した場合は、指定された規定値を返します。</para>
    /// </returns>
    public static T To<T>(this ulong target, T defaultValue)
    {
        return target.To<ulong, T>(defaultValue);
    }

    /// <summary>
    /// <see cref="ulong"/> を型変換します。（例外発生時処理指定あり）
    /// </summary>
    /// <typeparam name="T">変換対象の型。</typeparam>
    /// <param name="target">変換対象の <see cref="ulong"/> 。</param>
    /// <param name="throwException">例外発生時に例外を throw するか？</param>
    /// <returns>
    /// 変換結果。
    /// <para>※型変換に失敗した場合は、型ごとの規定値を返します。または、例外を発生させます。</para>
    /// </returns>
    /// <exception cref="InvalidCastException">型変換に失敗しました。</exception>
    /// <exception cref="FormatException">型変換に失敗しました。</exception>
    /// <exception cref="OverflowException">型変換に失敗しました。</exception>
    public static T To<T>(this ulong target, bool throwException)
    {
        return target.To<ulong, T>(throwException);
    }

    #endregion

    #region short

    /// <summary>
    /// <see cref="short"/> を型変換します。
    /// </summary>
    /// <typeparam name="T">変換対象の型。</typeparam>
    /// <param name="target">変換対象の <see cref="short"/> 。</param>
    /// <returns>
    /// 変換結果。
    /// <para>※型変換に失敗した場合は、型ごとの規定値を返します。</para>
    /// </returns>
    public static T To<T>(this short target)
    {
        return target.To<short, T>();
    }

    /// <summary>
    /// <see cref="short"/> を型変換します。（規定値指定あり）
    /// </summary>
    /// <typeparam name="T">変換対象の型。</typeparam>
    /// <param name="target">変換対象の <see cref="short"/> 。</param>
    /// <param name="defaultValue">規定値。</param>
    /// <returns>
    /// 変換結果。
    /// <para>※型変換に失敗した場合は、指定された規定値を返します。</para>
    /// </returns>
    public static T To<T>(this short target, T defaultValue)
    {
        return target.To<short, T>(defaultValue);
    }

    /// <summary>
    /// <see cref="short"/> を型変換します。（例外発生時処理指定あり）
    /// </summary>
    /// <typeparam name="T">変換対象の型。</typeparam>
    /// <param name="target">変換対象の <see cref="short"/> 。</param>
    /// <param name="throwException">例外発生時に例外を throw するか？</param>
    /// <returns>
    /// 変換結果。
    /// <para>※型変換に失敗した場合は、型ごとの規定値を返します。または、例外を発生させます。</para>
    /// </returns>
    /// <exception cref="InvalidCastException">型変換に失敗しました。</exception>
    /// <exception cref="FormatException">型変換に失敗しました。</exception>
    /// <exception cref="OverflowException">型変換に失敗しました。</exception>
    public static T To<T>(this short target, bool throwException)
    {
        return target.To<short, T>(throwException);
    }

    #endregion

    #region ushort

    /// <summary>
    /// <see cref="ushort"/> を型変換します。
    /// </summary>
    /// <typeparam name="T">変換対象の型。</typeparam>
    /// <param name="target">変換対象の <see cref="ushort"/> 。</param>
    /// <returns>
    /// 変換結果。
    /// <para>※型変換に失敗した場合は、型ごとの規定値を返します。</para>
    /// </returns>
    public static T To<T>(this ushort target)
    {
        return target.To<ushort, T>();
    }

    /// <summary>
    /// <see cref="ushort"/> を型変換します。（規定値指定あり）
    /// </summary>
    /// <typeparam name="T">変換対象の型。</typeparam>
    /// <param name="target">変換対象の <see cref="ushort"/> 。</param>
    /// <param name="defaultValue">規定値。</param>
    /// <returns>
    /// 変換結果。
    /// <para>※型変換に失敗した場合は、指定された規定値を返します。</para>
    /// </returns>
    public static T To<T>(this ushort target, T defaultValue)
    {
        return target.To<ushort, T>(defaultValue);
    }

    /// <summary>
    /// <see cref="ushort"/> を型変換します。（例外発生時処理指定あり）
    /// </summary>
    /// <typeparam name="T">変換対象の型。</typeparam>
    /// <param name="target">変換対象の <see cref="ushort"/> 。</param>
    /// <param name="throwException">例外発生時に例外を throw するか？</param>
    /// <returns>
    /// 変換結果。
    /// <para>※型変換に失敗した場合は、型ごとの規定値を返します。または、例外を発生させます。</para>
    /// </returns>
    /// <exception cref="InvalidCastException">型変換に失敗しました。</exception>
    /// <exception cref="FormatException">型変換に失敗しました。</exception>
    /// <exception cref="OverflowException">型変換に失敗しました。</exception>
    public static T To<T>(this ushort target, bool throwException)
    {
        return target.To<ushort, T>(throwException);
    }

    #endregion

    #region string

    /// <summary>
    /// <see cref="string"/> を型変換します。
    /// </summary>
    /// <typeparam name="T">変換対象の型。</typeparam>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <returns>
    /// 変換結果。
    /// <para>※型変換に失敗した場合は、型ごとの規定値を返します。</para>
    /// </returns>
    public static T To<T>(this string target)
    {
        return target.To<string, T>();
    }

    /// <summary>
    /// <see cref="string"/> を型変換します。（規定値指定あり）
    /// </summary>
    /// <typeparam name="T">変換対象の型。</typeparam>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <param name="defaultValue">規定値。</param>
    /// <returns>
    /// 変換結果。
    /// <para>※型変換に失敗した場合は、指定された規定値を返します。</para>
    /// </returns>
    public static T To<T>(this string target, T defaultValue)
    {
        return target.To<string, T>(defaultValue);
    }

    /// <summary>
    /// <see cref="string"/> を型変換します。（例外発生時処理指定あり）
    /// </summary>
    /// <typeparam name="T">変換対象の型。</typeparam>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <param name="throwException">例外発生時に例外を throw するか？</param>
    /// <returns>
    /// 変換結果。
    /// <para>※型変換に失敗した場合は、型ごとの規定値を返します。または、例外を発生させます。</para>
    /// </returns>
    /// <exception cref="InvalidCastException">型変換に失敗しました。</exception>
    /// <exception cref="FormatException">型変換に失敗しました。</exception>
    /// <exception cref="OverflowException">型変換に失敗しました。</exception>
    public static T To<T>(this string target, bool throwException)
    {
        return target.To<string, T>(throwException);
    }

    #endregion

    #endregion

    #region 数値 → bool 変換

    /// <summary>
    /// <see cref="byte"/> を <see cref="bool"/> へ変換します。
    /// </summary>
    /// <param name="target">変換対象 <see cref="byte"/> 。</param>
    /// <returns>
    /// <para>
    /// [0 の場合]
    /// <see langword="false"/> を返します。
    /// </para>
    /// <para>
    /// [1 の場合]
    /// <see langword="true"/> を返します。
    /// </para>
    /// <para>
    /// [その他の場合]
    /// <see langword="false"/> を返します。
    /// </para>
    /// </returns>
    public static bool ToBool(this byte target)
    {
        return target.To<short>().ToBool();
    }

    /// <summary>
    /// <see cref="byte"/> を <see cref="Nullable"/> <see cref="bool"/> へ変換します。
    /// </summary>
    /// <param name="target">変換対象 <see cref="byte"/> 。</param>
    /// <returns>
    /// <para>
    /// [0 の場合]
    /// <see langword="false"/> を返します。
    /// </para>
    /// <para>
    /// [1 の場合]
    /// <see langword="true"/> を返します。
    /// </para>
    /// <para>
    /// [その他の場合]
    /// <see langword="null"/> を返します。
    /// </para>
    /// </returns>
    public static bool? ToNullableBool(this byte target)
    {
        return target.To<short>().ToNullableBool();
    }

    /// <summary>
    /// <see cref="short"/> を <see cref="bool"/> へ変換します。
    /// </summary>
    /// <param name="target">変換対象 <see cref="short"/> 。</param>
    /// <returns>
    /// <para>
    /// [0 の場合]
    /// <see langword="false"/> を返します。
    /// </para>
    /// <para>
    /// [1 の場合]
    /// <see langword="true"/> を返します。
    /// </para>
    /// <para>
    /// [その他の場合]
    /// <see langword="false"/> を返します。
    /// </para>
    /// </returns>
    public static bool ToBool(this short target)
    {
        return target.ToNullableBool().ToNonNullable(false);
    }

    /// <summary>
    /// <see cref="short"/> を <see cref="Nullable"/> <see cref="bool"/> へ変換します。
    /// </summary>
    /// <param name="target">変換対象 <see cref="short"/> 。</param>
    /// <returns>
    /// <para>
    /// [0 の場合]
    /// <see langword="false"/> を返します。
    /// </para>
    /// <para>
    /// [1 の場合]
    /// <see langword="true"/> を返します。
    /// </para>
    /// <para>
    /// [その他の場合]
    /// <see langword="null"/> を返します。
    /// </para>
    /// </returns>
    public static bool? ToNullableBool(this short target)
    {
        switch (target)
        {
            case 0:
                return false;
            case 1:
                return true;
            default:
                return null;
        }
    }

    #endregion

    #region Null 許容 → Null 非許容型変換

    /// <summary>
    /// <see cref="Nullable"/> <see cref="bool"/> を <see cref="bool"/> へ変換します。
    /// </summary>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <returns>変換結果。</returns>
    public static bool ToNonNullable(this bool? target)
    {
        return target.ToNonNullable<bool?, bool>();
    }

    /// <summary>
    /// <see cref="Nullable"/> <see cref="bool"/> を <see cref="bool"/> へ変換します。
    /// </summary>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <param name="defaultValue">対象が <see langword="null"/> であった場合に置き換える規定値。</param>
    /// <returns>変換結果。</returns>
    public static bool ToNonNullable(this bool? target, bool defaultValue)
    {
        return target.ToNonNullable<bool?, bool>(defaultValue);
    }

    /// <summary>
    /// <see cref="Nullable"/> <see cref="byte"/> を <see cref="byte"/> へ変換します。
    /// </summary>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <returns>変換結果。</returns>
    public static byte ToNonNullable(this byte? target)
    {
        return target.ToNonNullable<byte?, byte>();
    }

    /// <summary>
    /// <see cref="Nullable"/> <see cref="byte"/> を <see cref="byte"/> へ変換します。
    /// </summary>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <param name="defaultValue">対象が <see langword="null"/> であった場合に置き換える規定値。</param>
    /// <returns>変換結果。</returns>
    public static byte ToNonNullable(this byte? target, byte defaultValue)
    {
        return target.ToNonNullable<byte?, byte>(defaultValue);
    }

    /// <summary>
    /// <see cref="Nullable"/> <see cref="sbyte"/> を <see cref="sbyte"/> へ変換します。
    /// </summary>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <returns>変換結果。</returns>
    public static sbyte ToNonNullable(this sbyte? target)
    {
        return target.ToNonNullable<sbyte?, sbyte>();
    }

    /// <summary>
    /// <see cref="Nullable"/> <see cref="sbyte"/> を <see cref="sbyte"/> へ変換します。
    /// </summary>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <param name="defaultValue">対象が <see langword="null"/> であった場合に置き換える規定値。</param>
    /// <returns>変換結果。</returns>
    public static sbyte ToNonNullable(this sbyte? target, sbyte defaultValue)
    {
        return target.ToNonNullable<sbyte?, sbyte>(defaultValue);
    }

    /// <summary>
    /// <see cref="Nullable"/> <see cref="char"/> を <see cref="char"/> へ変換します。
    /// </summary>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <returns>変換結果。</returns>
    public static char ToNonNullable(this char? target)
    {
        return target.ToNonNullable<char?, char>();
    }

    /// <summary>
    /// <see cref="Nullable"/> <see cref="char"/> を <see cref="char"/> へ変換します。
    /// </summary>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <param name="defaultValue">対象が <see langword="null"/> であった場合に置き換える規定値。</param>
    /// <returns>変換結果。</returns>
    public static char ToNonNullable(this char? target, char defaultValue)
    {
        return target.ToNonNullable<char?, char>(defaultValue);
    }

    /// <summary>
    /// <see cref="Nullable"/> <see cref="decimal"/> を <see cref="decimal"/> へ変換します。
    /// </summary>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <returns>変換結果。</returns>
    public static decimal ToNonNullable(this decimal? target)
    {
        return target.ToNonNullable<decimal?, decimal>();
    }

    /// <summary>
    /// <see cref="Nullable"/> <see cref="decimal"/> を <see cref="decimal"/> へ変換します。
    /// </summary>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <param name="defaultValue">対象が <see langword="null"/> であった場合に置き換える規定値。</param>
    /// <returns>変換結果。</returns>
    public static decimal ToNonNullable(this decimal? target, decimal defaultValue)
    {
        return target.ToNonNullable<decimal?, decimal>(defaultValue);
    }

    /// <summary>
    /// <see cref="Nullable"/> <see cref="double"/> を <see cref="double"/> へ変換します。
    /// </summary>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <returns>変換結果。</returns>
    public static double ToNonNullable(this double? target)
    {
        return target.ToNonNullable<double?, double>();
    }

    /// <summary>
    /// <see cref="Nullable"/> <see cref="double"/> を <see cref="double"/> へ変換します。
    /// </summary>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <param name="defaultValue">対象が <see langword="null"/> であった場合に置き換える規定値。</param>
    /// <returns>変換結果。</returns>
    public static double ToNonNullable(this double? target, double defaultValue)
    {
        return target.ToNonNullable<double?, double>(defaultValue);
    }

    /// <summary>
    /// <see cref="Nullable"/> <see cref="float"/> を <see cref="float"/> へ変換します。
    /// </summary>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <returns>変換結果。</returns>
    public static float ToNonNullable(this float? target)
    {
        return target.ToNonNullable<float?, float>();
    }

    /// <summary>
    /// <see cref="Nullable"/> <see cref="float"/> を <see cref="float"/> へ変換します。
    /// </summary>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <param name="defaultValue">対象が <see langword="null"/> であった場合に置き換える規定値。</param>
    /// <returns>変換結果。</returns>
    public static float ToNonNullable(this float? target, float defaultValue)
    {
        return target.ToNonNullable<float?, float>(defaultValue);
    }

    /// <summary>
    /// <see cref="Nullable"/> <see cref="int"/> を <see cref="int"/> へ変換します。
    /// </summary>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <returns>変換結果。</returns>
    public static int ToNonNullable(this int? target)
    {
        return target.ToNonNullable<int?, int>();
    }

    /// <summary>
    /// <see cref="Nullable"/> <see cref="int"/> を <see cref="int"/> へ変換します。
    /// </summary>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <param name="defaultValue">対象が <see langword="null"/> であった場合に置き換える規定値。</param>
    /// <returns>変換結果。</returns>
    public static int ToNonNullable(this int? target, int defaultValue)
    {
        return target.ToNonNullable<int?, int>(defaultValue);
    }

    /// <summary>
    /// <see cref="Nullable"/> <see cref="uint"/> を <see cref="uint"/> へ変換します。
    /// </summary>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <returns>変換結果。</returns>
    public static uint ToNonNullable(this uint? target)
    {
        return target.ToNonNullable<uint?, uint>();
    }

    /// <summary>
    /// <see cref="Nullable"/> <see cref="uint"/> を <see cref="uint"/> へ変換します。
    /// </summary>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <param name="defaultValue">対象が <see langword="null"/> であった場合に置き換える規定値。</param>
    /// <returns>変換結果。</returns>
    public static uint ToNonNullable(this uint? target, uint defaultValue)
    {
        return target.ToNonNullable<uint?, uint>(defaultValue);
    }

    /// <summary>
    /// <see cref="Nullable"/> <see cref="long"/> を <see cref="long"/> へ変換します。
    /// </summary>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <returns>変換結果。</returns>
    public static long ToNonNullable(this long? target)
    {
        return target.ToNonNullable<long?, long>();
    }

    /// <summary>
    /// <see cref="Nullable"/> <see cref="long"/> を <see cref="long"/> へ変換します。
    /// </summary>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <param name="defaultValue">対象が <see langword="null"/> であった場合に置き換える規定値。</param>
    /// <returns>変換結果。</returns>
    public static long ToNonNullable(this long? target, long defaultValue)
    {
        return target.ToNonNullable<long?, long>(defaultValue);
    }

    /// <summary>
    /// <see cref="Nullable"/> <see cref="ulong"/> を <see cref="ulong"/> へ変換します。
    /// </summary>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <returns>変換結果。</returns>
    public static ulong ToNonNullable(this ulong? target)
    {
        return target.ToNonNullable<ulong?, ulong>();
    }

    /// <summary>
    /// <see cref="Nullable"/> <see cref="ulong"/> を <see cref="ulong"/> へ変換します。
    /// </summary>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <param name="defaultValue">対象が <see langword="null"/> であった場合に置き換える規定値。</param>
    /// <returns>変換結果。</returns>
    public static ulong ToNonNullable(this ulong? target, ulong defaultValue)
    {
        return target.ToNonNullable<ulong?, ulong>(defaultValue);
    }

    /// <summary>
    /// <see cref="Nullable"/> <see cref="short"/> を <see cref="short"/> へ変換します。
    /// </summary>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <returns>変換結果。</returns>
    public static short ToNonNullable(this short? target)
    {
        return target.ToNonNullable<short?, short>();
    }

    /// <summary>
    /// <see cref="Nullable"/> <see cref="short"/> を <see cref="short"/> へ変換します。
    /// </summary>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <param name="defaultValue">対象が <see langword="null"/> であった場合に置き換える規定値。</param>
    /// <returns>変換結果。</returns>
    public static short ToNonNullable(this short? target, short defaultValue)
    {
        return target.ToNonNullable<short?, short>(defaultValue);
    }

    /// <summary>
    /// <see cref="Nullable"/> <see cref="ushort"/> を <see cref="ushort"/> へ変換します。
    /// </summary>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <returns>変換結果。</returns>
    public static ushort ToNonNullable(this ushort? target)
    {
        return target.ToNonNullable<ushort?, ushort>();
    }

    /// <summary>
    /// <see cref="Nullable"/> <see cref="ushort"/> を <see cref="ushort"/> へ変換します。
    /// </summary>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <param name="defaultValue">対象が <see langword="null"/> であった場合に置き換える規定値。</param>
    /// <returns>変換結果。</returns>
    public static ushort ToNonNullable(this ushort? target, ushort defaultValue)
    {
        return target.ToNonNullable<ushort?, ushort>(defaultValue);
    }

    /// <summary>
    /// <see langword="null"/> を <see cref="string.Empty"/> に置き換えます。
    /// </summary>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <returns>変換結果。</returns>
    public static string ToNonNullable(this string target)
    {
        return target.ToNonNullable(string.Empty);
    }

    /// <summary>
    /// <see langword="null"/> を規定値に置き換えます。
    /// </summary>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <param name="defaultValue">対象が <see langword="null"/> であった場合に置き換える規定値。</param>
    /// <returns>変換結果。</returns>
    public static string ToNonNullable(this string target, string defaultValue)
    {
        return target.ToNonNullable<string, string>(defaultValue);
    }

    /// <summary>
    /// <see cref="Nullable"/> <see cref="DateTime"/> を <see cref="DateTime"/> へ変換します。
    /// </summary>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <param name="defaultValue">対象が <see langword="null"/> であった場合に置き換える規定値。</param>
    /// <returns>変換結果。</returns>
    /// <remarks>
    /// 日付の規定値を一概には決められないため、規定値指定なしバージョンは設けません。
    /// 必要に応じ、各プロジェクトの独自 Framework にて対応して下さい。
    /// </remarks>
    public static DateTime ToNonNullable(this DateTime? target, DateTime defaultValue)
    {
        return target.ToNonNullable<DateTime?, DateTime>(defaultValue);
    }

    #endregion

    #region Null 許容 → 文字列変換

    /// <summary>
    /// <see cref="Nullable"/> <see cref="decimal"/> を <see cref="string"/> へ変換します。
    /// </summary>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <param name="nullValues">Null として扱う値。</param>
    /// <returns>変換結果。</returns>
    public static string ToString(this decimal? target, params decimal[] nullValues)
    {
        return target.ToString<decimal?, decimal>(nullValues);
    }

    /// <summary>
    /// <see cref="Nullable"/> <see cref="decimal"/> を <see cref="string"/> へ変換します。
    /// </summary>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <param name="defaultValue">対象が <see langword="null"/> であった場合に置き換える <see cref="string"/> 型の規定値。</param>
    /// <param name="nullValues">Null として扱う値。</param>
    /// <returns>変換結果。</returns>
    public static string ToString(this decimal? target, string defaultValue, params decimal[] nullValues)
    {
        return target.ToString<decimal?, decimal>(defaultValue, nullValues);
    }

    /// <summary>
    /// <see cref="Nullable"/> <see cref="double"/> を <see cref="string"/> へ変換します。
    /// </summary>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <param name="nullValues">Null として扱う値。</param>
    /// <returns>変換結果。</returns>
    public static string ToString(this double? target, params double[] nullValues)
    {
        return target.ToString<double?, double>(nullValues);
    }

    /// <summary>
    /// <see cref="Nullable"/> <see cref="double"/> を <see cref="string"/> へ変換します。
    /// </summary>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <param name="defaultValue">対象が <see langword="null"/> であった場合に置き換える <see cref="string"/> 型の規定値。</param>
    /// <param name="nullValues">Null として扱う値。</param>
    /// <returns>変換結果。</returns>
    public static string ToString(this double? target, string defaultValue, params double[] nullValues)
    {
        return target.ToString<double?, double>(defaultValue, nullValues);
    }

    /// <summary>
    /// <see cref="Nullable"/> <see cref="float"/> を <see cref="string"/> へ変換します。
    /// </summary>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <param name="nullValues">Null として扱う値。</param>
    /// <returns>変換結果。</returns>
    public static string ToString(this float? target, params float[] nullValues)
    {
        return target.ToString<float?, float>(nullValues);
    }

    /// <summary>
    /// <see cref="Nullable"/> <see cref="float"/> を <see cref="string"/> へ変換します。
    /// </summary>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <param name="defaultValue">対象が <see langword="null"/> であった場合に置き換える <see cref="string"/> 型の規定値。</param>
    /// <param name="nullValues">Null として扱う値。</param>
    /// <returns>変換結果。</returns>
    public static string ToString(this float? target, string defaultValue, params float[] nullValues)
    {
        return target.ToString<float?, float>(defaultValue, nullValues);
    }

    /// <summary>
    /// <see cref="Nullable"/> <see cref="int"/> を <see cref="string"/> へ変換します。
    /// </summary>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <param name="nullValues">Null として扱う値。</param>
    /// <returns>変換結果。</returns>
    public static string ToString(this int? target, params int[] nullValues)
    {
        return target.ToString<int?, int>(nullValues);
    }

    /// <summary>
    /// <see cref="Nullable"/> <see cref="int"/> を <see cref="string"/> へ変換します。
    /// </summary>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <param name="defaultValue">対象が <see langword="null"/> であった場合に置き換える <see cref="string"/> 型の規定値。</param>
    /// <param name="nullValues">Null として扱う値。</param>
    /// <returns>変換結果。</returns>
    public static string ToString(this int? target, string defaultValue, params int[] nullValues)
    {
        return target.ToString<int?, int>(defaultValue, nullValues);
    }

    /// <summary>
    /// <see cref="Nullable"/> <see cref="uint"/> を <see cref="string"/> へ変換します。
    /// </summary>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <param name="nullValues">Null として扱う値。</param>
    /// <returns>変換結果。</returns>
    public static string ToString(this uint? target, params uint[] nullValues)
    {
        return target.ToString<uint?, uint>(nullValues);
    }

    /// <summary>
    /// <see cref="Nullable"/> <see cref="uint"/> を <see cref="string"/> へ変換します。
    /// </summary>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <param name="defaultValue">対象が <see langword="null"/> であった場合に置き換える <see cref="string"/> 型の規定値。</param>
    /// <param name="nullValues">Null として扱う値。</param>
    /// <returns>変換結果。</returns>
    public static string ToString(this uint? target, string defaultValue, params uint[] nullValues)
    {
        return target.ToString<uint?, uint>(defaultValue, nullValues);
    }

    /// <summary>
    /// <see cref="Nullable"/> <see cref="long"/> を <see cref="string"/> へ変換します。
    /// </summary>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <param name="nullValues">Null として扱う値。</param>
    /// <returns>変換結果。</returns>
    public static string ToString(this long? target, params long[] nullValues)
    {
        return target.ToString<long?, long>(nullValues);
    }

    /// <summary>
    /// <see cref="Nullable"/> <see cref="long"/> を <see cref="string"/> へ変換します。
    /// </summary>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <param name="defaultValue">対象が <see langword="null"/> であった場合に置き換える <see cref="string"/> 型の規定値。</param>
    /// <param name="nullValues">Null として扱う値。</param>
    /// <returns>変換結果。</returns>
    public static string ToString(this long? target, string defaultValue, params long[] nullValues)
    {
        return target.ToString<long?, long>(defaultValue, nullValues);
    }

    /// <summary>
    /// <see cref="Nullable"/> <see cref="ulong"/> を <see cref="string"/> へ変換します。
    /// </summary>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <param name="nullValues">Null として扱う値。</param>
    /// <returns>変換結果。</returns>
    public static string ToString(this ulong? target, params ulong[] nullValues)
    {
        return target.ToString<ulong?, ulong>(nullValues);
    }

    /// <summary>
    /// <see cref="Nullable"/> <see cref="ulong"/> を <see cref="string"/> へ変換します。
    /// </summary>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <param name="defaultValue">対象が <see langword="null"/> であった場合に置き換える <see cref="string"/> 型の規定値。</param>
    /// <param name="nullValues">Null として扱う値。</param>
    /// <returns>変換結果。</returns>
    public static string ToString(this ulong? target, string defaultValue, params ulong[] nullValues)
    {
        return target.ToString<ulong?, ulong>(defaultValue, nullValues);
    }

    /// <summary>
    /// <see cref="Nullable"/> <see cref="short"/> を <see cref="string"/> へ変換します。
    /// </summary>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <param name="nullValues">Null として扱う値。</param>
    /// <returns>変換結果。</returns>
    public static string ToString(this short? target, params short[] nullValues)
    {
        return target.ToString<short?, short>(nullValues);
    }

    /// <summary>
    /// <see cref="Nullable"/> <see cref="short"/> を <see cref="string"/> へ変換します。
    /// </summary>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <param name="defaultValue">対象が <see langword="null"/> であった場合に置き換える <see cref="string"/> 型の規定値。</param>
    /// <param name="nullValues">Null として扱う値。</param>
    /// <returns>変換結果。</returns>
    public static string Totring(this short? target, string defaultValue, params short[] nullValues)
    {
        return target.ToString<short?, short>(defaultValue, nullValues);
    }

    /// <summary>
    /// <see cref="Nullable"/> <see cref="short"/> を <see cref="string"/> へ変換します。
    /// </summary>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <param name="nullValues">Null として扱う値。</param>
    /// <returns>変換結果。</returns>
    public static string ToString(this ushort? target, params ushort[] nullValues)
    {
        return target.ToString<ushort?, ushort>(nullValues);
    }

    /// <summary>
    /// <see cref="Nullable"/> <see cref="short"/> を <see cref="string"/> へ変換します。
    /// </summary>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <param name="defaultValue">対象が <see langword="null"/> であった場合に置き換える <see cref="string"/> 型の規定値。</param>
    /// <param name="nullValues">Null として扱う値。</param>
    /// <returns>変換結果。</returns>
    public static string ToString(this ushort? target, string defaultValue, params ushort[] nullValues)
    {
        return target.ToString<ushort?, ushort>(defaultValue, nullValues);
    }

    /// <summary>
    /// <see cref="Nullable"/> <see cref="DateTime"/> を <see cref="string"/> へ変換します。
    /// </summary>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <param name="provider">プロバイダー。</param>
    /// <param name="nullValues">Null として扱う値。</param>
    /// <returns>変換結果。</returns>
    public static string ToString(this DateTime? target, IFormatProvider provider, params DateTime[] nullValues)
    {
        return target.ToString(provider, string.Empty, nullValues);
    }

    /// <summary>
    /// <see cref="Nullable"/> <see cref="DateTime"/> を <see cref="string"/> へ変換します。
    /// </summary>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <param name="provider">プロバイダー。</param>
    /// <param name="defaultValue">対象が <see langword="null"/> であった場合に置き換える <see cref="string"/> 型の規定値。</param>
    /// <param name="nullValues">Null として扱う値。</param>
    /// <returns>変換結果。</returns>
    public static string ToString(this DateTime? target, IFormatProvider provider, string defaultValue, params DateTime[] nullValues)
    {
        var list = new List<DateTime>(nullValues);

        return target.HasValue && !list.Contains(target.Value) ?
            target.Value.ToString(provider) :
            defaultValue;
    }

    /// <summary>
    /// <see cref="Nullable"/> <see cref="DateTime"/> を <see cref="string"/> へ変換します。
    /// </summary>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <param name="format">フォーマット。</param>
    /// <param name="nullValues">Null として扱う値。</param>
    /// <returns>変換結果。</returns>
    public static string ToString(this DateTime? target, string format, params DateTime[] nullValues)
    {
        return target.ToString(format, string.Empty, nullValues);
    }

    /// <summary>
    /// <see cref="Nullable"/> <see cref="DateTime"/> を <see cref="string"/> へ変換します。
    /// </summary>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <param name="format">フォーマット。</param>
    /// <param name="defaultValue">対象が <see langword="null"/> であった場合に置き換える <see cref="string"/> 型の規定値。</param>
    /// <param name="nullValues">Null として扱う値。</param>
    /// <returns>変換結果。</returns>
    public static string ToString(this DateTime? target, string format, string defaultValue, params DateTime[] nullValues)
    {
        var list = new List<DateTime>(nullValues);

        return target.HasValue && !list.Contains(target.Value) ?
            target.Value.ToString(format) :
            defaultValue;
    }

    /// <summary>
    /// <see cref="Nullable"/> <see cref="DateTime"/> を <see cref="string"/> へ変換します。
    /// </summary>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <param name="format">フォーマット。</param>
    /// <param name="provider">プロバイダー。</param>
    /// <param name="nullValues">Null として扱う値。</param>
    /// <returns>変換結果。</returns>
    public static string ToString(this DateTime? target, string format, IFormatProvider provider, params DateTime[] nullValues)
    {
        return target.ToString(format, provider, string.Empty, nullValues);
    }

    /// <summary>
    /// <see cref="Nullable"/> <see cref="DateTime"/> を <see cref="string"/> へ変換します。
    /// </summary>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <param name="format">フォーマット。</param>
    /// <param name="provider">プロバイダー。</param>
    /// <param name="defaultValue">対象が <see langword="null"/> であった場合に置き換える <see cref="string"/> 型の規定値。</param>
    /// <param name="nullValues">Null として扱う値。</param>
    /// <returns>変換結果。</returns>
    public static string ToString(this DateTime? target, string format, IFormatProvider provider, string defaultValue, params DateTime[] nullValues)
    {
        var list = new List<DateTime>(nullValues);

        return target.HasValue && !list.Contains(target.Value) ?
            target.Value.ToString(format, provider) :
            defaultValue;
    }

    #endregion

    #region Null 非許容 → Null 許容型変換

    /// <summary>
    /// <see cref="bool"/> を <see cref="Nullable"/> へ変換します。
    /// </summary>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <param name="nullValues">Null として扱う値。</param>
    /// <returns>変換結果。</returns>
    public static bool? ToNullable(this bool target, params bool[] nullValues)
    {
        return target.ToNullable<bool, bool?>(nullValues);
    }

    /// <summary>
    /// <see cref="byte"/> を <see cref="Nullable"/> へ変換します。
    /// </summary>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <param name="nullValues">Null として扱う値。</param>
    /// <returns>変換結果。</returns>
    public static byte? ToNullable(this byte target, params byte[] nullValues)
    {
        return target.ToNullable<byte, byte?>(nullValues);
    }

    /// <summary>
    /// <see cref="sbyte"/> を <see cref="Nullable"/> へ変換します。
    /// </summary>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <param name="nullValues">Null として扱う値。</param>
    /// <returns>変換結果。</returns>
    public static sbyte? ToNullable(this sbyte target, params sbyte[] nullValues)
    {
        return target.ToNullable<sbyte, sbyte?>(nullValues);
    }

    /// <summary>
    /// <see cref="char"/> を <see cref="Nullable"/> へ変換します。
    /// </summary>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <param name="nullValues">Null として扱う値。</param>
    /// <returns>変換結果。</returns>
    public static char? ToNullable(this char target, params char[] nullValues)
    {
        return target.ToNullable<char, char?>(nullValues);
    }

    /// <summary>
    /// <see cref="decimal"/> を <see cref="Nullable"/> へ変換します。
    /// </summary>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <param name="nullValues">Null として扱う値。</param>
    /// <returns>変換結果。</returns>
    public static decimal? ToNullable(this decimal target, params decimal[] nullValues)
    {
        return target.ToNullable<decimal, decimal?>(nullValues);
    }

    /// <summary>
    /// <see cref="double"/> を <see cref="Nullable"/> へ変換します。
    /// </summary>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <param name="nullValues">Null として扱う値。</param>
    /// <returns>変換結果。</returns>
    public static double? ToNullable(this double target, params double[] nullValues)
    {
        return target.ToNullable<double, double?>(nullValues);
    }

    /// <summary>
    /// <see cref="float"/> を <see cref="Nullable"/> へ変換します。
    /// </summary>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <param name="nullValues">Null として扱う値。</param>
    /// <returns>変換結果。</returns>
    public static float? ToNullable(this float target, params float[] nullValues)
    {
        return target.ToNullable<float, float?>(nullValues);
    }

    /// <summary>
    /// <see cref="int"/> を <see cref="Nullable"/> へ変換します。
    /// </summary>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <param name="nullValues">Null として扱う値。</param>
    /// <returns>変換結果。</returns>
    public static int? ToNullable(this int target, params int[] nullValues)
    {
        return target.ToNullable<int, int?>(nullValues);
    }

    /// <summary>
    /// <see cref="uint"/> を <see cref="Nullable"/> へ変換します。
    /// </summary>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <param name="nullValues">Null として扱う値。</param>
    /// <returns>変換結果。</returns>
    public static uint? ToNullable(this uint target, params uint[] nullValues)
    {
        return target.ToNullable<uint, uint?>(nullValues);
    }

    /// <summary>
    /// <see cref="long"/> を <see cref="Nullable"/> へ変換します。
    /// </summary>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <param name="nullValues">Null として扱う値。</param>
    /// <returns>変換結果。</returns>
    public static long? ToNullable(this long target, params long[] nullValues)
    {
        return target.ToNullable<long, long?>(nullValues);
    }

    /// <summary>
    /// <see cref="ulong"/> を <see cref="Nullable"/> へ変換します。
    /// </summary>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <param name="nullValues">Null として扱う値。</param>
    /// <returns>変換結果。</returns>
    public static ulong? ToNullable(this ulong target, params ulong[] nullValues)
    {
        return target.ToNullable<ulong, ulong>(nullValues);
    }

    /// <summary>
    /// <see cref="short"/> を <see cref="Nullable"/> へ変換します。
    /// </summary>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <param name="nullValues">Null として扱う値。</param>
    /// <returns>変換結果。</returns>
    public static short? ToNullable(this short target, params short[] nullValues)
    {
        return target.ToNullable<short, short?>(nullValues);
    }

    /// <summary>
    /// <see cref="ushort"/> を <see cref="Nullable"/> へ変換します。
    /// </summary>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <param name="nullValues">Null として扱う値。</param>
    /// <returns>変換結果。</returns>
    public static ushort? ToNullable(this ushort target, params ushort[] nullValues)
    {
        return target.ToNullable<ushort, ushort?>(nullValues);
    }

    /// <summary>
    /// <see cref="string"/> を <see langword="null"/> 許容値へ変換します。
    /// </summary>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <returns>変換結果。</returns>
    public static string ToNullable(this string target)
    {
        return target.ToNullable(false);
    }

    /// <summary>
    /// <see cref="string"/> を <see langword="null"/> 許容値へ変換します。
    /// </summary>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <param name="allowsEmpty">空文字を許容するか？</param>
    /// <returns>変換結果。</returns>
    public static string ToNullable(this string target, bool allowsEmpty)
    {
        if (!allowsEmpty)
        {
            return string.IsNullOrWhiteSpace(target) ?
                null :
                target;
        }
        else
        {
            return target;
        }
    }

    /// <summary>
    /// <see cref="DateTime"/> を <see cref="Nullable"/> へ変換します。
    /// </summary>
    /// <param name="target">変換対象の <see cref="string"/> 。</param>
    /// <param name="nullValues">Null として扱う値。</param>
    /// <returns>変換結果。</returns>
    public static DateTime? ToNullable(this DateTime target, params DateTime[] nullValues)
    {
        return target.ToNullable<DateTime, DateTime?>(nullValues);
    }

    #endregion

    #region 標準 → DB Null 許容変換

    /// <summary>
    /// 自身を <see cref="DBNull"/> 許容の <see cref="object"/> へ変換します。
    /// </summary>
    /// <typeparam name="T">変換対象の型。</typeparam>
    /// <param name="target">変換対象。</param>
    /// <param name="nullValues">Null として扱う値。</param>
    /// <returns>変換結果。</returns>
    public static object ToDBNullable<T>(this T target, params T[] nullValues)
    {
        var list = new List<T>(nullValues);

        if (target == null ||
            list.Contains(target))
        {
            return DBNull.Value;
        }
        else
        {
            return target;
        }
    }

    #endregion

    #region private

    /// <summary>
    /// 対象を型変換します。
    /// </summary>
    /// <typeparam name="TFrom">変換元の型。</typeparam>
    /// <typeparam name="TTo">変換結果の型。</typeparam>
    /// <param name="target">変換対象 。</param>
    /// <returns>
    /// 変換結果。
    /// <para>※型変換に失敗した場合は、型ごとの規定値を返します。</para>
    /// </returns>
    /// <remarks>
    /// <see cref="To{TFrom, TTo}(TFrom, TTo)"/> を使用します。
    /// 未設定の引数には、一律デフォルト値を設定します。
    /// 乱用を避けるため、外部へは公開しません。
    /// </remarks>
    private static TTo To<TFrom, TTo>(this TFrom target)
    {
        return target.To(default(TTo));
    }

    /// <summary>
    /// 対象を型変換します。（規定値指定あり）
    /// </summary>
    /// <typeparam name="TFrom">変換元の型。</typeparam>
    /// <typeparam name="TTo">変換結果の型。</typeparam>
    /// <param name="target">変換対象。</param>
    /// <param name="defaultValue">規定値。</param>
    /// <returns>
    /// 変換結果。
    /// <para>※型変換に失敗した場合は、指定された規定値を返します。</para>
    /// </returns>
    /// <remarks>
    /// <see cref="To{TFrom, TTo}(TFrom, TTo, bool)"/>
    /// 未設定の引数には、一律デフォルト値を設定します。
    /// 乱用を避けるため、外部へは公開しません。
    /// </remarks>
    private static TTo To<TFrom, TTo>(this TFrom target, TTo defaultValue)
    {
        return target.To(defaultValue, false);
    }

    /// <summary>
    /// 対象を型変換します。（例外発生時処理指定あり）
    /// </summary>
    /// <typeparam name="TFrom">変換元の型。</typeparam>
    /// <typeparam name="TTo">変換結果の型。</typeparam>
    /// <param name="target">変換対象。</param>
    /// <param name="throwException">例外発生時に例外を throw するか？</param>
    /// <returns>
    /// 変換結果。
    /// <para>※型変換に失敗した場合は、型ごとの規定値を返します。または、例外を発生させます。</para>
    /// </returns>
    /// <exception cref="InvalidCastException">型変換に失敗しました。</exception>
    /// <exception cref="FormatException">型変換に失敗しました。</exception>
    /// <exception cref="OverflowException">型変換に失敗しました。</exception>
    /// <remarks>
    /// <see cref="To{TFrom, TTo}(TFrom, TTo, bool)"/> を使用します。
    /// 未設定の引数には、一律デフォルト値を設定します。
    /// 乱用を避けるため、外部へは公開しません。
    /// </remarks>
    private static TTo To<TFrom, TTo>(this TFrom target, bool throwException)
    {
        return target.To(default(TTo), throwException);
    }

    /// <summary>
    /// 対象を型変換します。（規定値、例外発生時処理指定あり）
    /// </summary>
    /// <typeparam name="TFrom">変換元の型。</typeparam>
    /// <typeparam name="TTo">変換結果の型。</typeparam>
    /// <param name="target">変換対象。</param>
    /// <param name="defaultValue">規定値。</param>
    /// <param name="throwException">例外発生時に例外を throw するか？</param>
    /// <returns>
    /// 変換結果。
    /// <para>※型変換に失敗した場合は、指定された規定値を返します。または、例外を発生させます。</para>
    /// </returns>
    /// <exception cref="InvalidCastException">型変換に失敗しました。</exception>
    /// <exception cref="FormatException">型変換に失敗しました。</exception>
    /// <exception cref="OverflowException">型変換に失敗しました。</exception>
    /// <remarks>
    /// <see cref="Convert.ChangeType(object, Type)"/> を使用して型変換を行います。
    /// <see cref="InvalidCastException"/>, <see cref="FormatException"/>, <see cref="OverflowException"/> が発生した場合の処理は、パラメーターに応じ切り替えられます。
    /// （例外を <see langword="throw"/> するようパラメーターで指定されている場合は throw し、それ以外は指定されたデフォルト値を指定します。）
    /// 乱用を避けるため、外部へは公開しません。
    /// </remarks>
    private static TTo To<TFrom, TTo>(this TFrom target, TTo defaultValue, bool throwException)
    {
        var t = typeof(TTo);
        t = Nullable.GetUnderlyingType(t) ?? t;

        try
        {
            return target == null || DBNull.Value.Equals(target) ?
               defaultValue :
               (TTo)Convert.ChangeType(target, t);
        }
        catch (Exception ex) when (
            !throwException &&
            (ex is InvalidCastException || ex is FormatException || ex is OverflowException))
        {
            return defaultValue;
        }
    }

    /// <summary>
    /// 対象を <see langword="null"/> 非許容の指定型へ変換します。
    /// </summary>
    /// <typeparam name="TNullable">変換元の型。</typeparam>
    /// <typeparam name="TNonNullable">変換結果の型。</typeparam>
    /// <param name="target">変換対象。</param>
    /// <returns>変換結果。</returns>
    /// <exception cref="InvalidCastException">型変換に失敗しました。</exception>
    /// <remarks>
    /// <see cref="ToNonNullable{TNullable, TNonNullable}(TNullable, TNonNullable)"/> を使用します。
    /// デフォルト値には、型ごとのデフォルト値を設定します。
    /// 乱用を避けるため、外部へは公開しません。
    /// </remarks>
    private static TNonNullable ToNonNullable<TNullable, TNonNullable>(this TNullable target)
    {
        return target.ToNonNullable(default(TNonNullable));
    }

    /// <summary>
    /// 対象を <see langword="null"/> 非許容の指定型へ変換します。（デフォルト値指定あり）
    /// </summary>
    /// <typeparam name="TNullable">変換元の型。</typeparam>
    /// <typeparam name="TNonNullable">変換結果の型。</typeparam>
    /// <param name="target">変換対象。</param>
    /// <param name="defaultValue">対象が <see langword="null"/> であった場合に置き換える規定値。</param>
    /// <returns>変換結果。</returns>
    /// <exception cref="InvalidCastException">型変換に失敗しました。</exception>
    /// <remarks>
    /// 対象が <see langword="null"/> でない場合、対象を <see lagnword="null"/> 非許容に変換した値を返します。
    /// その他の場合は、デフォルト値を返します。
    /// 乱用を避けるため、外部へは公開しません。
    /// </remarks>
    private static TNonNullable ToNonNullable<TNullable, TNonNullable>(this TNullable target, TNonNullable defaultValue)
    {
        return target != null ?
            target.To<TNullable, TNonNullable>() :
            defaultValue;
    }

    /// <summary>
    /// 対象を <see cref="string"/> へ変換します。
    /// </summary>
    /// <typeparam name="TNullable">変換元の型。</typeparam>
    /// <typeparam name="TNonNullable">変換元の型（Null 非許容）。</typeparam>
    /// <param name="target">変換対象。</param>
    /// <param name="nullValues">Null として扱う値。</param>
    /// <returns>変換結果。</returns>
    /// <exception cref="InvalidCastException">型変換に失敗しました。</exception>
    /// <remarks>
    /// <see cref="ToString{TNullable, TNonNullable}(TNullable, string, TNonNullable[])"/> を使用します。
    /// デフォルト値には、 <see cref="string.Empty"/> を指定します。
    /// 乱用を避けるため、外部へは公開しません。
    /// </remarks>
    private static string ToString<TNullable, TNonNullable>(this TNullable target, params TNonNullable[] nullValues)
    {
        return target.ToString(string.Empty, nullValues);
    }

    /// <summary>
    /// 対象を <see cref="string"/> へ変換します。（デフォルト値指定あり）
    /// </summary>
    /// <typeparam name="TNullable">変換元の型。</typeparam>
    /// <typeparam name="TNonNullable">変換元の型（Null 非許容）。</typeparam>
    /// <param name="target">変換対象。</param>
    /// <param name="defaultValue">対象が <see langword="null"/> であった場合に置き換える <see cref="string"/> 型の規定値。</param>
    /// <param name="nullValues">Null として扱う値。</param>
    /// <returns>変換結果。</returns>
    /// <exception cref="InvalidCastException">型変換に失敗しました。</exception>
    /// <remarks>
    /// 対象が <see langword="null"/> でない場合かつ <see langword="null"/> として扱う値に含まれていない場合、対象を <see cref="string"/> 化したものを返します。
    /// その他の場合は、デフォルト値を返します。
    /// 乱用を避けるため、外部へは公開しません。
    /// </remarks>
    private static string ToString<TNullable, TNonNullable>(this TNullable target, string defaultValue, params TNonNullable[] nullValues)
    {
        var list = new List<TNonNullable>(nullValues);

        return target != null && !list.Contains(target.ToNonNullable<TNullable, TNonNullable>()) ?
            target.ToString() :
            defaultValue;
    }

    /// <summary>
    /// 対象を <see cref="Nullable"/> へ変換します。
    /// </summary>
    /// <typeparam name="TNonNullable">変換元の型。</typeparam>
    /// <typeparam name="TNullable">変換結果の型。</typeparam>
    /// <param name="target">変換対象。</param>
    /// <param name="nullValues">Null として扱う値。</param>
    /// <returns>変換結果。</returns>
    /// <exception cref="InvalidCastException">型変換に失敗しました。</exception>
    /// <remarks>
    /// 対象が <see langword="null"/> として扱う値に含まれている場合、デフォルト値を返します。
    /// その他の場合、対象を <see langword="null"/> 非許容化した値を返します。
    /// 乱用を避けるため、外部へは公開しません。
    /// </remarks>
    private static TNullable ToNullable<TNonNullable, TNullable>(this TNonNullable target, params TNonNullable[] nullValues)
    {
        var list = new List<TNonNullable>(nullValues);

        return list.Contains(target) ?
            default(TNullable) :
            target.ToNonNullable<TNonNullable, TNullable>();
    }

    #endregion
}