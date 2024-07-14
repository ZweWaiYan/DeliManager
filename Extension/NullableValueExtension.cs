
namespace DeliManager.Common
{
    using System;

    public static class NullableValueExtension
    {
        /// <summary>
        /// Nothingだった場合にDBNullへ変換
        /// </summary>
        /// <param name="param">対象データ</param>
        /// <returns>変換した値</returns>
        public static object NothingToDBNull(this object param)
        {
            if (param == null)
            {
                return DBNull.Value;
            }
            else
            {
                return param;
            }
        }

        /// <summary>
        /// DBNullだった場合にNothingへ変換
        /// </summary>
        /// <param name="param">対象データ</param>
        /// <returns>変換した値</returns>
        public static object DBNullToNothing(this object param)
        {
            if (param == null || param == DBNull.Value)
            {
                return null;
            }
            else
            {
                return param;
            }
        }

        /// <summary>
        /// DBNullだった場合にNothingへ変換
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="param">対象データ</param>
        /// <returns>変換した値</returns>
        public static T DBNullToNothing<T>(this object param)
        {
            if (param == null || param == DBNull.Value)
            {
                return default(T);
            }
            else
            {
                return (T)param;
            }
        }

        /// <summary>
        /// DBNullの場合、Zeroを返す。(返却値の型：decimal)
        /// </summary>
        /// <param name="param">対象データ</param>
        /// <returns>変換した値</returns>
        public static decimal DBNullToDecimalZero(this object param)
        {
            if (param == null || param == DBNull.Value)
            {
                return 0.0m;
            }
            else
            {
                return Convert.ToDecimal(param);
            }
        }

        /// <summary>
        /// DBNullの場合、Zeroを返す。(返却値の型：integer)
        /// </summary>
        /// <param name="param">対象データ</param>
        /// <returns>変換した値</returns>
        public static int DBNullToIntegerZero(this object param)
        {
            if (param == null || param == DBNull.Value)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(param);
            }
        }

        /// <summary>
        /// DBNullの場合、Zeroを返す。(返却値の型：long)
        /// </summary>
        /// <param name="param">対象データ</param>
        /// <returns>変換した値</returns>
        public static long DBNullToLongZero(this object param)
        {
            if (param == null || param == DBNull.Value)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt64(param);
            }
        }

        /// <summary>
        /// Nothingをゼロに変換する
        /// </summary>
        /// <param name="param">対象データ</param>
        /// <returns>変換した値</returns>
        public static int ToNonNullable(this int? param)
        {
            if (param == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(param);
            }
        }

        /// <summary>
        /// NothingをString.Emptyに変換する
        /// </summary>
        /// <param name="param">対象データ</param>
        /// <returns>変換した値</returns>
        public static string ToNonNullable(this string param)
        {
            if (string.IsNullOrWhiteSpace(param))
            {
                return string.Empty;
            }

            return param;
        }

        /// <summary>
        /// null を日付の初期値に変換する
        /// </summary>
        /// <param name="param">対象データ</param>
        /// <returns>変換した値</returns>
        public static DateTime ToNonNullable(this DateTime? param)
        {
            DateTime defaultDate = SystemDate.DefaultDate;
            if (param == null)
            {
                return defaultDate;
            }
            else
            {
                if (param < defaultDate)
                {
                    return defaultDate;
                }
                else
                {
                    return Convert.ToDateTime(param);
                }
            }
        }

        /// <summary>
        /// 文字列をDateTime型に変換します。
        /// 変換できない場合は初期値を返します。
        /// </summary>
        /// <param name="param">変換対象となる文字列</param>
        /// <returns>DateTime型に変換された文字列</returns>
        public static DateTime ToForceDateTime(this string param)
        {
            DateTime ret = SystemDate.DefaultDate;
            DateTime.TryParse(param, out ret);
            return ret;
        }

        /// <summary>
        /// 文字列をint型に変換します。
        /// 変換できない場合はゼロを返します。
        /// </summary>
        /// <param name="param">変換対象となる文字列</param>
        /// <returns>int型に変換された文字列</returns>
        public static int ToForceInteger(this string param)
        {
            int ret = 0;
            int.TryParse(param, out ret);
            return ret;
        }

        /// <summary>
        /// 文字列をlong型に変換します。
        /// 変換できない場合はゼロを返します。
        /// </summary>
        /// <param name="param">変換対象となる文字列</param>
        /// <returns>int型に変換された文字列</returns>
        public static long ToForceLong(this string param)
        {
            long ret = 0L;
            long.TryParse(param, out ret);
            return ret;
        }

        /// <summary>
        /// 文字列をdecimal型に変換します。
        /// 変換できない場合はゼロを返します。
        /// </summary>
        /// <param name="param">変換対象となる文字列</param>
        /// <returns>decimal型に変換された文字列</returns>
        public static decimal ToForceDecimal(this string param)
        {
            decimal ret = 0M;
            decimal.TryParse(param, out ret);
            return ret;
        }

        internal static DateTime? ToNonNullable(object v)
        {
            throw new NotImplementedException();
        }
    }
}