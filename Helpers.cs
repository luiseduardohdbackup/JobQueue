using System;
using System.Collections.Generic;
using System.Text;

namespace TestConsole
{
    class Helpers
    {

        public static int s = 1000;
        public static int m = s * 60;
        public static int h = m * 60;
        public static int d = h * 24;
        public static int w = d * 7;
        public static double y = d * 365.25;
        public static int undefined = int.MinValue;

        /**
         * Parse or format the given `val`.
         *
         * Options:
         *
         *  - `long` verbose formatting [false]
         *
         * @param {String|Number} val
         * @param {Object} [options]
         * @throws {Error} throw an error if val is not a non-empty string or a number
         * @return {String|Number}
         * @api public
         */

        //module.exports = public void(val, options)
        //{
        //    options = options || { };
        //    var type = typeof val;
        //    if (type === 'string' && val.length > 0)
        //    {
        //        return parse(val);
        //    }
        //    else if (type === 'number' && isFinite(val))
        //    {
        //        return options.long? fmtLong(val) : fmtShort(val);
        //    }
        //    throw new Error(
        //      'val is not a non-empty string or a valid number. val=' +
        //        JSON.stringify(val)
        //    );
        //};

        /**
         * Parse the given `str` and return milliseconds.
         *
         * @param {String} str
         * @return {Number}
         * @api private
         */

        public double parse(string str)
        {
            //str = String(str);
            if (str.Length > 100)
            {
                return 0;
            }
            //var match = /^ (-? (?:\d +)?\.?\d +) *(milliseconds ?| msecs ?| ms | seconds ?| secs ?| s | minutes ?| mins ?| m | hours ?| hrs ?| h | days ?| d | weeks ?| w | years ?| yrs ?| y) ?$/ i.exec(
            //                                           str
            //                                         );
            //if (!match)
            //{
            //    return;
            //}
            //var n = parseFloat(match[1]);
            double n = 0;
            var type = "";// (match[2] || "ms").toLowerCase();
            switch (type)
            {
                case "years":
                case "year":
                case "yrs":
                case "yr":
                case "y":
                    return n * y;
                case "weeks":
                case "week":
                case "w":
                    return n * w;
                case "days":
                case "day":
                case "d":
                    return n * d;
                case "hours":
                case "hour":
                case "hrs":
                case "hr":
                case "h":
                    return n * h;
                case "minutes":
                case "minute":
                case "mins":
                case "min":
                case "m":
                    return n * m;
                case "seconds":
                case "second":
                case "secs":
                case "sec":
                case "s":
                    return n * s;
                case "milliseconds":
                case "millisecond":
                case "msecs":
                case "msec":
                case "ms":
                    return n;
                default:
                    return undefined;
            }
        }

        /**
         * Short format for `ms`.
         *
         * @param {Number} ms
         * @return {String}
         * @api private
         */

        public string fmtShort(decimal ms)
        {
            var msAbs = Math.Abs(ms);
            if (msAbs >= d)
            {
                return Math.Round(ms / d) + "d";
            }
            if (msAbs >= h)
            {
                return Math.Round(ms / h) + "h";
            }
            if (msAbs >= m)
            {
                return Math.Round(ms / m) + "m";
            }
            if (msAbs >= s)
            {
                return Math.Round(ms / s) + "s";
            }
            return ms + "ms";
        }

        /**
         * Long format for `ms`.
         *
         * @param {Number} ms
         * @return {String}
         * @api private
         */

        public string fmtLong(int ms)
        {
            var msAbs = Math.Abs(ms);
            if (msAbs >= d)
            {
                return plural(ms, msAbs, d, "day");
            }
            if (msAbs >= h)
            {
                return plural(ms, msAbs, h, "hour");
            }
            if (msAbs >= m)
            {
                return plural(ms, msAbs, m, "minute");
            }
            if (msAbs >= s)
            {
                return plural(ms, msAbs, s, "second");
            }
            return ms + " ms";
        }

        /**
         * Pluralization helper.
         */

        public string plural(decimal ms, int  msAbs,int n, string name)
        {
            var isPlural = msAbs >= n * 1.5;
            return Math.Round(ms / n) + " " + name + (isPlural ? "s" : "");
        }

    }
}
