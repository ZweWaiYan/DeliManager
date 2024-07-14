// =============================================================================
// <summary>
// 型判定拡張メソッド定義クラスです。
// </summary>
// <copyright file="TypingExtension.cs" company="Works">
// Copyright(C) Works Co.,Ltd.
// </copyright>
// <author>
// naoki.tahara
// </author>
// =============================================================================

using System;

/// <summary>
/// 型判定拡張メソッド定義クラスです。
/// </summary>
public static class TypingExtension
{
    /// <summary>
    /// <see cref="object"/> が指定された型であるか（変換可能であるか）判定します。
    /// </summary>
    /// <typeparam name="T">判定対象の型。</typeparam>
    /// <param name="target">判定対象。</param>
    /// <returns>
    /// 判定結果。
    /// <para><see langword="true"/> ：型である。</para>
    /// <para><see langword="false"/> ：型でない。</para>
    /// </returns>
    /// <remarks>
    /// <see cref="Convert.ChangeType(object, Type)"/> にて <see cref="InvalidCastException"/>, <see cref="FormatException"/>, <see cref="OverflowException"/> が発生しなかった場合、 <see langword="true"/> を返します。
    /// </remarks>
    public static bool Is<T>(this object target)
    {
        try
        {
            Convert.ChangeType(target, typeof(T));

            return true;
        }
        catch (Exception ex) when (ex is InvalidCastException || ex is FormatException || ex is OverflowException)
        {
            return false;
        }
    }
}
