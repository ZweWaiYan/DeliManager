
using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

/// <summary>
/// <see cref="SqlCommand"/> の拡張メソッド定義クラスです。
/// </summary>
public static class SqlCommandExtension
{
    /// <summary>
    /// <see cref="SqlCommand"/> に <see cref="FrameworkSettings"/> の設定を適用します。
    /// </summary>
    /// <param name="cm">対象の <see cref="SqlCommand"/> オブジェクト。</param>
    /// <exception cref="ArgumentException"><see cref="FrameworkSettings"/> の設定に誤りがあります。</exception>
    /// <remarks>
    /// <para>
    /// [<see cref="SqlCommand.CommandTimeout"/>]
    /// <see cref="SqlConnectionSettings.SqlCommandTimeoutSeconds"/> の設定値を反映します。
    /// </para>
    /// <para>
    /// [<see cref="LogSettings.SqlLogSetting"/> にてログ出力設定が行われている場合]
    /// <see cref="SqlCommand.StatementCompleted"/> に SQL ステートメントログ処理を関連づけます。
    /// </para>
    /// </remarks>
    public static void ApplySettings(this SqlCommand cm)
    {
        if (!FrameworkSettings.Default.SqlConnectionSettings.SqlCommandTimeoutSeconds.Value.Is<int>())
        {
            throw new ArgumentException("Framework.config の SQL コマンドタイムアウト設定に誤りがあります。");
        }

        cm.CommandTimeout = FrameworkSettings.Default.SqlConnectionSettings.SqlCommandTimeoutSeconds.Value.To<int>();

        //if (FrameworkSettings.Default.LogSettings.SqlLogSetting.Enabled)
        //{
        //    cm.StatementCompleted +=
        //        new StatementCompletedEventHandler(
        //            SqlLoggerProxy.WriteStatementLog);
        //}
    }

    /// <summary>
    /// <see cref="OleDbCommand"/> に <see cref="FrameworkSettings"/> の設定を適用します。
    /// </summary>
    /// <param name="cm">対象の <see cref="OleDbCommand"/> オブジェクト。</param>
    /// <exception cref="ArgumentException"><see cref="FrameworkSettings"/> の設定に誤りがあります。</exception>
    /// <remarks>
    /// <para>
    /// [<see cref="SqlCommand.CommandTimeout"/>]
    /// <see cref="SqlConnectionSettings.SqlCommandTimeoutSeconds"/> の設定値を反映します。
    /// </para>
    /// </remarks>
    public static void ApplySettings(this OleDbCommand cm)
    {
        if (!FrameworkSettings.Default.SqlConnectionSettings.SqlCommandTimeoutSeconds.Value.Is<int>())
        {
            throw new ArgumentException("Framework.config の SQL コマンドタイムアウト設定に誤りがあります。");
        }

        cm.CommandTimeout = FrameworkSettings.Default.SqlConnectionSettings.SqlCommandTimeoutSeconds.Value.To<int>();
    }
}
